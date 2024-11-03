create database K22CNTT3_LeTranKhanhDuy_2210900020_db;
use K22CNTT3_LeTranKhanhDuy_2210900020_db

CREATE TABLE NguoiDung (
    MaNguoiDung INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(20) DEFAULT 'NguoiDung', -- Phân quyền (NguoiDung hoặc QuanTri)
    NgayTao DATETIME DEFAULT GETDATE()
);
CREATE TABLE BaiViet (
    MaBaiViet INT PRIMARY KEY IDENTITY(1,1),
    MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    TieuDe NVARCHAR(200) NOT NULL,
    NoiDung TEXT NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE()
);
CREATE TABLE BinhLuan (
    MaBinhLuan INT PRIMARY KEY IDENTITY(1,1),
    MaBaiViet INT FOREIGN KEY REFERENCES BaiViet(MaBaiViet),
    MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    NoiDung NVARCHAR(500) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE()
);
CREATE TABLE DanhMuc (
    MaDanhMuc INT PRIMARY KEY IDENTITY(1,1),
    TenDanhMuc NVARCHAR(100) NOT NULL
);
CREATE TABLE The (
    MaThe INT PRIMARY KEY IDENTITY(1,1),
    TenThe NVARCHAR(50) NOT NULL
);
INSERT INTO NguoiDung (TenDangNhap, Email, MatKhau, VaiTro, NgayTao) VALUES 
('khanhduy', 'khanhduy@gmail.com', 'khanhduy', 'NguoiDung', '2004-12-08'),
('anhlongka', 'anhlongka@gmail.com', 'anhlongka', 'QuanTri', '2004-07-26'),
('minhngu', 'minhngu@gmail.com', 'minhngu', 'NguoiDung', '2004-09-14');
INSERT INTO BaiViet (MaNguoiDung, TieuDe, NoiDung, NgayTao) VALUES
(001, N'Công nghệ AI trong đời sống', N'Bài viết này nói về tác động của AI trong cuộc sống hàng ngày.','2024-1-1'),
(002, N'Hướng dẫn kinh doanh online', N'Những bước cơ bản để kinh doanh online hiệu quả.','2024-1-2'),
(003, N'Giải trí cuối tuần', N'Những hoạt động giải trí cho cuối tuần.','2024-1-3');
INSERT INTO BinhLuan (MaBaiViet, MaNguoiDung, NoiDung, NgayTao) VALUES 
(1, 2, N'Bài viết rất hay và bổ ích.','2024-1-1'),
(1, 3, N'Thật sự giúp mình hiểu rõ hơn về AI.','2024-1-1'),
(2, 1, N'Cảm ơn tác giả đã chia sẻ kinh nghiệm.','2024-1-2'),
(3, 2, N'Sẽ thử những hoạt động này vào cuối tuần.','2024-1-3');
INSERT INTO DanhMuc (TenDanhMuc) VALUES 
(N'Khoa học công nghệ'),
(N'Giải trí'),
(N'Giáo dục'),
(N'Kinh doanh');
INSERT INTO The (TenThe) VALUES 
(N'Công nghệ'),
(N'Giải trí'),
(N'Kinh tế'),
(N'Giáo dục'),
(N'Sức khỏe');
select * from NguoiDung
select * from BaiViet	
select * from BinhLuan
select * from DanhMuc
select * from The