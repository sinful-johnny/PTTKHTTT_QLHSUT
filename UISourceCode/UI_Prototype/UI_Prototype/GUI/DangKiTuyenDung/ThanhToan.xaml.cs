using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI_Prototype.BUS;

namespace UI_Prototype
{
    /// <summary>
    /// Interaction logic for ThanhToan.xaml
    /// </summary>
    public partial class ThanhToan : Window
    {
        SqlConnection _conn;
        BUS_HDDangTuyen _dataHDDangTuyen;
        BUS_HoaDon? _dataHoaDon;
        string _tenCTY;
        public ThanhToan(SqlConnection connection, BUS_HDDangTuyen data, string TenCTY)
        {
            InitializeComponent();
            this._conn = connection;
            this._dataHDDangTuyen = data;
            _tenCTY = TenCTY;

            HTThanhToanTextBox.DataContext = data.HinhThucThanhToan;
            MaHDTextBlock.DataContext = data.IDHDDangTuyen;
            TenDNTextBlock.DataContext = TenCTY;
        }

        private async void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;
            await Task.Run(() => Thread.Sleep(25));

            if(_dataHoaDon != null)
            {
                try
                {
                    await Task.Run(() => result = BUS_HoaDon.ThanhToanHoaDon(_conn, _dataHoaDon, _dataHDDangTuyen));
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
            }
            
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.IsIndeterminate = true;

            if (result)
            {
                MessageBox.Show("Thanh toán thành công!", "Thành công", MessageBoxButton.OK);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Hợp đồng không có thông tin hoá đơn!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            DialogResult= false;
        }

        async private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RootGrid.IsEnabled = false;
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;

            await Task.Run(() => _dataHoaDon = BUS_HoaDon.LoadHoaDon(_conn, _dataHDDangTuyen));
            if(_dataHoaDon != null)
            {
                _dataHoaDon.DotThanhToan += 1;
                _dataHoaDon.SoLanThanhToan += 1;
                _dataHoaDon.NgayLap = DateTime.Now;
                _dataHoaDon.SoTienDaTra = 0;
            }
            DataContext = _dataHoaDon;

            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));

            LoadingProgressBar.IsIndeterminate = true;
            RootGrid.IsEnabled = true;
        }
    }
}
