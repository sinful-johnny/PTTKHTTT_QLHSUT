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
using UI_Prototype.GUI.DangKiTuyenDung;
using UI_Prototype.GUI.QuyTrinhGiaHanHopDong;

namespace UI_Prototype
{
    /// <summary>
    /// Interaction logic for ThongTinDoanhNghiep.xaml
    /// </summary>
    public partial class ThongTinDoanhNghiep : Window
    {
        SqlConnection _conn;
        List<BUS_TTDoanhNghiep>? dataDoanhNghiep;
        List<BUS_HDDangTuyen>? dataHDDangTuyen;
        public ThongTinDoanhNghiep(SqlConnection connection)
        {
            InitializeComponent();
            _conn = connection;
        }

        async void LoadData()
        {
            BUS_TTDoanhNghiep selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;

            RootGrid.IsEnabled = false;
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;

            if (selectedDoanhNghiep != null && selectedDoanhNghiep.IDDoanhNghiep != null)
            {
                try
                {
                    await Task.Run(() => dataHDDangTuyen = BUS_HDDangTuyen.LoadHDTuyenDung(_conn, selectedDoanhNghiep.IDDoanhNghiep));
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                

                HDTuyenDungDataGrid.ItemsSource = dataHDDangTuyen;
            }

            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));

            LoadingProgressBar.IsIndeterminate = true;
            RootGrid.IsEnabled = true;
        }

        private void HDTuyenDungDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void TTDoanhNghiepDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BUS_TTDoanhNghiep selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;

            RootGrid.IsEnabled = false;
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;

            if (selectedDoanhNghiep != null && selectedDoanhNghiep.IDDoanhNghiep != null)
            {
                try
                {
                    await Task.Run(() => dataHDDangTuyen = BUS_HDDangTuyen.LoadHDTuyenDung(_conn, selectedDoanhNghiep.IDDoanhNghiep));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                
                HDTuyenDungDataGrid.ItemsSource = dataHDDangTuyen;
            }

            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));

            LoadingProgressBar.IsIndeterminate = true;
            RootGrid.IsEnabled = true;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchBox.Text;
            dataDoanhNghiep = BUS_TTDoanhNghiep.searchByNameKeywords(_conn, keyword);
            TTDoanhNghiepDataGrid.ItemsSource = dataDoanhNghiep;
        }

        private void TaoMoiHDButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;
            if(selectedDoanhNghiep != null && selectedDoanhNghiep.TenCongTy != null)
            {
                if(selectedDoanhNghiep.TinhTrangXacThuc != "Chua xac thuc")
                {
                    var screen = new ThaoTacHDTuyenDung(_conn, selectedDoanhNghiep);
                    var result = screen.ShowDialog();
                    if (result == true)
                    {
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Doanh nghiệp chưa xác thực!","Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Chọn một doanh nghiệp!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChinhSuaHDButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedHDTuyenDung = (BUS_HDDangTuyen)HDTuyenDungDataGrid.SelectedItem;
            var selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;

            if (selectedHDTuyenDung != null && selectedDoanhNghiep != null && selectedDoanhNghiep.TenCongTy != null)
            {
                if (selectedDoanhNghiep.TinhTrangXacThuc != "Chua xac thuc")
                {
                    var screen = new ThaoTacHDTuyenDung(_conn, selectedHDTuyenDung, selectedDoanhNghiep);
                    var result = screen.ShowDialog();
                    if (result == true)
                    {
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Doanh nghiệp chưa xác thực!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Chọn một doanh nghiệp và hơp đồng để chỉnh sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ThanhToanButton_Click(object sender, RoutedEventArgs e)
        {

            var selectedHDTuyenDung = (BUS_HDDangTuyen)HDTuyenDungDataGrid.SelectedItem;
            var selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;

            if (selectedHDTuyenDung != null && selectedDoanhNghiep != null && selectedDoanhNghiep.TenCongTy != null)
            {
                if (selectedDoanhNghiep.TinhTrangXacThuc == "Chua xac thuc")
                {
                    MessageBox.Show("Doanh nghiệp chưa xác thực!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var screen = new ThanhToan(_conn, selectedHDTuyenDung, selectedDoanhNghiep.TenCongTy);
                    var result = screen.ShowDialog();
                    if (result == true)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn một doanh nghiệp và hợp đồng để thanh toán!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RootGrid.IsEnabled = false;
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;

            try
            {
                await Task.Run(() => dataDoanhNghiep = BUS_TTDoanhNghiep.LoadData(_conn));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            TTDoanhNghiepDataGrid.ItemsSource = dataDoanhNghiep;

            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));

            LoadingProgressBar.IsIndeterminate = true;
            RootGrid.IsEnabled = true;
        }

        private void DangKiButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CanGiaHanButton_Click(object sender, RoutedEventArgs e)
        {
            BUS_TTDoanhNghiep selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;

            if (selectedDoanhNghiep != null && selectedDoanhNghiep.IDDoanhNghiep != null)
            {
                try
                {
                    BUS_TTDoanhNghiep.UpdateTiemNangDoanhNghiep(_conn, selectedDoanhNghiep.IDDoanhNghiep, "Đang xét duyệt");
                    MessageBox.Show("Đã cập nhật trạng thái cần gia hạn cho doanh nghiệp " + selectedDoanhNghiep.TenCongTy, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một doanh nghiệp để cập nhật!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DangNhapButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a pop-up window for password input
            var passwordInputWindow = new PasswordInputWindow();
            passwordInputWindow.ShowDialog();

            // Check if the entered password is correct
            if (passwordInputWindow.Password == "admin123")
            {
                // Open the GiaHanMainWindow
                var giaHanMainWindow = new GiaHanMainWindow(_conn);
                giaHanMainWindow.Show();
                this.Close(); // Close the current window
            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
