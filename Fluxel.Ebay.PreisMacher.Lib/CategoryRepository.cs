using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxel.Ebay.PreisMacher.Lib
{
    public static class CategoryRepository
    {
        private static readonly EbayCategory[] Categories = {
            new EbayCategory("Computer", 0.05m, 0.05m)
        };

        public static IEnumerable<EbayCategory> GetEbayCategories()
        {
            return Categories;
        }

    }
}
