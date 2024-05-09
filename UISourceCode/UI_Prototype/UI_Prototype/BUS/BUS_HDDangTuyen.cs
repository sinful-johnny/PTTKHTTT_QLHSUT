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
    public class BUS_HDDangTuyen : INotifyPropertyChanged
    {
        public string? IDDoanhNghiep { get; set; }
        public string? IDHDDangTuyen { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string? HinhThucDangTuyen { get; set; }
        public string? TinhTrangDangTuyen { get; set; }
        public string? HinhThucThanhToan { get; set; }
        public DateTime NgayLap { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        static public List<BUS_HDDangTuyen> LoadHDTuyenDung(SqlConnection conn, string IDDoanhNghiep)
        {
            return DAO_HDDangTuyen.getHDDangTuyen(conn, IDDoanhNghiep);
        }
    }
}
