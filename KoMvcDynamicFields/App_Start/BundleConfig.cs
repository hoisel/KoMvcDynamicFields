﻿using System.Web;
using System.Web.Optimization;

namespace KoMvcDynamicFields
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // ref:http://stackoverflow.com/questions/12533591/why-are-my-style-bundles-not-rendering-correctly-in-asp-net-mvc-4
            bundles.Add(new StyleBundle("~/bundles/all/css").Include(              
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}