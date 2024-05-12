using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.BUS;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows;

namespace UI_Prototype.DAO
{
     class DAO_UngVienDangKyTuyenDung
    {
        static public string DangKiUngVien(SqlConnection connection, BUS_UngVienDangKyTuyenDung dataDoanhNghiep)
        {
            string HOTEN = dataDoanhNghiep.HOTEN ?? "";
            DateTime NGAYSINH = dataDoanhNghiep.NGAYSINH ?? DateTime.MinValue;
            string DIACHI = dataDoanhNghiep.DIACHI ?? "";
            string SDT = dataDoanhNghiep.SDT ?? "";
            string email = dataDoanhNghiep.EMAIL ?? "";
            string CCCD = dataDoanhNghiep.CCCD ?? "";
            string newID = "check";
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (var command = new SqlCommand("sp_UV_InsertHoSoUngvien", connection) { CommandType = CommandType.StoredProcedure})
            {
                try
                {
                    //_connection.Open();
                    command.Parameters.Add("@HOTEN", SqlDbType.VarChar).Value = HOTEN;
                    command.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = NGAYSINH;
                    command.Parameters.Add("@DIACHI", SqlDbType.VarChar).Value = DIACHI;
                    command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = SDT;
                    command.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = email;
                    command.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = CCCD;
                    SqlParameter outputParam = new SqlParameter("@NewID", SqlDbType.NVarChar, 10);
                    outputParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParam);

                    command.ExecuteNonQuery();

                    newID = command.Parameters["@NewID"].Value.ToString() ?? "Error has occured";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            connection.Close();
            return newID;
        }
        
    }
}
