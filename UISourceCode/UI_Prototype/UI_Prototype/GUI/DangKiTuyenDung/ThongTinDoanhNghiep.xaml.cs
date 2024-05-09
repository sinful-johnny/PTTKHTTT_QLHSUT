﻿using System;
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
using UI_Prototype.GUI.DangKiTuyenDung;

namespace UI_Prototype
{
    /// <summary>
    /// Interaction logic for ThongTinDoanhNghiep.xaml
    /// </summary>
    public partial class ThongTinDoanhNghiep : Window
    {
        SqlConnection _conn;
        List<BUS_TTDoanhNghiep>? dataDoanhNghiep;
        List<BUS_HDDangTuyen>? dataHDDangTuyen;
        public ThongTinDoanhNghiep(SqlConnection connection)
        {
            InitializeComponent();
            _conn = connection;
        }

        void LoadData()
        {

        }

        private void HDTuyenDungDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void TTDoanhNghiepDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BUS_TTDoanhNghiep selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;

            RootGrid.IsEnabled = false;
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;

            if (selectedDoanhNghiep != null && selectedDoanhNghiep.IDDoanhNghiep != null)
            {
                await Task.Run(() => dataHDDangTuyen = BUS_HDDangTuyen.LoadHDTuyenDung(_conn, selectedDoanhNghiep.IDDoanhNghiep));
                
                HDTuyenDungDataGrid.ItemsSource = dataHDDangTuyen;
            }

            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));

            LoadingProgressBar.IsIndeterminate = true;
            RootGrid.IsEnabled = true;
        }

        private void DangKiButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchBox.Text;
            dataDoanhNghiep = BUS_TTDoanhNghiep.searchByName(_conn, keyword);
            TTDoanhNghiepDataGrid.ItemsSource = dataDoanhNghiep;
        }

        private void TaoMoiHDButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;
            if(selectedDoanhNghiep != null && selectedDoanhNghiep.TenCongTy != null)
            {
                var screen = new ThaoTacHDTuyenDung(_conn, selectedDoanhNghiep.TenCongTy);
                var result = screen.ShowDialog();
                if (result == true)
                {
                    LoadData();
                }
            }
        }

        private void ChinhSuaHDButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedHDTuyenDung = (BUS_HDDangTuyen)HDTuyenDungDataGrid.SelectedItem;
            var selectedDoanhNghiep = (BUS_TTDoanhNghiep)TTDoanhNghiepDataGrid.SelectedItem;

            if (selectedDoanhNghiep != null && selectedDoanhNghiep.TenCongTy != null)
            {
                var screen = new ThaoTacHDTuyenDung(_conn, selectedHDTuyenDung, selectedDoanhNghiep.TenCongTy);
                var result = screen.ShowDialog();
                if (result == true)
                {
                    LoadData();
                }
            }
        }

        private void ThanhToanButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ThanhToan();
            var result = screen.ShowDialog();
            if (result == true)
            {
                LoadData();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RootGrid.IsEnabled = false;
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;

            await Task.Run(() => dataDoanhNghiep = BUS_TTDoanhNghiep.LoadData(_conn));
            TTDoanhNghiepDataGrid.ItemsSource = dataDoanhNghiep;

            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));

            LoadingProgressBar.IsIndeterminate = true;
            RootGrid.IsEnabled = true;
        }
    }
}
