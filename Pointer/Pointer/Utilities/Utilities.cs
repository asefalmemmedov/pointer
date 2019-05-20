using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pointer.Utilities
{
    public static class Utilities
    {
        public static void RemoveImage(string image)
        {
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Public/images"), image);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static void RemoveImageAsAdministrator(string image)
        {
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Areas/Admin/Public/images"), image);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}