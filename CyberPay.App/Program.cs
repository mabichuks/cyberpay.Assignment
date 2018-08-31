using CyberPay.Cmd.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPay.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var billProvider = new QuickTellerBillProvider();
            var biller = billProvider.GetBillerById("104");

            var bankCodes = billProvider.GetBankCodes();

            foreach(var code in bankCodes)
            {
                Console.WriteLine($"{code.BankName}");
            }

            Console.Read();


            //foreach (var item in biller.PaymentItems)
            //{
            //    Console.WriteLine($"{item.PaymentItemName}");
            //}

            //Console.Read();
        }
    }
}
