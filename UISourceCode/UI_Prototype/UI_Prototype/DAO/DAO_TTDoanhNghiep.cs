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
        private SqlConnection _connection;
        public DAO_TTDoanhNghiep(SqlConnection connection)
        {
            _connection = connection;
        }
        public DataTable getDSTTDoanhNghiep()
        {
            DataTable dataTable = new DataTable();

            string sql = """
                            exec sp_NV_XemDSDoanhNghiep
                         """;
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            using (var command = new SqlCommand(sql, _connection))
            {
                //_connection.Open();
                var reader = command.ExecuteReader();
                dataTable.Load(reader);
                reader.Close();
            }

            _connection.Close();

            var res = dataTable;

            return res;
        }
    }
}
