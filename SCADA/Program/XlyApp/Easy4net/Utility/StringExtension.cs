using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy4net.Utility
{
    public static class StringExtension
    {
        /// <summary>
        /// 这种格式的日期时间字符串转换成日期时间：20090624101315
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime2(this string str)
        {
            DateTime dt;
            if (DateTime.TryParseExact(str, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                return DateTime.Parse(dt.ToString());
            }
            return DateTime.MinValue;
        }
        /// <summary>
        /// 截字符串
        /// </summary>
        public static string LeftString(this string str, int length)
        {
            return LeftString(str, length, "");
        }
        /// <summary>
        /// 截字符串
        /// </summary>
        public static string LeftStringASIIC(this string str, int length)
        {
            return LeftStringASIIC(str, length, "");
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">需要被截取的字符串</param>
        /// <param name="length">需要在多少长度后截取</param>
        /// <param name="ellipsis">需要在字符串后添加的字符</param>
        /// <returns></returns>
        public static string LeftString(this string str, int length, string ellipsis)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            string result = "";//返回值   
            if (str.Length <= length)
            {
                result = str;
            }
            else
            {
                result = str.Substring(0, length) + ellipsis;
            }
            return result;

        }
        /// <summary>
        /// 截字符串
        /// </summary>
        public static string LeftStringASIIC(this string str, int length, string ellipsis)
        {
            string result = "";//返回值   
            if (str.Length <= length / 2)
            {
                result = str;
            }
            else
            {
                int t = 0;
                char[] tmp = str.ToCharArray();
                for (int i = 0; i < str.Length; i++)
                {
                    int c;
                    c = (int)tmp[i];
                    if (c < 0)
                        c = c + 65536;
                    if (c > 255)
                        t = t + 2;
                    else
                        t = t + 1;
                    if (t > length)
                        break;
                    //return str;
                    //break;
                    result = result + str.Substring(i, 1);
                }
                result = result + ellipsis;
            }
            return result;

        }

        public static string RemonveLastFlag(this string str, string flag)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.LastIndexOf(flag) == str.Length - 1)
                    return str.Remove(str.Length - 1, 1);
                else
                    return str;
            }
            else return "";
        }

        public static string RemonveLastFlag(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.RemonveLastFlag(",");
            }
            return "";
        }

        public static string ToHtml(this string str)
        {
            return str!=null?str.Replace("\n", "<br/>"):"";
        }

        /// <summary>
        /// 输出固定位数的数字字符串，如果不到位数用0补足。如000123
        /// </summary>
        /// <param name="number"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateNumberString(int number,int length)
        {
            string s = number.ToString();
            while (s.Length < length)
            {
                s = "0" + s;
            }
            return s;
        }

        /// <summary>
        /// 将传输文本中的+和& 符号编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FinalHandle(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                //str = Regex.Replace(str, @"/\+/g", "%2B");
                //str = Regex.Replace(str, @"/\&/g", "%26");
                str = str.Replace("+", "%2B").Replace("&", "%26");
            }
            return str;
        }
        /// <summary>
        /// 转换为整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInteger(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                str = Regex.Replace(str, "[^0-9^-]", string.Empty);
                if (str != "")
                {
                    str = str.LeftString(1) + str.Substring(1).Replace('-', '\0');
                }
                int result;
                int.TryParse(str, out result);
                return result;
            }
            else
                return 0;
        }

        public static decimal ToDecimal(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(",", "");
                if (str != "")
                {
                    str = str.LeftString(1) + str.Substring(1).Replace('-', '\0');
                }

                decimal result;
                decimal.TryParse(str, out result);
                return result;
            }

            return 0;
        }
        //不进行四舍五入取小数点后6位
        public static decimal toDeci(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str != "")
                {
                    int dian = str.IndexOf(".");
                    str = str.LeftString(dian + 7);
                }
                decimal result;
                decimal.TryParse(str, out result);
                return result;
            }
            return 0;

        }

        public static float ToDouble(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str != "")
                {
                    str = str.LeftString(1) + str.Substring(1).Replace('-', '\0');
                }

                float result;
                float.TryParse(str, out result);
                return result;
            }

            return 0f;
        }

        public static DateTime ToDateTime(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime result;
                DateTime.TryParse(str, out result);
                return result;
            }

            return DateTime.MinValue;
        }

        public static string[] SpiltComma(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Split(new char[] { ',', '，', ';', '；', '、','-' });
            }
            else
                return new string[1];
        }

        public static IList<string> SpiltStrToList(this string str)
        {
            string[] strs = SpiltComma(str);
            IList<string> list = new List<string>();
            foreach (string s in strs)
            {
                if (s != null && s.Trim() != string.Empty)
                    list.Add(s.Trim());
            }
            return list;
        }

        public static IList<int> SpiltStrToIntList(this string str)
        {
            string[] strs = SpiltComma(str);
            IList<int> list = new List<int>();
            foreach (string s in strs)
            {
                if (s != null && s.Trim() != string.Empty)
                    list.Add(s.Trim().ToInteger());
            }
            return list;
        }

        public static string ReplaceToColor(this string str, string keyword, string color)
        {
            string style = "<span style=\"color:{0}\">{1}</span>";
            style = string.Format(style, color, keyword);

            if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(color) && !string.IsNullOrEmpty(keyword))
            {
                str = str.Replace(keyword, style);
            }
            return str;
        }

       

        public static string StripHTML(this string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                result = source.Replace("/r", "");        // Replace line breaks with space because browsers inserts space
                result = result.Replace("/n", "");        // Replace line breaks with space because browsers inserts space
                result = result.Replace("/t", string.Empty);    // Remove step-formatting
                result = System.Text.RegularExpressions.Regex.Replace(result, @"( )+", "");    // Remove repeating speces becuase browsers ignore them

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*head([^>])*>", "<head>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"(<( )*(/)( )*head( )*>)", "</head>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, "(<head>).*(</head>)", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*script([^>])*>", "<script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"(<( )*(/)( )*script( )*>)", "</script>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result, @"(<script>)([^(<script>/.</script>)])*(</script>)",string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"(<script>).*(</script>)", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*style([^>])*>", "<style>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"(<( )*(/)( )*style( )*>)", "</style>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, "(<style>).*(</style>)", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*td([^>])*>", "/t", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*br( )*>", "/r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*li( )*>", "/r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*div([^>])*>", "/r/r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*tr([^>])*>", "/r/r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*p([^>])*>", "/r/r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images, comments etc - anything thats enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<[^>]*>", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result, @"&nbsp;", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result, @"&bull;", " * ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"&lsaquo;", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"&rsaquo;", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"&trade;", "(tm)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"&frasl;", "/", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"<", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @">", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"&copy;", "(c)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, @"&reg;", "(r)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result, @"&(.{2,6});", string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testng
                //System.Text.RegularExpressions.Regex.Replace(result, this.txtRegex.Text,string.Empty, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("/n", "/r");

                // Remove extra line breaks and tabs: replace over 2 breaks with 2 and over 4 tabs with 4. 
                // Prepare first to remove any whitespaces inbetween the escaped characters and remove redundant tabs inbetween linebreaks
                result = System.Text.RegularExpressions.Regex.Replace(result, "(/r)( )+(/r)", "/r/r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, "(/t)( )+(/t)", "/t/t", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, "(/t)( )+(/r)", "/t/r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, "(/r)( )+(/t)", "/r/t", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result, "(/r)(/t)+(/r)", "/r/r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);    // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result, "(/r)(/t)+", "/r/t", System.Text.RegularExpressions.RegexOptions.IgnoreCase);        // Remove multible tabs followind a linebreak with just one tab
                string breaks = "/r/r/r";        // Initial replacement target string for linebreaks
                string tabs = "/t/t/t/t/t";        // Initial replacement target string for tabs
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "/r/r");
                    result = result.Replace(tabs, "/t/t/t/t");
                    breaks = breaks + "/r";
                    tabs = tabs + "/t";
                }
                result = result.Replace(@"&nbsp;", "");
                return result = result.Replace("/r", "");

            }
            catch
            {
            }
            return source;
        }

    }
}
