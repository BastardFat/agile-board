using System.Web;
using System.Web.Optimization;

namespace BastardFat.ThirdVersion.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                "~/Scripts/material.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ractive").Include(
                "~/Scripts/ractive.js",
                "~/Scripts/api-interaction.js"));

            bundles.Add(new StyleBundle("~/Content/material").Include(
                "~/Content/material-icons.css",
                "~/Content/material.green-blue.min.css"));
        }
    }
}