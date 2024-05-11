using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.DAO;
using System.Data.SqlClient;

namespace UI_Prototype.BUS
{
     class BUS_DSPhieuDangKyUngTuyen
    {
        public string? ID_UNGVIEN { get; set; }
        public string? ID_VITRIUNGTUYEN { get; set; }
        public string? VITRI_UNGTUYEN { get; set; }
        public int? DOUUTIEN { get; set; }
        public string? TINHTRANG_DUYET { get; set; }
        public string? TINHTRANG_PHANHOI { get; set; }

        public DateTime? NGAYTIEPNHAN {  get; set; }
        static public List<BUS_DSPhieuDangKyUngTuyen> HoSoDaNop(SqlConnection conn, string idUV)
        {
            return DAO_DSPhieuDangKyUngTuyen.getHoSoDaNop(conn, idUV);
        }
    }
}
