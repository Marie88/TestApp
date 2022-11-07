using System.Linq;

namespace IoCore.SharedReadKernel.Product
{
    internal static class ProductSpecifications
    {
        public static IQueryable<T> That<T>(this IQueryable<T> queryable) where T : class
        {
            return queryable;
        }

        public static IQueryable<Product> AreApprovedForUse(this IQueryable<Product> products)
        {
            return products.Where(product => product.Status == "APPROVEDFORUSE");
        }

        public static IQueryable<Product> AreDeprecated(this IQueryable<Product> products)
        {
            return products.Where(product => product.Status == "DEPRECATED");
        }
        
        public static IQueryable<Product> AreDraft(this IQueryable<Product> products)
        {
            return products.Where(product => product.Status == "DRAFT");
        }
    }
}
