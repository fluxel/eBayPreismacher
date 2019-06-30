using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Fluxel.Ebay.PreisMacher.Lib;
using HitWork.Presentation.Command;

namespace Fluxel.Ebay.PreisMacher.Main
{
    public class CalcCommand : CommandBase
    {
        private readonly MainController _mainController;

        public CalcCommand(MainController mainController)
        {
            _mainController = mainController;
        }

        public override void Execute(object parameter)
        {
            var m = this._mainController.ViewModel;
            var shippingVat = 1.19m;

            if (m.SelectedEbayCategory == null)
            {
                MessageBox.Show("Bitte wählen Sie eine eBay-Kategorie aus.", "Keine eBay-Kategorie",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            var r = CalculatorRepository.ByCategoryAndPayPal(m.SelectedEbayCategory,
                m.Net + m.Shipping, m.PayPalFee, m.EbayListingFee/100m);

            var nettoShipping = m.Shipping * (m.ShippingExclusive ? 1 : 0);
            var bruttoShipping = nettoShipping * (m.BruttoExlusiveShipping ? shippingVat : 1);

            m.NettoVk = r.NettoVk - nettoShipping;
            m.BruttoVk = r.BruttoVk - bruttoShipping;
            m.BruttoShipping = bruttoShipping;
            m.Fee = r.Fee;
        }
    }
}
