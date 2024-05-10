using System.Text;
using System.Windows;
using System.Windows.Controls;
using UI_Prototype.GUI.Converters;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Configuration;
using UI_Prototype.GUI.DangKiThanhVien;
using UI_Prototype.GUI.QuyTrinhDuyetHoSo;

namespace UI_Prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var screen = new ThongTinDoanhNghiep();
        //    screen.Show();
        //    this.Close();
        //}
        private SqlConnection _connection;
        public MainWindow()
        {
            InitializeComponent();

            //searchTextBox.DataContext = _keyword;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginScreen loginScreen = new LoginScreen();
            var result = loginScreen.ShowDialog();
            if (result == true)
            {
                _connection = loginScreen._connection;
            }
            else
            {
                this.Close();
                return;
            }
            this.Show();
            var screens = new ObservableCollection<TabItem>()
                {
                    new TabItem() { Content = new DanhSachDNDangKy(_connection), Header= "Đăng ký thành viên"},
                    //new TabItem() { Content = new ThongTinDoanhNghiep(_connection), Header= "Đăng kí tuyển dụng"},
                    //new TabItem() { Content = new QuyTrinhDuyetHoSoMainWindow(), Header= "Duyệt hồ sơ"},
                    //new TabItem() { Content = new ProductManagementScreen(_connection), Header= "Products"},
                    //new TabItem() {Content = new ManufacturerManagementUserControl(_connection), Header = "Manufacturer"},
                    //new TabItem() {Content = new PhoneOrder(_connection), Header = "Order"} ,
                    //new TabItem() {Content = new CustomerManagementUserControl(_connection), Header = "Customers"},
                    //new TabItem() {Content = new PromoManagementUserControl(_connection), Header = "Promotions"}
                };
            tabs.ItemsSource = screens;
            tabs.SelectedIndex = 0;
        }


        //private void RibbonWindow_Closing(object sender, CancelEventArgs e)
        //{
        //    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    config.AppSettings.Settings["LastAccessedTabIndex"].Value = tabs.SelectedIndex.ToString();
        //    config.Save(ConfigurationSaveMode.Minimal);
        //}
        //private void LogOut_buttonClicked(object sender, RoutedEventArgs e)
        //{
        //    _connection.Close();
        //    this.Close();
        //}

        private void DuyetHoSoButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new QuyTrinhDuyetHoSoMainWindow();
            this.Hide();
            screen.ShowDialog();
            this.Show();
        }

        private void DangKiTuyenDungButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ThongTinDoanhNghiep(_connection);
            this.Hide();
            screen.ShowDialog();
            this.Show();
        }
    }
}