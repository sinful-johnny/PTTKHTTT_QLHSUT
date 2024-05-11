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
    class DAO_DSViTriUngTuyen
    {
        static public List<BUS_DSVITRIUNGTUYEN> getDSVITRIUNGTUYEN(SqlConnection conn)
        {
            var result = new List<BUS_DSVITRIUNGTUYEN>();
            string query = """
                SELECT * FROM VITRIUNGTUYEN;
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var record = new BUS_DSVITRIUNGTUYEN();
                        record.ID_VITRIUNGTUYEN = (string)reader["ID_VITRIUNGTUYEN"];
                        record.TENVITRI = reader["TENVITRI"] != DBNull.Value ? (string)reader["TENVITRI"] : null;
                        record.TINHTRANG_UNGTUYEN = reader["TINHTRANG_UNGTUYEN"] != DBNull.Value ? (string)reader["TINHTRANG_UNGTUYEN"] : null;
                        record.SOLUONG_TUYENDUNG = reader["SOLUONG_TUYENDUNG"] != DBNull.Value ? (int)reader["SOLUONG_TUYENDUNG"] : null;
                        record.YEUCAU_UNGVIEN = reader["YEUCAU_UNGVIEN"] != DBNull.Value ? (string)reader["YEUCAU_UNGVIEN"] : null;
                        record.ID_HD_DANGTUYEN = reader["ID_HD_DANGTUYEN"] != DBNull.Value ? (string)reader["ID_HD_DANGTUYEN"] : null;

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
