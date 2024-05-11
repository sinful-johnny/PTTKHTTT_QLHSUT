using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using UI_Prototype.GUI.DangKiThanhVien;
using UI_Prototype.BUS;

namespace UI_Prototype.GUI.NopHoSoTuyenDung
{
    public partial class UngVienDangKyTuyenDung : UserControl
    {
        private SqlConnection _connection;
        private string _HoTenTextBox;
        private string _NgaySinhTextBox;
        private string _SDTTextBox;
        private string _DiaChiTextBox;
        private string _EmailTextBox;
        private string _CCCDTextBox;
        public UngVienDangKyTuyenDung(SqlConnection con)
        {
            InitializeComponent();
            _connection = con;
        }
        private async void DangKiButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => {

                var newdataDoanhNghiep = new BUS_UngVienDangKyTuyenDung();
                newdataDoanhNghiep.HOTEN = _HoTenTextBox;
                newdataDoanhNghiep.NGAYSINH = _NgaySinhTextBox;
                newdataDoanhNghiep.SDT = _SDTTextBox;
                newdataDoanhNghiep.DIACHI = _DiaChiTextBox;
                newdataDoanhNghiep.EMAIL = _EmailTextBox;
                newdataDoanhNghiep.CCCD = _CCCDTextBox;


                BUS_UngVienDangKyTuyenDung.DangKiUngVien(_connection, newdataDoanhNghiep);
            });

            var screen = new DSViTriUngTuyen(_connection);
            var result = screen.ShowDialog();
        }
        private void HoTenTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _HoTenTextBox = HoTenTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void NgaySinhTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _NgaySinhTextBox = NgaySinhTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void SDTTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _SDTTextBox = SDTTextBox.Text;
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
                _DiaChiTextBox = DiaChiTextBox.Text;
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
                _EmailTextBox = EmailTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void CCCDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _CCCDTextBox = CCCDTextBox.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Input Wrong format", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
