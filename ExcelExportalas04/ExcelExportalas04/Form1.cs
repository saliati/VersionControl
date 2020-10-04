using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ExcelExportalas04
{
    public partial class Form1 : Form
    {

        RealEstateEntities context = new RealEstateEntities();
        List<Flat> Flats; //LINQ műveletek lokálisan kerülnek kiszámolásra a szerver terhelése nélkül

        public Form1()
        {
            InitializeComponent();
            LoadData();
            //CreateExcel();

            Excel.Application xlApp; // A Microsoft Excel alkalmazás
            Excel.Workbook xlWB; // A létrehozott munkafüzet
            Excel.Worksheet xlSheet; // Munkalap a munkafüzeten belül

        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }

        /*private void CreateExcel()
        {
            
        }*/
    }
}
