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
        private ObservableCollection<TTDoanhNghiep> tTDoanhNghiepList;
        private TTDoanhNghiep selectedTTDoanhNghiep;
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
            tTDoanhNghiepList = new ObservableCollection<TTDoanhNghiep>();
            var busTTDN = new BUS_TTDoanhNghiep();  // Create an instance of BUS_TTDoanhNghiep

            try
            {
                // Call the LoadDSDoanhNghiep method from BUS_TTDoanhNghiep, passing the connection
                List<TTDoanhNghiep> data = busTTDN.LoadDSDoanhNghiep(_connection)
                                        .Where(x => x.TiemNangDoanhNghiep == "Đang xét duyệt")
                                        .ToList(); ;
                foreach (TTDoanhNghiep item in data)
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
                string details = $"Tên: {selectedTTDoanhNghiep.Ten}\nLoại hình: {selectedTTDoanhNghiep.LoaiHinh}\nTiềm năng: {selectedTTDoanhNghiep.TiềmNang}";
                (FindName("DetailsTextBox") as TextBox).Text = details;
            }
        }

        private void RenewButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTTDoanhNghiep != null)
            {
                // Update selectedTTDoanhNghiep properties with new potential type and policy (assuming these are bound to UI controls)
                selectedTTDoanhNghiep.TiemNang = (PotentialTypeComboBox.SelectedItem as PotentialType).Name;
                selectedTTDoanhNghiep.ChinhSachUuDai = (FindName("PolicyTextBox") as TextBox)?.Text; // Assuming PolicyTextBox is bound to ChinhSachUuDai property

                // Call BUS_TTDoanhNghiep method to update the database with the modified TTDoanhNghiep object
                var busTTDN = new BUS_TTDoanhNghiep();
                try
                {
                    busTTDN.updateDNSelected(_connection, selectedTTDoanhNghiep);
                    MessageBox.Show("Cập nhật thành công!"); // Show success message
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error updating data");
                }
            }
        }

        // Implement RenewButton_Click and DoNotRenewButton_Click logic as needed
    }

    public class TTDoanhNghiep
    {
        public string Ten { get; set; }
        public string LoaiHinh { get; set; }
        public string TiềmNang { get; set; }

        public TTDoanhNghiep(string ten, string loaiHinh, string tiềmNang)
        {
            Ten = ten;
            LoaiHinh = loaiHinh;
            TiềmNang = tiềmNang;
        }
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
