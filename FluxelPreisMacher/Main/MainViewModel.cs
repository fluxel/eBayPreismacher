using System.Collections.ObjectModel;
using Fluxel.Ebay.PreisMacher.Lib;
using HitWork.Presentation.ViewModel;

namespace Fluxel.Ebay.PreisMacher.Main
{
    public class MainViewModel : ViewModelBase
    {

        public virtual ObservableCollection<EbayCategory> EbayCategories { get; set; }
        public virtual EbayCategory SelectedEbayCategory { get; set; }
        public virtual int PayPalSalesValue { get; set; }
        public virtual PayPalFee PayPalFee { get; set; }
        public virtual decimal Shipping { get; set; }
        public virtual bool ShippingExclusive { get; set; }
        public virtual bool BruttoExlusiveShipping { get; set; }
        public virtual decimal Net { get; set; }
        public virtual bool PayPalMicropayment { get; set; }

        public virtual CalcCommand CalcCommand { get; set; }

        public virtual decimal NettoVk { get; set; }
        public virtual decimal BruttoVk { get; set; }
        public virtual decimal Fee { get; set; }
        public virtual decimal BruttoShipping { get; set; }
    }
}