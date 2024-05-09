using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI_Prototype.DAO;

namespace UI_Prototype.BUS
{
    public class BUS_HDDangTuyen : INotifyPropertyChanged, ICloneable
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

        public object Clone()
        {
            return MemberwiseClone();
        }

        static public bool createHDDangTuyen(SqlConnection conn, BUS_HDDangTuyen data)
        {
            bool result = false;
            if(data != null)
            {
                if (data.NgayBatDau > data.NgayKetThuc)
                {
                    result = false;
                    throw new Exception("Ngày bắt đầu không được ở sau ngày kết thúc!");
                }
                else if (data.NgayBatDau < data.NgayLap)
                {
                    result = false;
                    throw new Exception("Ngày bắt đầu không được ở trước ngày lập hợp đồng!");
                }
                else
                {
                    result = DAO_HDDangTuyen.createHDDangTuyen(conn, data);
                }
            }
            return result;
        }

        static public bool updateHDDangTuyen(SqlConnection conn, BUS_HDDangTuyen data)
        {
            return DAO_HDDangTuyen.updateHDDangTuyen(conn, data);
        }
    }
}
