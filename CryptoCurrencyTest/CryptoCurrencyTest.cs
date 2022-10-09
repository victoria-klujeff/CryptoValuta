using CryptoCurrency;
namespace CryptoCurrencyTest
{
   
    public class CryptocurrencyTest
    {
        /**[Theory]
        [InlineData("bitcoin", 12)]
        [InlineData("Bitcoin", 20)]
        [InlineData("Ethereum", 12)]
        [InlineData("ethereum", 15)]
        public void add_currency_to_dict(string currencyName, double unitPrice)
        {
            Converter sut = new Converter();
            sut.SetPricePerUnit(currencyName, unitPrice);

            double res = sut.currencyDict[currencyName.ToUpper()];

            Assert.Equal(unitPrice, res);
        }

         [Theory]
         [InlineData("polygon", 12, 20)]
         [InlineData("Dogecoin", 20, 20)]
         [InlineData("dai", 12, 12)]
         [InlineData("Polkadot", 15, 15)]
         public void override_currency_in_dict(string currencyName, double unitPriceInitial, double unitPriceFinal)
         {
             Converter sut = new Converter();
             sut.SetPricePerUnit(currencyName, unitPriceInitial);
             sut.SetPricePerUnit(currencyName, unitPriceFinal); 

             double res = sut.currencyDict[currencyName.ToUpper()];

             Assert.Equal(unitPriceFinal, res);
         }**/

        [Theory]
        [InlineData("polygon",12, "Dogecoin",14, 2000,1714.2857142857142 )]
        [InlineData("Dogecoin", 30, "dai",300, 1000.4, 100.04)]
        [InlineData("dai", 0.2, "Polkadot", 99.9, 8600, 17.217217217217218)]
        public void succesfully_convert(string fromCurrencyName, double fromUnitPrice, string toCurrencyName, double toUnitPrice, double amount, double expectedResult)
        {
            Converter sut = new Converter();
            sut.SetPricePerUnit(fromCurrencyName, fromUnitPrice);
            sut.SetPricePerUnit(toCurrencyName, toUnitPrice);

            double res = sut.Convert(fromCurrencyName, toCurrencyName, amount);

            Assert.Equal(expectedResult, res);
        }
        [Fact]
        public void throws_exception_currencyname_empty()
        {
            Converter sut = new Converter();
            Assert.Throws<ArgumentException>(() => sut.SetPricePerUnit("", 10));
        }

        
        [Theory]
        [InlineData("polygon", 12, "Dogecoin", 14, 2000)]
        [InlineData("Dogecoin", 30, "dai", 300, 1000.4)]
        public void throws_exception_currencyname_not_in_dict(string fromCurrencyName, double fromUnitPrice, string toCurrencyName, double toUnitPrice, double amount)
        {
            Converter sut = new Converter();
            sut.SetPricePerUnit(fromCurrencyName, fromUnitPrice);
            sut.SetPricePerUnit(toCurrencyName, toUnitPrice);

            Assert.Throws<ArgumentException>(() => sut.Convert("dollars", toCurrencyName, amount));

        }

    }

}