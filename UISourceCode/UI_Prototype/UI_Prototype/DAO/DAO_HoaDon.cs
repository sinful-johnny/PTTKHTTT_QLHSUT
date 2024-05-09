using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.BUS;

namespace UI_Prototype.DAO
{
    internal class DAO_HoaDon
    {
        static public bool createHoaDon(SqlConnection conn, string IDHDDangTuyen, int soTienCanTra)
        {
            bool result = true;

            string query = """
                    INSERT INTO HOADON (ID_HOADON,ID_HD_DANGTUYEN,NGAYLAP,SOTIENCANTRA,SOTIENDATRA,SOLAN_THANHTOAN,DOT_THANHTOAN,TINHTRANG_THANHTOAN)
                    VALUES (CONVERT(varchar(255), NEWID()),@idhddangtuyen,@ngaylap,@sotiencantra,0,0,0,'Chua thanh toan');
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idhddangtuyen", SqlDbType.VarChar).Value = IDHDDangTuyen;
                    cmd.Parameters.Add("@ngaylap", SqlDbType.Date).Value = DateTime.Now;
                    cmd.Parameters.Add("@sotiencantra", SqlDbType.Int).Value = soTienCanTra;

                    var count = cmd.ExecuteNonQuery();
                    if (count <= 0)
                    {
                        result = false;
                    }

                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw new Exception(ex.ToString());
                }
            }
            conn.Close();

            return result;
        }
    }
}
