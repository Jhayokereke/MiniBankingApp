using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingApp
{
    public class Account
    {
        public Account(decimal initialDeposit = 0)
        {
            Balance = 1000 + initialDeposit;
            //string acctNum = "";
            //string firstTwo = "07";
            //string nextSix = DateTime.Now.ToString("yyMMdd");

            //string LastTwo = new Random().Next(99).ToString().PadLeft(2, '0');
            //acctNum = firstTwo + nextSix + LastTwo;

            //Number = acctNum;
            Number = $"07{DateTime.Now.ToString("yyMMdd")}{new Random().Next(99).ToString().PadLeft(2, '0')}";
            Console.WriteLine($"{Number}");
        }
        public string Number { get; set; }
        public string TransactionPin { get; set; }
        public decimal Balance { get; set; }
    }
}
