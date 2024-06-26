﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Prototype.DAO;

namespace UI_Prototype.BUS
{
    public class BUS_ViTriTuyenDung : INotifyPropertyChanged, ICloneable
    {
        public string? IDViTriUngTuyen  { get; set; }
        public string? TenViTri { get; set; }
        public int? SoLuongTuyen { get; set; }
        public string? TinhTrangUngTuyen { get; set; }
        public string? YeuCauUngVien { get; set; }
        public string? IDHDDangTuyen { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        static public List<BUS_ViTriTuyenDung> getViTriTuyenDung(SqlConnection conn, string IDHD)
        {
            return DAO_ViTriTuyenDung.getViTriTuyenDung(conn, IDHD);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        static public bool insertViTriTuyenDung(SqlConnection conn, List<BUS_ViTriTuyenDung> data)
        {
            bool result = true;

            try
            {
                foreach(var item in data)
                {
                    result = DAO_ViTriTuyenDung.insertViTriTuyenDung(conn, item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
        static public bool deleteViTriTuyenDung(SqlConnection conn, List<BUS_ViTriTuyenDung> data)
        {
            bool result = true;

            try
            {
                foreach (var item in data)
                {
                    result = DAO_ViTriTuyenDung.deleteViTriTuyenDung(conn,item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
        static public bool updateViTriTuyenDung(SqlConnection conn, List<BUS_ViTriTuyenDung> data)
        {
            bool result = true;

            try
            {
                foreach (var item in data)
                {
                    result = DAO_ViTriTuyenDung.updateViTriTuyenDung(conn, item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
    }
}
