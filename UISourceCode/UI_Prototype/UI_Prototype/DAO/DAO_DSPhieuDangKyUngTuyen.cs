using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.BUS;
using System.Data.SqlClient;

namespace UI_Prototype.DAO
{
     class DAO_DSPhieuDangKyUngTuyen
    {
        static public List<BUS_DSPhieuDangKyUngTuyen> getHoSoDaNop(SqlConnection conn, string idUV)
        {
            var result = new List<BUS_DSPhieuDangKyUngTuyen>();
            string query = """
                SELECT * FROM PHIEUDANGKI_UNGTUYEN WHERE ID_UNGVIEN = @idUV;
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@idUV", idUV);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var record = new BUS_DSPhieuDangKyUngTuyen();
                        record.ID_UNGVIEN = (string)reader["ID_UNGVIEN"];
                        record.ID_VITRIUNGTUYEN = reader["ID_VITRIUNGTUYEN"] != DBNull.Value ? (string)reader["ID_VITRIUNGTUYEN"] : null;
                        record.VITRI_UNGTUYEN = reader["VITRI_UNGTUYEN"] != DBNull.Value ? (string)reader["VITRI_UNGTUYEN"] : null;
                        record.DOUUTIEN = reader["DOUUTIEN"] != DBNull.Value ? (int)reader["DOUUTIEN"] : null;
                        record.TINHTRANG_DUYET = reader["TINHTRANG_DUYET"] != DBNull.Value ? (string)reader["TINHTRANG_DUYET"] : null;
                        record.TINHTRANG_PHANHOI = reader["TINHTRANG_PHANHOI"] != DBNull.Value ? (string)reader["TINHTRANG_PHANHOI"] : null;
                        record.NGAYTIEPNHAN = reader["NGAYTIEPNHAN"] != DBNull.Value ? (DateTime)reader["NGAYTIEPNHAN"] : null;
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
