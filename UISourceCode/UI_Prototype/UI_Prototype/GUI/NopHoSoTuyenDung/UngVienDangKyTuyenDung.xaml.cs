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
using System.Globalization;

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
            _HoTenTextBox = HoTenTextBox.Text;
            _NgaySinhTextBox = NgaySinhTextBox.Text;
            _SDTTextBox = SDTTextBox.Text;
            _DiaChiTextBox = DiaChiTextBox.Text;
            _EmailTextBox = EmailTextBox.Text;
            _CCCDTextBox = CCCDTextBox.Text;

            string idUV = "error";
            try
            {
                await Task.Run(() =>
                {
                    var newdataDoanhNghiep = new BUS_UngVienDangKyTuyenDung();
                    newdataDoanhNghiep.HOTEN = _HoTenTextBox;
                    DateTime ngaySinh;
                    if (DateTime.TryParseExact(_NgaySinhTextBox, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh))
                    {
                        newdataDoanhNghiep.NGAYSINH = ngaySinh;
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format. Please enter date in the format yyyy-MM-dd.");
                        return;
                    }
                    newdataDoanhNghiep.SDT = _SDTTextBox;
                    newdataDoanhNghiep.DIACHI = _DiaChiTextBox;
                    newdataDoanhNghiep.EMAIL = _EmailTextBox;
                    newdataDoanhNghiep.CCCD = _CCCDTextBox;


                    idUV = BUS_UngVienDangKyTuyenDung.DangKiUngVien(_connection, newdataDoanhNghiep);
                    MessageBox.Show(idUV);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var screen = new DSViTriUngTuyen(_connection, idUV);
            var result = screen.ShowDialog();


        }

        private void DaDangKiButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DSViTriUngTuyen(_connection, "UV028");
            var result = screen.ShowDialog();
        }
    }
 }

