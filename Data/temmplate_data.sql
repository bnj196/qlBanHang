USE QLBanHang;
GO

-- ===================================================================
-- 1. INSERT DỮ LIỆU VÀO BẢNG NHÓM SẢN PHẨM (NhomSP)
-- ===================================================================
INSERT INTO NhomSP (MaNSP, TenNSP) VALUES
('NSP01', N'Điện thoại'),
('NSP02', N'Máy tính'),
('NSP03', N'Phụ kiện');
GO

-- ===================================================================
-- 2. INSERT DỮ LIỆU VÀO BẢNG LOẠI SẢN PHẨM (LoaiSP)
-- ===================================================================
INSERT INTO LoaiSP (MaLSP, TenLSP, MaNSP) VALUES
('LSP01', N'iPhone', 'NSP01'),
('LSP02', N'Samsung', 'NSP01'),
('LSP03', N'Laptop', 'NSP02'),
('LSP04', N'PC', 'NSP02'),
('LSP05', N'Tai nghe', 'NSP03'),
('LSP06', N'Sạc dự phòng', 'NSP03');
GO

-- ===================================================================
-- 3. INSERT DỮ LIỆU VÀO BẢNG ĐƠN VỊ TÍNH (DonViTinh)
-- ===================================================================
INSERT INTO DonViTinh (MaDVT, TenDVT) VALUES
('DVT01', N'Cái'),
('DVT02', N'Chiếc'),
('DVT03', N'Bộ');
GO

-- ===================================================================
-- 4. INSERT DỮ LIỆU VÀO BẢNG SẢN PHẨM (SanPham)
-- ===================================================================
INSERT INTO SanPham (MaSP, TenSP, DonGia, AnhSP, MoTaChiTiet, ThongTinChiTiet, MaLSP, MaDVT) VALUES
('SP01', N'iPhone 15 Pro Max 256GB', 29990000, 'iphone15promax.jpg', 
 N'Điện thoại cao cấp của Apple', 'Chip A17 Pro, Camera 48MP, Pin 4422 mAh', 'LSP01', 'DVT01'),
 
('SP02', N'Samsung Galaxy S24 Ultra', 27990000, 's24ultra.jpg', 
 N'Flagship của Samsung', 'Chip Snapdragon 8 Gen 3, S-Pen, Camera 200MP', 'LSP02', 'DVT01'),
 
('SP03', N'MacBook Pro 14 inch M3', 49990000, 'macbookpro14.jpg', 
 N'Laptop chuyên nghiệp', 'Chip M3, RAM 16GB, SSD 512GB', 'LSP03', 'DVT02'),
 
('SP04', N'Tai nghe AirPods Pro 2', 5990000, 'airpodspro2.jpg', 
 N'Tai nghe không dây cao cấp', 'Chống ồn chủ động, Audio không gian', 'LSP05', 'DVT01');
GO

-- ===================================================================
-- KIỂM TRA DỮ LIỆU ĐÃ INSERT
-- ===================================================================
SELECT 'NhomSP' AS Bang, COUNT(*) AS SoLuong FROM NhomSP
UNION ALL
SELECT 'LoaiSP', COUNT(*) FROM LoaiSP
UNION ALL
SELECT 'DonViTinh', COUNT(*) FROM DonViTinh
UNION ALL
SELECT 'SanPham', COUNT(*) FROM SanPham;
GO