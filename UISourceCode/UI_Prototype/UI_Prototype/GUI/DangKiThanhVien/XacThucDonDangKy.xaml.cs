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

namespace UI_Prototype.GUI
{
    /// <summary>
    /// Interaction logic for XacThucDonDangKy.xaml
    /// </summary>
    public partial class XacThucDonDangKy : Window
    {
        private BUS_TTDoanhNghiep _dataDoanhNghiep;
        private SqlConnection _connection;
        public XacThucDonDangKy(SqlConnection connection, BUS_TTDoanhNghiep dataDoanhNghiep)
        {
            InitializeComponent();
            _connection = connection;
            _dataDoanhNghiep = dataDoanhNghiep;
            TenCongTyTextBox.IsReadOnly = true;
            MaSoThueTextBox.IsReadOnly = true;
            NguoiDaiDienTextBox.IsReadOnly = true;
            DiaChiTextBox.IsReadOnly = true;
            EmailTextBox.IsReadOnly = true;
        }

        private async void KhongHopLeButton_Click(object sender, RoutedEventArgs e)
        {
            string companyName = "";
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;
            await Task.Run(() => {

                string State = "Chưa hợp lệ";
                var newdataDoanhNghiep = _dataDoanhNghiep;
                newdataDoanhNghiep.IDDoanhNghiep = _dataDoanhNghiep.IDDoanhNghiep;
                newdataDoanhNghiep.TenCongTy = _dataDoanhNghiep.TenCongTy;
                newdataDoanhNghiep.IDThue = _dataDoanhNghiep.IDThue;
                newdataDoanhNghiep.NguoiDaiDien = _dataDoanhNghiep.NguoiDaiDien;
                newdataDoanhNghiep.DiaChi = _dataDoanhNghiep.DiaChi;
                newdataDoanhNghiep.Email = _dataDoanhNghiep.Email;
                newdataDoanhNghiep.TinhTrangXacThuc = State;

                companyName = newdataDoanhNghiep.TenCongTy;


                BUS_TTDoanhNghiep.updateDNSelected(_connection, newdataDoanhNghiep);
            });
            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));
            MessageBox.Show($"{companyName} xác nhận chưa hợp lệ!", "Chưa hợp lệ", MessageBoxButton.OK);
            DialogResult = true;
        }

        private async void HopLeButton_Click(object sender, RoutedEventArgs e)
        {
            string companyName = "";
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;
            await Task.Run(() => {

                string State = "Hợp lệ";
                var newdataDoanhNghiep = _dataDoanhNghiep;
                newdataDoanhNghiep.IDDoanhNghiep = _dataDoanhNghiep.IDDoanhNghiep;
                newdataDoanhNghiep.TenCongTy = _dataDoanhNghiep.TenCongTy;
                newdataDoanhNghiep.IDThue = _dataDoanhNghiep.IDThue;
                newdataDoanhNghiep.NguoiDaiDien = _dataDoanhNghiep.NguoiDaiDien;
                newdataDoanhNghiep.DiaChi = _dataDoanhNghiep.DiaChi;
                newdataDoanhNghiep.Email = _dataDoanhNghiep.Email;
                newdataDoanhNghiep.TinhTrangXacThuc = State;

                companyName = newdataDoanhNghiep.TenCongTy;


                BUS_TTDoanhNghiep.updateDNSelected(_connection, newdataDoanhNghiep);
            });
            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));
            MessageBox.Show($"{companyName} xác nhận hợp lệ!", "Hợp lệ", MessageBoxButton.OK);
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LabelContent.Content = "Xác thực đơn đăng ký";
            TenCongTyTextBox.Text = _dataDoanhNghiep.TenCongTy;
            MaSoThueTextBox.Text = _dataDoanhNghiep.IDThue;
            NguoiDaiDienTextBox.Text = _dataDoanhNghiep.NguoiDaiDien;
            DiaChiTextBox.Text = _dataDoanhNghiep.DiaChi;
            EmailTextBox.Text = _dataDoanhNghiep.Email;
            verifyLabel.Content = _dataDoanhNghiep.TinhTrangXacThuc;
        }
    }
}
