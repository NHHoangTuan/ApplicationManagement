--Sử dụng Database
USE QLTuyenDung
go

--NHANVIEN

EXEC AddNhanVien 'Nguyen Van A', '2023-06-27', '123456789012', 'Nam', '1990-01-01', '0912345678';
go

--DOANHNGHIEP
EXEC AddDoanhNghiep '1234567890', @LogoPath = 'Assets/Images/Design/logo.png';
go

--PDK_THONGTIN
EXEC AddPDKThongTin 
    @TenCTy = N'Công ty TNHHMMTCH', 
    @MaThue = '1234567890', 
    @MaNV = 1, 
    @NguoiDaiDien = N'Nguyễn Văn Báo', 
    @DiaChi = N'123 đường ABC, quận 1, TPHCM', 
    @Email = 'example@example.com';
go

--PCC_TT_DangTuyen
EXEC AddPCC_TT_DangTuyen 
    @ViTriTuyenDung = 'Developer', 
    @SLTuyenDung = 5, 
    @KTGDangTuyen = 30, 
    @ThongTinYeuCau = 'Experience in C#';
go

--DOANHNGHIEP_DANGTUYEN
EXEC AddDoanhNghiepDangTuyen 
    @MaThue = '1234567890', 
    @MaPhieu = 1, 
    @MaNV = 1, 
    @TGDangTuyen = '2024-06-27', 
    @HinhThuc = 'BAOGIAY';
go

--PDK_QUANGCAO
EXEC AddPDKQuangCao 
    @MaThue = '1234567890', 
    @MaPhieuDT = 1, 
    @MaNV = 1;
go

--HOADON
EXEC AddHoaDon 
    @MaThue = '1234567890', 
    @MaPhieu = 1, 
    @SoTien = 500000, 
    @DaNhan = -1;
go

--HSUV
EXEC AddHSUV 
    @CCCD = '123456789012', 
    @Ten = N'Nguyễn Văn Bố Đời', 
    @GioiTinh = 'Nam', 
    @NgaySinh = '1990-01-01', 
    @SDT = '0123456789';
go

--PDK_UNGTUYEN
EXEC AddPDKUngTuyen 
    @MaNV = 1, 
    @CCCD = '123456789012', 
    @ViTri = N'Kỹ sư phần mềm', 
    @GhiChu = N'Không có';
go

--DUYETHOSO
EXEC AddDuyetHoSo 
    @MaPhieuQC = 1, 
    @MaPhieuUT = 1, 
    @ThoiGian = '2023-06-26';
go

--UUDAI
EXEC AddUuDai 
    @TenChienLuoc = N'Chương trình khuyến mãi mùa hè', 
    @ChiTiet = N'Giảm giá 20% cho tất cả các dịch vụ đăng tuyển trong mùa hè';
go

--DN_TIEMNANG
EXEC AddDNTiemNang 
    @MaThue = '1234567890', 
    @SLUngTuyen = 5, 
    @MaNV = 1, 
    @MaUD = NULL;
go

--QUYEN
INSERT INTO QUYEN (MaQuyen, TenQuyen) 
VALUES 
(1, N'Nhân viên'),
(2, N'Doanh nghiệp'),
(3, N'Ứng viên');
GO

--TAIKHOAN
INSERT INTO TAIKHOAN (MaTK, TenTaiKhoan, MatKhau, MaQuyen) 
VALUES
('1', 'NV01', 'NV01', 1),
('1234567890', 'DN01', 'DN01', 2),
('123456789012', 'UV01', 'UV01', 3);
GO