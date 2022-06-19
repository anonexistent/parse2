using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Net.Http;
using AngleSharp;
using System.Windows.Controls;

namespace parse2.Model.parser
{
    internal class ParserOne
    {
        //погода в россии - список областей
        public string MainUrl { get{ return @"https://yandex.ru/pogoda/region/225"; } set { MainUrl = value; } }
        public string ChildUrl { get { return @"https://clck.ru/rayNK"; } set { MainUrl = value; } }        

        private string _result;
        public string result
        {
            get { return _result; }
            set { _result = value; }
        }



        //      \/         

        //private ObservableCollection<MainWindowModel> Work()
        //{
        //    ObservableCollection<MainWindowModel> result = new ObservableCollection<MainWindowModel>();

        //    WebClient client = new WebClient();

        //    string pageSource = client.DownloadString(MainUrl);

        //    string regStr = @"<a class=""link place-list__item-name oNd0aD8s link_js_inited"" tabindex=""0"" href=""(\w*)?via=reg"" \w*";

        //    string resultSource = Regex.Match(pageSource, regStr).Groups[1].Value;

        //    return result;
        //}

        public string Goo()
        {
            WebClient client = new WebClient();

            string pageSource = client.DownloadString(ChildUrl);

            string regStr = @"<a class=""link place-list__item-name oNd0aD8s link_js_inited""(\w*)";

            string resultSource = Regex.Match(pageSource, regStr).Groups[0].Value;

            return pageSource;
        }



        public async void Go()
        {
            using (WebClient client = new WebClient())
            {
                //using var context = BrowsingContext.New(Configuration.Default);
                //context.SetCookie(new Cookie("123"));
                //using var doc = await context.OpenAsync(MainUrl);
                //var title = doc.GetElementsByClassName("Text Text_weight_regular Text_typography_body-long-m")[0];
                //result = title.NodeValue;



                //client.Encoding = System.Text.Encoding.UTF8;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                //var htmlData = client.DownloadData(MainUrl);
                //string htmlCode = Encoding.UTF8.GetString(htmlData);

                //result = htmlCode;

                ////var parts1 = Regex.Split(htmlCode, "nick=upread.ru\">");
                ////var parts2 = Regex.Split(parts1[1], " ");
                ////int numberPosition = Convert.ToInt32(Regex.Replace(parts2[0], @"[^\d]+", ""));

                ////this.Invoke(new MethodInvoker(delegate {
                ////    label1.Text = Convert.ToString("Позиция: " + numberPosition + " Время: " + System.DateTime.Now.ToLongTimeString());
                ////}));
            }
        }
    }
}
