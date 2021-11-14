using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Automanager.Core.UtilsCommon
{
    public class HtmlUtil
    {
        private static readonly Regex HtmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty, RegexOptions.Compiled);
        }

        public static string StripTagsRegexCompiled(string source)
        {
            return HtmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        ///     Xóa các thẻ html có trong removeTags.
        ///     removeTags format: "script|embed|object|frameset|frame|iframe|meta|link|style|a"
        /// </summary>
        public static string FillterHtmlTag(string html, string removeTags)
        {
            var ret = Regex.Replace(html, @"</?(?i:" + removeTags + ")(.|\n)*?>", "");
            ret = ret.Replace("javascript", "");
            return ret;
        }

        /// <summary>
        ///     Định dạng lại chuỗi keyword thành chuối không có dấu cách sau dấu phẩy và đưa về ký tự thường. VD: Tăng thanh Hà,
        ///     Diễn viên -> ,tăng thanh hà,diễn viên,
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConvertKeyword(string source)
        {
            var sb = new StringBuilder();
            var result = "";

            if (source.Trim().Length > 0)
            {
                source.Replace(",,", "");
                source = source.Trim();

                if (source.StartsWith(","))
                    source = source.Substring(1, source.Length - 1 - source.IndexOf(",", StringComparison.Ordinal));

                if (source.EndsWith(","))
                    source = source.Substring(0, source.LastIndexOf(",", StringComparison.Ordinal));

                var arr = source.Split(',');

                for (var i = 0; i < arr.Length; i++)
                    if (i < arr.Length - 1)
                        sb.Append(arr[i].Trim().ToLower() + ",");
                    else
                        sb.Append(arr[i].Trim().ToLower());

                sb.ToString().Replace(",,", "");

                if (sb.ToString().Trim().Length > 0)
                    result = "," + sb + ",";

                return result;
            }

            return "";
        }
    }
}
