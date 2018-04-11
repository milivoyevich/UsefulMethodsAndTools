using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace WebMemoryGame
{
    public class BoundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var cssBundle = new StyleBundle("~/Content/css");
            var jsBundle = new ScriptBundle("~/Bundles/js");                  
            cssBundle.Transforms.Add(new FileHashVersionBundleTransform());
            jsBundle.Transforms.Add(new FileHashVersionBundleTransform());        
           
            bundles.Add(cssBundle.Include(
                       "~/Assets/Main.css"             
                       ));
            bundles.Add(jsBundle.Include(
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/jquery-migrate-{version}.js",
                       "~/Scripts/Main.js"
                       ));
        }
    }
    public class FileHashVersionBundleTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            foreach (var file in response.Files)
            {
                using (FileStream fs = File.OpenRead(HostingEnvironment.MapPath(file.IncludedVirtualPath)))
                {
                    //get hash of file contents
                    byte[] fileHash = new SHA256Managed().ComputeHash(fs);

                    //encode file hash as a query string param
                    string version = HttpServerUtility.UrlTokenEncode(fileHash);
                    file.IncludedVirtualPath = string.Concat(file.IncludedVirtualPath, "?v=", version);
                }
            }
        }
    }
}