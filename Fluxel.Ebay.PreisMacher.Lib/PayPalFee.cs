using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxel.Ebay.PreisMacher.Lib
{
    public sealed class PayPalFee
    {
        public decimal Fee { get; }
        public decimal Percentage { get; }

        internal PayPalFee(decimal fee, decimal percent)
        {
            Fee = fee;
            Percentage = percent;
        }
    }

}
