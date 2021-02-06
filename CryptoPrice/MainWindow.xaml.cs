using System.Collections.Generic;
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
using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void PriceButton_Click(object sender, RoutedEventArgs e)
        {

            while (true)
            {
                var temp = APIAccess.APIData.Connect();

                this.ShowPrice.Text = temp.LiveData.ExchangeRate+" "+ temp.LiveData.Date;
                
                
                await Task.Delay(12000);
            }
        }

        
    }
}
