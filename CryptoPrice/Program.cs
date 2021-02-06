using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            AVConnection conn = new AVConnection("J792SK2EZWSZBJKG");
            conn.SaveCSVFromURL("BTC");
        }
    }
    public class AVConnection
    {
        private readonly string _apiKey;
        public AVConnection(string apiKey) { this._apiKey = apiKey; }
        
        public void SaveCSVFromURL(string symbol)
        {
            while (true)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={symbol}&to_currency=USD&apikey={this._apiKey}");
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();

                var temp = JsonConvert.DeserializeObject<GetJSONData>(results);
                Console.WriteLine("Deserialization: " + temp.LiveData.ExchangeRate + " " + temp.LiveData.Date);
      
                Thread.Sleep(12000);
            }
        }

        public string Printres(string res)
        {

            int ind = res.IndexOf("Exchange Rate\": \"");
            int quoteCount = 2;
            string num = "";

            while (quoteCount > -1)
            {
                if (Char.IsDigit(res[ind]) || res[ind] == '.')
                {
                    num += res[ind];
                    ind++;
                }
                else if (res[ind] == '"')
                {
                    quoteCount--;
                    ind++;
                }
                else ind++;
            }
            return num;
        }
    }
}
