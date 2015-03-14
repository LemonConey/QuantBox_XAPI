using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantBox.XAPI.Callback;
using QuantBox;
using QuantBox.XAPI;
using System.Runtime.InteropServices;
using System.Threading;
namespace ConsoleApplication
{
    class Program
    {
        static void OnConnectionStatus(object sender, ConnectionStatus status, ref RspUserLoginField userLogin, int size1)
        {
            Console.WriteLine(status + userLogin.ErrorMsg());
            if (status == ConnectionStatus.Done)
            {
                quoteApi.Subscribe("IF1212;IF1211;IF1210", "");
            }
        }
        static void OnRtnError(object sender, [In] ref ErrorField error)
        {

        }

        static void OnRtnQuote(object sender, [In] ref QuoteField quote)
        {

        }

        static void OnRtnDepthMarketData(object sender, ref DepthMarketDataField marketData)
        {
            //Debugger.Log(0, null, "CTP:C#");
            Console.WriteLine(marketData.InstrumentID);
            Console.WriteLine(marketData.ExchangeID);
            Console.WriteLine(marketData.LastPrice);
        }
        public static XApi quoteApi = null;
        static void Main(string[] args)
        {
            quoteApi = new XApi(@"QuantBox_Femas_Quote.dll");
            quoteApi.Server.Address = "tcp://117.184.207.108:6888"; //"tcp://124.74.248.150:7230";//
            quoteApi.User.UserID = "155092"; //"jk8";//
            quoteApi.User.Password = "666666"; //"111111";//
            quoteApi.Server.BrokerID = "0001"; //"0152";//
            quoteApi.Server.TopicId = 100;
            quoteApi.Server.MarketDataTopicResumeType = ResumeType.Quick;
            
            //quoteApi.SubscribedInstruments["S"] = new SortedSet<string>() { "IF1212;IF1211;IF1210" };
            quoteApi.OnConnectionStatus = OnConnectionStatus;
            quoteApi.OnRtnDepthMarketData = OnRtnDepthMarketData;
            quoteApi.OnRtnError = OnRtnError;
            quoteApi.Connect();
            //Thread.Sleep(1000);
            
            //quoteApi.SubscribeQuote("IF1212", "");//IF1211;IF1210;44
            Console.ReadKey();
        }
    }
}
