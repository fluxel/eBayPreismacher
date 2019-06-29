using System.Net;

namespace Fluxel.Ebay.PreisMacher.Lib
{
    public static class PayPalFeeRepository
    {
        public static PayPalFee ForMicroPayment()
        {
            return new PayPalFee(0.1m, 0.1m);
        }

        public static PayPalFee ForNormal(int turnover)
        {
            var percent = 2.49m;
            if (turnover > 100000)
            {
                percent = 1.49m;
            }
            else if (turnover > 25000)
            {
                percent = 1.79m;
            }
            else if (turnover > 5000)
            {
                percent = 1.99m;
            }
            else if (turnover > 2000)
            {
                percent = 2.19m;
            }
            return new PayPalFee(0.35m, percent  / 100m);
        }
    }
}