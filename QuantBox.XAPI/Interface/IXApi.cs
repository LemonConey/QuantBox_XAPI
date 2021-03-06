﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.XAPI.Interface
{
    public interface IXApi
    {
        DelegateOnConnectionStatus OnConnectionStatus { get; set; }
        DelegateOnRtnError OnRtnError { get; set; }

        void Connect();
        void Disconnect();

        ApiType GetApiType { get;}
        string GetApiName { get;}
        string GetApiVersion { get;}
    }

    public interface IXMarketData
    {
        DelegateOnRtnDepthMarketData OnRtnDepthMarketData { get; set; }
        void Subscribe(string szInstrument, string szExchange);
        void Unsubscribe(string szInstrument, string szExchange);
    }

    public interface IXInstrument
    {
        DelegateOnRspQryInstrument OnRspQryInstrument { get; set; }
        void ReqQryInstrument(string szInstrument, string szExchange);
    }

    public interface IXTrade
    {
        DelegateOnRspQryTradingAccount OnRspQryTradingAccount { get; set; }
        DelegateOnRspQryInvestorPosition OnRspQryInvestorPosition { get; set; }
        DelegateOnRspQrySettlementInfo OnRspQrySettlementInfo { get; set; }
        DelegateOnRtnOrder OnRtnOrder { get; set; }
        DelegateOnRtnTrade OnRtnTrade { get; set; }
        DelegateOnRtnQuote OnRtnQuote { get; set; }

        void ReqQryTradingAccount();
        void ReqQryInvestorPosition(string szInstrument, string szExchange);
        void ReqQrySettlementInfo(string szTradingDay);
        void SendOrder(int OrderRef, ref OrderField[] orders, out string[] OrderRefs);
        void CancelOrder(string[] szId,out string[] errs);
        string SendQuote(int QuoteRef, ref QuoteField quote);
        int CancelQuote(string szId);
    }

    public interface IXHistoricalData
    {
        DelegateOnRspQryHistoricalTicks OnRspQryHistoricalTicks { get; set; }
        DelegateOnRspQryHistoricalBars OnRspQryHistoricalBars { get; set; }

        int ReqQryHistoricalTicks(ref HistoricalDataRequestField request);
        int ReqQryHistoricalBars(ref HistoricalDataRequestField request);
    }
}
