using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UI_Prototype.BUS;
using System.Windows;

namespace UI_Prototype.DAO
{
     class DAO_NopHoSoTuyenDung
    {
        static public void NopHoSo(SqlConnection connection, BUS_NopHoSoTuyenDung dataDoanhNghiep)
        {
            string ID_UNGVIEN = dataDoanhNghiep.ID_UNGVIEN ?? "";
            string ID_VITRIUNGTUYEN = dataDoanhNghiep.ID_VITRIUNGTUYEN ?? "";
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (var command = new SqlCommand("sp_UV_InsertPhieuDangKiUngTuyen", connection) { CommandType = CommandType.StoredProcedure })
            {
                //_connection.Open();
                command.Parameters.Add("@ID_UNGVIEN", SqlDbType.VarChar).Value = ID_UNGVIEN;
                command.Parameters.Add("@ID_VITRIUNGTUYEN", SqlDbType.VarChar).Value = ID_VITRIUNGTUYEN;

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        static public void ChungTuBangCap(SqlConnection connection, BUS_NopHoSoTuyenDung dataDoanhNghiep)
        {
            string TEN_CHUNGTU = dataDoanhNghiep.TEN_CHUNGTU ?? "";
            string TEN_BANGCAP = dataDoanhNghiep.TEN_BANGCAP ?? "";
            string ID_UNGVIEN = dataDoanhNghiep.ID_UNGVIEN ?? "";
            string ID_VITRIUNGTUYEN = dataDoanhNghiep.ID_VITRIUNGTUYEN ?? "";

            string sql = """
                            exec sp_UV_InsertUngvienChungTuBangCap  @TEN_CHUNGTU,
                                                                    @TEN_BANGCAP,
                                                                    @ID_UNGVIEN,
                                                                    @ID_VITRIUNGTUYEN,
                                                                    @ID_CHUNGTU,
                                                                    @ID_BANGCAP
                         """;
            
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (var command = new SqlCommand(sql, connection))
            {
                try
                {
                    //_connection.Open();
                    command.Parameters.Add("@TEN_CHUNGTU", SqlDbType.VarChar).Value = TEN_CHUNGTU;
                    command.Parameters.Add("@TEN_BANGCAP", SqlDbType.VarChar).Value = TEN_BANGCAP;
                    command.Parameters.Add("@ID_UNGVIEN", SqlDbType.VarChar).Value = ID_UNGVIEN;
                    command.Parameters.Add("@ID_VITRIUNGTUYEN", SqlDbType.NVarChar).Value = ID_VITRIUNGTUYEN;
                    command.Parameters.Add("@ID_CHUNGTU", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;
                    command.Parameters.Add("@ID_BANGCAP", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            connection.Close();
         }
            
     }
}

