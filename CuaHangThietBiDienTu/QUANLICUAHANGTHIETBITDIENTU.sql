CREATE DATABASE CUAHANGTHIETBIDIENTU
GO
USE CUAHANGTHIETBIDIENTU
GO
CREATE TABLE LOAISANPHAM
(
	MALOAISP VARCHAR(10) PRIMARY KEY,
	TENLOAISP NVARCHAR(20)
)
GO
CREATE TABLE THUONGHIEU
(
	MATH VARCHAR(10) PRIMARY KEY,
	TENTHUONGHIEU NVARCHAR(20),
	QUOCGIA NVARCHAR(30) 
)
GO
CREATE TABLE NHANVIEN
(
	MANV VARCHAR(6) PRIMARY KEY,
	TENNV NVARCHAR(40) NOT NULL,
	DIACHI NVARCHAR(100),
	SDT VARCHAR(12),
	EMAIL VARCHAR(40),
	CMND VARCHAR(14) NOT NULL,
	CHUCVU NVARCHAR(20),
	GIOITINH NVARCHAR(6),
	TAIKHOAN VARCHAR(16),
    MATKHAU VARCHAR(16),
	ISADMIN BIT
)
CREATE TABLE KHACHHANG
(
	MAKH VARCHAR(10) PRIMARY KEY,
	TENKH NVARCHAR(40) NOT NULL,
	DIACHI NVARCHAR(100) ,
	SDT VARCHAR(12),
	EMAIL VARCHAR(40),
	CMND VARCHAR(14) NOT NULL,
	TAIKHOAN VARCHAR(16),
    MATKHAU VARCHAR(100)
)

CREATE TABLE HOADON
(	
	MAHOADON VARCHAR(12) PRIMARY KEY,
	MANV VARCHAR(6) ,
	MAKH VARCHAR(10) NOT NULL,
	NGAYTAO DATETIME,
	TINHTRANGDONHANG NVARCHAR(100),	
	FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
	FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
)
CREATE TABLE THONGSOKYTHUAT
(
	MATSKT VARCHAR(10) PRIMARY KEY,
	HEDIEUHANH VARCHAR(10),
	RAM INT,
	ROM VARCHAR(10),
	KICHCOMANHINH FLOAT,
	VIXULY VARCHAR(30),
	PIN INT,
	CAMERA VARCHAR(50)
)

CREATE TABLE SANPHAM(
	MASP VARCHAR(10) PRIMARY KEY,
	TENSP NVARCHAR(100) NOT NULL,
	DONGIA NUMERIC NOT NULL,
	SOLUONG INT NOT NULL,
	MOTA NVARCHAR(500) ,
	ANH VARCHAR(150),
	MALOAISP VARCHAR(10) NOT NULL,
	MATH VARCHAR(10) NOT NULL,
	MATSKT VARCHAR(10) NOT NULL,
	FOREIGN KEY(MALOAISP) REFERENCES LOAISANPHAM(MALOAISP),
	FOREIGN KEY(MATH) REFERENCES THUONGHIEU(MATH),
	FOREIGN KEY(MATSKT) REFERENCES THONGSOKYTHUAT(MATSKT)
)

CREATE TABLE CHITIETHOADON
(
	MAHOADON VARCHAR(12),
	MASP VARCHAR(10),
	SOLUONG INT NOT NULL,
	DONGIAXUAT NUMERIC NOT NULL,
	PRIMARY KEY(MAHOADON, MASP),
	FOREIGN KEY(MAHOADON) REFERENCES HOADON(MAHOADON),
	FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP)
)

CREATE TABLE PHIEUNHAP
(
	MAPN VARCHAR(10) PRIMARY KEY,
	MANV VARCHAR(6) NOT NULL,
	NGAYNHAP DATETIME,
	FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
) 
CREATE TABLE  CHITIETPHIEUNHAP
(
	MAPN VARCHAR(10) NOT NULL,
	MASP VARCHAR(10) NOT NULL,
	SOLUONG INT NOT NULL,
	DONGIANHAP INT NOT NULL,
	PRIMARY KEY (MAPN, MASP),
	FOREIGN KEY(MAPN) REFERENCES PHIEUNHAP(MAPN),
	FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP)
)
CREATE TABLE GIOHANG
(
	MAKH VARCHAR(10) NOT NULL,
	MASP VARCHAR(10) NOT NULL,
	SOLUONG INT NOT NULL,
	DONGIA NUMERIC,
	FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH),
	FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP),
	PRIMARY KEY(MAKH,MASP)
)
INSERT INTO LOAISANPHAM VALUES ('LSP06', N'Laptop');
INSERT INTO LOAISANPHAM VALUES ('LSP07', N'Điện thoại');
INSERT INTO LOAISANPHAM VALUES ('LSP08', N'Máy tính bảng');
GO
INSERT INTO NHANVIEN VALUES
('NV0001', N'Lê Hoàng Gia Thái', N'Phường Phúc Lợi, Quận Long Biên, Hà Nội', '0778790341', 'lehoanggiathai23@gmail.com', '574638673', N'Quản lý ', N'Nam', NULL, NULL, NULL),
('NV0002', N'Nguyễn Thị Thùy Vinh', N'Thị trấn Sơn Tây, Huyện Ba Vì, Hà Nội', '0937189375', 'thuyvinh.nguyen87@yahoo.com', '751334249', N'Kế toán', N'Nữ', NULL, NULL, NULL),
('NV0003', N'Võ Hoài Vũ', N'Phường Hải Tân, Thành phố Hải Dương, Hải Dương', '0671263848', 'hoaivu.vo54@hotmail.com', '959069243', N'Bảo vệ', N'Nam', NULL, NULL, NULL),
('NV0004', N'Mai Thị Thuận', N'Thị trấn Tây Giang, Huyện Tây Giang, Quảng Nam', '0677746396', 'maithithuan09@outlook.com', '978145772', N'Kho ', N'Nữ', NULL, NULL, NULL),
('NV0005', N'Phan Thanh Nhật', N'Xã Hòa Sơn, Huyện Đức Trọng, Lâm Đồng', '0871206765', 'thanhnhat.phan65@gmail.com', '254734243', N'Bán hàng', N'Nam', NULL, NULL, NULL),
('NV0006', N'Nguyễn Thị Ánh Nguyệt', N'Thôn Tân Lập, Xã Bình Tân, Huyện Sơn Tây, Quảng Ngãi', '0779915501', 'nguyenanhnguyet01@gmail.com', '957420514', N'Bán hàng', N'Nữ', NULL, NULL, NULL),
('NV0007', N'Nguyễn Thị Ánh Nguyệt', N'Thôn Tân Lập, Xã Bình Tân, Huyện Sơn Tây, Quảng Ngãi', '0779915501', 'nguyenanhnguyet01@gmail.com', '957420514', N'Bán hàng', N'Nữ', 'admin', '123', 1);

INSERT INTO NHANVIEN VALUES 
('NHANVIEN', N'Nguyễn Thị Ánh Nguyệt', N'Thôn Tân Lập, Xã Bình Tân, Huyện Sơn Tây, Quảng Ngãi', '0779915501', 'nguyenanhnguyet01@gmail.com', '957420514', N'Bán hàng', N'Nữ', 'nhanvien1', 'nhanvien1', 0),


INSERT INTO KHACHHANG VALUES
('KH001', N'Nguyễn Thị Ngọc Ánh', N'Thị trấn Cát Bà, Huyện Cát Hải, Hải Phòng', '0160309315', 'ngocanh.nguyen123@gmail.com', '820400565', NULL, NULL),
('KH002', N'Trần Minh Anh', N'Xã Thanh Thúy, Huyện Thanh Oai, Hà Nội', '0233232475', 'minhanh.tran456@gmail.com', '565293494', NULL, NULL),
('KH003', N'Lê Thị Thu Ba', N'Thị trấn Đức Phổ, Huyện Đức Phổ, Quảng Ngãi', '0476581663', 'thuba.le789@gmail.com', '440591501', NULL, NULL),
('KH004', N'Dương Văn Bình', N'Phường Bắc Sơn, Thành phố Uông Bí, Quảng Ninh', '0038445056', 'vanbinh.duong123@gmail.com', '557870639', NULL, NULL),
('KH005', N'Phạm Minh Châu', N'Xã Tân Thành, Huyện Tân Châu, An Giang', '0660012007', 'minhchau.pham456@gmail.com', '121401199', NULL, NULL),
('KH006', N'Trần Thị Hà Dương', N'Phường 3, Thành phố Bạc Liêu, Bạc Liêu', '0863661709', 'haduong.tran789@gmail.com', '371978927', NULL, NULL),
('KH007', N'Lê Đức Giang', N'Thị trấn Đạ Ma, Huyện Đức Trọng, Lâm Đồng', '0393437670', 'ducgiang.le123@gmail.com', '101129963', NULL, NULL),
('KH008', N'Nguyễn Thành Hiền', N'Xã Thạnh Hải, Huyện Kiên Lương, Kiên Giang', '0232509649', 'thanhhien.nguyen456@gmail.com', '504320399', NULL, NULL),
('KH009', N'Hoàng Thị Hoa', N'Phường Trảng Dài, Thành phố Biên Hòa, Đồng Nai', '0676536447', 'hoa.hoang789@gmail.com', '230755157', NULL, NULL),
('KH010', N'Trần Văn Hùng', N'Thị trấn Đất Mũi, Huyện Ngọc Hiển, Cà Mau', '0351817463', 'vanhung.tran123@gmail.com', '611568946', NULL, NULL);

INSERT INTO THUONGHIEU(MATH, TENTHUONGHIEU, QUOCGIA) VALUES
('TH001', N'Acer', N'Đài Loan'),
('TH002', N'Huawei', N'Trung Quốc'),
('TH003', N'ASUS', N'Đài Loan'),
('TH004', N'Dell', N'Hoa Kỳ'),
('TH005', N'Samsung', N'Hàn Quốc'),
('TH006', N'Apple', N'Hoa Kỳ'),
('TH007', N'Lenovo', N'Trung Quốc'),
('TH008', N'LG', N'Hàn Quốc'),
('TH009', N'Google', N'Hoa Kỳ'),
('TH010', N'Realme', N'Trung Quốc'),
('TH011', N'Xiaomi', N'Trung Quốc'),
('TH012', N'Oppo', N'Trung Quốc'),
('TH013', N'Nokia', N'Phần Lan'),
('TH014', N'Vivo', N'Trung Quốc'),
('TH015', N'Logitech', N'Thụy Sĩ'),
('TH016', N'MSI', N'Đài Loan'),
('TH017', N'Sony', N'Nhật Bản');

INSERT INTO HOADON VALUES
('HD0001', 'NV0006', 'KH001', '2019-12-08', N'Hẹn ngày giao'),
('HD0002', 'NV0006', 'KH002', '2020-10-31', N'Đang giao hàng'),
('HD0003', 'NV0005', 'KH003', '2018-03-17', N'Giao hàng thành công'),
('HD0004', 'NV0005', 'KH004', '2021-06-12', N'Giao hàng thất bại'),
('HD0005', 'NV0006', 'KH005', '2019-07-28', N'Chờ xác nhận'),
('HD0006', 'NV0005', 'KH006', '2023-02-14', N'Giao hàng thất bại'),
('HD0007', 'NV0005', 'KH007', '2022-09-09', N'Chờ xác nhận'),
('HD0008', 'NV0006', 'KH008', '2020-04-02', N'Đang giao hàng'),
('HD0009', 'NV0006', 'KH009', '2021-12-25', N'Hẹn ngày giao'),
('HD0010', 'NV0005', 'KH010', '2018-08-17', N'Giao hàng thất bại');

INSERT INTO THONGSOKYTHUAT VALUES
('TSKT001', 'Android', 4, '16GB', 5.5, 'Snapdragon 665', 4000, '20MP + 12MP'),
('TSKT002', 'iOS', 6, '64GB', 6.1, 'A13 Bionic', 3500, '12MP + 12MP'),
('TSKT003', 'Android', 8, '128GB', 6.7, 'Exynos 990', 4500, '108MP + 48MP + 12MP'),
('TSKT004', 'iOS', 4, '32GB', 4.7, 'A9', 1715, '12MP'),
('TSKT005', 'Android', 6, '64GB', 6.5, 'MediaTek Helio G90T', 4500, '64MP + 8MP + 2MP + 2MP'),
('TSKT006', 'iOS', 3, '16GB', 4.0, 'A7', 1560, '8MP'),
('TSKT007', 'Android', 4, '64GB', 6.4, 'Qualcomm Snapdragon 665', 5000, '48MP + 8MP + 2MP + 2MP'),
('TSKT008', 'Android', 8, '256GB', 6.78, 'Qualcomm Snapdragon 888', 4500, '50MP + 48MP + 48MP + 5MP'),
('TSKT009', 'iOS', 4, '64GB', 5.8, 'A11 Bionic', 2716, '12MP + 12MP'),
('TSKT010', 'Android', 8, '128GB', 6.67, 'Qualcomm Snapdragon 865', 4780, '64MP + 13MP + 5MP + 2MP'),
('TSKT011', 'Windows 10', 16, '512GB SSD', 15.6, 'Intel Core i7-10750H', 72, '720p HD'),
('TSKT012', 'macOS', 8, '256GB SSD', 13.3, 'Intel Core i5', 58, '720p HD'),
('TSKT013', 'Windows 10', 32, '1TB SSD', 17.3, 'Intel Core i9-11900H', 99, '720p HD'),
('TSKT014', 'Windows 10', 8, '512GB SSD', 14.0, 'Intel Core i5-1035G1', 52.5, '720p HD'),
('TSKT015', 'Windows 10', 16, '1TB SSD', 15.6, 'AMD Ryzen 9 5900HX', 90, '720p HD'),
('TSKT016', 'Windows 10', 16, '512GB SSD', 14.0, 'Intel Core i7-1185G7', 63, '720p HD'),
('TSKT017', 'Windows 10', 16, '512GB SSD', 15.6, 'AMD Ryzen 7 5800H', 80, '720p HD'),
('TSKT018', 'Windows 10', 32, '2TB SSD', 17.3, 'Intel Core i9-11980HK', 94, '1080p FHD'),
('TSKT019', 'macOS', 16, '512GB SSD', 16.0, 'Apple M1', 90, '720p HD'),
('TSKT020', 'Windows 10', 8, '256GB SSD', 13.3, 'Intel Core i5-10210U', 52, '720p HD'),
('TSKT021', 'Android', 4, '64GB', 10.1, 'Snapdragon 662', 7040, 'Chính 8MP, Phụ 5MP'),
('TSKT022', 'iOS', 4, '128GB', 11.0, 'A12 Bionic', 7812, 'Chính 8MP, Phụ 7MP'),
('TSKT023', 'Windows', 8, '256GB', 12.3, 'Intel Core i5', 8000, 'Chính 8MP, Phụ 5MP'),
('TSKT024', 'Android', 6, '64GB', 8.0, 'Kirin 710A', 5100, 'Chính 8MP, Phụ 5MP'),
('TSKT025', 'Windows', 16, '512GB', 10.5, 'Intel Core i7', 7500, 'Chính 13MP, Phụ 8MP'),
('TSKT026', 'Android', 8, '128GB', 8.4, 'Snapdragon 865+', 8200, 'Chính 13MP, Phụ 5MP'),
('TSKT027', 'iOS', 4, '64GB', 10.5, 'A10 Fusion', 8827, 'Chính 8MP, Phụ 1.2MP'),
('TSKT028', 'Android', 3, '32GB', 7.0, 'Mediatek MT8167', 3450, 'Chính 5MP, Phụ 2MP'),
('TSKT029', 'Windows', 8, '256GB', 12.4, 'Intel Core i5', 9000, 'Chính 13MP, Phụ 5MP'),
('TSKT030', 'Android', 6, '128GB', 10.4, 'Exynos 9611', 7040, 'Chính 8MP, Phụ 5MP'),
('TSKT031', 'ANDROID', 12, '256GB', 6.9, 'EXYNOS 990', 4500, '108MP + 12MP + 12MP'),
('TSKT032', 'IOS', 4, '64GB', 5.4, 'A14 BIONIC', 2227, '12MP + 12MP'),
('TSKT033', 'ANDROID', 6, '128GB', 6.34, 'SNAPDRAGON 765G', 4680, '12.2MP + 16MP'),
('TSKT034', 'ANDROID', 8, '128GB', 6.43, 'MEDIATEK DIMENSITY 1200', 4500, '50MP + 8MP + 2MP'),
('TSKT035', 'ANDROID', 6, '128GB', 6.67, 'SNAPDRAGON 860', 5160, '48MP + 8MP + 2MP + 2MP'),
('TSKT036', 'ANDROID', 8, '128GB', 6.1, 'SNAPDRAGON 865', 4000, '12MP + 12MP + 12MP'),
('TSKT037', 'ANDROID', 8, '512GB', 6.58, 'KIRIN 990 5G', 4200, '50MP +8MP + 8MP + 40MP'),
('TSKT038', 'ANDROID', 12, '256GB', 6.55, 'SNAPDRAGON 870', 4500, '50MP + 13MP + 16MP + 2MP'),
('TSKT039', 'ANDROID', 4, '64GB', 6.6, 'SNAPDRAGON 662', 5000, '48MP + 2MP + 2MP'),
('TSKT040', 'ANDROID', 8, '128GB', 6.8, 'SNAPDRAGON 765G', 4000, '64MP + 13MP + 12MP'),
('TSKT041', 'Windows 10', 4, '256GB SSD', 15.6, 'Intel Celeron N4020', 5000, 'Camera trước 0.3MP và sau 2.0MP'),
('TSKT042', 'Windows 10', 16, '512GB SSD', 14, 'Intel Core i5-1155G7', 56, 'Camera trước 720p và sau 2.0MP'),
('TSKT043', 'Windows 10', 8, '512GB SSD', 15.6, 'Intel Core i5-12450H', 76, 'Camera trước HD và sau 720p'),
('TSKT044', 'Windows 10', 16, '512GB SSD', 15.6, 'Intel Core i7-11800H', 53, 'Camera trước HD và sau 720p'),
('TSKT045', 'Windows 10', 4, '512GB SSD', 14, 'Intel Core i3-1220P', 42, 'Camera trước VGA và sau 720p'),
('TSKT046', 'macOS', 8, '256GB SSD', 13.3, 'Apple M1 7-core GPU', 49.9, 'Camera trước HD và sau 720p'),
('TSKT047', 'macOS', 16, '256GB', 13.3, 'Apple M2 8-core GPU', 12, '720p FaceTime HD camera'),
('TSKT048', 'macOS', 8, '512GB', 13.3, 'Apple M1 8-core GPU', 12, '720p FaceTime HD camera'),
('TSKT049', 'macOS', 16, '512GB', 13.3, 'Apple M2 10-core GPU', 12, '720p FaceTime HD camera'),
('TSKT050', 'iPadOS 14', 8, '128GB', 12.9, 'Apple M1', 9720, '12MP Wide, 10MP Ultra Wide'),
('TSKT051', 'Android 11', 3, '32GB', 8.4, 'Snapdragon 662', 5100, '8MP Rear, 5MP Front'),
('TSKT052', 'Android 11', 4, '64GB', 8.7, 'Helio P22T', 5100, '8MP Rear, 2MP Front'),
('TSKT053', 'Android 11', 12, '256GB', 14.5, 'Snapdragon 888', 11000, '13MP Wide, 5MP Ultra Wide, 5MP Macro, 8MP Front'),
('TSKT054', 'Android 11', 4, '64GB',11, 'Snapdragon 750G', 10090, '8MP Wide, 5MP Ultra Wide, 5MP Macro, 5MP Front'),
('TSKT055', 'iPadOS 14', 16, '2TB', 11, 'Apple M1', 7538, '12MP Wide, 10MP Ultra Wide'),
('TSKT056', 'iPadOS 14', 8, '256GB', 12.9, 'Apple M1', 9720, '12MP Wide, 10MP Ultra Wide'),
('TSKT057', 'iPadOS 15', 8, '128GB', 11, 'Apple M2', 7538, '12MP Wide, 10MP Ultra Wide'),
('TSKT058', 'iPadOS 15', 4, '64GB', 8.3, 'Apple A15', 5124, '12MP Wide, 12MP Ultra Wide'),
('TSKT059', 'iPadOS 14', 4, '64GB', 10.9, 'Apple M1', 7606, '12MP Wide, 7MP Front');



INSERT INTO SANPHAM VALUES
('SP000001', N'iPhone 13', 27990000, 10, N'iPhone 13: Màn hình OLED 6,1 inch, camera kép 12MP, hỗ trợ 5G. Trải nghiệm chụp ảnh, xem video chất lượng cao và truy cập các ứng dụng mới nhất.', 'iphone-13-bh-org.jpg', 'LSP07', 'TH006', 'TSKT002'), 
('SP000002', N'Samsung Galaxy S21', 19990000, 4, N'Samsung Galaxy S21: Màn hình Dynamic AMOLED 6,2 inch, camera chính 64MP, hỗ trợ 5G, pin 4000mAh. Trải nghiệm chụp ảnh và quay video chất lượng cao, xem video và chơi game mượt mà', 'samsung-galaxy-s21-trang-bbh-org.jpg', 'LSP07', 'TH005', 'TSKT001'), 
('SP000003', N'OnePlus 9 Pro', 19990000, 2, N'Màn hình Fluid AMOLED 6,7 inch, camera chính 48MP, hỗ trợ 5G, pin 4500mAh. Trải nghiệm chụp ảnh và quay video chất lượng cao, xem video và chơi game mượt mà, hỗ trợ sạc nhanh Warp Charge 65T.', 'oneplus-9-pro-600x600-1-600x600.jpg', 'LSP07', 'TH011', 'TSKT003'), 
('SP000004', N'Xiaomi Mi 11', 18990000, 1, N'Xiaomi Mi 11 là một sản phẩm cao cấp của Xiaomi với nhiều tính năng hiện đại. Màn hình AMOLED 6,81 inch cho trải nghiệm xem video và chơi game đỉnh cao, với độ phân giải 2K+ và tốc độ làm mới 120Hz', 'xiaomi-mi-11-xanhduong-1-org.jpg', 'LSP07', 'TH011', 'TSKT004'), 
('SP000005', N'Google Pixel 6', 6999000, 5, N'Trải nghiệm chụp ảnh và quay video chất lượng cao, xem video và chơi game mượt mà, hỗ trợ sạc nhanh.', 'google-pixel-6-600x600.jpg', 'LSP07', 'TH009', 'TSKT006'), 
('SP000006', N'Sony Xperia 1 III', 14990000, 8, N'Màn hình OLED 6,5 inch, chip Snapdragon 888, camera chính 12MP, hỗ trợ 5G, pin 4500mAh. Trải nghiệm chụp ảnh và quay video chất lượng cao, xem video và chơi game mượt mà, hỗ trợ sạc nhanh.', 'sony-xperia-1-iii-1-600x600.jpg', 'LSP07', 'TH017', 'TSKT007'), 
('SP000007', N'Huawei P50 Pro', 19990000, 4, N' Màn hình OLED 6,6 inch, chip Kirin 9000, camera chính 50MP, hỗ trợ 5G, pin 4360mAh. Trải nghiệm chụp ảnh và quay video chất lượng cao, xem video và chơi game mượt mà, hỗ trợ sạc nhanh.', 'huawei-p50-pro-600x600.jpg', 'LSP07', 'TH002', 'TSKT008'), 
('SP000008', N'Oppo Find X3 Pro', 17990000, 5, N'Màn hình AMOLED 6,7 inch, chip Snapdragon 888,camera chính 50MP, hỗ trợ 5G, pin 4500mAh. Trải nghiệm chụp ảnh và quay video chất lượng cao, xem video và chơi game mượt mà, hỗ trợ sạc nhanh.', 'oppo-find-x3-pro-bh-org-1-org.jpg', 'LSP07', 'TH012', 'TSKT009'), 
('SP000009', N'Realme Q3 Pro', 3999000, 8, N'Màn hình IPS 6,43 inch, chip Dimensity 1100, camera chính 64MP, hỗ trợ 5G, pin 4500mAh. Trải nghiệm chụp ảnh và quay video chất lượng cao, xem video và chơi game mượt mà, hỗ trợ sạc nhanh.', 'realme-q3-pro-1-600x600.jpg', 'LSP07', 'TH010', 'TSKT005'), 
('SP000010', N'Nokia X50', 14990000, 5, N'Nokia X50: Màn hình AMOLED 6,67 inch, camera 108MP, pin 4470mAh, hỗ trợ 5G. Trải nghiệm chụp ảnh, xem video trực tiếp và sử dụng các ứng dụng mới nhất.', 'nokia-x50-600x600.jpg', 'LSP07', 'TH013', 'TSKT010'),
('SP000011', N'Dell XPS 13', 29990000, 8, N'Dell XPS 13: Màn hình 13 inch, Intel Core i7, RAM 16GB. Thiết kế siêu mỏng và nhẹ, thời lượng pin lâu, xử lý tốt các tác vụ đa nhiệm.', 'dell-xps-13-plus_1280x720-800-resize.jpg', 'LSP06', 'TH004', 'TSKT011'), 
('SP000012', N'HP Spectre x360', 26990000, 6, N'HP Spectre x360: Màn hình 13,3 inch, Intel Core i7, RAM 16GB. Thiết kế 2 trong 1, xoay màn hình dễ dàng, thời lượng pin lâu, âm thanh tốt.', 'hp-spectre-x360-13-ac028tu-i7-7500u-nau-1-org.jpg', 'LSP06', 'TH009', 'TSKT013'), 
('SP000013', N'Lenovo ThinkPad X1 Carbon', 35990000, 5, N'Lenovo ThinkPad X1 Carbon: Màn hình 14 inch, Intel Core i7, RAM16GB. Thiết kế bền bỉ và chắc chắn, kết nối internet nhanh chóng, xử lý tốt các tác vụ đa nhiệm.', 'lenovo-thinkpad-x1-carbon-gen-10-i7-21cb00a8vn-2-1.jpg', 'LSP06', 'TH007', 'TSKT014'), 
('SP000014', N'Asus ZenBook UX425', 22990000, 9, N'Asus ZenBook UX425: Màn hình 14 inch, Intel Core i7, RAM 16GB. Thiết kế sang trọng và tinh tế, thời lượng pin lâu, xử lý tốt các tác vụ đa nhiệm.', 'asus-zenbook-ux425ea-i5-bm069t-2-org.jpg', 'LSP06', 'TH003', 'TSKT015'), 
('SP000015', N'MacBook Pro 16-inch', 52990000, 7, N'MacBook Pro 16-inch: Màn hình Retina 16 inch, Intel Core i9, RAM 64GB. Thiết kế tinh tế, màn hình đẹp mắt, thời lượng pin lâu, xử lý tốt các tác vụ đa nhiệm.', 'apple-macbook-pro-16-m1-pro-2021-10-core-cpu-2.jpg', 'LSP06', 'TH006', 'TSKT012'), 
('SP000016', N'Acer Swift 5', 20990000, 1, N'Acer Swift 5: Màn hình 14 inch, Intel Core i7, RAM 16GB. Thiết kế siêu mỏng và nhẹ, khả năng xử lý tốt các tác vụ thông thường.', 'acer-swift-sf5-i7-8565u-8gb-256gb-win10-xanh-duong-2-org.jpg', 'LSP06', 'TH001', 'TSKT016'), 
('SP000017', N'Dell VOSTRO 3558', 9990000, 6, N'Dell VOSTRO 3558: Màn hình 15,6 inch, Intel Core i3, RAM 4GB. Thiết kế đơn giản, xử lý tốt cáctác vụ thông thường, phù hợp cho học tập và làm việc văn phòng.', 'dell-vostro-3558-i3-4005u-4gb-500gb-win81-org-1.jpg', 'LSP06', 'TH004', 'TSKT017'), 
('SP000018', N'Razer Blade Stealth 13', 39990000, 8, N'Razer Blade Stealth 13: Màn hình 13,3 inch, Intel Core i7, RAM 16GB. Thiết kế đẹp mắt, khả năng xử lý tốt các tác vụ đa nhiệm và đồ họa, phù hợp cho chơi game máy tính.', 'gturqbjdmvvqbmfc7jczm-1366-80-_1366x768-800-resize.jpg', 'LSP06', 'TH002', 'TSKT018'), 
('SP000019', N'MSI Prestige 14', 31990000, 1, N'MSI Prestige 14: Màn hình 14 inch, Intel Core i7, RAM 16GB. Thiết kế đẹp mắt, màn hình đẹp, khả năng xử lý tốt các tác vụ đa nhiệm và đồ họa, phù hợp cho làm việc và sáng tạo.', 'msi-prestige-14-a11sc-i7-202vn-2-2.jpg', 'LSP06', 'TH003', 'TSKT019'), 
('SP000020', N'LG Gram 17', 39990000, 6, N'LG Gram 17: Màn hình 17 inch, Intel Core i7, RAM 16GB. Thiết kế siêu mỏng và nhẹ, thời lượng pin lâu, khả năng xử lý tốt các tác vụ đa nhiệm. Trải nghiệm làm việc và giải trí tuyệt vời.', 'lg-gram-2023-i7-14z90rgah75a5-1.jpg', 'LSP06', 'TH008', 'TSKT020'),
('SP000021', N'Samsung Galaxy Tab S7', 14990000, 3, N'Màn hình 11 inch, RAM 6GB, bút S Pen đi kèm. Khả năng xử lý tốt các tác vụ đa nhiệm, chơi game và làm việc trên màn hình lớn, hỗ trợ bút S Pen cho trải nghiệm viết và vẽ tuyệt vời.', 'samsung-galaxy-tab-s7-vang-dong-1-org.jpg', 'LSP08', 'TH005', 'TSKT021'), 
('SP000022', N'Apple iPad Pro (2021)', 23990000, 7, N'Thiết kế tinh tế, khả năng xử lý tốt các tác vụ đa nhiệm, trải nghiệm viết, vẽ và gõ phím tuyệt vời với bút Apple Pencil và bàn phím Magic Keyboard.', 'ipad-pro-m1-11-inch-wifi-2-1.jpg', 'LSP08', 'TH006', 'TSKT022'), 
('SP000023', N'Microsoft Surface Pro 7', 29990000, 3, N'Thiết kế 2 trong 1, xoay màn hình dễ dàng, khả năng xử lý tốt các tác vụ đa nhiệm và đồ họa, hỗ trợ bút Surface Pen cho trải nghiệm viết và vẽ tuyệt vời.', 'surface-pro-7-i5-puv00001-den-1.jpg', 'LSP08', 'TH015', 'TSKT023'), 
('SP000024', N'Lenovo Tab P11 Pro', 11990000, 9, N'bút Lenovo Precision Pen đi kèm. Thiết kế đẹp mắt, khả năng xử lý tốt các tác vụ đa nhiệm, hỗ trợ bút Lenovo Precision Pen cho trải nghiệm viết và vẽ tuyệt vời.', 'lenovo-tab-p11-pro-073820-043835-600x600.jpg', 'LSP08', 'TH007', 'TSKT024'), 
('SP000025', N'iPad 10', 3490000, 7, N'Thiết kế đơn giản và dễ sử dụng, khả năng xử lý tốt các tác vụ đa nhiệm, trải nghiệm viết, vẽ và gõ phím tuyệt vời với bút Apple Pencil và bàn phím Smart Keyboard.', 'ipad-10-vang-glr-1.jpg', 'LSP08', 'TH016', 'TSKT025'), 
('SP000026', N'Huawei MatePad Pro 12.6', 25990000, 7, N'hỗ trợ M-Pencil và bàn phím thông minh. Thiết kế đẹp mắt, khả năng xử lý tốt các tác vụ đa nhiệm, trải nghiệm viết, vẽ và gõ phím tuyệt vời với bút M-Pencil và bàn phím thông minh.', 'huawei-matepad-pro-129-2021-600x600.jpg', 'LSP08', 'TH012', 'TSKT026'), 
('SP000027', N'ASUS ZenPad 3S 10', 8990000, 2, N' Màn hình IPS 9,7 inch, chip MediaTek MT8176, RAM 4GB. Thiết kế đẹp mắt và nhẹ, khả năng xử lý tốt các tác vụ thông thường, phù hợp cho giải trí và làm việc văn phòng.', 'asus-zenpad-3s-10-z500kl_m-1-300x300.jpg', 'LSP08', 'TH003', 'TSKT027'), 
('SP000028', N'Samsung Galaxy Tab A8', 27990000, 10, N'Màn hình 8 inch, RAM 2GB. Thiết kế đơn giản và dễ sử dụng, khả năng xử lý tốt các tác vụ thông thường, phùhợp cho giải trí và đọc sách, trải nghiệm xem video và chơi game cơ bản.', 'samsung-galaxy-tab-a8-1-1.jpg', 'LSP08', 'TH015', 'TSKT028'), 
('SP000029', N'Xiaomi Mi Pad 5 Pro', 9990000, 5, N'Màn hình 11 inch, RAM 8GB, hỗ trợ bút điện tử Xiaomi. Thiết kế đẹp mắt, khả năng xử lý tốt các tác vụ đa nhiệm và đồ họa, hỗ trợ bút điện tử Xiaomi cho trải nghiệm viết và vẽ tuyệt vời.', 'xiaomi-mi-pad-5-pro-600x600.jpg', 'LSP08', 'TH011', 'TSKT029'), 
('SP000030', N'LG G Pad 5 10.1', 6990000, 10, N'Màn hình IPS 10,1 inch, chip Snapdragon 821, RAM 4GB. Thiết kế đẹp mắt và nhẹ, khả năng xử lý tốt các tác vụ thông thường, phù hợp cho giải trí và làm việc văn phòng.', 'lg4_800x450.jpg', 'LSP08', 'TH008', 'TSKT030'),
('SP000031', N'Samsung Galaxy Note 20 Ultra', 27790000, 3, N'Samsung Galaxy Note 20 Ultra: Một trong những chiếc điện thoại cao cấp nhất của Samsung, với màn hình Dynamic AMOLED 2X 6.9 inch, camera sau 108 MP và hỗ trợ bút S Pen.', 'samsung-galaxy-s21-ultra-bac-1-org.jpg', 'LSP07', 'TH005', 'TSKT031'), 
('SP000032', N'Apple iPhone 12 Mini', 25990000, 10, N'Apple iPhone 12 Mini: Phiên bản nhỏ gọn nhất của iPhone 12, với màn hình Super Retina XDR 5.4 inch, camera sau kép 12 MP và hỗ trợ sạc nhanh MagSafe.', 'iphone-12-mini-tim-gc-1-org.jpg', 'LSP07', 'TH006', 'TSKT032'), 
('SP000033', N'Google Pixel 5a', 16190000, 9, N'Google Pixel 5a: Chiếc điện thoại mới nhất của Google, được trang bị chip Snapdragon 765G, camera sau kép 12.2 MP và hỗ trợ 5G.', 'google-pixel-5a-040921-051453-600x600.jpg', 'LSP07', 'TH014', 'TSKT033'), 
('SP000034', N'OnePlus Nord 2', 22590000, 9, N'OnePlus Nord 2: Chiếc điện thoại tầm trung của OnePlus, với màn hình Fluid AMOLED 6.43 inch, camera sau 50 MP và hỗ trợ sạc nhanh Warp Charge 65.', 'oneplus-nord-2-5g-600x600.jpg', 'LSP07', 'TH011', 'TSKT034'), 
('SP000035', N'Xiaomi Poco X3 Pro', 18990000, 2, N'Xiaomi Poco X3 Pro: Chiếc điện thoại tầm trung của Xiaomi, với màn hình IPS LCD 6.67 inch, camera sau 48 MP và hỗ trợ sạc nhanh 33W.', 'xiaomi-poco-x3-pro-600x600-1-600x600.jpg', 'LSP07', 'TH011', 'TSKT035'), 
('SP000036', N'Sony Xperia 5 II', 31990000, 9, N'Sony Xperia 5 II: Một trong những chiếc điện thoại cao cấp nhất của Sony, với màn hình OLED 6.1 inch, camera sau 12 MP và hỗ trợ chụp ảnh RAW.', 'sony-xperia-5-ii-215020-015023-600x600.jpg', 'LSP07', 'TH016', 'TSKT036'), 
('SP000037', N'Huawei P40 Pro Plus', 25990000, 9, N'Huawei P40 Pro Plus: Chiếc điện thoại cao cấp của Huawei, với màn hình OLED 6.58 inch, camera sau 50 MP và hỗ trợ sạc nhanh 40W.', 'huawei-p40-pro-plus-600x600-1-600x600.jpg', 'LSP07', 'TH017', 'TSKT037'), 
('SP000038', N'Oppo Reno 6 Pro+', 24490000, 3, N'Oppo Reno 6 Pro+: Chiếc điện thoại cao cấp của Oppo, với màn hình AMOLED 6.55 inch, camera sau 50 MP và hỗ trợ sạc nhanh 65W.', 'oppo-reno6-pro-plus-600x600.jpg', 'LSP07', 'TH012', 'TSKT038'), 
('SP000039', N'Motorola Moto G Power (2021)', 23990000, 9, N'Motorola Moto G Power (2021): Chiếc điện thoại tầm trung của Motorola, với màn hình IPS LCD 6.6 inch, camera sau 48 MP và pin dung lượng lớn 5000 mAh.', 'motorola-moto-g8-power-600x600-600x600.jpg', 'LSP07', 'TH011', 'TSKT039'), 
('SP000040', N'LG Wing 5G', 12990000, 7, N'LG Wing 5G: Chiếc điện thoại độc đáo của LG, với màn hình OLED 6.8 inch, camera sau kép 64 MP và màn hình phụ OLED 3.9 inch xoay dọc, cho phép sử dụng 2 ứng dụng cùng lúc và trải nghiệm độc đáo.', '600-lg-wing-600x600.jpg', 'LSP07', 'TH008', 'TSKT040'),
('SP000041', N'itel ABLE 1S N4020 (71006300027)', 6990000, 9, N'laptop học tập - văn phòng sử dụng hiệu quả cho các tác vụ cơ bản, thiết kế thanh lịch, gọn nhẹ, đáp ứng nhu cầu về hiệu năng và giá thành cho các khách hàng trong phân khúc.', 'itel-able-1s-n4020-71006300027-2-2.jpg', 'LSP06', 'TH014', 'TSKT041'), 
('SP000042', N'Lenovo Ideapad 5 Pro 14ITL6 i5 1155G7 (82L300M9VN)', 24490000, 7, N'Ngoại hình hiện đại, thanh lịch, hiệu năng mạnh mẽ cùng màn hình 2.2K sắc nét sẽ là những ưu điểm mà bạn nên lựa chọn laptop Lenovo Ideapad 5 Pro 14ITL6 i5 (82L300M9VN) làm trợ thủ đắc lực trong phân khúc laptop học tập - văn phòng.', 'lenovo-ideapad-5-pro-14itl6-i5-82l300m9vn-xy-2.jpg', 'LSP06', 'TH007', 'TSKT042'), 
('SP000043', N'Asus Gaming TUF Dash F15 FX517ZC i5 12450H (HN077W)', 31990000, 7, N'Sở hữu ngoại hình ấn tượng thu hút mọi ánh nhìn cùng hiệu năng mạnh mẽ đến từ laptop CPU thế hệ 12 mới nhất, Asus Gaming TUF Dash F15 FX517ZC i5 (HN077W) là lựa chọn xứng tầm cho mọi nhu cầu chiến game giải trí hay đồ hoạ - kỹ thuật của người dùng.', 'asus-tuf-gaming-fx517zc-i5-hn077w-ab-2.jpg', 'LSP06', 'TH003', 'TSKT043'), 
('SP000044', N'MSI Gaming GF63 Thin 11UD i7 11800H (648VN)', 29990000, 10, N'Sở hữu một vẻ ngoài độc đáo, mạnh mẽ phù hợp với mọi game thủ, chiếc laptop MSI Gaming GF63 Thin 11UD i7 11800H (648VN) được trang bị dòng chip Intel thế hệ 11 hiệu năng mạnh mẽ vượt trội khi đi cùng card rời RTX 30 series sẵn sàng chiến mượt bất kì tựa game phổ biến hay thiết kế đồ họa chuyên sâu.', 'msi-gaming-gf63-thin-11ud-i7-648vn-2.jpg', 'LSP06', 'TH016', 'TSKT044'), 
('SP000045', N'Asus Vivobook 14 X1402ZA i3 1220P (EK249W)', 12990000, 8, N'sở hữu cấu hình vượt trội từ bộ vi xử lý Intel Gen 12 cùng kiểu dáng thiết kế thời thượng, xứng danh người cộng sự lý tưởng, sẵn sàng đồng hành cùng bạn mọi lúc mọi nơi, trong cả công việc hay giải trí.', 'asus-vivobook-14-x1402za-i3-ek249w-2-1.jpg', 'LSP06', 'TH003', 'TSKT045'), 
('SP000046', N'MacBook Air M1 2020 7-core GPU', 24990000, 6, N'laptop cao cấp sang trọng có cấu hình mạnh mẽ, chinh phục được các tính năng văn phòng lẫn đồ hoạ mà bạn mong muốn, thời lượng pin dài, thiết kế mỏng nhẹ sẽ đáp ứng tốt các nhu cầu làm việc của bạn.', 'macbook-air-m1-2020-silver-01-org.jpg', 'LSP06', 'TH006', 'TSKT046'), 
('SP000047', N'MacBook Air M2 2022 8-core GPU', 30990000, 8, N'thiết kế hoàn toàn mới, độ dày không thay đổi tương tự như MacBook Pro, đánh bật mọi rào cản với con chip Apple M2 đầy mạnh mẽ.', 'apple-macbook-air-m2-2022-02-2.jpg', 'LSP06', 'TH006', 'TSKT047'), 
('SP000048', N'MacBook Air M1 2020 8-core GPU', 29990000, 1, N'vẻ ngoài hiện đại cùng cấu hình mạnh mẽ vượt trội đến từ con chip M1 được sản xuất trên quy trình tân tiến, là người bạn đồng hành lý tưởng cho bất kỳ ai trong cả những công việc văn phòng hay thiết kế đồ họa.', 'apple-macbook-air-m1-2020-8-core-gpu-xam-01.jpg', 'LSP06', 'TH006', 'TSKT048'), 
('SP000049', N'MacBook Air M2 2022 10-core GPU', 35990000, 5, N'khẳng định vị thế hàng đầu của Apple trong phân khúc laptop cao cấp - sang trọng vào giữa năm 2022 khi sở hữu phong cách thiết kế thời thượng, đẳng cấp cùng sức mạnh bộc phá đến từ bộ vi xử lý Apple M2 mạnh mẽ.', 'apple-macbook-air-m2-2022-16gb-2.jpg', 'LSP06', 'TH006', 'TSKT049'),
('SP000050', N'iPad Pro M1 12.9 inch 5G', 30000000, 2, N'Bạn có đang mong chờ những sản phẩm chất lượng đến từ Apple? Sau hàng loạt các sản phẩm đình đám như iPhone 12 series thì hãng đã tung ra chiếc iPad Pro M1 12.9 inch Wifi Cellular 128GB (2021) trang bị những tính năng ngày càng vượt trội và thời thượng.', 'ipad-pro-m1-129-inch-wifi-cellular--1.jpg', 'LSP08', 'TH006', 'TSKT050'), 
('SP000051', N'Samsung Galaxy Tab A8 (2022)', 6000000, 10, N'Samsung Galaxy Tab A8 (2022) là 1 phiên bản tuyệt vời trong Galaxy Tab A Series, sản phẩm này chắc chắn sẽ trở thành công cụ liên lạc online trong thời hiện đại mà bạn chắc chắn sẽ rất hài lòng khi sở hữu.', 'samsung-galaxy-tab-a8-1-1 (1).jpg', 'LSP08', 'TH005', 'TSKT051'), 
('SP000052', N'Samsung Galaxy Tab A7 Lite', 4000000, 1, N'Máy tính bảng Samsung Galaxy Tab A7 Lite là phiên bản rút gọn của dòng tablet "ăn khách" Galaxy Tab A7 thuộc thương hiệu Samsung, đáp ứng nhu cầu giải trí của khách hàng thuộc phân khúc bình dân với màn hình lớn nhưng vẫn gọn nhẹ hợp túi tiền.', 'samsung-galaxy-tab-a7-lite-gray-600x600.jpg', 'LSP08', 'TH005', 'TSKT052'), 
('SP000053', N'Samsung Galaxy Tab S8 Ultra 5G', 20000000, 8, N'Samsung Galaxy Tab S8 Ultra ra mắt với kích thước màn hình siêu to cùng một cấu hình mạnh mẽ, được xem là thiết bị phù hợp đối với những ai thường xuyên làm các công việc thiết kế hay thao tác trên trình duyệt web, bên cạnh đó Tab S8 Ultra còn mang đến những trải nghiệm tương tự một chiếc laptop khi sử dụng kèm với bàn phím.', 'samsung-tab-s8-ultra-thumb-600x600.jpg', 'LSP08', 'TH005', 'TSKT053'), 
('SP000054', N'Samsung Galaxy Tab S7 FE 4G', 15000000, 6, N'Samsung chính thức trình làng mẫu máy tính bảng có tên Galaxy Tab S7 FE, máy trang bị cấu hình mạnh mẽ, màn hình giải trí siêu lớn và điểm ấn tượng nhất là viên pin siêu khủng được tích hợp bên trong, giúp tăng hiệu suất làm việc nhưng vẫn có tính di động cực cao.', 'samsung-galaxy-tab-s7-fe-black-600x600.jpg', 'LSP08', 'TH005', 'TSKT054'), 
('SP000055', N'iPad Pro M1 11 inch WiFi Cellular 2TB (2021)', 41000000, 1, N'Máy tính bảng iPad Pro M1 11 inch WiFi Cellular 2TB (2021) mang vẻ ngoài sang trọng, chắc chắn của lớp vỏ kim loại nguyên khối hoàn thiện tinh tế, thiết kế vuông vức hiện đại, kích thước màn hình 11 inch sử dụng thuận tiện như 1 chiếc laptop mini dùng cho cá nhân.', 'pad-pro-m1-11-inch-wifi-cellular-1tb-2021-xam-thumb-600x600.jpg', 'LSP08', 'TH006', 'TSKT055'), 
('SP000056', N'iPad Pro M1 12.9 inch WiFi', 25000000, 2, N'iPad Pro M1 12.9 inch WiFi 512GB (2021) chiếc máy tính bảng với thiết kế sang trọng đẳng cấp, màn hình mini-LED tuyệt hảo 12.9 inch, sức mạnh tương đương máy tính để bàn nhờ bộ vi xử lý Apple M1 và hệ thống camera chất lượng rất đáng để đầu tư và nâng cấp.', 'ipad-pro-m1-129-inch-wifi-sliver-thumb-600x600.jpg', 'LSP08', 'TH006', 'TSKT056'), 
('SP000057', N'iPad Pro M2 11 inch WiFi', 35000000, 4, N'Cơn sốt của iPhone 14 series chưa kịp lắng xuống thì mới đây nhà Apple lại vừa tung ra bộ sản phẩm tablet cho năm 2022 với nhiều điểm thu hút. Con chip Apple M2 từng khuấy đảo thị trường laptop bây giờ đã được xuất hiện trên iPad Pro M2 11 inch WiFi 128GB, nó quả thực là một tin chấn động trong giới công nghệ bởi đây có thể là chiếc máy tính bảng có hiệu năng vô đối trên thị trường (10/2022).', 'ipad-pro-m2-11-wifi-xam-thumb-600x600.jpg', 'LSP08', 'TH006', 'TSKT057'), 
('SP000058', N'iPad mini 6 WiFi Cellular 64GB', 14000000, 2, N'iPad mini 6 WiFi Cellular 64GB đánh dấu sự trở lại mạnh mẽ của Apple trên dòng sản phẩm iPad mini, thiết bị mới được người dùng yêu thích bởi thiết kế trẻ trung, hiệu suất đỉnh cao với con chip A15 Bionic và hỗ trợ bút cảm ứng Apple Pencil 2 tiện lợi.', 'ipad-mini-6-wifi-cellular-pink-1-600x600.jpg', 'LSP08', 'TH006', 'TSKT058'), 
('SP000059', N'iPad Air 5 M1 Wifi 64GB', 16000000, 3, N'iPad Air 5 M1 Wifi 64 GB đã được công bố tại sự kiện Peek Performance diễn ra hôm 9/3 (theo giờ Việt Nam). Năm nay Apple đã có những thay đổi lớn về cả hiệu năng và bổ sung màu sắc mới cho thiết bị.', 'ipad-air-5-wifi-grey-thumb-600x600.jpg', 'LSP08', 'TH006', 'TSKT059');

INSERT INTO CHITIETHOADON VALUES
('HD0001', 'SP000003', 4, 111960000),
('HD0002', 'SP000007', 1, 19990000),
('HD0003', 'SP000007', 2, 39980000),
('HD0004', 'SP000001', 4, 75960000),
('HD0005', 'SP000051', 2, 13998000),
('HD0001', 'SP000001', 2, 55980000),
('HD0002', 'SP000002', 2, 39980000),
('HD0003', 'SP000047', 1, 19990000),
('HD0004', 'SP000004', 1, 18990000),
('HD0005', 'SP000005', 3, 20997000),
('HD0006', 'SP000013', 1, 14990000),
('HD0007', 'SP000007', 1, 19990000),
('HD0008', 'SP000008', 2, 35980000),
('HD0009', 'SP000009', 3, 11997000),
('HD0010', 'SP000016', 3, 44970000);

INSERT INTO PHIEUNHAP VALUES
('PN001', 'NV0004', '2019-07-28'),
('PN002', 'NV0004', '2023-02-14'),
('PN003', 'NV0004', '2022-09-09'),
('PN004', 'NV0004', '2020-04-02'),
('PN005', 'NV0004', '2021-12-25'),
('PN006', 'NV0004', '2018-08-17'),
('PN007', 'NV0004', '2023-01-01'),
('PN008', 'NV0004', '2019-03-29'),
('PN009', 'NV0004', '2022-05-11');

INSERT INTO CHITIETPHIEUNHAP VALUES
('PN001', 'SP000001', 7, 7060792),
('PN002', 'SP000002', 3, 4051749),
('PN003', 'SP000003', 7, 6380169),
('PN004', 'SP000004', 4, 8541444),
('PN005', 'SP000005', 6, 2391786),
('PN006', 'SP000013', 2, 3261985),
('PN007', 'SP000007', 4, 430445),
('PN008', 'SP000008', 9, 2996886),
('PN009', 'SP000009', 9, 8991740),
('PN004', 'SP000016', 7, 4128512);


select * from HOADON
select * from CHITIETHOADON
select * from KHACHHANG