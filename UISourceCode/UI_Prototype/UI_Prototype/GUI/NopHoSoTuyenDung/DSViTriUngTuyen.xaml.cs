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
using System.Drawing;
using UI_Prototype.BUS;
using UI_Prototype.DAO;

namespace UI_Prototype.GUI.NopHoSoTuyenDung
{
    public partial class DSViTriUngTuyen : Window
    {
        private SqlConnection _connection;
        private string idUV;
        public DSViTriUngTuyen(SqlConnection con, string idUV)
        {
            InitializeComponent();
            _connection = con;
            this.idUV = idUV;
            try
            {
                DSVITRIUNGTUYENDataGrid.ItemsSource = BUS_DSVITRIUNGTUYEN.LoadData(_connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void XemDSButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DSVITRIUNGTUYENDataGrid.ItemsSource = BUS_DSVITRIUNGTUYEN.LoadData(_connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void NopHoSoButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new NopHoSoTuyenDung(_connection,idUV);
            var result = screen.ShowDialog();
        }
        private void HoSoDaNopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DSVITRIUNGTUYENDataGrid.ItemsSource = BUS_DSPhieuDangKyUngTuyen.HoSoDaNop(_connection,idUV);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
