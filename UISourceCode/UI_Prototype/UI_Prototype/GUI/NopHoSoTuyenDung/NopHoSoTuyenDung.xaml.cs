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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Globalization;
using UI_Prototype.BUS;

namespace UI_Prototype.GUI.NopHoSoTuyenDung
{
    public partial class NopHoSoTuyenDung : Window
    {
        private SqlConnection _connection;
        private string idUV;
        private string _IdViTriTextBox;
        private string _TenChungTuTextBox;
        private string _TenBangCapTextBox;
        public NopHoSoTuyenDung(SqlConnection con, string idUV)
        {
            InitializeComponent();

            _connection = con;
            this.idUV = idUV;
        }

        private async void NopHoSoTuyenDungButton_Click(object sender, RoutedEventArgs e)
        {
            _IdViTriTextBox = IdViTriTextBox.Text;
            _TenChungTuTextBox = TenChungTuTextBox.Text;
            _TenBangCapTextBox = TenBangCapTextBox.Text;

            MessageBox.Show(_IdViTriTextBox);
            try
            {
                await Task.Run(() => {
                var newdataDoanhNghiep = new BUS_NopHoSoTuyenDung();
                newdataDoanhNghiep.ID_VITRIUNGTUYEN = _IdViTriTextBox;
                newdataDoanhNghiep.TEN_CHUNGTU = _TenChungTuTextBox;
                newdataDoanhNghiep.TEN_BANGCAP = _TenBangCapTextBox;
                newdataDoanhNghiep.ID_UNGVIEN = idUV;


                BUS_NopHoSoTuyenDung.NopHoSo(_connection, newdataDoanhNghiep);
            });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
