using System.Collections.Generic;

namespace OpenRates.iOS.Shared.Model
{
    public static class KnownCurrencyExtensions
    {
        static readonly Dictionary<KnownCurrency, CurrencyInfo> CurrencyInfos;
        
        static KnownCurrencyExtensions()
        {
            CurrencyInfos = new Dictionary<KnownCurrency, CurrencyInfo>
            {
                { KnownCurrency.EUR, new CurrencyInfo { FullName = "Euro (EUR)", Symbol = "€"} },
                { KnownCurrency.USD, new CurrencyInfo { FullName = "US Dollar (USD)", Symbol = "$"} },
                { KnownCurrency.GBP, new CurrencyInfo { FullName = "British Pound (GBP)", Symbol = "£"} },
                { KnownCurrency.CAD, new CurrencyInfo { FullName = "Canadian Dollar (CAD)", Symbol = "$"} },
                { KnownCurrency.AUD, new CurrencyInfo { FullName = "Australian Dollar (AUD)", Symbol = "$"} },
                { KnownCurrency.CNY, new CurrencyInfo { FullName = "Chinese Yuan Renminbi (CNY)", Symbol = "¥"} },
                { KnownCurrency.JPY, new CurrencyInfo { FullName = "Japanese Yen (JPY)", Symbol = "¥"} },
                { KnownCurrency.INR, new CurrencyInfo { FullName = "Indian Rupee (INR)", Symbol = "₹"} },
            };
        }
        
        public static string GetFullName(this KnownCurrency currency)
        {
            return CurrencyInfos.ContainsKey(currency) ? CurrencyInfos[currency].FullName : currency.ToString();
        }

        public static string GetSymbol(this KnownCurrency currency)
        {
            return CurrencyInfos.ContainsKey(currency) ? CurrencyInfos[currency].Symbol : currency.ToString();
        }

        class CurrencyInfo
        {
            public string FullName { get; set; }

            public string Symbol { get; set; }
        }
    }
}