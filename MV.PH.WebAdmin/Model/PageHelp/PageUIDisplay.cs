using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MV.PH.WebAdmin.Model.PageHelp
{
    public class PageUIDisplay
    {
        public static string Display(int curPage, int countPage, string url, int extendPage)
        {
            return Display(curPage, countPage, url, extendPage, "page");
        }
        public static string Display(int curPage, int countPage, string url, int extendPage, string pagetag)
        {
            return Display(curPage, countPage, url, extendPage, pagetag, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curPage">当前页</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">连接地址</param>
        /// <param name="extendPage">结束导航 例如：页码只显示1-8，此时就为8</param>
        /// <param name="pagetag">连接地址后面的参数</param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public static string Display(int curPage, int countPage, string url, int extendPage, string pagetag, string anchor)
        {
            if (pagetag == "")
                pagetag = "page";
            int startPage = 1;   //初始页码
            int endPage = 1;     //截止页码
            

            if (string.IsNullOrWhiteSpace(url))
            {
                url = HttpContext.Current.Request.RawUrl;
                string baseUrl = "";
                NameValueCollection nvc = null;
                ParseUrl(url, out baseUrl, out nvc);
                url = baseUrl + "?";
                foreach (string key in nvc.Keys)
                {
                    Console.WriteLine("{0}:{1}", key, nvc[key]);
                    if (key != "page")
                        url += key + "=" + nvc[key] + "&";
                }
                if (url.EndsWith("&"))
                    url = url.TrimEnd('&');
            }
            if (url.IndexOf("?") > 0)
                url = url + "&";
            else
                url = url + "?";

            int syy = curPage - 1 <= 1 ? 1 : curPage - 1;
            int xyy = curPage + 1 > countPage ? countPage : curPage + 1;
            string t1 = "<a href=\"" + url + "&" + pagetag + "=1\"> 首页</a><a href=\"" + url + "&" + pagetag + "=" + syy;
            string t2 = "<a href=\"" + url + "&" + pagetag + "=" + xyy + "\">下一页</a><a href=\"" + url + "&" + pagetag + "=" + countPage;
            if (anchor != null)
            {
                t1 += anchor;
                t2 += anchor;
            }
            t1 += "\">上一页</a>";//上一页
            t2 += "\">尾页</a>";//下一页

            


            if (countPage < 1)
                countPage = 1;
            if (extendPage < 3)
                extendPage = 2;

            if (countPage > extendPage)
            {
                if (curPage - (extendPage / 2) > 0)
                {
                    if (curPage + (extendPage / 2) <= countPage)
                    {
                        startPage = curPage - (extendPage / 2)+1;
                        endPage = startPage + extendPage - 1;
                    }
                    else
                    {
                        endPage = countPage;
                        startPage = endPage - extendPage + 1;
                        //t2 = "";
                    }
                }
                else
                {
                    endPage = extendPage;
                    //t1 = "";
                }
            }
            else
            {
                startPage = 1;
                endPage = countPage;
            }

            StringBuilder s = new StringBuilder("");

            if (curPage <= 1)
            {
                s.Append("<span class=\"disabled\">首页</span><span class=\"disabled\">上一页</span>");
            }
            else
            {
                s.Append(t1);
            }

            
            for (int i = startPage; i <= endPage; i++)
            {

                if (i == curPage)
                {
                    s.Append("<span class=\"current\">"+i+"</span>");
                }
                else
                {
                    s.Append("<a href=\"");
                    s.Append(url);
                    s.Append(pagetag);
                    s.Append("=");
                    s.Append(i);
                    if (anchor != null)
                    {
                        s.Append(anchor);
                    }
                    s.Append("\">");
                    s.Append(i);
                    s.Append("</a>");
                }
            }

            if (curPage>=countPage)
            {
                s.Append("<span class=\"disabled\">下一页</span><span class=\"disabled\">尾页</span>");
            }
            else
            {
                s.Append(t2);
            }
            

            return s.ToString();
        }

        private static void ParseUrl(string url, out string baseUrl, out NameValueCollection nvc)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            nvc = new NameValueCollection();
            baseUrl = "";
            if (url == "")
                return;
            int questionMarkIndex = url.IndexOf('?');
            if (questionMarkIndex == -1)
            {
                baseUrl = url;
                return;
            }
            baseUrl = url.Substring(0, questionMarkIndex);
            if (questionMarkIndex == url.Length - 1)
                return;
            string ps = url.Substring(questionMarkIndex + 1);
            // 开始分析参数对  
            Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
            MatchCollection mc = re.Matches(ps);
            foreach (Match m in mc)
            {
                nvc.Add(m.Result("$2").ToLower(), m.Result("$3"));
            }
        }


    }
}