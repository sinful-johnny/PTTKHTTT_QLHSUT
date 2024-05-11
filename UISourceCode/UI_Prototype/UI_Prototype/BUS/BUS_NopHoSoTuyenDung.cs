using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UI_Prototype.DAO;

namespace UI_Prototype.BUS
{
     class BUS_NopHoSoTuyenDung
    {
        public string? ID_UNGVIEN { get; set; }
        public string? ID_VITRIUNGTUYEN { get; set; }
        public string? TEN_CHUNGTU { get; set; }
        public string? TEN_BANGCAP { get; set; }
        static public void NopHoSo(SqlConnection connection, BUS_NopHoSoTuyenDung dataUngvien)
        {
            DAO_NopHoSoTuyenDung.NopHoSo(connection, dataUngvien);
            ChungTuBangCap(connection, dataUngvien);
        }
        static public void ChungTuBangCap(SqlConnection connection, BUS_NopHoSoTuyenDung dataUngvien)
        {
             DAO_NopHoSoTuyenDung.ChungTuBangCap(connection, dataUngvien);
        }
    }
}
