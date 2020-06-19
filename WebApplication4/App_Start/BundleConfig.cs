using System.Web;
using System.Web.Optimization;

namespace WebApplication4
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryTemplate").Include(
                        "~/Scripts/vendor/jquery-easing/jquery.easing.min.js",
                        "~/Scripts/js/sb-admin-2.min.js",
                        "~/Scripts/vendor/chart.js/Chart.min.js",
                        "~/Scripts/js/demo/chart-area-demo.js",
                        "~/Scripts/js/demo/chart-pie-demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/vendor/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.min.css",
                      "~/Content/site.css",
                      "~/Scripts/css/sb-admin-2.css",
                      "~/Scripts/vendor/fontawesome-free/css/all.min.css"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryburger").Include(
                        "~/Scripts/vendor/jquery/jquery.min.js",
                        "~/Scripts/vendor/bootstrap/js/bootstrap.bundle.min.js"));
        }
    }
}
