using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace UI_Prototype.GUI.DangKiThanhVien
{
    /// <summary>
    /// Interaction logic for DanhSachDNDangKy.xaml
    /// </summary>
    public partial class DanhSachDNDangKy : UserControl
    {
        private SqlConnection _connection;
        public DanhSachDNDangKy(SqlConnection con)
        {
            InitializeComponent();
            _connection = con;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        private void HienThiDNButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void XoaDNButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TTDoanhNghiepDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
