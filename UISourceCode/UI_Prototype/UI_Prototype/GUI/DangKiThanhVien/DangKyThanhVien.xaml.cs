using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using UI_Prototype.BUS;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI_Prototype.GUI.DangKiThanhVien
{
    /// <summary>
    /// Interaction logic for DangKyThanhVien.xaml
    /// </summary>
    public partial class DangKyThanhVien : System.Windows.Window
    {
        private BUS_TTDoanhNghiep _dataDoanhNghiep;
        private SqlConnection _connection;

        private string _idDoanhNghiep;
        private string _newTenCongTy;
        private string _newMaSoThue;
        private string _newNguoiDaiDien;
        private string _newDiaChi;
        private string _newEmail;
        public DangKyThanhVien(SqlConnection connection, BUS_TTDoanhNghiep dataDoanhNghiep)
        {
            InitializeComponent();
            _connection = connection;
            _dataDoanhNghiep = dataDoanhNghiep;

            _idDoanhNghiep = _dataDoanhNghiep.IDDoanhNghiep;
            _newTenCongTy = _dataDoanhNghiep.TenCongTy;
            _newMaSoThue = _dataDoanhNghiep.IDThue;
            _newNguoiDaiDien = _dataDoanhNghiep.NguoiDaiDien;
            _newDiaChi = _dataDoanhNghiep.DiaChi;
            _newEmail = _dataDoanhNghiep.Email;
        }                 

        private void HuyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Hủy cập nhật thông tin đăng ký cho doanh nghiệp {_newTenCongTy}!", 
                "Hủy", MessageBoxButton.OK);
            DialogResult = false;
            this.Close();
            
        }

        private async void CapNhatButton_Click(object sender, RoutedEventArgs e)
        {

            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;
            await Task.Run(() => {

                var newdataDoanhNghiep = new BUS_TTDoanhNghiep();
                newdataDoanhNghiep.IDDoanhNghiep = _idDoanhNghiep;
                newdataDoanhNghiep.TenCongTy = _newTenCongTy;
                newdataDoanhNghiep.IDThue = _newMaSoThue;
                newdataDoanhNghiep.NguoiDaiDien = _newNguoiDaiDien;
                newdataDoanhNghiep.DiaChi = _newDiaChi;
                newdataDoanhNghiep.Email = _newEmail;
                newdataDoanhNghiep.TinhTrangXacThuc = _dataDoanhNghiep.TinhTrangXacThuc;


                BUS_TTDoanhNghiep.updateDNSelected(_connection, newdataDoanhNghiep);
            });
            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));
            MessageBox.Show($"Cập nhật thông tin đăng ký cho doanh nghiệp {_newTenCongTy} thành công!", "Thành công", MessageBoxButton.OK);
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TenCongTyTextBox.Text = _dataDoanhNghiep.TenCongTy;
            MaSoThueTextBox.Text = _dataDoanhNghiep.IDThue;
            NguoiDaiDienTextBox.Text = _dataDoanhNghiep.NguoiDaiDien;
            DiaChiTextBox.Text = _dataDoanhNghiep.DiaChi;
            EmailTextBox.Text = _dataDoanhNghiep.Email;
            verifyLabel.Content = _dataDoanhNghiep.TinhTrangXacThuc;
        }

        private void TenCongTyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _newTenCongTy = TenCongTyTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void MaSoThueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _newMaSoThue = MaSoThueTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void NguoiDaiDienTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _newNguoiDaiDien = NguoiDaiDienTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void DiaChiTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _newDiaChi = DiaChiTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _newEmail = EmailTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
