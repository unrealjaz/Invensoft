using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invensoft.Models;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Web.ModelBinding;

namespace Invensoft
{
    public partial class SalesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                years.DataBind();
                years.Items.Insert(0, "-- Select Year --");
            }
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
            reportSales.LocalReport.DataSources.Add(new ReportDataSource("dsSales", GetSalesReport(Convert.ToInt32(years.SelectedValue))));

            byte[] bytes = reportSales.LocalReport.Render(exportOptions.SelectedValue, null, out mimeType, out encoding, out extension, out streamids, out warnings);

            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.ContentType = mimeType;
            Response.AddHeader("content-length", bytes.Length.ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        public IQueryable GetYears()
        {
            var _db = new Invensoft.Models.AdventureWorks2012Entities();

            var query = (from y in _db.vSalesByYears
                         group y by y.Year into g
                         select new { Year = g.Key });

            return query.OrderBy(y => y.Year);
        }

        public IQueryable<vSalesByYear> GetSalesReport([Control("years")] int? year)
        {
            var _db = new Invensoft.Models.AdventureWorks2012Entities();

            IQueryable<vSalesByYear> query = _db.vSalesByYears;

            if (year.HasValue && year > 0)
            {
                query = query.Where(p => p.Year == year);
            }

            // if (!String.IsNullOrEmpty(categoryName))
            // {
            //     query = query.Where(p => String.Compare(p.ProductSubcategory.ProductCategory.Name, categoryName) == 0);
            // }

            return query.OrderBy(s => s.ProductNumber);
        }
    }
}