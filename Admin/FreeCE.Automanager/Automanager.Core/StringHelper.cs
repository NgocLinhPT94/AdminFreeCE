using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Core
{
    public static class StringHelper
    {
        /// <summary>
        /// Ham loai bo cac nguy co gay ra SQL Injection cua 1 chuoi ky tu
        /// Loai bo cac ky tu dac biet nhu:insert,update,select,delete
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static bool RemoveSqlInjection(string inputString)
        {
            bool isSQLInjection = false;
            string[] sqlCheckList = { "--",";--",";","/*","*/","@@","@","char","nchar","varchar","nvarchar","alter","begin",
                                       "cast","create","cursor","declare","delete","drop","end","exec","execute","fetch","insert",
                                        "kill","select","sys","sysobjects","syscolumns","table","update"};
            string CheckString = inputString.Replace("'", "''");
            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    isSQLInjection = true;
                }
            }
            return isSQLInjection;
        }

        /// <summary>
        /// So sanh chuoi 1,2 là kiểu dạng văn bản (có xuống dòng, có chữ hoa chữ thường)
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static double Compare2StringBySentence(string str1, string str2)
        {
            var lengthOfStr2Pre = 0;

            try
            {
                str1 = str1.Replace(" ", string.Empty).Replace("\n", ",").Replace("\t", string.Empty)
                    .Replace("\r", string.Empty).Replace(".", ",");
                str2 = str2.Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\t", string.Empty)
                    .Replace("\r", string.Empty).Replace(".", string.Empty).Replace(",", string.Empty);

                lengthOfStr2Pre = str2.Length;
                var str1Array = str1.Split(',');
                foreach (var t in str1Array)
                {
                    if (str2.Length < 1) return 100;

                    var strTemp = t.Trim();
                    if (string.IsNullOrEmpty(strTemp)) continue;
                    str2 = str2.Replace(strTemp, string.Empty);
                }
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }

            return (double)(lengthOfStr2Pre - str2.Length) / lengthOfStr2Pre * 100;
        }

        /// <summary>
        /// Remove 1 bien query string trong 1 chuoi url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryStringVarName"></param>
        /// <returns></returns>
        public static string RemoveQueryStringvarFromURL(string url, string queryStringVarName)
        {
            //ex: http:tpb.vn?id=01&name=linh
            if (string.IsNullOrEmpty(url)) return url;

            var urlArray = url.Split('?');
            if (urlArray.Length == 2)
            {
                var mainUrl = urlArray[0];
                var queryStringArray = urlArray[1].Split('&');

                url = mainUrl;
                foreach (var t in queryStringArray)
                {
                    if (t.Contains(queryStringVarName + "=")) continue;
                    if (url == mainUrl)
                        url += "?" + t;
                    else
                        url += "&" + t;
                }
            }
            else
            {
                return url;
            }
            return url;
        }

        /// <summary>
        ///     Hàm lấy substring có xử lý việc cắt ở giữa từ
        /// </summary>
        /// <param name="input">Chuỗi truyền vào</param>
        /// <param name="len">Số ký tự cần lấy</param>
        /// <returns></returns>
        public static string SubString(string input, int len)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (!input.Contains(" ")) return input;
            if (len > input.Length) return input;
            return input.Substring(0, input.Substring(0, len).LastIndexOf(" ", StringComparison.Ordinal)) + "...";
        }

        /// <summary>
        ///     Bỏ các tham số của url
        /// </summary>
        /// <param name="url">Url có tham số</param>
        /// <returns>Url gốc</returns>
        public static string CutUrlForFacebookLike(string url)
        {

            if (!string.IsNullOrEmpty(url))
            {
                url = url.Replace("%3a8288", "").Replace(":8288", "");
                //StringSplitOption.RemoveEmptyEntries dung sẽ xóa đi các vị trí rỗng trong chuỗi gây ra bởi các Escape. 
                //Nó sẽ được thực thi sau khi chuỗi được tách.
                var list = url.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
                if (list.Any())
                    return list[0];
            }
            return url;
        }
    }

    
}
