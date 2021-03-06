﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Invensoft
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterCustomRoutes(RouteTable.Routes);

            RoleActions roleActions = new RoleActions();
            roleActions.CreateAdmin();
            roleActions.CreateProductionUser();
            roleActions.CreateSalesUser();
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "ProductsByCategoryRoute",
                "Category/{categoryName}",
                "~/Production/ProductList.aspx"
                );

            routes.MapPageRoute(
                "ProductByNameRoute",
                "Product/{productName}",
                "~/Production/ProductDetails.aspx"
                );

            routes.MapPageRoute(
                "ProductById",
                "Product/{productId}",
                "~/Production/ProductDetails.aspx"
                );
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex is HttpUnhandledException)
            {
                if (ex.InnerException != null)
                {
                    ex = new Exception(ex.InnerException.Message);
                    //Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
                }
            }
        }
    }
}