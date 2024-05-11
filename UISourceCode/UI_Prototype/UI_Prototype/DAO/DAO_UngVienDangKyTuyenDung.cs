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
     class DAO_UngVienDangKyTuyenDung
    {
        static public void DangKiUngVien(SqlConnection connection, BUS_UngVienDangKyTuyenDung dataDoanhNghiep)
        {
            string ID_UNGVIEN = dataDoanhNghiep.ID_UNGVIEN;
            string HOTEN = dataDoanhNghiep.HOTEN;
            DateTime NGAYSINH = dataDoanhNghiep.NGAYSINH;
            string DIACHI = dataDoanhNghiep.DIACHI;
            string SDT = dataDoanhNghiep.SDT;
            string email = dataDoanhNghiep.EMAIL;
            string CCCD = dataDoanhNghiep.CCCD;

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
        }
    }
}
