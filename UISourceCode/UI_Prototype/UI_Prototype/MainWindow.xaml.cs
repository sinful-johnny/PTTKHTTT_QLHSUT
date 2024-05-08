using System.Text;
using System.Windows;
using System.Windows.Controls;
using UI_Prototype.GUI.Converters;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Configuration;
using UI_Prototype.GUI.DangKiThanhVien;

namespace UI_Prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
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


        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginScreen loginScreen = new LoginScreen();
            var result = loginScreen.ShowDialog();
            int lastAccessedTabIndex = loginScreen.lastAccessedTabIndex;
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
                    //new TabItem() { Content = new ProductManagementScreen(_connection), Header= "Products"},
                    //new TabItem() {Content = new ManufacturerManagementUserControl(_connection), Header = "Manufacturer"},
                    //new TabItem() {Content = new PhoneOrder(_connection), Header = "Order"} ,
                    //new TabItem() {Content = new CustomerManagementUserControl(_connection), Header = "Customers"},
                    //new TabItem() {Content = new PromoManagementUserControl(_connection), Header = "Promotions"}
                };
            tabs.ItemsSource = screens;
            tabs.SelectedIndex = lastAccessedTabIndex;
        }


        private void RibbonWindow_Closing(object sender, CancelEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["LastAccessedTabIndex"].Value = tabs.SelectedIndex.ToString();
            config.Save(ConfigurationSaveMode.Minimal);
        }
        private void LogOut_buttonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}