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

namespace UI_Prototype.GUI.DangKiTuyenDung
{
    /// <summary>
    /// Interaction logic for ThaoTacHDTuyenDung.xaml
    /// </summary>
    public partial class ThaoTacHDTuyenDung : Window
    {
        SqlConnection _conn;
        int _mode = Modes.Insert;
        BUS_HDDangTuyen? _dataHDDangTuyen;
        List<BUS_ViTriTuyenDung>? _dataViTriTuyenDung;
        List<string> HinhThucThanhToanOptions = new List<string>()
        {
            "Thanh toan mot lan", "Thanh toan nhieu lan"
        };
        DateTime _ngayLap = DateTime.Now;
        string _tenCTY;
        public ThaoTacHDTuyenDung(SqlConnection conn, string tenCTY)
        {
            InitializeComponent();
            _conn = conn;
            _mode = Modes.Insert;
            _dataHDDangTuyen = new BUS_HDDangTuyen();
            _dataViTriTuyenDung = new List<BUS_ViTriTuyenDung>();
            _tenCTY = tenCTY;

            NgayLapTextBlock.DataContext = _ngayLap;
            TenCTYTextBlock.DataContext = _tenCTY;
            TTHDDangTuyenGrid.DataContext = _dataHDDangTuyen;
            MainDataGrid.ItemsSource = _dataViTriTuyenDung;
        }

        public ThaoTacHDTuyenDung(SqlConnection conn, BUS_HDDangTuyen data, string tenCTY)
        {
            InitializeComponent();
            _conn = conn;
            _mode = Modes.Update;
            _dataHDDangTuyen = data;
            if(data != null && data.IDHDDangTuyen != null)
            {
                _dataViTriTuyenDung = BUS_ViTriTuyenDung.getViTriTuyenDung(conn, data.IDHDDangTuyen);
            }
            
            _tenCTY = tenCTY;

            NgayLapTextBlock.DataContext = _ngayLap;
            TenCTYTextBlock.DataContext = _tenCTY;
            TTHDDangTuyenGrid.DataContext = _dataHDDangTuyen;
            MainDataGrid.ItemsSource = _dataViTriTuyenDung;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = false;
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;
            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));
            MessageBox.Show("Tạo hợp đồng thành công!", "Thành công", MessageBoxButton.OK);
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ThemSuaViTriDangTuyen();
            screen.ShowDialog();
        }

        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SuaButton_Click(object sender, RoutedEventArgs e)
        {
            var data = new BUS_ViTriTuyenDung();
            var screen = new ThemSuaViTriDangTuyen(data);
            screen.ShowDialog();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        internal class Modes
        {
            static public int Insert => 1;
            static public int Update => 2;
        }
    }
}
