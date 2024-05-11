using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.DAO;
using System.Data.SqlClient;

namespace UI_Prototype.BUS
{
    class BUS_UngVienDangKyTuyenDung
    {
        public string? ID_UNGVIEN { get; set; }
        public string? HOTEN { get; set; }
        public DateTime? NGAYSINH { get; set; }
        public string? DIACHI { get; set; }
        public string? SDT { get; set; }
        public string? EMAIL { get; set; }
        public string? CCCD { get; set; }
        static public void DangKiUngVien(SqlConnection connection, BUS_UngVienDangKyTuyenDung dataUngvien)
        {
            DAO_UngVienDangKyTuyenDung.DangKiUngVien(connection, dataUngvien);
        }
    }
}
