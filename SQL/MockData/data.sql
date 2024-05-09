use QLHSUT
go

--DS_DOANH_NGHIEP
INSERT INTO DS_DOANHNGHIEP(ID_DOANHNGHIEP, TEN_CONGTY, NGUOIDAIDIEN, DIACHI, EMAIL, TINHTRANG_XACTHUC, TIEMNANG_DN)
VALUES
  ('DN001', N'TẬP ĐOÀN XĂNG DẦU VIỆT NAM', N'Nguyễn Gia Khánh', N'95 Ngô Gia Tự', 'nguyengiakhanh@gmail.com', null, null),
  ('DN002', N'CÔNG TY CỔ PHẦN TẬP ĐOÀN HÒA PHÁT', N'Lê Quang Dài', N'99 Lê Văn Sỹ', 'lequangdai@gmail.com', null, null),
  ('DN003', N'TẬP ĐOÀN VINGROUP - CTCP', N'Nguyễn Hi Hữu', N'74/35 Cao Thắng', 'nguyenhihuu@gmail.com', null, null),
  ('DN004', N'TỔNG CÔNG TY KHÍ VIỆT NAM', N'Trần Hoàng Duy', N'45 Hồng Bàng', 'tranhoangduy@gmail.com', null, null),
  ('DN005', N'NGÂN HÀNG TMCP QUÂN ĐỘI', N'Phạm Nhật Vượng', N'666 Trường Chinh', 'phamnhatvuong@gmail.com', null, null),
  ('DN006', N'CÔNG TY CỔ PHẦN TẬP ĐOÀN THÀNH CÔNG', N'Lê Bảo Châu', N'35 Lý Chính Thắng', 'lebaochau@gmail.com', null, null),
  ('DN007', N'NGÂN HÀNG TMCP Á CHÂU', N'Nguyễn Bá Khá', N'43 Lý Thường Kiệt', 'nguyenbakha@gmail.com', null, null),
  ('DN008', N'NGÂN HÀNG TMCP ĐÔNG NAM Á', N'JassMin', N'12 Thành Thái', 'jassmin@gmail.com', null, null),
  ('DN009', N'CÔNG TY TNHH HÀO HƯNG', N'Kyle Ken', N'10 Ngô Thời Nhiệm', 'kyleken@gmail.com', null, null),
  ('DN010', N'CÔNG TY CỔ PHẦN PVI', N'Nguyễn Huỳnh Phúc', N'30 3 tháng 2', 'nguyenhuynhphuc@gmail.com', null, null);


--CHINHSACH_UUDAI
INSERT INTO CHINHSACH_UUDAI(ID_CHINHSACH, TEN_CHINHSACH, NOIDUNG, NGAYBATDAU, NGAYKETTHUC, TINHTRANG_SUDUNG, ID_DOANHNGHIEP)
VALUES
  ('CS001', N'Ưu đãi về thuế suất', N'Áp dụng thuế suất thấp hơn mức thuế suất thuế TNDN phổ thông trong một thời hạn nhất định hoặc cho cả vòng đời của dự án đầu tư', 
  '01/02/2022','04/05/2022', 'Chưa sử dụng', null),
  ('CS002', N'Ưu đãi về thời gian được miễn thuế, giảm thuế', N'Miễn, giảm nghĩa vụ thuế TNDN có thời hạn',
  '01/02/2022','04/05/2022', 'Chưa sử dụng', null),
  ('CS003', N'Giảm trừ thu nhập chịu thuế TNDN trên cơ sở mức vốn đầu tư của dự án', N'Nhà đầu tư được giảm trừ vào thu nhập chịu thuế TNDN một tỷ lệ nhất định số vốn đầu tư thực hiện',
  '01/02/2022','04/05/2022', 'Chưa sử dụng', null),
  ('CS004', N'Giảm trừ trực tiếp nghĩa vụ thuế TNDN', N'Nhà đầu tư được giảm trừ trực tiếp vào nghĩa vụ thuế TNDN phải nộp một số tiền nhất định được xác định trước', 
  '01/02/2022','04/05/2022', 'Chưa sử dụng', null),
  ('CS005', N'Cho phép áp dụng cơ chế khấu hao nhanh', N'Áp dụng cơ chế khấu hao nhanh', 
  '01/02/2022','04/05/2022', 'Chưa sử dụng', null);

INSERT INTO HOSO_UNGVIEN(ID_UNGVIEN, HOTEN, NGAYSINH, DIACHI, SDT, EMAIL, CCCD)
VALUES
  ('UV001', 'Kerry', 'Nov 13 1994', 'Suite 829', '660-906-5951', 'Kerry.Boyle-Schuster@yahoo.com', '077203045754'),
  ('UV002', 'Vera', 'Sep 24 1984', 'Apt. 203', '765-750-5674', 'Vera.Schimmel@gmail.com', '077203045345'),
  ('UV003', 'Rickey', 'Feb 20 1974', 'Apt. 210', '454-522-2453', 'Rickey_Beahan@yahoo.com', '077203045234'),
  ('UV004', 'Debbie', 'Jul 29 1974', 'Apt. 995', '218-264-2025', 'Debbie_Christiansen@hotmail.com', '077203045678'),
  ('UV005', 'Joseph', 'Jul 30 1985', 'Suite 233', '808-497-2934', 'Jo5@yahoo.com', '077203043452'),
  ('UV006', 'Wesley', 'Sep 24 1985', 'Apt. 440', '400-444-7293', 'Wesley_Yundt93@gmail.com', '077203043467'),
  ('UV007', 'Christian', 'Jun 01 1993', 'Apt. 742', '913-026-5927', 'Christian59@gmail.com', '077203128737'),
  ('UV008', 'Armando', 'Apr 05 2001', 'Apt. 945', '607-808-1550', 'Armando.Jakubowski@gmail.com', '077203043429');
go