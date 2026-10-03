USE QLBanHang;
GO

-- ===================================================================
-- 1. STORED PROCEDURE: SanPham_DS (Lấy danh sách tất cả sản phẩm)
-- ===================================================================
IF OBJECT_ID('dbo.SanPham_DS', 'P') IS NOT NULL DROP PROC dbo.SanPham_DS;
GO
CREATE PROCEDURE dbo.SanPham_DS
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaSP, TenSP, DonGia, AnhSP, MoTaChiTiet, ThongTinChiTiet, MaLSP, MaDVT
    FROM SanPham
    ORDER BY MaSP ASC;
END
GO

-- ===================================================================
-- 2. STORED PROCEDURE: SanPham_CT (Lấy chi tiết 1 sản phẩm theo MaSP)
-- ===================================================================
IF OBJECT_ID('dbo.SanPham_CT', 'P') IS NOT NULL DROP PROC dbo.SanPham_CT;
GO
CREATE PROCEDURE dbo.SanPham_CT
    @MaSP VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaSP, TenSP, DonGia, AnhSP, MoTaChiTiet, ThongTinChiTiet, MaLSP, MaDVT
    FROM SanPham
    WHERE MaSP = @MaSP;
END
GO

-- ===================================================================
-- 3. STORED PROCEDURE: SanPham_Them (Thêm mới 1 sản phẩm)
-- ===================================================================
IF OBJECT_ID('dbo.SanPham_Them', 'P') IS NOT NULL DROP PROC dbo.SanPham_Them;
GO
CREATE PROCEDURE dbo.SanPham_Them
    @MaSP VARCHAR(10),
    @TenSP NVARCHAR(150),
    @DonGia DECIMAL(18, 2),
    @AnhSP VARCHAR(255),
    @MoTaChiTiet NVARCHAR(MAX), 
    @ThongTinChiTiet VARCHAR(MAX),
    @MaLSP VARCHAR(10),
    @MaDVT VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO SanPham (MaSP, TenSP, DonGia, AnhSP, MoTaChiTiet, ThongTinChiTiet, MaLSP, MaDVT)
    VALUES (@MaSP, @TenSP, @DonGia, @AnhSP, @MoTaChiTiet, @ThongTinChiTiet, @MaLSP, @MaDVT);
END
GO

-- ===================================================================
-- 4. STORED PROCEDURE: SanPham_Sua (Cập nhật thông tin 1 sản phẩm)
-- ===================================================================
IF OBJECT_ID('dbo.SanPham_Sua', 'P') IS NOT NULL DROP PROC dbo.SanPham_Sua;
GO
CREATE PROCEDURE dbo.SanPham_Sua
    @MaSP VARCHAR(10),
    @TenSP NVARCHAR(150),
    @DonGia DECIMAL(18, 2),
    @AnhSP VARCHAR(255),
    @MoTaChiTiet NVARCHAR(MAX),
    @ThongTinChiTiet VARCHAR(MAX),
    @MaLSP VARCHAR(10),
    @MaDVT VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE SanPham
    SET TenSP = @TenSP,
        DonGia = @DonGia,
        AnhSP = @AnhSP,
        MoTaChiTiet = @MoTaChiTiet,
        ThongTinChiTiet = @ThongTinChiTiet,
        MaLSP = @MaLSP,
        MaDVT = @MaDVT
    WHERE MaSP = @MaSP;
END
GO

-- ===================================================================
-- 5. STORED PROCEDURE: SanPham_Xoa (Xóa 1 sản phẩm theo MaSP)
-- ===================================================================
IF OBJECT_ID('dbo.SanPham_Xoa', 'P') IS NOT NULL DROP PROC dbo.SanPham_Xoa;
GO
CREATE PROCEDURE dbo.SanPham_Xoa
    @MaSP VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM SanPham
    WHERE MaSP = @MaSP;
END
GO