create database QLTV
go

use QLTV
go

create table DocGia
(
	MaDG int identity(1,1),
	TenDG nvarchar(50),
	NgaySinh Date,
	GioiTinh nvarchar(10),
	DiaChi nvarchar(50),
	primary key (MaDG)
)

create table Sach
(
	MaSach int identity(1,1),
	TenSach nvarchar(50),
	Loai int,
	TenTG nvarchar(50),
	NSB nvarchar(50),
	GiaTien float,
	SoLuong int,
	primary key (MaSach)
)

create table LoaiSach
(
	MaLoai int identity(1,1),
	TenLoai nvarchar(50),
	primary key (MaLoai)
)

create table PhieuMuon
(
	MaPM int identity(1,1),
	MaDG int,
	NgayMuon date not null,
	NgayTra date,
	
	primary key (MaPM)
)
create table ChiTietPM
(
	MaPM int,
	MaSach int,
	SoLuong int,
	primary key (MaPM, MaSach)
)

go
-- bảng sach
alter table Sach add constraint FK_Sach_LoaiSach foreign key (Loai) references LoaiSach(MaLoai)
-- bang phieu muon

alter table PhieuMuon add constraint FK_PhieuMuon_DocGia foreign key (MaDG) references DocGia(MaDG)
-- bảng chitiet

alter table ChiTietPM add constraint FK_ChiTietPM_PhieuMuon foreign key (MaPM) references PhieuMuon(MaPM)
alter table ChiTietPM add constraint FK_ChiTietPM_Sach foreign key (MaSach) references Sach(MaSach)

go

-- LoaiSach

insert into LoaiSach (TenLoai)
values (N'Triết học và Tâm lý học') -- 1
insert into LoaiSach (TenLoai)
values (N'Công nghệ và khoa học ứng dụng') -- 2
insert into LoaiSach (TenLoai)
values (N'Nghệ thuật') -- 3
insert into LoaiSach (TenLoai)
values (N'Văn học') -- 4
insert into LoaiSach (TenLoai)
values (N'Địa lý và lịch sử') -- 5
insert into LoaiSach (TenLoai)
values (N'Nông nghiệp') -- 6


go
-- DocGia
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Tạ Tấn Phúc', '1994-6-29', N'Nam', N'ngõ 81 Tổ 12 Mậu Lương,P.Kiến Hưng,Q.Hà Đông') --1
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Nguyễn Đình Hà', '1996-3-19', N'Nữ', N'nhà số 14 ngách 18 ngõ 111 Triều Khúc,Hà Nội') --2
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Nguyễn Ngọc Minh Thanh', '1993-6-2', N'Nam', N'nhà số 7 ngõ 122 /2 đường Kim Giang,P.Đại Kim,Hoàng Mai,Hà Nội') --3
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Đào Văn Danh', '1997-3-9', N'Nam', N'số 18 ngõ 54 Phùng Khoang,Nam Từ Liêm,Hà Nội') --4
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Trần Thị Ngọc Vàng', '1996-12-4', N'Nữ', N'nhà số 29 ngách 10 ngõ 2 Hoàng Liệt,P.Hoàng Liệt,Hoàng Mai') --5
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Đào Thế Hòa', '1998-8-2', N'Nữ', N'16 ngách242/74 Minh Khai, Hoàng Mai, Hà Nội') --6
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Nguyễn Thành Đạt', '1995-3-3', N'Nam', N'số 36 trường lâm, long biên, Hà nội') --7
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Đinh Duy Phương', '1995-5-23', N'Nam', N'Ngõ 52/28 Tô Ngọc Vân, phường Quảng An, Tây Hồ, Hà Nội') --8
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Phạm Văn Vạn', '1994-7-2', N'Nam', N'Phòng 504, tòa B, chung cư Golden Land, 275 Nguyễn Trãi, Thanh Xuân, Hà Nội') --9
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Đỗ Thanh Hải', '1995-10-9', N'Nữ', N'số 33/89 ngõ Thịnh Quang, Đống Đa, Hà Nội') --10
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Nguyễn Đắc Hồng', '1993-4-19', N'Nữ', N'3A ngõ 264/17 Âu Cơ, Nhật Tân, Tây Hồ') --11
insert into DocGia (TenDG, NgaySinh, GioiTinh, DiaChi)
values (N'Huỳnh Kim Hoàng', '1994-4-28', N'Nam', N'ngõ 362 đường Giải Phóng, phường Thịnh Liệt, quận Hoàng Mai') --12
go

-- Sach

insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Những nguyên lý cơ bản chủ nghĩa', 1, N'Mác', N'Nhà sách quốc gia', 50000, 10) --1 
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Công nghệ mô phỏng', 2, N'Hoàng Văn Khoa', N'Kim Đồng', 100000, 5) -- 2
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Truyện Kiều', 4, N'Nguyễn Du', N'Giáo dục và đào tạo', 15000, 20) --3 
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Vẽ Tranh Đông Hồ', 3, N'Ngô Duy Dương', N'Văn Hoá Nghệ Thuật', 40000, 4) -- 4
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Lịch Sử Loài Người', 5, N'', N'Nguyễn Hưu Hoàn', 45000, 5) -- 5
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Ngôn Ngữ Cơ Thể', 1, N'Lê Minh Thảo', N'Kim Đồng', 78000, 4) -- 6
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Sản xuất nông nghiệp sạch', 6, N'Lê Thành Nhân', N'Tuổi Trẻ', 45000, 14) --7 
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Bản Đồ Kho Báu', 5, N'Jack Sparrow', N'Bản đồ', 15000, 11) -- 8
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Đừng bao giờ từ bỏ mơ ước', 4, N'Nguyễn Hà Anh', N'Thanh niên', 45000, 8) -- 9
insert into Sach(TenSach, Loai, TenTG, NSB, GiaTien, SoLuong)
values (N'Công nghệ 4.0', 2, N'Henning Kagermann', N'Cộng Nghệ Khoa Học', 120000, 4) -- 10


go
-- PhieuMuon

insert into PhieuMuon (MaDG, NgayMuon, NgayTra)
values (1, '2018-1-1', '2018-4-3') -- 1
insert into PhieuMuon (MaDG, NgayMuon, NgayTra)
values (2, '2018-2-5', '2018-2-27') -- 2
insert into PhieuMuon (MaDG, NgayMuon, NgayTra)
values (4, '2018-1-25', '2018-3-5') -- 3
insert into PhieuMuon (MaDG, NgayMuon, NgayTra)
values (6, '2018-3-1', '2018-5-3') -- 4
insert into PhieuMuon (MaDG, NgayMuon, NgayTra)
values (7,'2018-3-15', null) -- 5
insert into PhieuMuon (MaDG, NgayMuon, NgayTra)
values (10, '2018-2-15', null) -- 6
insert into PhieuMuon (MaDG, NgayMuon, NgayTra)
values (11, '2018-1-3', null) -- 7


go
--ChiTietPM
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (1, 3, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (1, 1, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (1, 6, 2) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (1, 9, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (2, 3, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (2, 7, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (2, 10, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (3, 2, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (3, 1, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (3, 5, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (3, 7, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (4, 4, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (4, 2, 2) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (4, 6, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (5, 4, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (5, 1, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (5, 8, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (5, 9, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (6, 3, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (6, 6, 2) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (7, 3, 1) 
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (7, 2, 1)
insert into ChiTietPM(MaPM, MaSach, SoLuong)
values (7, 8, 1)

go



go



CREATE PROC themdg(@hoten nvarchar(50), @ngaysinh date, @gioitinh nvarchar(10), @diachi nvarchar(100))
AS
BEGIN
	INSERT INTO DocGia (TenDG, NgaySinh, GioiTinh, DiaChi) -- nếu ổn thì thêm
	VALUES (@hoten, @ngaysinh, @gioitinh, @diachi)
	--PRINT'Đã thêm thành công'
END
-- sửa lương của 1 nv
go
CREATE PROC suadg (@ma int, @hoten nvarchar(50), @ngaysinh date, @gioitinh nvarchar(10), @diachi nvarchar(100)) 
AS
BEGIN
	if (@ma not in  (select MaDG from DocGia)) return

	if(len(@hoten) > 0)
	begin
		UPDATE DocGia
		SET TenDG = @hoten
		WHERE MaDG = @ma
	end
	if((YEAR(@ngaysinh) - 1900) > 0)
	begin
		UPDATE DocGia
		SET NgaySinh = @ngaysinh
		WHERE MaDG = @ma
	end
	if(len(@diachi) > 0)
	begin
		UPDATE DocGia
		SET DiaChi = @diachi
		WHERE MaDG = @ma
	end
	if(len(@gioitinh) > 0)
	begin
		UPDATE DocGia
		SET GioiTinh = @gioitinh
		WHERE MaDG = @ma
	end
END
-- xóa 1 nv
go
CREATE PROC xoadg(@ma int) -- xóa 1 nv
AS
BEGIN
	if(@ma not in (select MaDG from DocGia)) return
	if(@ma in (select MaDG from PhieuMuon)) -- nếu nv có trong hóa đơn nhập , thì chuyển về null
	begin
		UPDATE PhieuMuon
		SET MaDG = null
		WHERE MaDG = @ma
	end

	
	DELETE DocGia 
	WHERE MaDG = @ma
END
go

-----------------------------------------

go

CREATE PROC themsach (@ten nvarchar(50), @loai int, @tacgia nvarchar(50), @nsb nvarchar(50), @giatien float, @soluong int)
AS
BEGIN
	if(@loai not in (select MaLoai from LoaiSach)) return
	if(@giatien < 0 and @soluong < 0) return
	INSERT INTO Sach (TenSach, Loai, TenTG, NSB, GiaTien, SoLuong) -- nếu ổn thì thêm
	VALUES (@ten, @loai, @tacgia, @nsb, @giatien, @soluong)
END
-- sửa lương của 1 nv
go
CREATE PROC suasach (@ma int, @ten nvarchar(50), @loai int, @tacgia nvarchar(50), @nsb nvarchar(50), @giatien float, @soluong int) 
AS
BEGIN
	if (@ma not in  (select MaSach from Sach)) return
	if(@loai not in (select MaLoai from LoaiSach)) return
	if(len(@ten) > 0)
	begin
		UPDATE Sach
		SET TenSach = @ten
		WHERE MaSach = @ma
	end
	
	if(len(@tacgia) > 0)
	begin
		UPDATE Sach
		SET TenTG = @tacgia
		WHERE MaSach = @ma
	end
	if(len(@nsb) > 0)
	begin
		UPDATE Sach
		SET NSB = @nsb
		WHERE MaSach = @ma
	end
	if(@giatien >= 0)
	begin
		UPDATE Sach
		SET GiaTien = @giatien
		WHERE MaSach = @ma
	end
	if(@soluong >= 0)
	begin
		UPDATE Sach
		SET SoLuong = @soluong
		WHERE MaSach = @ma
	end
END
-- xóa 1 nv
go
CREATE PROC xoasach(@ma int) -- xóa 1 nv
AS
BEGIN
	if(@ma not in (select MaSach from Sach)) return
	if(@ma in (select MaSach from ChiTietPM)) -- nếu nv có trong hóa đơn nhập , thì chuyển về null
	begin
		Delete ChiTietPM
		where MaSach = @ma
	end
	
	DELETE Sach 
	WHERE MaSach = @ma
END
go
---------------------------------------------------------------
create proc themloai (@ten nvarchar(50))
as
begin
	if(len(@ten) > 0)
	begin
		insert into LoaiSach (TenLoai)
		values (@ten)
	end
end

----------------------------------------------------------
go

CREATE PROC thempm(@madg int, @ngaymuon date, @ngaytra date)
AS
BEGIN
	if(@madg not in (select MaDG from DocGia)) return
	if((YEAR(@ngaymuon) - 1900) <= 0) return
	declare @tra date
	if((YEAR(@ngaytra) - 1900) <= 0)
	begin
		set @tra = null
	end
	else
	begin
		set @tra = @ngaytra
	end
	INSERT INTO PhieuMuon(MaDG, NgayMuon, NgayTra)
	VALUES (@madg, @ngaymuon, @tra)
END
-- sửa lương của 1 nv
go
CREATE PROC suapm (@ma int, @madg int, @ngaymuon date, @ngaytra date) 
AS
BEGIN
	if (@ma not in  (select MaPM from PhieuMuon)) return

	if(@ma in (select MaDG from DocGia))
	begin
		UPDATE PhieuMuon
		SET MaDG = @madg
		WHERE MaPM = @ma
	end
	if((YEAR(@ngaymuon) - 1900) > 0)
	begin
		UPDATE PhieuMuon
		SET NgayMuon = @ngaymuon
		WHERE MaPM = @ma
	end
	if((YEAR(@ngaytra) - 1900) <= 0)
	begin
		Update PhieuMuon
		set NgayTra = null
		where MaPM = @ma
	end
	else
	begin
		Update PhieuMuon
		set NgayTra = @ngaytra
		where MaPM = @ma
	end
END
-- xóa 1 nv
go
CREATE PROC xoapm(@ma int) -- xóa 1 nv
AS
BEGIN
	if(@ma not in (select MaPM from PhieuMuon)) return
	if(@ma in (select MaPM from ChiTietPM)) -- nếu nv có trong hóa đơn nhập , thì chuyển về null
	begin
		delete ChiTietPM where MaPM = @ma
	end
	
	DELETE PhieuMuon
	WHERE MaPM = @ma
END
go
---------------------------------------------------------------
go

create proc themctpm (@mapm int, @masach int, @soluong int)
as
begin
	if(@mapm not in (select MaPM from PhieuMuon)) return
	if(@masach not in (select MaSach from Sach)) return
	if(@soluong < 0) return

	insert into ChiTietPM (MaPM, MaSach, SoLuong)
	values (@mapm, @masach, @soluong)
end
go
create proc suactpm (@mapm int , @masach int, @soluong int)
as
begin
	if(@mapm not in (select MaPM from PhieuMuon)) return
	if(@masach not in (select MaSach from Sach)) return
	if(@soluong < 0) return
	update ChiTietPM
	set SoLuong = @soluong
	where MaPM = @mapm and MaSach = @masach
end
go
create proc xoactpm (@mapm int, @masach int)
as 
begin
	delete ChiTietPM where MaPM = @mapm and MaSach = @masach
end
go

create proc xoactpm_all (@mapm int)
as
begin
	delete ChiTietPM where MaPM = @mapm
end




