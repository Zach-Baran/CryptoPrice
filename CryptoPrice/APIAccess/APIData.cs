using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CryptoPrice.APIAccess
{
    class APIData
    {
        public static APIAccess.DeserializeHelper Connect()
        {
            AVConnection conn = new AVConnection("J792SK2EZWSZBJKG");
            return conn.GetAPI("BTC");
        }

    }
    public class AVConnection
    {
        private readonly string _apiKey;
        public AVConnection(string apiKey) { this._apiKey = apiKey; }

        public APIAccess.DeserializeHelper GetAPI(string symbol)
        {
            
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={symbol}&to_currency=USD&apikey={this._apiKey}");
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();

                var temp = JsonConvert.DeserializeObject<DeserializeHelper>(results);
                //Console.WriteLine("Deserialization: " + temp.LiveData.ExchangeRate + " " + temp.LiveData.Date);
                return temp;

                
            
        }
    }
}
