using Invensoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invensoft.Production
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetProductPrice(Product p)
        {
            var _db = new AdventureWorks2012Entities();
            var product = _db.Products.Where(pr => pr.ProductID == p.ProductID).FirstOrDefault();

            product.ListPrice = p.ListPrice;

            TryUpdateModel(product);

            if (ModelState.IsValid)
            {
                _db.SaveChanges();
            }
        }

        public IQueryable<Product> GetProduct([QueryString("productId")] int? productId)
        {
            var _db = new AdventureWorks2012Entities();
            IQueryable<Product> query = _db.Products;

            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else
                query = null;

            return query;
        }
    }
}