--Sử dụng Database
USE QLTuyenDung
go

--NHANVIEN

EXEC AddNhanVien 'Nguyen Van A', '2023-06-27', '123456789012', 'Nam', '1990-01-01', '0912345678';
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
('1', 'NV', 'NV', 1);
GO