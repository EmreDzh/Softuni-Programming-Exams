using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;

            this.Portfolio = new List<Stock>();
        }


        public List<Stock> Portfolio { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }


        public int Count
        {
            get
            {
                return Portfolio.Count;
            }
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare) // might be > MoneyToInvest  // mostlikely wrong
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            

            if (!this.Portfolio.Any(x => x.CompanyName == companyName))
            {

                return $"{companyName} does not exist.";
            }
            
            var findCompanyName = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (findCompanyName.PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";  
            }

            this.Portfolio.Remove(findCompanyName);
            this.MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";

        }

        public Stock FindStock(string companyName)
        {
           
            return this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            
        }

        public Stock FindBiggestCompany()
        {
            
            return this.Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
            
        }

        public string InvestorInformation()
        {
            return $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:{Environment.NewLine}{string.Join(Environment.NewLine, this.Portfolio)}";
        }

    }
}
