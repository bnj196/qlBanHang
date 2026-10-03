USE QLBanHang;
GO

-- ===================================================================
-- 1. SP: LoaiSP_Theo_NhomSP
--    Lấy danh sách Loại SP thuộc 1 Nhóm SP (theo MaNSP)
-- ===================================================================
IF OBJECT_ID('dbo.LoaiSP_Theo_NhomSP', 'P') IS NOT NULL 
    DROP PROC dbo.LoaiSP_Theo_NhomSP;
GO
CREATE PROCEDURE dbo.LoaiSP_Theo_NhomSP
    @MaNSP VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLSP, TenLSP, MaNSP
    FROM LoaiSP
    WHERE MaNSP = @MaNSP
    ORDER BY MaLSP ASC;
END
GO

-- ===================================================================
-- 2. SP: SanPham_Theo_LoaiSP
--    Lấy danh sách Sản phẩm thuộc 1 Loại SP (theo MaLSP)
-- ===================================================================
IF OBJECT_ID('dbo.SanPham_Theo_LoaiSP', 'P') IS NOT NULL 
    DROP PROC dbo.SanPham_Theo_LoaiSP;
GO
CREATE PROCEDURE dbo.SanPham_Theo_LoaiSP
    @MaLSP VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaSP, TenSP, DonGia, AnhSP, MoTaChiTiet, ThongTinChiTiet, MaLSP, MaDVT
    FROM SanPham
    WHERE MaLSP = @MaLSP
    ORDER BY MaSP ASC;
END
GO

-- ===================================================================
-- 3. SP: SanPham_Theo_NhomSP
--    Lấy danh sách Sản phẩm thuộc 1 Nhóm SP (qua LoaiSP)
-- ===================================================================
IF OBJECT_ID('dbo.SanPham_Theo_NhomSP', 'P') IS NOT NULL 
    DROP PROC dbo.SanPham_Theo_NhomSP;
GO
CREATE PROCEDURE dbo.SanPham_Theo_NhomSP
    @MaNSP VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sp.MaSP, sp.TenSP, sp.DonGia, sp.AnhSP, 
           sp.MoTaChiTiet, sp.ThongTinChiTiet, sp.MaLSP, sp.MaDVT
    FROM SanPham sp
    INNER JOIN LoaiSP lsp ON sp.MaLSP = lsp.MaLSP
    WHERE lsp.MaNSP = @MaNSP
    ORDER BY sp.MaSP ASC;
END
GO

-- ===================================================================
-- TEST CÁC STORED PROCEDURE VỪA TẠO
-- ===================================================================
-- Lấy tất cả Loại SP thuộc nhóm "Điện thoại" (NSP01)
EXEC LoaiSP_Theo_NhomSP @MaNSP = 'NSP01';

-- Lấy tất cả Sản phẩm thuộc loại "iPhone" (LSP01)
EXEC SanPham_Theo_LoaiSP @MaLSP = 'LSP01';

-- Lấy tất cả Sản phẩm thuộc nhóm "Điện thoại" (NSP01)
EXEC SanPham_Theo_NhomSP @MaNSP = 'NSP01';