use QLCuaHangTapHoa
select convert(varchar, getdate(), 105)

delete from HoaDon where MaHD = 'HD001'
delete from NhapKho where MaSP = 1

alter table NhapKho
alter column GiaBan int

Insert into TaiKhoan(TenTK,MatKhau,MaNV)
values('hidan','1','QL002')

alter table NhapKho 
alter column GiaNhap int


Insert into NhanVien(MaNV,TenNV,GioiTinh,NgaySinh,DiaChi,SDT,CCCD,Email,MaCV)
values(N'QL002',N'Phạm Anh Hào',N'Nam','2002-09-17',N'phường Xuân Khánh,Ninh Kiều,Cần Thơ',0930664293,364231041,N'phamanhhao1412@gmail.com',1)