using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using Fluxel.Ebay.PreisMacher.Lib;
using Fluxel.Ebay.PreisMacher.Main;
using Fluxel.Ebay.PreisMacher.Properties;
using HitWork.Controller;
using HitWork.Services;

namespace Fluxel.Ebay.PreisMacher
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /*var cat = CategoryRepository.GetEbayCategories().First();
            var pp = PayPalFeeRepository.ForNormal(0);
            var r = CalculatorRepository.ByCategoryAndPayPal(cat, 95, pp);
            
            Console.WriteLine(r.NettoVk);
            Console.WriteLine(r.Fee);

            Console.ReadLine();*/       

            var boot = Bootstrap.Singleton;
            boot.Boot(Resource.Program_Main_Fluxel_eBay_Preismacher);
            var ds = boot.DependencyService;

            var ws = ds.Find<IWindowService>();
            ws.Navigate(ds.Find<MainController>());
            ws.BaseWindow.Height = 700;
            ws.BaseWindow.MinHeight = ws.BaseWindow.Height;
            ws.BaseWindow.Width = 400;
            ws.BaseWindow.MinWidth = ws.BaseWindow.Width;

            boot.Run();
        }
    }
}
