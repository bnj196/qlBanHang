using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebQLBanHang.Data;
using WebQLBanHang.Models;

namespace WebQLBanHang.Controllers
{
    public class NhomSPsController : Controller
    {
        private readonly AppDbContext _context;

        public NhomSPsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.NhomSP_DS());
        }

        public IActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var nhomSP = _context.NhomSP_CT(id);
            return nhomSP == null ? NotFound() : View(nhomSP);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaNSP,TenNSP")] NhomSP nhomSP)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.NhomSP_Them(nhomSP);
                    return RedirectToAction(nameof(Index));
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError(string.Empty, GetDatabaseError(ex));
                }
            }

            return View(nhomSP);
        }

        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var nhomSP = _context.NhomSP_CT(id);
            return nhomSP == null ? NotFound() : View(nhomSP);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("MaNSP,TenNSP")] NhomSP nhomSP)
        {
            if (id != nhomSP.MaNSP) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.NhomSP_Sua(nhomSP);
                    return RedirectToAction(nameof(Index));
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError(string.Empty, GetDatabaseError(ex));
                }
            }

            return View(nhomSP);
        }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var nhomSP = _context.NhomSP_CT(id);
            return nhomSP == null ? NotFound() : View(nhomSP);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            try
            {
                _context.NhomSP_Xoa(id);
            }
            catch (SqlException ex)
            {
                TempData["ErrorMessage"] = GetDatabaseError(ex);
            }

            return RedirectToAction(nameof(Index));
        }

        private static string GetDatabaseError(SqlException exception)
        {
            return exception.Number switch
            {
                2627 or 2601 => "Mã nhóm sản phẩm đã tồn tại.",
                547 => "Không thể xóa vì nhóm sản phẩm đang được sử dụng.",
                _ => "Không thể lưu dữ liệu. Vui lòng kiểm tra kết nối cơ sở dữ liệu."
            };
        }
    }
}