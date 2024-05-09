using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.BUS;
using UI_Prototype.GUI.NopHoSoTuyenDung;

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

        static public bool insertViTriTuyenDung(SqlConnection conn, BUS_ViTriTuyenDung data)
        {
            bool result = true;

            if(data.IDHDDangTuyen == null || data.IDHDDangTuyen == "" || data.IDHDDangTuyen == " " || data.IDViTriUngTuyen == null || data.IDViTriUngTuyen == "" || data.IDViTriUngTuyen == " ")
            {
                throw new Exception("Không được bỏ trống mã vị trí tuyển dụng!");
            }

                string query = """
                INSERT INTO VITRIUNGTUYEN (ID_VITRIUNGTUYEN,TENVITRI,TINHTRANG_UNGTUYEN,SOLUONG_TUYENDUNG,YEUCAU_UNGVIEN,ID_HD_DANGTUYEN)
                VALUES (@idvitriungtuyen,@tenvitri,@tinhtrangungtuyen,@soluongtuyendung,@yeucauungvien,@idhddangtuyen);
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idvitriungtuyen", SqlDbType.VarChar).Value = data.IDViTriUngTuyen;
                    cmd.Parameters.Add("@idhddangtuyen", SqlDbType.VarChar).Value = data.IDHDDangTuyen;
                    cmd.Parameters.Add("@tenvitri", SqlDbType.NVarChar).Value = data.TenViTri != null ? data.TenViTri : DBNull.Value;
                    cmd.Parameters.Add("@tinhtrangungtuyen", SqlDbType.VarChar).Value = data.TinhTrangUngTuyen != null ? data.TinhTrangUngTuyen : DBNull.Value;
                    cmd.Parameters.Add("@soluongtuyendung", SqlDbType.Int).Value = data.SoLuongTuyen != null ? data.SoLuongTuyen : DBNull.Value;
                    cmd.Parameters.Add("@yeucauungvien", SqlDbType.NVarChar).Value = data.YeuCauUngVien != null ? data.YeuCauUngVien : DBNull.Value;

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
        static public bool updateViTriTuyenDung(SqlConnection conn, BUS_ViTriTuyenDung data)
        {
            bool result = true;

            if (data.IDHDDangTuyen == null || data.IDHDDangTuyen == "" || data.IDHDDangTuyen == " " || data.IDViTriUngTuyen == null || data.IDViTriUngTuyen == "" || data.IDViTriUngTuyen == " ")
            {
                throw new Exception("Không được bỏ trống mã vị trí tuyển dụng!");
            }

            string query = """
                UPDATE VITRIUNGTUYEN set    TENVITRI = @tenvitri,
                                            TINHTRANG_UNGTUYEN = @tinhtrangungtuyen,
                                            SOLUONG_TUYENDUNG = @soluongtuyendung,
                                            YEUCAU_UNGVIEN = @yeucauungvien
                WHERE ID_VITRIUNGTUYEN = @idvitriungtuyen
                """;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idvitriungtuyen", SqlDbType.VarChar).Value = data.IDViTriUngTuyen;
                    cmd.Parameters.Add("@tenvitri", SqlDbType.NVarChar).Value = data.TenViTri != null ? data.TenViTri : DBNull.Value;
                    cmd.Parameters.Add("@tinhtrangungtuyen", SqlDbType.VarChar).Value = data.TinhTrangUngTuyen != null ? data.TinhTrangUngTuyen : DBNull.Value;
                    cmd.Parameters.Add("@soluongtuyendung", SqlDbType.Int).Value = data.SoLuongTuyen != null ? data.SoLuongTuyen : DBNull.Value;
                    cmd.Parameters.Add("@yeucauungvien", SqlDbType.NVarChar).Value = data.YeuCauUngVien != null ? data.YeuCauUngVien : DBNull.Value;

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
        static public bool deleteViTriTuyenDung(SqlConnection conn, BUS_ViTriTuyenDung data)
        {
            bool result = true;

            if (data.IDHDDangTuyen == null || data.IDHDDangTuyen == "" || data.IDHDDangTuyen == " " || data.IDViTriUngTuyen == null || data.IDViTriUngTuyen == "" || data.IDViTriUngTuyen == " ")
            {
                throw new Exception("Không được bỏ trống mã vị trí tuyển dụng!");
            }

            string query = """
                DELETE FROM VITRIUNGTUYEN WHERE ID_VITRIUNGTUYEN = @idvitriungtuyen;
                """;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var cmd = new SqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.Add("@idvitriungtuyen", SqlDbType.VarChar).Value = data.IDViTriUngTuyen;

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
