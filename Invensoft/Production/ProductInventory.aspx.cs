using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invensoft.Models;
using Microsoft.Reporting.WebForms;
using System.Web.ModelBinding;

namespace Invensoft.Production
{
    public partial class ProductInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                location.DataBind();
                location.Items.Insert(0, "-- Select Location --");
            }
        }
        public IQueryable<Location> GetLocations()
        {
            AdventureWorks2012Entities _db = new AdventureWorks2012Entities();
            IQueryable<Location> query = _db.Locations;

            return query.OrderBy(i => i.LocationID);
        }

        public IQueryable<vProductInventory> GetProductInventory([Control("location")] int? locationId)
        {
            AdventureWorks2012Entities _db = new AdventureWorks2012Entities();
            IQueryable<vProductInventory> query = _db.vProductInventories;

            if (locationId.HasValue && locationId > 0)
            {
                query = query.Where(p => p.LocationID == locationId);
            }

            return query.OrderBy(i => i.ProductNumber).OrderBy(i => i.LocationID);
        }

        public void exportTo_Click(object sender, EventArgs e)
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
                    fileName = "ProductInventory.xls";
                    break;
                case "PDF":
                    fileName = "ProductInventory.pdf";
                    break;
                default:
                    break;
            }

            productInventoryReport.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            productInventoryReport.LocalReport.ReportPath = Server.MapPath("~/Production/ProductInventory.rdlc");
            productInventoryReport.LocalReport.DataSources.Add(new ReportDataSource("dsProductInventory", GetProductInventory(Convert.ToInt32(location.SelectedValue))));

            byte[] bytes = productInventoryReport.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamids, out warnings);

            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.ContentType = mimeType;
            Response.AddHeader("content-length", bytes.Length.ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}