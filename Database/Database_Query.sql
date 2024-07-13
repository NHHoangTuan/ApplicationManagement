--Sử dụng Database
USE QLTuyenDung
go

--View/Add/Update/Delete
--NHANVIEN
--View
CREATE PROCEDURE ViewNhanVien
AS
BEGIN
    SELECT * FROM NHANVIEN;
END
go


CREATE PROCEDURE ViewListNhanVien
	@MaThue CHAR(10)
AS
BEGIN
	SELECT * FROM PDK_THONGTIN
	WHERE MaThue = @MaThue
END
GO
--Add
CREATE PROCEDURE AddNhanVien
    @TenNV NVARCHAR(100),
    @NgayGiaNhap DATE,
    @CCCD CHAR(12),
    @GioiTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SDT VARCHAR(11)
AS
BEGIN
    INSERT INTO NHANVIEN (TenNV, NgayGiaNhap, CCCD, GioiTinh, NgaySinh, SDT)
    VALUES (@TenNV, @NgayGiaNhap, @CCCD, @GioiTinh, @NgaySinh, @SDT);
END
go
--Update
CREATE PROCEDURE UpdateNhanVien
    @MaNV INT,
    @TenNV NVARCHAR(100),
    @NgayGiaNhap DATE,
    @CCCD CHAR(12),
    @GioiTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SDT VARCHAR(11)
AS
BEGIN
    UPDATE NHANVIEN
    SET TenNV = @TenNV, NgayGiaNhap = @NgayGiaNhap, CCCD = @CCCD, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SDT = @SDT
    WHERE MaNV = @MaNV;
END
go
--Delete
CREATE PROCEDURE DeleteNhanVien
    @MaNV INT
AS
BEGIN
    DELETE FROM NHANVIEN WHERE MaNV = @MaNV;
END
go
--DOANHNGHIEP
--View
CREATE PROCEDURE ViewDoanhNghiep
AS
BEGIN
    SELECT * FROM DOANHNGHIEP;
END
go
--Add
CREATE PROCEDURE AddDoanhNghiep
    @MaThue CHAR(10),
	@LogoPath NVARCHAR(130)
AS
BEGIN
    INSERT INTO DOANHNGHIEP (MaThue, NgayDangKy, LogoPath)
    VALUES (@MaThue, GETDATE(), @LogoPath);
END
go
--Update
CREATE PROCEDURE UpdateDoanhNghiep
    @MaThue CHAR(10)
AS
BEGIN
    UPDATE DOANHNGHIEP
    SET NgayDangKy = GETDATE()
    WHERE MaThue = @MaThue;
END
go
--Delete
CREATE PROCEDURE DeleteDoanhNghiep
    @MaThue CHAR(10)
AS
BEGIN
    DELETE FROM DOANHNGHIEP WHERE MaThue = @MaThue;
END
go

--PDK_THONGTIN
--View
CREATE PROCEDURE ViewPDKThongTin
AS
BEGIN
    SELECT *
    FROM PDK_THONGTIN;
END
go
--Add
CREATE PROCEDURE AddPDKThongTin
    @TenCTy NVARCHAR(255),
    @MaThue CHAR(10),
    @MaNV INT,
    @NguoiDaiDien NVARCHAR(100),
    @DiaChi NVARCHAR(255),
    @Email NVARCHAR(100)
AS
BEGIN
    INSERT INTO PDK_THONGTIN (TenCTy, MaThue, MaNV, NguoiDaiDien, DiaChi, Email, TinhHopLe)
    VALUES (@TenCTy, @MaThue, @MaNV, @NguoiDaiDien, @DiaChi, @Email, 'NOT OK');
END
go
--Update
CREATE PROCEDURE UpdatePDKThongTin
    @TenCTy NVARCHAR(255),
    @MaThue CHAR(10),
    @MaNV INT,
    @NguoiDaiDien NVARCHAR(100),
    @DiaChi NVARCHAR(255),
    @Email NVARCHAR(100),
    @TinhHopLe NVARCHAR(10)
AS
BEGIN
    UPDATE PDK_THONGTIN
    SET MaNV = @MaNV,
        NguoiDaiDien = @NguoiDaiDien,
        DiaChi = @DiaChi,
        Email = @Email,
        TinhHopLe = @TinhHopLe
    WHERE TenCTy = @TenCTy AND MaThue = @MaThue;
END
go
--Delete
CREATE PROCEDURE DeletePDKThongTin
    @TenCTy NVARCHAR(255),
    @MaThue CHAR(10)
AS
BEGIN
    DELETE FROM PDK_THONGTIN
    WHERE TenCTy = @TenCTy AND MaThue = @MaThue;
END
go

--PCC_TT_DANGTUYEN
--View
CREATE PROCEDURE ViewPCC_TT_DangTuyen
AS
BEGIN
    SELECT * FROM PCC_TT_DANGTUYEN;
END
go
--Add
CREATE PROCEDURE AddPCC_TT_DangTuyen
    @ViTriTuyenDung NVARCHAR(100),
    @SLTuyenDung INT,
    @KTGDangTuyen INT,
    @ThongTinYeuCau NVARCHAR(255)
AS
BEGIN
    INSERT INTO PCC_TT_DANGTUYEN (ViTriTuyenDung, SLTuyenDung, KTGDangTuyen, ThongTinYeuCau)
    VALUES (@ViTriTuyenDung, @SLTuyenDung, @KTGDangTuyen, @ThongTinYeuCau);
END
go
--Update
CREATE PROCEDURE UpdatePCC_TT_DangTuyen
    @MaPhieu INT,
    @ViTriTuyenDung NVARCHAR(100),
    @SLTuyenDung INT,
    @KTGDangTuyen INT,
    @ThongTinYeuCau NVARCHAR(255)
AS
BEGIN
    UPDATE PCC_TT_DANGTUYEN
    SET ViTriTuyenDung = @ViTriTuyenDung,
        SLTuyenDung = @SLTuyenDung,
        KTGDangTuyen = @KTGDangTuyen,
        ThongTinYeuCau = @ThongTinYeuCau
    WHERE MaPhieu = @MaPhieu;
END
go
--Delete
CREATE PROCEDURE DeletePCC_TT_DangTuyen
    @MaPhieu INT
AS
BEGIN
    DELETE FROM PCC_TT_DANGTUYEN
    WHERE MaPhieu = @MaPhieu;
END
go

--DOANHNGHIEP_DANGTUYEN
--View
CREATE PROCEDURE ViewDoanhNghiepDangTuyen
AS
BEGIN
    SELECT * FROM DOANHNGHIEP_DANGTUYEN;
END
go
--Add
CREATE PROCEDURE AddDoanhNghiepDangTuyen
    @MaThue CHAR(10),
    @MaPhieu INT,
    @MaNV INT,
    @TGDangTuyen DATE,
    @HinhThuc NVARCHAR(20)
AS
BEGIN
    INSERT INTO DOANHNGHIEP_DANGTUYEN (MaThue, MaPhieu, MaNV, TGDangTuyen, HinhThuc, TinhHopLe)
    VALUES (@MaThue, @MaPhieu, @MaNV, @TGDangTuyen, @HinhThuc, 'NOT OK');
END
go
--Update
CREATE PROCEDURE UpdateDoanhNghiepDangTuyen
    @MaThue CHAR(10),
    @MaPhieu INT,
    @MaNV INT,
    @TGDangTuyen DATE,
    @HinhThuc NVARCHAR(20),
    @TinhHopLe NVARCHAR(10)
AS
BEGIN
    UPDATE DOANHNGHIEP_DANGTUYEN
    SET MaNV = @MaNV,
        TGDangTuyen = @TGDangTuyen,
        HinhThuc = @HinhThuc,
        TinhHopLe = @TinhHopLe
    WHERE MaThue = @MaThue AND MaPhieu = @MaPhieu;
END
go
--Delete
CREATE PROCEDURE DeleteDoanhNghiepDangTuyen
    @MaThue CHAR(10),
    @MaPhieu INT
AS
BEGIN
    DELETE FROM DOANHNGHIEP_DANGTUYEN
    WHERE MaThue = @MaThue AND MaPhieu = @MaPhieu;
END
go

--PDK_QUANGCAO
--View
CREATE PROCEDURE ViewPDKQuangCao
AS
BEGIN
    SELECT * FROM PDK_QUANGCAO;
END
go
--Add
CREATE PROCEDURE AddPDKQuangCao
    @MaThue CHAR(10),
    @MaPhieuDT INT,
    @MaNV INT
AS
BEGIN
    INSERT INTO PDK_QUANGCAO (MaThue, MaPhieuDT, MaNV)
    VALUES (@MaThue, @MaPhieuDT, @MaNV);
END
go
--Update
CREATE PROCEDURE UpdatePDKQuangCao
    @MaPhieu INT,
    @MaThue CHAR(10),
    @MaPhieuDT INT,
    @MaNV INT
AS
BEGIN
    UPDATE PDK_QUANGCAO
    SET MaThue = @MaThue,
        MaPhieuDT = @MaPhieuDT,
        MaNV = @MaNV
    WHERE MaPhieu = @MaPhieu;
END
go
--Delete
CREATE PROCEDURE DeletePDKQuangCao
    @MaPhieu INT
AS
BEGIN
    DELETE FROM PDK_QUANGCAO
    WHERE MaPhieu = @MaPhieu;
END
go

--HOADON
--View
CREATE PROCEDURE ViewHoaDon
AS
BEGIN
    SELECT * FROM HOADON;
END
go
--Add
CREATE PROCEDURE AddHoaDon
    @MaThue CHAR(10),
    @MaPhieu INT,
    @SoTien INT,
    @DaNhan INT
AS
BEGIN
    INSERT INTO HOADON (MaThue, MaPhieu, SoTien, DaNhan)
    VALUES (@MaThue, @MaPhieu, @SoTien, @DaNhan);
END
go
--Update
CREATE PROCEDURE UpdateHoaDon
    @MaHoaDon INT,
    @MaThue CHAR(10),
    @MaPhieu INT,
    @SoTien INT,
    @DaNhan INT
AS
BEGIN
    UPDATE HOADON
    SET MaThue = @MaThue,
        MaPhieu = @MaPhieu,
        SoTien = @SoTien,
        DaNhan = @DaNhan
    WHERE MaHoaDon = @MaHoaDon;
END
go
--Delete
CREATE PROCEDURE DeleteHoaDon
    @MaHoaDon INT
AS
BEGIN
    DELETE FROM HOADON
    WHERE MaHoaDon = @MaHoaDon;
END
go

--HSUV
--View
CREATE PROCEDURE ViewHSUV
AS
BEGIN
    SELECT * FROM HSUV;
END
go
--Add
CREATE PROCEDURE AddHSUV
    @CCCD CHAR(12),
    @Ten NVARCHAR(100),
    @GioiTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SDT VARCHAR(11)
AS
BEGIN
    INSERT INTO HSUV (CCCD, Ten, GioiTinh, NgaySinh, SDT)
    VALUES (@CCCD, @Ten, @GioiTinh, @NgaySinh, @SDT);
END
go
--Update
CREATE PROCEDURE UpdateHSUV
    @CCCD CHAR(12),
    @Ten NVARCHAR(100),
    @GioiTinh NVARCHAR(3),
    @NgaySinh DATE,
    @SDT VARCHAR(11)
AS
BEGIN
    UPDATE HSUV
    SET Ten = @Ten,
        GioiTinh = @GioiTinh,
        NgaySinh = @NgaySinh,
        SDT = @SDT
    WHERE CCCD = @CCCD;
END
go
--Delete
CREATE PROCEDURE DeleteHSUV
    @CCCD CHAR(12)
AS
BEGIN
    DELETE FROM HSUV
    WHERE CCCD = @CCCD;
END
go

--PDK_UNGTUYEN
--View
CREATE PROCEDURE ViewPDKUngTuyen
AS
BEGIN
    SELECT * FROM PDK_UNGTUYEN;
END
go
--Add
CREATE PROCEDURE AddPDKUngTuyen
    @MaNV INT,
    @CCCD CHAR(12),
    @ViTri NVARCHAR(255),
    @GhiChu NVARCHAR(255)
AS
BEGIN
    INSERT INTO PDK_UNGTUYEN (MaNV, CCCD, ViTri, TinhHopLe, GhiChu)
    VALUES (@MaNV, @CCCD, @ViTri, 'NOT OK', @GhiChu);
END
go
--Update
CREATE PROCEDURE UpdatePDKUngTuyen
    @MaPhieu INT,
    @MaNV INT,
    @CCCD CHAR(12),
    @ViTri NVARCHAR(255),
    @TinhHopLe NVARCHAR(10),
    @GhiChu NVARCHAR(255)
AS
BEGIN
    UPDATE PDK_UNGTUYEN
    SET MaNV = @MaNV,
        CCCD = @CCCD,
        ViTri = @ViTri,
        TinhHopLe = @TinhHopLe,
        GhiChu = @GhiChu
    WHERE MaPhieu = @MaPhieu;
END
go
--Delete
CREATE PROCEDURE DeletePDKUngTuyen
    @MaPhieu INT
AS
BEGIN
    DELETE FROM PDK_UNGTUYEN
    WHERE MaPhieu = @MaPhieu;
END
go

--DUYETHOSO
--View
CREATE PROCEDURE ViewDuyetHoSo
AS
BEGIN
    SELECT * FROM DUYETHOSO;
END
go
--Add
CREATE PROCEDURE AddDuyetHoSo
    @MaPhieuQC INT,
    @MaPhieuUT INT,
    @ThoiGian DATE
AS
BEGIN
    INSERT INTO DUYETHOSO (MaPhieuQC, MaPhieuUT, ThoiGian)
    VALUES (@MaPhieuQC, @MaPhieuUT, @ThoiGian);
END
go
--Update
CREATE PROCEDURE UpdateDuyetHoSo
    @MaPhieuQC INT,
    @MaPhieuUT INT,
    @ThoiGian DATE
AS
BEGIN
    UPDATE DUYETHOSO
    SET ThoiGian = @ThoiGian
    WHERE MaPhieuQC = @MaPhieuQC AND MaPhieuUT = @MaPhieuUT;
END
go
--Delete
CREATE PROCEDURE DeleteDuyetHoSo
    @MaPhieuQC INT,
    @MaPhieuUT INT
AS
BEGIN
    DELETE FROM DUYETHOSO
    WHERE MaPhieuQC = @MaPhieuQC AND MaPhieuUT = @MaPhieuUT;
END
go

--UUDAI
--View
CREATE PROCEDURE ViewUuDai
AS
BEGIN
    SELECT * FROM UUDAI;
END
go
--Add
CREATE PROCEDURE AddUuDai
    @TenChienLuoc NVARCHAR(255),
    @ChiTiet NVARCHAR(255)
AS
BEGIN
    INSERT INTO UUDAI (TenChienLuoc, ChiTiet)
    VALUES (@TenChienLuoc, @ChiTiet);
END
go
--Update
CREATE PROCEDURE UpdateUuDai
    @MaUD INT,
    @TenChienLuoc NVARCHAR(255),
    @ChiTiet NVARCHAR(255)
AS
BEGIN
    UPDATE UUDAI
    SET TenChienLuoc = @TenChienLuoc, ChiTiet = @ChiTiet
    WHERE MaUD = @MaUD;
END
go
--Delete
CREATE PROCEDURE DeleteUuDai
    @MaUD INT
AS
BEGIN
    DELETE FROM UUDAI
    WHERE MaUD = @MaUD;
END
go

--DN_TIEMNANG
--View
CREATE PROCEDURE ViewDNTiemNang
AS
BEGIN
    SELECT * FROM DN_TIEMNANG;
END
go
--Add
CREATE PROCEDURE AddDNTiemNang
    @MaThue CHAR(10),
    @SLUngTuyen INT,
    @MaNV INT,
    @MaUD INT = NULL -- MaUD có thể là NULL
AS
BEGIN
    INSERT INTO DN_TIEMNANG (MaThue, SLUngTuyen, MaNV, MaUD)
    VALUES (@MaThue, @SLUngTuyen, @MaNV, @MaUD);
END
go
--Update
CREATE PROCEDURE UpdateDNTiemNang
    @MaThue CHAR(10),
    @SLUngTuyen INT,
    @MaNV INT,
    @MaUD INT = NULL -- MaUD có thể là NULL
AS
BEGIN
    UPDATE DN_TIEMNANG
    SET SLUngTuyen = @SLUngTuyen, MaNV = @MaNV, MaUD = @MaUD
    WHERE MaThue = @MaThue;
END
go
--Delete
CREATE PROCEDURE DeleteDNTiemNang
    @MaThue CHAR(10)
AS
BEGIN
    DELETE FROM DN_TIEMNANG
    WHERE MaThue = @MaThue;
END
go

--Kiểm tra đăng nhập
CREATE PROC procLogin
@user nvarchar(50),
@pass nvarchar(50)
AS
BEGIN
	SELECT * 
	FROM TAIKHOAN 
	WHERE TenTaiKhoan = @user 
		AND MatKhau = @pass
END
GO



--PHEDUYET
--View
CREATE PROCEDURE ViewPheDuyet
AS
BEGIN
    SELECT * FROM PHEDUYET;
END
go
--Add
CREATE PROCEDURE AddPheDuyet
    @MaPhieuUT INT,
    @MaThue CHAR(10),
    @TrangThai INT
AS
BEGIN
    INSERT INTO PHEDUYET (MaPhieuUT, MaThue, TrangThai)
    VALUES (@MaPhieuUT, @MaThue, @TrangThai);
END
go
--Update
CREATE PROCEDURE UpdatePheDuyet
    @MaPhieuUT INT,
    @MaThue CHAR(10),
    @TrangThai INT
AS
BEGIN
    UPDATE PHEDUYET
    SET TrangThai = @TrangThai
    WHERE MaPhieuUT = @MaPhieuUT;
END
go
--Delete
CREATE PROCEDURE DeletePheDuyet
    @MaPhieuUT INT,
	@MaThue CHAR(10)
AS
BEGIN
    DELETE FROM PHEDUYET
    WHERE MaPhieuUT = @MaPhieuUT AND MaThue = @MaThue;
END
go