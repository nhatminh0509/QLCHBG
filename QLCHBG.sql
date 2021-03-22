create database QLCHBG
go

use QLCHBG
go

create table NhanVien
(
	idNhanVien nvarchar(100) not null,
	matKhau nvarchar(1000)not null,
	tenNhanVien nvarchar(100) not null,
	cmnd nvarchar(20) not null,
	sdt nvarchar(20) not null,
	ngaySinh datetime,
	diaChi nvarchar(1000) not null,
	loaiNhanVien nvarchar(100) not null,
	trangThai int not null, -- 1: còn làm 0: nghỉ làm
	
	constraint PK_NhanVien primary key(idNhanVien)
)
go

create table KhachHang
(
	sdt nvarchar(20) not null,
	tenKhachHang nvarchar(100) not null,
	cmnd nvarchar(100),
	ngaySinh datetime,
	diaChi nvarchar(1000),
	tongChiTieu int,
	trangthai int,
	
	constraint PK_KhachHang primary key(sdt)
)
go

create table HangGiay
(
	id int identity not null,
	tenHang nvarchar(100) not null,
	trangThai int not null, -- 1: còn bán 0: không bán
	constraint PK_HangGiay primary key(id)
)
go

create table LoaiGiay
(
	id int identity not null,
	tenLoaiGiay nvarchar(100),
	idHang int,
	trangThai int,
	
	constraint PK_LoaiGiay primary key(id),
	constraint FK_LoaiGiay_HangGiay foreign key(idHang) references HangGiay(id),
	
)


create table Giay
(
	id int identity not null,
	tenGiay nvarchar(100) not null,
	idHangGiay int not null,
	idLoaiGiay int,
	giamGia int,
	hinhAnh nvarchar(1000),
	trangThai int not null, -- 1: còn bán 0: không bán
	
	constraint PK_Giay primary key(id),
	constraint FK_Giay_HangGiay foreign key(idHangGiay) references HangGiay(id),
	constraint FK_Giay_LoaiGiay foreign key(idLoaiGiay) references LoaiGiay(id)
)
go
create table BangSize
(	
	idGiay int ,
	sizeGiay nvarchar(20)not null,
	giaBan int not null,
	giaNhap int not null,
	soLuong int not null,
	trangThai int not null,
	
	constraint PK_BangSize primary key(idGiay,sizeGiay),
	constraint FK_BangSize_Giay foreign key(idGiay) references Giay(id) 
)
go


create table HoaDon
(
	id int identity not null,
	idNhanVien nvarchar(100) not null,
	sdtKhachHang nvarchar(20) not null,
	ngayLap datetime not null,
	tongTien int not null,
	giamGia int,
	thanhToan int,
	trangThai int not null, -- 1: đã thanh toán 0: chưa thanh toán -1: hủy
	
	constraint PK_HoaDon primary key(id),
	constraint FK_HoaDon_Khachhang foreign key(sdtKhachHang) references KhachHang(sdt),
	constraint FK_HoaDon_NhanVien foreign key(idNhanVien) references NhanVien(idNhanVien),
)
go

create table ChiTietHoaDon
(
	idHoaDon int not null,
	idGiay int,
	sizeGiay nvarchar(20),
	soLuong int not null,
	
	constraint PK_ChiTietHoaDon primary key(idHoaDon,idGiay,sizeGiay),
	constraint FK_ChiTietHoaDon_HoaDon foreign key(idHoaDon) references HoaDon(id),
	constraint FK_ChiTietHoaDon_BangSize foreign key(idGiay,sizeGiay) references BangSize(idGiay,sizeGiay),
)
go


create table NhaCungCap
(
	maNCC nvarchar(100) not null,
	tenNhaCungCap nvarchar(100) not null,
	sdt nvarchar(20),
	email nvarchar(200),
	diaChi nvarchar(1000) ,
	website nvarchar(1000),
	trangThai int,
	
	constraint PK_NhaCungCap primary key(maNCC)
)
go


create table HoaDonNhap
(
	id int identity not null,
	idNhanVien nvarchar(100) not null,
	maNCC nvarchar(100),
	ngayNhap datetime,
	tongTien int,
	trangThai int not null, -- 1: xong 0: chưa xong -1: hủy
	
	constraint PK_HoaDonNhap primary key(id),
	constraint FK_HoaDonNhap_NhanVien foreign key(idNhanVien) references NhanVien(idNhanVien),
	constraint FK_HoaDonNhap_NhaCungCap foreign key(maNCC) references NhaCungCap(maNCC),
)
go

create table ChiTietHoaDonNhap
(
	idHoaDonNhap int not null,
	idGiay int,
	sizeGiay nvarchar(20),
	soLuong int not null,
	donGia int not null,
	
	constraint PK_ChiTietHoaDonNhap primary key(idHoaDonNhap,idGiay,sizeGiay),
	constraint FK_ChiTietHoaDonNhap_HoaDonNhap foreign key(idHoaDonNhap) references HoaDonNhap(id),
	constraint FK_ChiTietHoaDonNhap_BangSize foreign key(idGiay,sizeGiay) references BangSize(idGiay,sizeGiay),
)
go

--Them,Xoa,Sua NV
create procedure DangNhap (@idNhanVien nvarchar(100),@matKhau nvarchar(100))
as
	Select * From NhanVien where idNhanVien=@idNhanVien and matKhau = @matKhau and trangThai = 1
go

create procedure ThemNhanVien (@idNhanVien nvarchar(100),@matKhau nvarchar(100),@tenNhanVien nvarchar(100), @cmnd nvarchar(20), @ngaySinh datetime,@sdt nvarchar(20), @diaChi nvarchar(1000), @loaiNhanVien nvarchar(100),@trangThai int)
as
	Insert into NhanVien(idNhanVien,matKhau,tenNhanVien,cmnd,ngaySinh,sdt,diaChi,loaiNhanVien,trangThai) values (@idNhanVien,@matKhau,@tenNhanVien,@cmnd,@ngaySinh,@sdt,@diaChi,@loaiNhanVien,@trangThai)
go

create procedure XoaNhanVien (@idNhanVien nvarchar(100))
as
	Update NhanVien	Set trangThai = 0 where idNhanVien = @idNhanVien
go

create procedure SuaNhanVien (@idNhanVien nvarchar(100),@matKhau nvarchar(100),@tenNhanVien nvarchar(100), @cmnd nvarchar(20), @ngaySinh datetime,@sdt nvarchar(20), @diaChi nvarchar(1000), @loaiNhanVien nvarchar(100),@trangThai int)
as
	Update NhanVien set tenNhanVien=@tenNhanVien ,matKhau = @matKhau, cmnd=@cmnd, ngaySinh=@ngaySinh, sdt=@sdt, diaChi=@diaChi, loaiNhanVien=@loaiNhanVien, trangThai=@trangThai where idNhanVien=@idNhanVien
go
create procedure NhanVienBanGioiNhatThang(@thang int)
as
	Select top 1 SUM(CTHD.soLuong) as 'soLuongSPBanDuoc', NV.idNhanVien,NV.matKhau,NV.tenNhanVien,NV.cmnd,NV.sdt,NV.ngaySinh,NV.diaChi,NV.loaiNhanVien,NV.trangThai From HoaDon as HD, ChiTietHoaDon as CTHD,NhanVien as NV where HD.id = CTHD.idHoaDon and HD.idNhanVien = NV.idNhanVien and MONTH(HD.ngayLap) = @thang and HD.trangThai = 1 and NV.trangThai = 1 Group by NV.idNhanVien,NV.matKhau,NV.tenNhanVien,NV.cmnd,NV.sdt,NV.ngaySinh,NV.diaChi,NV.loaiNhanVien,NV.trangThai Order by 1 Desc
go

--Them,xoa,sua KH
create procedure ThemKhachHang (@sdt nvarchar(20), @tenKhachHang nvarchar(100),@cmnd nvarchar(20),@ngaySinh Datetime,@diaChi nvarchar(1000), @tongChiTieu int,@trangThai int)
as
	Insert into KhachHang(sdt,tenKhachHang,cmnd,ngaySinh,diaChi,tongChiTieu,trangThai) values (@sdt,@tenKhachHang,@cmnd,@ngaySinh,@diaChi,@tongChiTieu,@trangThai)
go

create procedure XoaKhachHang (@sdt nvarchar(20))
as
	Update KhachHang Set trangThai = 0 where sdt = @sdt
go

create procedure SuaKhachHang (@sdt nvarchar(20), @tenKhachHang nvarchar(100),@cmnd nvarchar(20),@ngaySinh Datetime,@diaChi nvarchar(1000), @tongChiTieu int,@trangThai int)
as
	Update KhachHang set tenKhachHang=@tenKhachHang,cmnd=@cmnd,ngaySinh=@ngaySinh,diaChi=@diaChi,tongChiTieu=@tongChiTieu,trangthai=@trangThai where sdt = @sdt
go
create procedure KHThanhToan(@sdt nvarchar(20),@soTien int)
as
Begin
	Declare @tongChiTieu int
	Select @tongChiTieu = tongChiTieu from KhachHang where sdt = @sdt
	Update KhachHang set tongChiTieu = @tongChiTieu+@soTien where sdt = @sdt
end
go
--Them,Xoa Sua NCC
create procedure ThemNCC (@maNCC nvarchar(100),@tenNCC nvarchar(100),@sdt nvarchar(20),@email nvarchar(200),@diaChi nvarchar(1000),@website nvarchar(1000),@trangThai int)
as
	Insert into NhaCungCap(maNCC,tenNhaCungCap,sdt,email,diaChi,website,trangThai) Values (@maNCC,@tenNCC,@sdt,@email,@diaChi,@website,@trangThai)
go

create procedure XoaNCC (@maNCC nvarchar(100))
as
	Update NhaCungCap Set trangThai = 0 where maNCC = @maNCC
go

create procedure SuaNCC(@maNCC nvarchar(100),@tenNCC nvarchar(100),@sdt nvarchar(20),@email nvarchar(200),@diaChi nvarchar(1000),@website nvarchar(1000),@trangThai int)
as
	Update NhaCungCap set tenNhaCungCap = @tenNCC,sdt=@sdt,email=@email,diaChi=@diaChi,website=@website,trangThai = @trangThai where maNCC = @maNCC
go
--Them Xoa Sua Hang Giay
create procedure ThemHangGiay (@tenHang nvarchar(100),@trangThai int)
as
	Insert into HangGiay(tenHang,trangThai) values (@tenHang,@trangThai)
go

create procedure XoaHangGiay (@id int)
as
	Update HangGiay Set trangThai = 0 where id = @id
go
create procedure SuaHangGiay (@id int,@tenHang nvarchar(100),@trangThai int)
as
	Update HangGiay Set tenHang = @tenHang, trangThai = @trangThai where id = @id
go
--Them Xoa Sua Loai Giay

create procedure ThemLoaiGiay (@tenLoaiGiay nvarchar(100),@idHang int ,@trangThai int)
as
	Insert into LoaiGiay(tenLoaiGiay,idHang,trangThai) values (@tenLoaiGiay,@idHang,@trangThai)
go

create procedure XoaLoaiGiay (@id int)
as
	Update LoaiGiay Set trangThai = 0 where id = @id
go
create procedure SuaLoaiGiay (@id int,@tenLoaiGiay nvarchar(100),@trangThai int)
as
	Update LoaiGiay Set tenLoaiGiay =@tenLoaiGiay,trangThai = @trangThai  where id = @id
go

--Them Xoa Sua Giay
create procedure ThemGiay (@tenGiay nvarchar(100),@idHang int ,@idLoai int,@giamGia int, @hinhAnh nvarchar(1000),@trangThai int)
as
	Insert into Giay(tenGiay,idHangGiay,idLoaiGiay,giamGia,hinhAnh,trangThai) values (@tenGiay,@idHang,@idLoai,@giamGia,@hinhAnh,@trangThai)
go
create procedure XoaGiay (@id int)
as
	Update Giay Set trangThai = 0 where id = @id
go
create procedure SuaGiay (@id int,@tenGiay nvarchar(100),@idHang int ,@idLoai int,@giamGia int, @hinhAnh nvarchar(1000),@trangThai int)
as
	Update Giay Set tenGiay =@tenGiay,idHangGiay = @idHang,idLoaiGiay=@idLoai,giamGia=@giamGia,hinhAnh=@hinhAnh,trangThai = @trangThai  where id = @id
go
create procedure TimSPBanChayTheoThang(@thang int)
as
	Select Top 1 Sum(CTHD.soLuong) as 'soLuong',G.id,G.tenGiay,G.idHangGiay,G.idLoaiGiay,G.giamGia,G.hinhAnh,G.trangThai From HoaDon as HD,ChiTietHoaDon as CTHD,Giay as G Where HD.id = CTHD.idHoaDon and CTHD.idGiay=G.id and HD.trangThai = 1 and MONTH(HD.ngayLap) = @thang Group By G.id,G.tenGiay,G.idHangGiay,G.idLoaiGiay,G.giamGia,G.hinhAnh,G.trangThai Order by 1 Desc
go

create procedure SLGiayDaBanTheoNgay(@idGiay int,@sizeGiay nvarchar(20),@ngayBatDau datetime,@ngayKetThuc datetime)
as
	Select SUM(CTHD.soLuong) as 'soLuongDaBan' from HoaDon as HD,ChiTietHoaDon as CTHD where HD.id = CTHD.idHoaDon and HD.ngayLap>=@ngayBatDau and HD.ngayLap<=@ngayKetThuc and CTHD.idGiay = @idGiay and CTHD.sizeGiay = @sizeGiay
go
--Them Xoa Sua BangSize
create procedure ThemSize (@idGiay int,@sizeGiay nvarchar(20),@giaBan int , @giaNhap int, @soLuong int, @trangThai int)
as
	Insert into BangSize(idGiay,sizeGiay,giaBan,giaNhap,soLuong,trangThai) values (@idGiay,@sizeGiay,@giaBan,@giaNhap,@soLuong,@trangThai)
go
create procedure XoaSize (@idGiay int,@sizeGiay nvarchar(20))
as
	Update BangSize Set trangThai = 0 where idGiay = @idGiay and sizeGiay = @sizeGiay
go
create procedure SuaSize (@idGiay int,@sizeGiay nvarchar(20),@giaBan int , @giaNhap int, @soLuong int, @trangThai int)
as
	Update BangSize Set giaBan = @giaBan,giaNhap = @giaNhap,soLuong = @soLuong,trangThai = @trangThai where idGiay = @idGiay and sizeGiay = @sizeGiay
go

create procedure CapNhatSoLuongDaBan(@idgiay int, @sizeGiay nvarchar(20),@soLuongDaBan int)
as
Begin
	Declare @soLuongCu int
	select @soLuongCu = soLuong from BangSize where idGiay = @idgiay and sizeGiay = @sizeGiay
	Declare @soLuongMoi int = @soLuongCu - @soLuongDaBan
	Update BangSize set soLuong = @soLuongMoi where idGiay = @idgiay and sizeGiay = @sizeGiay
end	
go

create procedure CapNhatKho(@idgiay int, @sizeGiay nvarchar(20),@soLuongDaNhap int,@giaNhap int)
as
Begin
	Declare @soLuongCu int
	Declare @giaNhapCu int
	select @soLuongCu = soLuong,@giaNhapCu = giaNhap from BangSize where idGiay = @idgiay and sizeGiay = @sizeGiay
	Declare @soLuongMoi int = @soLuongCu + @soLuongDaNhap
	Declare @giaNhapMoi int = ((@giaNhapCu * @soLuongCu) + (@giaNhap * @soLuongDaNhap)) / @soLuongMoi
	Update BangSize set soLuong = @soLuongMoi,giaNhap=@giaNhapMoi where idGiay = @idgiay and sizeGiay = @sizeGiay
end	
go

--Them HD
create procedure ThemHoaDon (@idNhanVien nvarchar(100),@sdtKhachHang nvarchar(20),@ngayLap DateTime,@tongTien int,@giamGia int,@thanhToan int,@trangThai int)
as
	Insert into HoaDon(idNhanVien,sdtKhachHang,ngayLap,tongTien,giamGia,thanhToan,trangThai) Values(@idNhanVien,@sdtKhachHang,@ngayLap,@tongTien,@giamGia,@thanhToan,@trangThai)
go
create procedure CapNhapTien (@idHoaDon int,@tongTien int,@giamGia int,@thanhToan int)
as
	Update HoaDon set tongTien = @tongTien,giamGia=@giamGia,thanhToan=@thanhToan where id=@idHoaDon
go
create procedure ThanhToanHD(@idHoaDon int,@tongTien int,@giamGia int,@thanhToan int)
as
	Update HoaDon set tongTien = @tongTien,giamGia=@giamGia,thanhToan=@thanhToan,trangThai = 1 where id = @idHoaDon
go
create procedure HuyHD(@idHoaDon int,@tongTien int,@giamGia int,@thanhToan int)
as
	Update HoaDon set tongTien = @tongTien,giamGia=@giamGia,thanhToan=@thanhToan,trangThai = -1 where id = @idHoaDon
go
CREATE PROCEDURE TongDoanhThuTheoThang(@thang int)
as
	Select SUM(HD.tongTien) as 'TongDoanhThu' From HoaDon as HD where HD.trangThai = 1 and MONTH(HD.ngayLap) = @thang
go
--Them CTHD

create procedure ThemCTHD (@idHoaDon int,@idGiay int,@sizeGiay nvarchar(20),@soLuong int)
as
Begin	
	Declare @KTTonTai int
	Declare @soLuongCu int
	
	Select @KTTonTai = COUNT(*),@soLuongCu = soLuong From ChiTietHoaDon Where idHoaDon=@idHoaDon and idGiay = @idGiay and sizeGiay = @sizeGiay Group by idHoaDon,idGiay,sizeGiay,soLuong
	
	If(@KTTonTai > 0)
	Begin
		Declare @soLuongMoi int = @soLuongCu + @soLuong
		If(@soLuongMoi > 0)
			Update ChiTietHoaDon Set soLuong = @soLuongMoi where idHoaDon = @idHoaDon and idGiay = @idGiay and sizeGiay = @sizeGiay
		Else
			Delete ChiTietHoaDon where idHoaDon = @idHoaDon and idGiay = @idGiay and sizeGiay = @sizeGiay		
	End
	Else
	Begin
		If(@soLuong>0)
		Begin
		Insert into ChiTietHoaDon(idHoaDon,idGiay,sizeGiay,soLuong)Values(@idHoaDon,@idGiay,@sizeGiay,@soLuong)
		end
	End
end
go
--HD Nhập 
create procedure ThemHoaDonNhap (@idNhanVien nvarchar(100),@maNCC nvarchar(100),@ngayNhap DateTime,@tongTien int,@trangThai int)
as
	Insert into HoaDonNhap(idNhanVien,maNCC,ngayNhap,tongTien,trangThai) Values(@idNhanVien,@maNCC,@ngayNhap,@tongTien,@trangThai)
go
create procedure CapNhapTienHDNhap (@idHoaDonNhap int,@tongTien int)
as
	Update HoaDonNhap set tongTien = @tongTien where id=@idHoaDonNhap
go
create procedure ThanhToanHDNhap(@idHoaDonNhap int,@tongTien int)
as
	Update HoaDonNhap set tongTien = @tongTien,trangThai = 1 where id = @idHoaDonNhap
go
create procedure HuyHDNhap(@idHoaDonNhap int,@tongTien int)
as
	Update HoaDonNhap set tongTien = @tongTien,trangThai = -1 where id = @idHoaDonNhap
go
create procedure SoLanNhapTheoThang(@thang int)
as
	Select COUNT(HDN.id) as 'soLanNhapTrongThang' from HoaDonNhap as HDN where HDN.trangThai = 1 and MONTH(HDN.ngayNhap) = @thang
go
--Them CTHD Nhap
create procedure ThemCTHDNhap (@idHoaDonNhap int,@idGiay int,@sizeGiay nvarchar(20),@soLuong int,@donGia int)
as
Begin	
	Declare @KTTonTai int
	Declare @soLuongCu int
	
	Select @KTTonTai = COUNT(*),@soLuongCu = soLuong From ChiTietHoaDonNhap Where idHoaDonNhap=@idHoaDonNhap and idGiay = @idGiay and sizeGiay = @sizeGiay Group by idHoaDonNhap,idGiay,sizeGiay,soLuong,donGia
	
	If(@KTTonTai > 0)
	Begin
		Declare @soLuongMoi int = @soLuongCu + @soLuong
		If(@soLuongMoi > 0)
			Update ChiTietHoaDonNhap Set soLuong = @soLuongMoi,donGia=@donGia where idHoaDonNhap = @idHoaDonNhap and idGiay = @idGiay and sizeGiay = @sizeGiay
		Else
			Delete ChiTietHoaDonNhap where idHoaDonNhap = @idHoaDonNhap and idGiay = @idGiay and sizeGiay = @sizeGiay
	End
	Else
	Begin
		If(@soLuong>0)
		Begin
		Insert into ChiTietHoaDonNhap(idHoaDonNhap,idGiay,sizeGiay,soLuong,donGia)Values(@idHoaDonNhap,@idGiay,@sizeGiay,@soLuong,@donGia)
		end
	End
end
go


