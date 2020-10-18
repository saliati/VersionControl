using SOAP.Entities;
using SOAP.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace SOAP
{
    

    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        //BindingList<string> currencies = new BindingList<string>();


        public Form1() //form1 konstruktora
        {
            InitializeComponent();
            //comboBox1.DataSource = currencies;
            RefreshData();
        }

        public void RefreshData() 
        {
            Rates.Clear();
            dataGridView1.DataSource = Rates;

            fuggXml();
            fuggArfolyam();
            diagram();
        }

        string result;

        public void fuggArfolyam() //2020-as év első félévének euró árfolyamának lekérdezése
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                /*currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"*/

                currencyNames = Convert.ToString(comboBox1.SelectedItem),
                startDate = Convert.ToString(dateTimePicker1.Value),
                endDate = Convert.ToString(dateTimePicker2.Value)
            };

            var response = mnbService.GetExchangeRates(request);
            result = response.GetExchangeRatesResult;

        }

        public void fuggXml()
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit")); //ChildElement?
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0) //nem egyenlő
                    rate.Value = value / unit;
            }

        }

        public void diagram() 
        {
            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
