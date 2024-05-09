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
    class DAO_ViTriTuyenDung
    {
        static public List<BUS_ViTriTuyenDung> getViTriTuyenDung(SqlConnection conn, string IDHD)
        {
            var result = new List<BUS_ViTriTuyenDung>();
            string query = """
                SELECT * FROM VITRIUNGTUYEN where ID_HD_DANGTUYEN = @id;
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@id",SqlDbType.VarChar).Value = IDHD;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var record = new BUS_ViTriTuyenDung();
                        record.IDViTriUngTuyen = (string)reader["ID_VITRIUNGTUYEN"];
                        record.TenViTri = reader["TENVITRI"] != DBNull.Value ? (string)reader["TENVITRI"] : null;
                        record.TinhTrangUngTuyen = reader["TINHTRANG_UNGTUYEN"] != DBNull.Value ? (string)reader["TINHTRANG_UNGTUYEN"] : null;
                        record.SoLuongTuyen = reader["SOLUONG_TUYENDUNG"] != DBNull.Value ? (int)reader["SOLUONG_TUYENDUNG"] : 0;
                        record.YeuCauUngVien = reader["YEUCAU_UNGVIEN"] != DBNull.Value ? (string)reader["YEUCAU_UNGVIEN"] : null;
                        record.IDHDDangTuyen = reader["ID_HD_DANGTUYEN"] != DBNull.Value ? (string)reader["ID_HD_DANGTUYEN"] : null;

                        result.Add(record);
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
