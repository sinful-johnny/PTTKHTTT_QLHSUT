using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.DAO;

namespace UI_Prototype.BUS
{
    internal class BUS_HoaDon : INotifyPropertyChanged
    {
        public string? IDHDDangTuyen { get; set; }
        public int TongSoTien { get; set; }
        public int SoTienCanTra { get; set; }

        public int SoTienDaTra { get; set; }
        public DateTime? NgayLap { get; set; }
        public int SoLanThanhToan { get; set; }
        public int DotThanhToan { get; set; }
        public string? TinhTrangThanhToan { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        static public BUS_HoaDon? LoadHoaDon(SqlConnection conn, BUS_HDDangTuyen? tthd)
        {
            BUS_HoaDon? result = null;

            try
            {
                if (tthd == null)
                {
                    throw new Exception("Chưa có thông tin hợp đồng!");
                }
                else if (tthd.IDHDDangTuyen != null)
                {
                    result = DAO_HoaDon.getHoaDon(conn, tthd.IDHDDangTuyen);
                }
                else if (tthd.IDHDDangTuyen == null)
                {
                    throw new Exception("Thông tin hợp đồng đăng tuyển trống!");
                }
            }catch
            {
                throw;
            }

            return result;
        }

        static public bool TaoHoaDon(SqlConnection conn, string IDHDDangTuyen, int soTienCanTra)
        {
            bool result = true;

            try
            {
                result = DAO_HoaDon.createHoaDon(conn, IDHDDangTuyen, soTienCanTra);
            }catch (Exception ex)
            {
                throw new Exception(ex.ToString(),ex);
            }

            return result;
        }

        static public bool ThanhToanHoaDon(SqlConnection conn, BUS_HoaDon hoaDon, BUS_HDDangTuyen hDDangTuyen)
        {
            bool result = true;

            if(hoaDon.TinhTrangThanhToan == "Da thanh toan")
            {
                throw new Exception("Không thể thanh toán hoá đơn đã được thanh toán xong!");
            }

            if(hoaDon.SoTienCanTra < hoaDon.SoTienDaTra)
            {
                throw new Exception("Số tiền đã trả lớn hơn số tiền cần trả!");
            }

            hoaDon.SoTienCanTra -= hoaDon.SoTienDaTra;

            if(hoaDon.SoTienCanTra == 0)
            {
                hoaDon.TinhTrangThanhToan = "Da thanh toan";
            }else if(hoaDon.SoTienCanTra > 0)
            {
                hoaDon.TinhTrangThanhToan = "Chua thanh toan xong";
            }

            if(hDDangTuyen.HinhThucThanhToan == "Thanh toan nhieu lan" && hoaDon.SoTienDaTra < (hoaDon.TongSoTien * 30 / 100))
            {
                throw new Exception("Số tiền đã trả không được nhỏ hơn 30% tổng giá trị hợp đồng!");
            }else if (hDDangTuyen.HinhThucThanhToan == "Thanh toan mot lan" && hoaDon.SoTienDaTra < hoaDon.TongSoTien)
            {
                throw new Exception("Chưa đủ số tiền thanh toán một lần!");
            }

            TimeSpan? v = (DateTime.Now - hoaDon.NgayLap);
            if (v != null)
            {
                TimeSpan interval = (TimeSpan)v;
                if (interval.Days > 10)
                {
                    throw new Exception("Đã quá hạn 10 ngày thanh toán!");
                }
            }

            try
            {
                result = DAO_HoaDon.ThanhToanHoaDon(conn, hoaDon);
                if (result == false)
                {
                    return false;
                }
                else
                {
                    result = DAO_HoaDon.updateHoaDon(conn, hoaDon);
                }
            }catch
            {
                throw;
            }

            return result;
        }
    }
}
