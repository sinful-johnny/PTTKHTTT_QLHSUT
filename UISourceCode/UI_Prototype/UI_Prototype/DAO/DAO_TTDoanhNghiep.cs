using System.Data;
using System.Data.SqlClient;
using UI_Prototype.BUS;

namespace UI_Prototype.DAO
{
    class DAO_TTDoanhNghiep
    {
        public DataTable getDSTTDoanhNghiep(SqlConnection connection)
        {
            DataTable dataTable = new DataTable();

            string sql = """
                            exec sp_NV_XemDSDoanhNghiep
                         """;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using (var command = new SqlCommand(sql, connection))
            {
                //_connection.Open();
                var reader = command.ExecuteReader();
                dataTable.Load(reader);
                reader.Close();
            }

            connection.Close();

            var res = dataTable;

            return res;
        }

        public DataTable getByName(SqlConnection connection, string searchName)
        {
            DataTable dataTable = new DataTable();

            string sql = """
                            exec sp_NV_SearchTTDoanhNghiep @searchName
                         """;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            using (var command = new SqlCommand(sql, connection))
            {
                //_connection.Open();
                command.Parameters.Add("@searchName", SqlDbType.NVarChar).Value = searchName;

                var reader = command.ExecuteReader();
                dataTable.Load(reader);
                reader.Close();
            }

            connection.Close();

            var res = dataTable;

            return res;
        }
<<<<<<< Updated upstream
        static public List<BUS_TTDoanhNghiep> getTTDoanhNghiep(SqlConnection conn)
        {
            var result = new List<BUS_TTDoanhNghiep>();
            string query = """
                SELECT * FROM DS_DOANHNGHIEP;
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
                        var record = new BUS_TTDoanhNghiep();
                        record.IDDoanhNghiep = (string)reader["ID_DOANHNGHIEP"];
                        record.TenCongTy = reader["TEN_CONGTY"] != DBNull.Value ? (string)reader["TEN_CONGTY"] : null;
                        record.NguoiDaiDien = reader["NGUOIDAIDIEN"] != DBNull.Value ? (string)reader["NGUOIDAIDIEN"] : null;
                        record.DiaChi = reader["DIACHI"] != DBNull.Value ? (string)reader["DIACHI"] : null;
                        record.Email = reader["EMAIL"] != DBNull.Value ? (string)reader["EMAIL"] : null;
                        record.TinhTrangXacThuc = reader["TINHTRANG_XACTHUC"] != DBNull.Value ? (string)reader["TINHTRANG_XACTHUC"] : null;
                        record.TiemNangDoanhNghiep = reader["TIEMNANG_DN"] != DBNull.Value ? (string)reader["TIEMNANG_DN"] : null;

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

        static public List<BUS_TTDoanhNghiep> getByNameKeywords(SqlConnection conn, string TenDN)
            {
                var result = new List<BUS_TTDoanhNghiep>();
                string query = """
                SELECT * FROM DS_DOANHNGHIEP where CONTAINS (TEN_CONGTY,@Keyword);
                """;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (var cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = TenDN;

                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var record = new BUS_TTDoanhNghiep();
                            record.IDDoanhNghiep = (string)reader["ID_DOANHNGHIEP"];
                            record.TenCongTy = reader["TEN_CONGTY"] != DBNull.Value ? (string)reader["TEN_CONGTY"] : null;
                            record.NguoiDaiDien = reader["NGUOIDAIDIEN"] != DBNull.Value ? (string)reader["NGUOIDAIDIEN"] : null;
                            record.DiaChi = reader["DIACHI"] != DBNull.Value ? (string)reader["DIACHI"] : null;
                            record.Email = reader["EMAIL"] != DBNull.Value ? (string)reader["EMAIL"] : null;
                            record.TinhTrangXacThuc = reader["TINHTRANG_XACTHUC"] != DBNull.Value ? (string)reader["TINHTRANG_XACTHUC"] : null;
                            record.TiemNangDoanhNghiep = reader["TIEMNANG_DN"] != DBNull.Value ? (string)reader["TIEMNANG_DN"] : null;

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
=======

        public void deleteTTDoanhNghiep(SqlConnection connection, List<string> IdDoanhNghiepList)
        {
            string sql = """
                            exec sp_NV_XoaTTDoanhNghiep @IDDoanhNghiep
                         """;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            foreach (string IdDoanNghiep in IdDoanhNghiepList) 
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    //_connection.Open();
                    command.Parameters.Add("@IDDoanhNghiep", SqlDbType.VarChar).Value = IdDoanNghiep;

                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public void updateTTDoanhNghiep(SqlConnection connection, BUS_TTDoanhNghiep dataDoanhNghiep)
        {
            string iddoanhnghiep = dataDoanhNghiep.IDDoanhNghiep;
            string tencongty = dataDoanhNghiep.TenCongTy;
            string idthue = dataDoanhNghiep.IDThue;
            string nguoidaidien = dataDoanhNghiep.NguoiDaiDien;
            string diachi = dataDoanhNghiep.DiaChi;
            string email = dataDoanhNghiep.Email;
            string tinhtrangxacthuc = dataDoanhNghiep.TinhTrangXacThuc;

            string sql = """
                            exec sp_NV_SuaTTDoanhNghiep @iddoanhnghiep,
                                                        @tencongty,
                                                        @idthue,
                                                        @nguoidaidien,
                                                        @diachi,
                                                        @email,
                                                        @tinhtrangxacthuc
                         """;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (var command = new SqlCommand(sql, connection))
            {
                //_connection.Open();
                command.Parameters.Add("@iddoanhnghiep", SqlDbType.VarChar).Value = iddoanhnghiep;
                command.Parameters.Add("@tencongty", SqlDbType.NVarChar).Value = tencongty;
                command.Parameters.Add("@idthue", SqlDbType.VarChar).Value = idthue;
                command.Parameters.Add("@nguoidaidien", SqlDbType.NVarChar).Value = nguoidaidien;
                command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = diachi;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                command.Parameters.Add("@tinhtrangxacthuc", SqlDbType.NVarChar).Value = tinhtrangxacthuc;

                command.ExecuteNonQuery();
            }
            connection.Close();
>>>>>>> Stashed changes
        }
    }
