using System;
using System.Configuration;
using System.Web;

namespace Automanager.Core
{
    public class Config
    {
        #region General config
        public static string ConnectionString => ConfigurationManager.AppSettings["FreeCE_ConnectString"]; // => tương đương return
        public static string UploadUrl => ConfigurationManager.AppSettings["UploadUrl"];

        public static string UploadPath()
        {
            var x = ConfigurationManager.AppSettings["UploadPath"];
            return x.Contains(":\\") ? x : HttpContext.Current.Server.MapPath(x);
        }
        #endregion
    }
}
