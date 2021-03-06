﻿namespace SnapCot.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                   "~/Scripts/KendoUI/kendo.all.min.js",
                   "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                  "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/background").Include(
                     "~/Content/background-images.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                   "~/Content/KendoUI/kendo.common.min.css",
                   "~/Content/KendoUI/kendo.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui")
               .Include("~/Content/themes/base/all.css"));

            bundles.Add(new StyleBundle("~/Inrastructure/notification")
              .Include("~/Inrastructure/css/notifier.css"));

            bundles.Add(new ScriptBundle("~/bundles/notification")
             .Include("~/Inrastructure/js/jquery-2.1.1.min.js",
                      "~/Inrastructure/js/notifier.js"));
        }
    }
}
