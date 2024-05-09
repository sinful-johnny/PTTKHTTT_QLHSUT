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

        static public bool createHDDangTuyen(SqlConnection conn, BUS_HDDangTuyen data)
        {
            bool result = true;

            string query = """
                    INSERT INTO HOPDONG_DANGTUYEN (ID_HD_DANGTUYEN,ID_DOANHNGHIEP,NGAYBATDAU,NGAYKETTHUC,HINHTHUCDANGTUYEN,TINHTRANG_DANGTUYEN,HINHTHUC_THANHTOAN,NGAYLAP)
                    VALUES (@idhddangtuyen,@iddoanhnghiep,@ngaybatdau,@ngayketthuc,@hinhthucdangtuyen,@tinhtrangdangtuyen,@hinhthucthanhtoan,@ngaylap);
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idhddangtuyen", SqlDbType.VarChar).Value = data.IDHDDangTuyen;
                    cmd.Parameters.Add("@iddoanhnghiep", SqlDbType.VarChar).Value = data.IDDoanhNghiep;
                    cmd.Parameters.Add("@ngaybatdau", SqlDbType.Date).Value = data.NgayBatDau;
                    cmd.Parameters.Add("@ngayketthuc", SqlDbType.Date).Value = data.NgayKetThuc;
                    cmd.Parameters.Add("@hinhthucdangtuyen", SqlDbType.NVarChar).Value = data.HinhThucDangTuyen;
                    cmd.Parameters.Add("@tinhtrangdangtuyen", SqlDbType.NVarChar).Value = data.TinhTrangDangTuyen;
                    cmd.Parameters.Add("@hinhthucthanhtoan", SqlDbType.NVarChar).Value = data.HinhThucThanhToan;
                    cmd.Parameters.Add("@ngaylap", SqlDbType.Date).Value = data.NgayLap;

                    var count = cmd.ExecuteNonQuery();
                    if(count <= 0)
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
        static public bool updateHDDangTuyen(SqlConnection conn, BUS_HDDangTuyen data)
        {
            var result = true;
            string query = """
                    UPDATE HOPDONG_DANGTUYEN set    NGAYBATDAU = @ngaybatdau,
                                                    NGAYKETTHUC = @ngayketthuc,
                                                    HINHTHUCDANGTUYEN = @hinhthucdangtuyen,
                                                    TINHTRANG_DANGTUYEN = @tinhtrangdangtuyen,
                                                    HINHTHUC_THANHTOAN = @hinhthucthanhtoan,
                                                    NGAYLAP = @ngaylap
                    where ID_HD_DANGTUYEN = @idhddangtuyen;
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idhddangtuyen", SqlDbType.VarChar).Value = data.IDHDDangTuyen;
                    cmd.Parameters.Add("@ngaybatdau", SqlDbType.Date).Value = data.NgayBatDau;
                    cmd.Parameters.Add("@ngayketthuc", SqlDbType.Date).Value = data.NgayKetThuc;
                    cmd.Parameters.Add("@hinhthucdangtuyen", SqlDbType.NVarChar).Value = data.HinhThucDangTuyen;
                    cmd.Parameters.Add("@tinhtrangdangtuyen", SqlDbType.NVarChar).Value = data.TinhTrangDangTuyen;
                    cmd.Parameters.Add("@hinhthucthanhtoan", SqlDbType.NVarChar).Value = data.HinhThucThanhToan;
                    cmd.Parameters.Add("@ngaylap", SqlDbType.Date).Value = data.NgayLap;

                    var count = cmd.ExecuteNonQuery();
                    if(count > 0)
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
