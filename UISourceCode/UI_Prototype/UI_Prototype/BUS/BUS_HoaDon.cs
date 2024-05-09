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
        public string? IDHoaDon { get; set; }
        public string? IDHDDangTuyen { get; set; }
        public int SoTienCanTra { get; set; }
        public DateTime? NgayLap { get; set; }
        public int SoLanThanhToan { get; set; }
        public int DotThanhToan { get; set; }
        public string? TinhTrangThanhToan { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        static public BUS_HoaDon? LoadHoaDon(SqlConnection conn, string IDHDDangTuyen)
        {
            BUS_HoaDon? result = null;

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
    }
}
