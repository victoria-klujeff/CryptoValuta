using System;
using System.Collections.Generic;

namespace CryptoCurrency
{
    public class Converter
    {
        private readonly IDictionary<string, double> _currencyDict = new Dictionary<string, double>();

        /// <summary>
        /// Angiver prisen for en enhed af en kryptovaluta. Prisen angives i dollars.
        /// Hvis der tidligere er angivet en værdi for samme kryptovaluta, 
        /// bliver den gamle værdi overskrevet af den nye værdi
        /// </summary>
        /// <param name="currencyName">Navnet på den kryptovaluta der angives</param>
        /// <param name="price">Prisen på en enhed af valutaen målt i dollars. Prisen kan ikke være negativ</param>
        public void SetPricePerUnit(String currencyName, double price)
        {
            if (_currencyDict.ContainsKey(currencyName.ToUpper()))
            {
                _currencyDict[currencyName.ToUpper()] = price;
            }
            else
            {
                _currencyDict.Add(currencyName.ToUpper(), price);
            }

        }

        /// <summary>
        /// Konverterer fra en kryptovaluta til en anden. 
        /// Hvis en af de angivne valutaer ikke findes, kaster funktionen en ArgumentException
        /// 
        /// </summary>
        /// <param name="fromCurrencyName">Navnet på den valuta, der konverterers fra</param>
        /// <param name="toCurrencyName">Navnet på den valuta, der konverteres til</param>
        /// <param name="amount">Beløbet angivet i valutaen angivet i fromCurrencyName</param>
        /// <returns>Værdien af beløbet i toCurrencyName</returns>
        public double Convert(String fromCurrencyName, String toCurrencyName, double amount) 
        {
            if (!_currencyDict.ContainsKey(fromCurrencyName.ToUpper()))
            {
                throw new ArgumentException($"{fromCurrencyName} is an unknown currency");
            }
            if (!_currencyDict.ContainsKey(toCurrencyName.ToUpper()))
            {
                throw new ArgumentException($"{toCurrencyName} is an unknown currency");
            }
            double exchangeRate = _currencyDict[fromCurrencyName.ToUpper()] / _currencyDict[toCurrencyName.ToUpper()];
 
            return exchangeRate * amount;
        }
        static void Main() { }
    }
}
