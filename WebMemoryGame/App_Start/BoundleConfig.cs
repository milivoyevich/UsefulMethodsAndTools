using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebMemoryGame
{
    public class BoundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Assets/Main.css"             
                       ));
            bundles.Add(new ScriptBundle("~/Bundles/js").Include(
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/jquery-migrate-{version}.js",
                       "~/Scripts/Main.js"
                       ));
        }
    }
}