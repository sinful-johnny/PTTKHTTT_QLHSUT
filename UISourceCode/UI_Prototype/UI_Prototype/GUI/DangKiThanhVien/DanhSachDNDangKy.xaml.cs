using UI_Prototype.BUS;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows.Input;

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
            var busTTDN = new BUS_TTDoanhNghiep();
            TTDoanhNghiepDataGrid.ItemsSource = busTTDN.LoadDSDoanhNghiep(_connection);
            TTDoanhNghiepDataGrid.Columns[7].Visibility = Visibility.Collapsed;
            TTDoanhNghiepDataGrid.Columns[8].Visibility = Visibility.Collapsed;
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
            //textname from search textbox
            string searchName = SearchTextBox.Text;

            var busTTDN = new BUS_TTDoanhNghiep();
            TTDoanhNghiepDataGrid.ItemsSource = busTTDN.searchByName(_connection, searchName);
            TTDoanhNghiepDataGrid.Columns[7].Visibility = Visibility.Collapsed;
            TTDoanhNghiepDataGrid.Columns[8].Visibility = Visibility.Collapsed;
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string searchName = SearchTextBox.Text;

                var busTTDN = new BUS_TTDoanhNghiep();
                TTDoanhNghiepDataGrid.ItemsSource = busTTDN.searchByName(_connection, searchName);
                TTDoanhNghiepDataGrid.Columns[7].Visibility = Visibility.Collapsed;
                TTDoanhNghiepDataGrid.Columns[8].Visibility = Visibility.Collapsed;

                e.Handled = true;
            }
        }

        private void TTDoanhNghiepDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("The data has been changed", "Data changed");
        }
    }
}
