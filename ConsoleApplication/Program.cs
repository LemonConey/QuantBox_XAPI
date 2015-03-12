using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantBox.XAPI.Callback;
using QuantBox;
using QuantBox.XAPI;
namespace ConsoleApplication
{
    class Program
    {
        static void OnConnectionStatus(object sender, ConnectionStatus status, ref RspUserLoginField userLogin, int size1)
        {
            Console.WriteLine("333333" + status + userLogin.ErrorMsg());
        }

        static void OnRtnDepthMarketData(object sender, ref DepthMarketDataField marketData)
        {
            //Debugger.Log(0, null, "CTP:C#");
            Console.WriteLine(marketData.InstrumentID);
            Console.WriteLine(marketData.ExchangeID);
            Console.WriteLine(marketData.LastPrice);
        }
        static void Main(string[] args)
        {
            XApi quoteApi = new XApi(@"QuantBox_Femas_Quote.dll");
            quoteApi.Server.Address = "tcp://117.184.207.108:6888"; //"tcp://124.74.248.150:7230";//
            quoteApi.User.UserID = "155092"; //"jk8";//
            quoteApi.User.Password = "666666"; //"111111";//
            quoteApi.Server.BrokerID = "0001"; //"0152";//

            quoteApi.OnConnectionStatus = OnConnectionStatus;
            quoteApi.OnRtnDepthMarketData = OnRtnDepthMarketData;
            quoteApi.Connect();
            quoteApi.Subscribe("IF1503", "");

            Console.ReadKey();
        }
    }
}
