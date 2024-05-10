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
                    INSERT INTO HOADON (ID_HD_DANGTUYEN,NGAYLAP,TONGSOTIEN,SOTIENCANTRA,SOTIENDATRA,SOLAN_THANHTOAN,DOT_THANHTOAN,TINHTRANG_THANHTOAN)
                    VALUES (@idhddangtuyen,@ngaylap,@tongsotien,@sotiencantra,0,0,0,'Chua thanh toan');
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
                    cmd.Parameters.Add("@tongsotien", SqlDbType.Int).Value = soTienCanTra;

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

        static public BUS_HoaDon? getHoaDon(SqlConnection conn, string IDHDDangTuyen)
        {
            var result = new BUS_HoaDon();
            string query = """
                SELECT * FROM HOADON 
                where   ID_HD_DANGTUYEN = @idhddangtuyen
                        and DOT_THANHTOAN = (select MAX(DOT_THANHTOAN) from HOADON where ID_HD_DANGTUYEN = @idhddangtuyen);
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idhddangtuyen", SqlDbType.NVarChar).Value = IDHDDangTuyen;

                    var reader = cmd.ExecuteReader();

                    var record = new BUS_HoaDon();
                    while(reader.Read())
                    {
                        record.IDHDDangTuyen = (string)reader["ID_HD_DANGTUYEN"];
                        record.TongSoTien = reader["TONGSOTIEN"] != DBNull.Value ? (int)reader["TONGSOTIEN"] : 0;
                        record.SoTienCanTra = reader["SOTIENCANTRA"] != DBNull.Value ? (int)reader["SOTIENCANTRA"] : 0;
                        record.SoTienDaTra = reader["SOTIENDATRA"] != DBNull.Value ? (int)reader["SOTIENDATRA"] : 0;
                        record.NgayLap = reader["NGAYLAP"] != DBNull.Value ? (DateTime)reader["NGAYLAP"] : new DateTime();
                        record.SoLanThanhToan = reader["SOLAN_THANHTOAN"] != DBNull.Value ? (int)reader["SOLAN_THANHTOAN"] : 0;
                        record.DotThanhToan = reader["DOT_THANHTOAN"] != DBNull.Value ? (int)reader["DOT_THANHTOAN"] : 0;
                        record.TinhTrangThanhToan = reader["TINHTRANG_THANHTOAN"] != DBNull.Value ? (string)reader["TINHTRANG_THANHTOAN"] : null;
                    }
                    result = record;
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

        static public bool ThanhToanHoaDon(SqlConnection conn, BUS_HoaDon hoaDon)
        {
            bool result = true;

            string query = """
                    INSERT INTO HOADON (ID_HD_DANGTUYEN,NGAYLAP,TONGSOTIEN,SOTIENCANTRA,SOTIENDATRA,SOLAN_THANHTOAN,DOT_THANHTOAN,TINHTRANG_THANHTOAN)
                    VALUES (@idhddangtuyen,@ngaylap,@tongsotien,@sotiencantra,@sotiendatra,@solanthanhtoan,@dotthanhtoan,@tinhtrangthanhtoan);
                    UPDATE HOADON SET SOLAN_THANHTOAN = @solanthanhtoan where ID_HD_DANGTUYEN = @idhddangtuyen;
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idhddangtuyen", SqlDbType.VarChar).Value = hoaDon.IDHDDangTuyen;
                    cmd.Parameters.Add("@ngaylap", SqlDbType.Date).Value = hoaDon.NgayLap;
                    cmd.Parameters.Add("@sotiencantra", SqlDbType.Int).Value = hoaDon.SoTienCanTra;
                    cmd.Parameters.Add("@tongsotien", SqlDbType.Int).Value = hoaDon.TongSoTien;
                    cmd.Parameters.Add("@solanthanhtoan", SqlDbType.Int).Value = hoaDon.SoLanThanhToan;
                    cmd.Parameters.Add("@dotthanhtoan", SqlDbType.Int).Value = hoaDon.DotThanhToan;
                    cmd.Parameters.Add("@sotiendatra", SqlDbType.Int).Value = hoaDon.SoTienDaTra;
                    cmd.Parameters.Add("@tinhtrangthanhtoan", SqlDbType.NVarChar).Value = hoaDon.TinhTrangThanhToan;


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

        static public bool updateHoaDon(SqlConnection conn, BUS_HoaDon hoaDon)
        {
            bool result = true;

            string query = """
                    UPDATE HOADON SET SOLAN_THANHTOAN = @solanthanhtoan where ID_HD_DANGTUYEN = @idhddangtuyen;
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idhddangtuyen", SqlDbType.VarChar).Value = hoaDon.IDHDDangTuyen;
                    cmd.Parameters.Add("@solanthanhtoan", SqlDbType.Int).Value = hoaDon.SoLanThanhToan;

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
