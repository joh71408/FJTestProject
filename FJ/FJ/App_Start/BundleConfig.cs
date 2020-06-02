using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FJ
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/datatable.js",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/jquery.easing.min.js",
                "~/Scripts/sb-admin-2.js",
                "~/Content/datatables/jquery.dataTables.min.js",
                "~/Content/datatables/dataTables.bootstrap4.js",
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/datepicker.js"      
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/fontawesome-free/css/all.min.css",
                "~/Content/sb-admin-2.min.css",
                "~/Content/dataTables.bootstrap4.min.css",
                "~/Content/bootstrap-datetimepicker.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/loginjs").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/jquery.easing.min.js",
                "~/Scripts/sb-admin-2.js"  
                ));

            bundles.Add(new StyleBundle("~/Content/logincss").Include(
                "~/Content/fontawesome-free/css/all.min.css",
                "~/Content/sb-admin-2.min.css"
                ));


            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

        }
    }
}