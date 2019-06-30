using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fluxel.Ebay.PreisMacher.Lib
{
    public static class CalculatorRepository
    {

        public static CalculationResult ByCategoryAndPayPal(EbayCategory category, decimal netto, PayPalFee payPalFee, decimal listingFee = 0, decimal mwst = 19m)
        {
            var fNetto = netto.GetNettoFix(payPalFee, category);
            var fBrutto = fNetto.AddVat(mwst).RoundBrutto(2);
            
            var percentageFee = category.Percentage*100m + payPalFee.Percentage*100m + listingFee*100m;
            var value = 0m;
            while (true)
            {
                var targetBrutto = (fBrutto + value);
                var targetFee = targetBrutto.GetPercent(percentageFee);
                var targetWithoutFee = targetBrutto - targetFee.AddVat(mwst);
                if (targetWithoutFee > fBrutto)
                {
                    return new CalculationResult(targetBrutto.ReduceVat(mwst), targetBrutto, targetBrutto.ReduceVat(mwst)-netto);
                }
                value += 0.01m;
            }
        }

    }

    internal static class DecimalExtensions
    {
        public static decimal RoundBrutto(this decimal v, int acc)
        {
            return Math.Round(v, acc, MidpointRounding.AwayFromZero);
        }

        public static decimal AddPercent(this decimal v, decimal p)
        {
            return v + v.GetPercent(p);
        }

        public static decimal GetPercent(this decimal v, decimal p)
        {
            return v / 100 * p;
        }
        
        public static decimal Get100PercentOf(this decimal v, decimal p)
        {
            return v * 100 / (100-p);
        }

        public static decimal GetNettoFix(this decimal netto, PayPalFee payPalFee, EbayCategory category)
        {
            return netto + category.Fee + payPalFee.Fee;
        }
        
        public static decimal AddVat(this decimal netto, decimal vat)
        {
            return netto * (1 + vat / 100);
        }
        
        public static decimal ReduceVat(this decimal netto, decimal vat)
        {
            return netto / (1 + vat / 100);
        }
    }
}
