using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxel.Ebay.PreisMacher.Lib;
using Fluxel.Ebay.PreisMacher.Properties;
using HitWork.Presentation.Controller;

namespace Fluxel.Ebay.PreisMacher.Main
{
    public class MainController : NavigationTargetController<MainViewModel>
    {
        public MainController()
        {
        }

        public override void Initialized()
        {
            this.Title = Resource.MainController_Initialized_Eingabe;

            this.ViewModel.EbayCategories = new ObservableCollection<EbayCategory>(CategoryRepository.GetEbayCategories());
            this.ViewModel.CalcCommand = new CalcCommand(this);

            this.ViewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(MainViewModel.PayPalSalesValue) || args.PropertyName == nameof(MainViewModel.PayPalMicropayment))
                {
                    this.UpdatePayPalFee();
                }
            };
            this.UpdatePayPalFee();
        }

        public void UpdatePayPalFee()
        {
            
            if (this.ViewModel.PayPalMicropayment)
            {
                this.ViewModel.PayPalFee = PayPalFeeRepository.ForMicroPayment();
                return;
            }
                    
            this.ViewModel.PayPalFee = PayPalFeeRepository.ForNormal(this.ViewModel.PayPalSalesValue);
        }
    }
}
