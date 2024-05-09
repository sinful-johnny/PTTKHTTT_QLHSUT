using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using UI_Prototype.BUS;
using UI_Prototype.DAO;

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
        BUS_HoaDon? _dataHoaDon;
        List<BUS_ViTriTuyenDung>? originalDataViTriUngTuyen;
        BindingList<BUS_ViTriTuyenDung>? _dataViTriTuyenDung;
        List<string> HinhThucThanhToanOptions = new List<string>()
        {
            "Thanh toan mot lan", "Thanh toan nhieu lan"
        };
        List<string> TinhTrangDangTuyenOptions = new List<string>()
        {
            "Ngung tuyen", "Dang tuyen", "Tam ngung"
        };
        DateTime _ngayLap = DateTime.Now;
        string? _tenCTY;
        List<BUS_ViTriTuyenDung> inserted = new List<BUS_ViTriTuyenDung>();
        List<BUS_ViTriTuyenDung> updated = new List<BUS_ViTriTuyenDung>();
        List<BUS_ViTriTuyenDung> deleted = new List<BUS_ViTriTuyenDung>();
        public ThaoTacHDTuyenDung(SqlConnection conn, BUS_TTDoanhNghiep CTY)
        {
            InitializeComponent();
            _conn = conn;
            _mode = Modes.Insert;
            _dataHDDangTuyen = new BUS_HDDangTuyen();
            _dataHoaDon = new BUS_HoaDon() { SoTienCanTra = 0 };
            originalDataViTriUngTuyen = new List<BUS_ViTriTuyenDung>();
            _dataViTriTuyenDung = new BindingList<BUS_ViTriTuyenDung>();
            _dataHDDangTuyen.NgayBatDau = DateTime.Now;
            _dataHDDangTuyen.NgayKetThuc = DateTime.Now;

            _dataViTriTuyenDung = new BindingList<BUS_ViTriTuyenDung>();
            if (CTY.TenCongTy != null)
            {
                _tenCTY = CTY.TenCongTy;
            }
            if(CTY.IDDoanhNghiep != null)
            {
                _dataHDDangTuyen.IDDoanhNghiep = CTY.IDDoanhNghiep;
            }
            
            HinhThucThanhToanComboBox.ItemsSource = HinhThucThanhToanOptions;
            NgayLapTextBlock.DataContext = _ngayLap;
            TenCTYTextBlock.DataContext = _tenCTY;
            TTHDDangTuyenGrid.DataContext = _dataHDDangTuyen;
            MainDataGrid.ItemsSource = _dataViTriTuyenDung;
            TinhTrangDangTuyenComboBox.ItemsSource = TinhTrangDangTuyenOptions;
            GiaTriHopDongTextBox.DataContext = _dataHoaDon;
        }

        public ThaoTacHDTuyenDung(SqlConnection conn, BUS_HDDangTuyen data, BUS_TTDoanhNghiep CTY)
        {
            InitializeComponent();
            _conn = conn;
            _mode = Modes.Update;
            _dataHDDangTuyen = (BUS_HDDangTuyen)data.Clone();
            if(data != null && data.IDHDDangTuyen != null )
            {
                _dataViTriTuyenDung = new BindingList<BUS_ViTriTuyenDung>();
                originalDataViTriUngTuyen = BUS_ViTriTuyenDung.getViTriTuyenDung(conn, data.IDHDDangTuyen);
                originalDataViTriUngTuyen.ForEach(x =>
                {
                    _dataViTriTuyenDung.Add((BUS_ViTriTuyenDung)x.Clone());
                });
                _ngayLap = data.NgayLap;
            }

            if (CTY.TenCongTy != null)
            {
                _tenCTY = CTY.TenCongTy;
            }
            if (CTY.IDDoanhNghiep != null)
            {
                _dataHDDangTuyen.IDDoanhNghiep = CTY.IDDoanhNghiep;
            }

            NgayLapTextBlock.DataContext = _ngayLap;
            TenCTYTextBlock.DataContext = _tenCTY;
            TTHDDangTuyenGrid.DataContext = _dataHDDangTuyen;
            MainDataGrid.ItemsSource = _dataViTriTuyenDung;
            HinhThucThanhToanComboBox.ItemsSource = HinhThucThanhToanOptions;
            TinhTrangDangTuyenComboBox.ItemsSource = TinhTrangDangTuyenOptions;
            GiaTriHopDongTextBox.DataContext = _dataHoaDon;
            try
            {
                HinhThucThanhToanComboBox.SelectedItem = HinhThucThanhToanOptions.Single(x => x == _dataHDDangTuyen.HinhThucThanhToan);
                TinhTrangDangTuyenComboBox.SelectedItem = TinhTrangDangTuyenOptions.Single(x => x == _dataHDDangTuyen.TinhTrangDangTuyen);
            }
            catch { }

            GiaTriHopDongTextBox.IsEnabled = false;
            IDHDDangTuyenTextBox.IsEnabled = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ThemButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ThemSuaViTriDangTuyen();
            var result = screen.ShowDialog();
            if (result == true && _dataViTriTuyenDung != null)
            {
                if (_dataHDDangTuyen != null && originalDataViTriUngTuyen != null && originalDataViTriUngTuyen.Contains(screen._DataContext) != true)
                {
                    screen._DataContext.IDHDDangTuyen = _dataHDDangTuyen.IDHDDangTuyen;
                    inserted.Add(screen._DataContext);
                }
                
                _dataViTriTuyenDung.Add(screen._DataContext);
            }
        }

        private void XoaButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = (BUS_ViTriTuyenDung)MainDataGrid.SelectedItem;
            if (_dataViTriTuyenDung != null && selected != null)
            {
                if (originalDataViTriUngTuyen != null 
                    && originalDataViTriUngTuyen.SingleOrDefault(x => x.IDViTriUngTuyen == selected.IDViTriUngTuyen) != null)
                {
                    deleted.Add(selected);
                }
                else
                {
                    BUS_ViTriTuyenDung? instance = null;
                    try
                    {
                        instance = inserted.SingleOrDefault(x => x.IDViTriUngTuyen == selected.IDViTriUngTuyen);
                    }
                    catch { instance = null; }

                    if (instance != null)
                    {
                        inserted.Remove(instance);
                    } 
                }

                _dataViTriTuyenDung.Remove(selected);
            }
        }

        private void SuaButton_Click(object sender, RoutedEventArgs e)
        {
            var data = (BUS_ViTriTuyenDung)MainDataGrid.SelectedItem;
            var screen = new ThemSuaViTriDangTuyen(data);
            var result = screen.ShowDialog();
            if (result == true && _dataViTriTuyenDung != null)
            {
                if (originalDataViTriUngTuyen != null && originalDataViTriUngTuyen.SingleOrDefault(x => x.IDViTriUngTuyen == data.IDViTriUngTuyen) != null)
                {
                    updated.Add(data);
                }

                BUS_ViTriTuyenDung? instance = null;
                try
                {
                    instance = inserted.SingleOrDefault(x => x.IDViTriUngTuyen == data.IDViTriUngTuyen);
                }
                catch { instance = null; }

                if (instance != null)
                {
                    inserted.Remove(instance);
                    inserted.Add(data);
                }
            } else if (result == false && _dataViTriTuyenDung != null && screen._originalData != null)
            {
                data.IDViTriUngTuyen = screen._originalData.IDViTriUngTuyen;
                data.YeuCauUngVien = screen._originalData.YeuCauUngVien;
                data.SoLuongTuyen = screen._originalData.SoLuongTuyen;
                data.TenViTri = screen._originalData.TenViTri;
                data.TinhTrangUngTuyen = screen._originalData.TinhTrangUngTuyen;
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            RootGrid.IsEnabled = false;
            LoadingProgressBar.IsIndeterminate = false;
            LoadingProgressBar.Value = 10;
            await Task.Run(() => Thread.Sleep(10));
            LoadingProgressBar.Value = 40;

            var result = true;

            if (_mode == Modes.Insert)
            { 
                try
                {
                    if (_dataHDDangTuyen != null)
                    {
                        await Task.Run(() => result = BUS_HDDangTuyen.createHDDangTuyen(_conn, _dataHDDangTuyen));
                        LoadingProgressBar.Value = 50;
                        await Task.Run(() => result = BUS_ViTriTuyenDung.insertViTriTuyenDung(_conn, inserted));
                        LoadingProgressBar.Value = 60;
                        await Task.Run(() => result = BUS_ViTriTuyenDung.deleteViTriTuyenDung(_conn, deleted));
                        LoadingProgressBar.Value = 70;
                        await Task.Run(() => result = BUS_ViTriTuyenDung.updateViTriTuyenDung(_conn, updated));
                        if (_dataHDDangTuyen.IDHDDangTuyen != null && _dataHoaDon != null)
                        {
                            await Task.Run(() => result = BUS_HoaDon.TaoHoaDon(_conn, _dataHDDangTuyen.IDHDDangTuyen, _dataHoaDon.SoTienCanTra));
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    MessageBox.Show(ex.ToString(), "Thất bại!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (_mode == Modes.Update)
            {
                try
                {
                    if (_dataHDDangTuyen != null)
                    {
                        await Task.Run(() => result = BUS_HDDangTuyen.updateHDDangTuyen(_conn, _dataHDDangTuyen));
                        LoadingProgressBar.Value = 50;
                        await Task.Run(() => result = BUS_ViTriTuyenDung.insertViTriTuyenDung(_conn, inserted));
                        LoadingProgressBar.Value = 60;
                        await Task.Run(() => result = BUS_ViTriTuyenDung.deleteViTriTuyenDung(_conn, deleted));
                        LoadingProgressBar.Value = 70;
                        await Task.Run(() => result = BUS_ViTriTuyenDung.updateViTriTuyenDung(_conn, updated));
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    MessageBox.Show(ex.ToString(), "Thất bại!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            await Task.Run(() => Thread.Sleep(25));
            LoadingProgressBar.Value = 80;
            await Task.Run(() => Thread.Sleep(50));
            LoadingProgressBar.Value = 100;
            await Task.Run(() => Thread.Sleep(25));
            RootGrid.IsEnabled = true;
            LoadingProgressBar.IsIndeterminate = true;

            if (result)
            {
                MessageBox.Show("Sửa hợp đồng thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }

        }

        internal class Modes
        {
            static public int Insert => 1;
            static public int Update => 2;
        }
    }
}
