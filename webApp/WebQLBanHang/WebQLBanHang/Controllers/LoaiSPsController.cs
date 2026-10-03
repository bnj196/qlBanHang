using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using WebQLBanHang.Data;
using WebQLBanHang.Models;

namespace WebQLBanHang.Controllers
{
    public class LoaiSPsController : Controller
    {
        private readonly AppDbContext _context;

        public LoaiSPsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.NhomSPNames = _context.NhomSP_DS().ToDictionary(item => item.MaNSP, item => item.TenNSP);
            return View(_context.LoaiSP_DS());
        }

        public IActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var loaiSP = _context.LoaiSP_CT(id);
            if (loaiSP == null) return NotFound();
            SetNhomSP(loaiSP.MaNSP);
            return View(loaiSP);
        }

        public IActionResult Create()
        {
            SetNhomSP();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaLSP,TenLSP,MaNSP")] LoaiSP loaiSP)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.LoaiSP_Them(loaiSP);
                    return RedirectToAction(nameof(Index));
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError(string.Empty, GetDatabaseError(ex));
                }
            }

            SetNhomSP(loaiSP.MaNSP);
            return View(loaiSP);
        }

        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var loaiSP = _context.LoaiSP_CT(id);
            if (loaiSP == null) return NotFound();
            SetNhomSP(loaiSP.MaNSP);
            return View(loaiSP);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("MaLSP,TenLSP,MaNSP")] LoaiSP loaiSP)
        {
            if (id != loaiSP.MaLSP) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.LoaiSP_Sua(loaiSP);
                    return RedirectToAction(nameof(Index));
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError(string.Empty, GetDatabaseError(ex));
                }
            }

            SetNhomSP(loaiSP.MaNSP);
            return View(loaiSP);
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var loaiSP = _context.LoaiSP_CT(id);
            if (loaiSP == null) return NotFound();
            SetNhomSP(loaiSP.MaNSP);
            return View(loaiSP);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            try
            {
                _context.LoaiSP_Xoa(id);
            }
            catch (SqlException ex)
            {
                TempData["ErrorMessage"] = GetDatabaseError(ex);
            }

            return RedirectToAction(nameof(Index));
        }

        private void SetNhomSP(string? selectedId = null)
        {
            ViewBag.MaNSP = new SelectList(_context.NhomSP_DS(), "MaNSP", "TenNSP", selectedId);
        }

        private static string GetDatabaseError(SqlException exception)
        {
            return exception.Number switch
            {
                2627 or 2601 => "Mã loại sản phẩm đã tồn tại.",
                547 => "Không thể xóa vì loại sản phẩm đang được sử dụng.",
                _ => "Không thể lưu dữ liệu. Vui lòng kiểm tra kết nối cơ sở dữ liệu."
            };
        }
    }
}