namespace Fluxel.Ebay.PreisMacher.Lib
{
    public sealed class EbayCategory
    {
        internal EbayCategory(string label, decimal fee, decimal percentage)
        {
            Label = label;
            Fee = fee;
            Percentage = percentage;
        }

        public string Label { get; }
        public decimal Fee { get; }
        public decimal Percentage { get; }
    }
}