using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

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
    }
}
