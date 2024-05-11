using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.DAO;
using System.Data.SqlClient;

namespace UI_Prototype.BUS
{
    class BUS_DSVITRIUNGTUYEN
    {
        public string? ID_VITRIUNGTUYEN { get; set; }
        public string? TENVITRI { get; set; }
        public string? TINHTRANG_UNGTUYEN { get; set; }
        public int? SOLUONG_TUYENDUNG { get; set; }
        public string? YEUCAU_UNGVIEN { get; set; }
        public string? ID_HD_DANGTUYEN { get; set; }

        static public List<BUS_DSVITRIUNGTUYEN> LoadData(SqlConnection conn)
        {
            return DAO_DSViTriUngTuyen.getDSVITRIUNGTUYEN(conn);
        }

    }
}
