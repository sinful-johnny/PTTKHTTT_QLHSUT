using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI_Prototype.BUS;


namespace UI_Prototype.GUI.QuyTrinhGiaHanHopDong
{
    /// <summary>
    /// Interaction logic for GiaHanMainWindow.xaml
    /// </summary>
    public partial class GiaHanMainWindow : Window
    {
        private ObservableCollection<BUS_TTDoanhNghiep> tTDoanhNghiepList;
        private BUS_TTDoanhNghiep selectedTTDoanhNghiep;
        private List<PotentialType> potentialTypeList;
        private PotentialType selectedPotentialType;
        private SqlConnection _connection; // Assuming your connection object

        public GiaHanMainWindow(SqlConnection connection) // Inject the connection through the constructor
        {
            InitializeComponent();
            _connection = connection; // Store the connection

            // Load TTDoanhNghiep list from database on window load
            LoadTTDoanhNghiepList();

            potentialTypeList = new List<PotentialType>() // Mock data for potential types
            {
                new PotentialType("Tiềm năng"),
                new PotentialType("Tiềm năng lớn"),
                new PotentialType("Khách hàng tiềm năng"),
            };

            // Set data context for listbox and combobox
            TTDoanhNghiepListBox.ItemsSource = tTDoanhNghiepList;
            PotentialTypeComboBox.ItemsSource = potentialTypeList;

            // Update UI when selectedTTDoanhNghiep or selectedPotentialType changes
            TTDoanhNghiepListBox.SelectionChanged += (s, e) => UpdateDetails();
            PotentialTypeComboBox.SelectionChanged += (s, e) => UpdateDetails();
        }

        private void LoadTTDoanhNghiepList()
        {
            tTDoanhNghiepList = new ObservableCollection<BUS_TTDoanhNghiep>();
            var busTTDN = new BUS_TTDoanhNghiep();  // Create an instance of BUS_TTDoanhNghiep

            try
            {
                // Call the new LoadDSDoanhNghiepByTiemNang method, passing connection and desired tiemNang value
                List<BUS_TTDoanhNghiep> data = BUS_TTDoanhNghiep.LoadDSDoanhNghiepByTiemNang(_connection, "Đang xét duyệt");
                foreach (var item in data)
                {
                    tTDoanhNghiepList.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading data");
            }
        }


        private void UpdateDetails()
        {
            if (selectedTTDoanhNghiep != null)
            {
                string details = $"Tên: {selectedTTDoanhNghiep.TenCongTy}\nID Thuế: {selectedTTDoanhNghiep.IDThue}\nNgười đại diện: {selectedTTDoanhNghiep.NguoiDaiDien}\nĐịa chỉ: {selectedTTDoanhNghiep.DiaChi}\nEmail: {selectedTTDoanhNghiep.Email}\nTình trạng xác thực: {selectedTTDoanhNghiep.TinhTrangXacThuc}\nTềm năng: {selectedTTDoanhNghiep.TiemNangDoanhNghiep}";
                (FindName("DetailsTextBox") as TextBox).Text = details;
            }
        }

        private void RenewButton_Click(object sender, RoutedEventArgs e)
        {
            BUS_TTDoanhNghiep selectedTTDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepListBox.SelectedItem;
            if (selectedTTDoanhNghiep != null)
            {
                // Update selectedTTDoanhNghiep properties with new potential type and policy (assuming these are bound to UI controls)
                selectedTTDoanhNghiep.TiemNangDoanhNghiep = (PotentialTypeComboBox.SelectedItem as PotentialType).Name;
                selectedTTDoanhNghiep.ChinhSachUuDai = (FindName("PolicyTextBox") as TextBox)?.Text; // Assuming PolicyTextBox is bound to ChinhSachUuDai property

                // Call BUS_TTDoanhNghiep method to update the database with the modified TTDoanhNghiep object
                var busTTDN = new BUS_TTDoanhNghiep();
                try
                {
                    BUS_TTDoanhNghiep.updateDNSelected(_connection, selectedTTDoanhNghiep);
                    MessageBox.Show("Cập nhật thành công!"); // Show success message
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error updating data");
                }
            }
        }
        private void DoNotRenewButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // Implement RenewButton_Click and DoNotRenewButton_Click logic as needed
    }

    public class PotentialType
    {
        public string Name { get; set; }

        public PotentialType(string name)
        {
            Name = name;
        }
    }
}
