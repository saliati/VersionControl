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
using System.Xml;

namespace SOAP
{
    

    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();

        public Form1() //form1 konstruktora
        {
            InitializeComponent();

            DataGridView datagridview1 = new DataGridView();
            datagridview1.DataSource = Rates;

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
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

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

        }
    }
}
