﻿CREATE DATABASE QuanLyCaPhe
GO

USE QuanLyCaPhe
GO

-- Ban
-- NhanVien
-- DanhSach
-- ThucDon
-- HoaDon



CREATE TABLE NhanVien
(
	idNV CHAR(10) PRIMARY KEY,
	TenNV NVARCHAR(50) NOT NULL,
	GioiTinh NVARCHAR(5) NOT NULL,
	NgaySinh DATE NOT NULL,
	QueQuan NVARCHAR(50) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	Email CHAR(50) NOT NULL,
	SDT CHAR(10) NOT NULL,
)
GO

CREATE TABLE DanhSach
(
	idDanhSach CHAR(10) PRIMARY KEY,
	TenThucDon NVARCHAR(100) NOT NULL,
)
GO

CREATE TABLE ThucDon
(
	idThucDon CHAR(10) PRIMARY KEY,
	TenThucDon NVARCHAR(100) NOT NULL,
	GiaTien NVARCHAR(100) NOT NULL,
	
	FOREIGN KEY (idThucDon) REFERENCES dbo.DanhSach(idDanhSach)
)
GO

CREATE TABLE HoaDon
(
	idHoaDon CHAR(10) PRIMARY KEY,
	TenBan NVARCHAR(100) NOT NULL,
	TenThucDon NVARCHAR(100) NOT NULL,
	ThoiDiemDen DATE NOT NULL DEFAULT GETDATE(),
	ThoiDiemRa DATE,
	TrangThai NVARCHAR(50) NOT NULL,

	FOREIGN KEY (idHoaDon) REFERENCES dbo.ThucDon(idThucDon)
)

CREATE TABLE Ban
(
	idBan CHAR(10) PRIMARY KEY,
	TenBan NVARCHAR(100) NOT NULL,
	TrangThai NVARCHAR(100) NOT NULL,
	FOREIGN KEY (idBan) REFERENCES dbo.HoaDon(idHoaDon)
)
GO