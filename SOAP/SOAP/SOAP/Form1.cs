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

namespace SOAP
{
    public partial class Form1 : Form
    {
        public Form1() //form1 konstruktora
        {
            InitializeComponent();

            BindingList<RateData> Rates = new BindingList<RateData>();

            DataGridView datagridview1 = new DataGridView();
            datagridview1.DataSource = Rates;
            

            //2020-as év első félévének euró árfolyamának lekérdezése

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
    }
}
