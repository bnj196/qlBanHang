-- 1. Thủ tục lấy danh sách Đơn vị tính
CREATE OR ALTER PROC DonViTinh_DS
AS
BEGIN
    SELECT MaDVT, TenDVT 
    FROM DonViTinh
    ORDER BY MaDVT;
END
GO

-- 2. Thủ tục lấy chi tiết Đơn vị tính theo Mã
CREATE OR ALTER PROC DonViTinh_CT
    @MaDVT VARCHAR(10)
AS
BEGIN
    SELECT MaDVT, TenDVT 
    FROM DonViTinh 
    WHERE MaDVT = @MaDVT;
END
GO

-- 3. Thủ tục Thêm mới Đơn vị tính
CREATE OR ALTER PROC DonViTinh_Them
    @MaDVT VARCHAR(10),
    @TenDVT NVARCHAR(50)
AS
BEGIN
    INSERT INTO DonViTinh (MaDVT, TenDVT)
    VALUES (@MaDVT, @TenDVT);
END
GO

-- 4. Thủ tục Sửa Đơn vị tính
CREATE OR ALTER PROC DonViTinh_Sua
    @MaDVT VARCHAR(10),
    @TenDVT NVARCHAR(50)
AS
BEGIN
    UPDATE DonViTinh
    SET TenDVT = @TenDVT
    WHERE MaDVT = @MaDVT;
END
GO

-- 5. Thủ tục Xóa Đơn vị tính
CREATE OR ALTER PROC DonViTinh_Xoa
    @MaDVT VARCHAR(10)
AS
BEGIN
    DELETE FROM DonViTinh 
    WHERE MaDVT = @MaDVT;
END
GO