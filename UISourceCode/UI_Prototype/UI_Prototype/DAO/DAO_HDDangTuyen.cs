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
    class DAO_HDDangTuyen
    {
        static public List<BUS_HDDangTuyen> getHDDangTuyen(SqlConnection conn, string IDDoanhNghiep)
        {
            var result = new List<BUS_HDDangTuyen>();
            string query = """
                    SELECT * FROM HOPDONG_DANGTUYEN where ID_DOANHNGHIEP = @id;
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = IDDoanhNghiep;


                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var record = new BUS_HDDangTuyen();
                        record.IDDoanhNghiep = (string)reader["ID_DOANHNGHIEP"];
                        record.IDHDDangTuyen = (string)reader["ID_HD_DANGTUYEN"];
                        record.NgayBatDau = reader["NGAYBATDAU"] != DBNull.Value ? (DateTime)reader["NGAYBATDAU"] : new DateTime();
                        record.NgayKetThuc = reader["NGAYKETTHUC"] != DBNull.Value ? (DateTime)reader["NGAYKETTHUC"] : new DateTime();
                        record.HinhThucDangTuyen = reader["HINHTHUCDANGTUYEN"] != DBNull.Value ? (string)reader["HINHTHUCDANGTUYEN"] : null;
                        record.TinhTrangDangTuyen = reader["TINHTRANG_DANGTUYEN"] != DBNull.Value ? (string)reader["TINHTRANG_DANGTUYEN"] : null;
                        record.HinhThucThanhToan = reader["HINHTHUC_THANHTOAN"] != DBNull.Value ? (string)reader["HINHTHUC_THANHTOAN"] : null;
                        record.NgayLap = reader["NGAYLAP"] != DBNull.Value ? (DateTime)reader["NGAYLAP"] : new DateTime();
                        
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
