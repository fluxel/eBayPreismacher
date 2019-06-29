namespace Fluxel.Ebay.PreisMacher.Lib
{
    public sealed class CalculationResult
    {
        public decimal NettoVk { get; }
        public decimal BruttoVk { get; }
        public decimal Fee { get; }

        internal CalculationResult(decimal netto, decimal brutto, decimal fee)
        {
            NettoVk = netto;
            BruttoVk = brutto;
            Fee = fee;
        }
    }
}