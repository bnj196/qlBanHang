using Microsoft.AspNetCore.Mvc;
using WebQLBanHang.Data;
using WebQLBanHang.Models;

namespace WebQLBanHang.Controllers
{
    public class DonViTinhsController : Controller
    {
        private readonly AppDbContext _context;

        public DonViTinhsController(AppDbContext context)
        {
            _context = context;
        }


        // Index -get 
        public IActionResult Index()
        {
            var danhSach = _context.DonViTinh_DS();
            return View(danhSach);
        }


        //Detail - Get 
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Gọi hàm Chi Tiết từ AppDbContext
            var donViTinh = _context.DonViTinh_CT(id);
            if (donViTinh == null)
            {
                return NotFound();
            }

            return View(donViTinh);
        }

        // Create - get
        public IActionResult Create()
        {
            return View();
        }

        // 3b. CREATE: Xử lý lưu (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaDVT,TenDVT")] DonViTinh donViTinh)
        {
            if (ModelState.IsValid)
            {

                _context.DonViTinh_Them(donViTinh);
                return RedirectToAction(nameof(Index));
            }
            return View(donViTinh);
        }

        //Edit -get 
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Gọi hàm Chi Tiết để lấy dữ liệu cũ đổ lên Form
            var donViTinh = _context.DonViTinh_CT(id);
            if (donViTinh == null)
            {
                return NotFound();
            }
            return View(donViTinh);
        }

        // 4b. EDIT: Xử lý lưu dữ liệu đã sửa (POST) -
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("MaDVT,TenDVT")] DonViTinh donViTinh)
        {
            if (id != donViTinh.MaDVT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.DonViTinh_Sua(donViTinh);
                return RedirectToAction(nameof(Index));
            }
            return View(donViTinh);
        }

        // delete get
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donViTinh = _context.DonViTinh_CT(id);
            if (donViTinh == null)
            {
                return NotFound();
            }

            return View(donViTinh);
        }

        // 5b. DELETE: Thực hiện xóa (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {

            _context.DonViTinh_Xoa(id);
            return RedirectToAction(nameof(Index));
        }


        private bool DonViTinhExists(string id)
        {
            // Kiểm tra bằng cách gọi hàm Chi Tiết, nếu khác null là có tồn tại
            return _context.DonViTinh_CT(id) != null;
        }
    }
}