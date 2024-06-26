﻿using UI_Prototype.BUS;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UI_Prototype.GUI.DangKiThanhVien
{
    /// <summary>
    /// Interaction logic for DanhSachDNDangKy.xaml
    /// </summary>
    public partial class DanhSachDNDangKy : UserControl
    {
        private SqlConnection _connection;
        public DanhSachDNDangKy(SqlConnection con)
        {
            InitializeComponent();
            _connection = con;
        }
        private void loadDataDN()
        {
            TTDoanhNghiepDataGrid.ItemsSource = BUS_TTDoanhNghiep.LoadDSDoanhNghiep(_connection);
            //TTDoanhNghiepDataGrid.Columns[7].Visibility = Visibility.Collapsed;
            //TTDoanhNghiepDataGrid.Columns[8].Visibility = Visibility.Collapsed;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataDN();
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        private void HienThiDNButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;

                if (row.TinhTrangXacThuc != "Hop le")
                {
                    var screen = new XacThucDonDangKy(_connection, row);
                    var result = screen.ShowDialog();
                    if (result == true)
                    {
                        loadDataDN();
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin doanh nghiệp này đã hợp lệ nên không được xác thực nữa", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void CapNhatDNButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;
                if (row.TinhTrangXacThuc == null)
                {
                    MessageBox.Show("Ô này trống không thể cập nhật", "Lỗi");
                    return;
                }
                if (row.TinhTrangXacThuc != "Hop le")
                {
                    var screen = new DangKyThanhVien(_connection, row);
                    var result = screen.ShowDialog();
                    if (result == true)
                    {
                        loadDataDN();
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin doanh nghiệp này đã hợp lệ nên không cần chỉnh sửa", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void XoaDNButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //List<int> indexSelectedItems = new List<int>();

                BUS_TTDoanhNghiep row = new BUS_TTDoanhNghiep();
                List<string> IdDoanhNghiepList = new List<string>();
                if (TTDoanhNghiepDataGrid.SelectedIndex >= 0)
                {
                    for (int i = 0; i < TTDoanhNghiepDataGrid.SelectedItems.Count; i++)
                    {
                        row = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItems[i];
                        if (row.TinhTrangXacThuc != "Hop le")
                        {
                            //indexSelectedItems.Add(TTDoanhNghiepDataGrid.SelectedItems.IndexOf(row));
                            //TTDoanhNghiepDataGrid.Items.Remove(row);
                            string IDDoanhNghiep = row.IDDoanhNghiep;
                            IdDoanhNghiepList.Add(IDDoanhNghiep);
                        }
                        else
                        {
                            MessageBox.Show($"Thông tin doanh nghiệp {row.IDDoanhNghiep} đã hợp lệ nên không được xóa", "Thông báo");
                        }
                    }
                }
                //foreach (int indexSelectedItem in indexSelectedItems)
                //        TTDoanhNghiepDataGrid.Items.RemoveAt(indexSelectedItem);

                BUS_TTDoanhNghiep.deleteDNList(_connection, IdDoanhNghiepList);
                loadDataDN();

                // Clear selected items 
                TTDoanhNghiepDataGrid.SelectedItems.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
}

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //textname from search textbox
            string searchName = SearchTextBox.Text;

            TTDoanhNghiepDataGrid.ItemsSource = BUS_TTDoanhNghiep.searchByName(_connection, searchName);
            TTDoanhNghiepDataGrid.Columns[7].Visibility = Visibility.Collapsed;
            TTDoanhNghiepDataGrid.Columns[8].Visibility = Visibility.Collapsed;
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string searchName = SearchTextBox.Text;

                TTDoanhNghiepDataGrid.ItemsSource = BUS_TTDoanhNghiep.searchByName(_connection, searchName);
                TTDoanhNghiepDataGrid.Columns[7].Visibility = Visibility.Collapsed;
                TTDoanhNghiepDataGrid.Columns[8].Visibility = Visibility.Collapsed;

                e.Handled = true;
            }
        }
    }
}
