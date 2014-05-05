using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invensoft.Models;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace Invensoft
{
    public partial class SalesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //reportSales.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            //reportSales.LocalReport.ReportPath = Server.MapPath("~/Sales.rdlc");
            //reportSales.LocalReport.DataSources.Add(new ReportDataSource("Sales", GetSalesReport()));
        }

        protected void exportTo_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string fileName = string.Empty;

            switch (exportOptions.SelectedValue)
            {
                case "Excel":
                    fileName = "SalesReport.xls";
                    break;
                case "PDF":
                    fileName = "SalesReport.pdf";
                    break;
                default:
                    break;
            }

            reportSales.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            reportSales.LocalReport.ReportPath = Server.MapPath("~/Sales/Sales.rdlc");
            reportSales.LocalReport.DataSources.Add(new ReportDataSource("dsSales", GetSalesReport()));

            byte[] bytes = reportSales.LocalReport.Render(exportOptions.SelectedValue, null, out mimeType, out encoding, out extension, out streamids, out warnings);

            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.ContentType = mimeType;
            Response.AddHeader("content-length", bytes.Length.ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

            //FileStream fs = new FileStream(@"C:\SalesReport.xls", FileMode.Create);
            //fs.Write(bytes, 0, bytes.Length);
            //fs.Close();
            //reportSales.LocalReport.DataSources.Clear();
            //reportSales.LocalReport.DataSources.Add()

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=SalesReport.xlsx");
            //Response.Charset = "";
            //Response.ContentType = "application/ms-excel";

            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    salesReportGrid.RenderControl(hw);
            //    Response.Write(sw.ToString());
            //    Response.End();
            //}
        }

        public IQueryable<vSalesByYear> GetSalesReport()
        {
            var _db = new Invensoft.Models.AdventureWorks2012Entities();


            /*
             SELECT [ProductNumber], [Name], SUM([OrderQty]) Quantity, SUM([LineTotal]) TotalCost
        FROM [AdventureWorks2012].[Sales].[SalesOrderDetail] d inner join
             [AdventureWorks2012].[Sales].[SalesOrderHeader] h on
             d.SalesOrderID = h.SalesOrderID
             inner join [AdventureWorks2012].[Production].[Product] p
             on d.ProductID = p.ProductID
             GROUP BY [ProductNumber], [Name]
             order by [ProductNumber]
             */



            //var query = from d in _db.SalesOrderDetails
            //            join h in _db.SalesOrderHeaders on d.SalesOrderID equals h.SalesOrderID
            //            join p in _db.Products on d.ProductID equals p.ProductID
            //            group d by d.ProductID into g
            //            select new
            //            {
            //                ProductNumber = (from pr in _db.Products where pr.ProductID == g.Key select new { pr.ProductNumber }),
            //                Name = (from pr in _db.Products where pr.ProductID == g.Key select new { pr.Name }),
            //                Quantity = g.Sum(q => q.OrderQty),
            //                SalesTotal = g.Sum(q => q.LineTotal)
            //            };

            IQueryable<vSalesByYear> query = _db.vSalesByYears.OrderBy(s => s.ProductNumber);

            //if (categoryId.HasValue && categoryId > 0)
            // {
            //     query = query.Where(p => p.ProductSubcategoryID == categoryId);
            // }

            // if (!String.IsNullOrEmpty(categoryName))
            // {
            //     query = query.Where(p => String.Compare(p.ProductSubcategory.ProductCategory.Name, categoryName) == 0);
            // }

            return query;
        }
    }
}