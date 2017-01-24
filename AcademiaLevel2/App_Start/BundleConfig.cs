using System.Web;
using System.Web.Optimization;

namespace AcademiaLevel2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

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

            bundles.Add(new StyleBundle("~/Content/frends/css").Include(
                     "~/Content/Frends/frends.css"
                     ));
            bundles.Add(new ScriptBundle("~/Scripts/friends").Include(
               "~/Scripts/jquery-1.10.2.min.js",
               "~/Scripts/Friends.js"));
            bundles.Add(new StyleBundle("~/Content/Post/css").Include(
                    "~/Content/Post/post.css"
                    ));
            bundles.Add(new ScriptBundle("~/Scripts/post").Include(
               "~/Scripts/jquery-1.10.2.min.js",
               "~/Scripts/post.js"));

            bundles.Add(new ScriptBundle("~/Scripts/angular-components").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-messages.js",
                        "~/Scripts/angular-ui-router.js",
                        "~/Scripts/ng-input.js",
                        "~/Scripts/ui-bootstrap-custom-2.2.0.min.js",
                        "~/Scripts/ui-bootstrap-custom-tpls-2.2.0.min.js",
                        "~/Scripts/angular-toastr.tpls.js",
                        "~/Scripts/ng-croppie.js",
                        "~/Scripts/ng-file-upload-all.min.js",
                        "~/Scripts/ng-file-upload.min.js",
                        "~/Scripts/freewall.js",
                        "~/Scripts/angulargrid.min.js"

                      ));

            bundles.Add(new ScriptBundle("~/Scripts/angular-app").Include(
                        "~/Scripts/Post/app.js",
                        "~/Scripts/Post/app.home.js",
                        "~/Scripts/Post/app.component.js",
                        "~/Scripts/Post/app.directive.js",
                        "~/Scripts/Post/app.services.js"
                      ));

        }
    }
}
