using System.Collections.Generic;
using System.Linq;

namespace EssentialTools.Models {

    public class LinqValueCalculator : IValueCalculator {
        private IDiscountHelper discounter;

        public LinqValueCalculator(IDiscountHelper discounterParam) {
            discounter = discounterParam;
        }

        public decimal ValueProducts(IEnumerable<Product> products) {
            return  discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}