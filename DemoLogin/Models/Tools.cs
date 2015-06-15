using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using HtmlAgilityPack;

namespace DemoLogin.Models
{
    public class Tools
    {
        public static string NoHTML(string Htmlstring)
        {

            ////删除脚本

            //Htmlstring = Regex.Replace(Htmlstring, @"]*?>.*?", "",

            //RegexOptions.IgnoreCase);

            ////删除HTML

            //Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",

            //RegexOptions.IgnoreCase);

            //Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",

            //RegexOptions.IgnoreCase);

            //Htmlstring.Replace("<", "");

            //Htmlstring.Replace(">", "");

            //Htmlstring.Replace("\r\n", "");

            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            var document = new HtmlDocument();
            document.LoadHtml(Htmlstring);
            HtmlNode rootNode = document.DocumentNode;
            string _content = rootNode.InnerText;
            
            return _content;

        }
    }
}