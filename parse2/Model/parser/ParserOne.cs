using MSHTML;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace parse2.Model.parser
{
    public class ParserOne : INotifyPropertyChanged
    {
        //погода в россии - список областей
        public static string MainUrl { get { return @"https://yandex.ru/pogoda/region/225"; } }
        //public string ChildUrl { get { return @"https://clck.ru/rayNK"; } set { MainUrl = value; } }        

        public static string Page { get; set; }

        private string regionName;
        public string RegionName
        {
            get { return regionName; }
            set { regionName = value; }
        }

        private string regionSource;
        public string RegionSource
        {
            get { return regionSource; }
            set { regionSource = value; }
        }



        public static ObservableCollection<ParserOne> RegionsSource { get; set; }


        public static void GetResult()
        {
            string ClassRegionPattern;

            using (WebBrowser web = new WebBrowser())
            {
                web.Visibility = Visibility.Visible;
                web.Navigate(MainUrl);
                HTMLDocument doc = (HTMLDocument)web.Document;
                Page = doc.documentElement.innerHTML;
                ClassRegionPattern = @"lass=.link place-list__item-name.{0,40}(pogoda.region.\d+)";

                FlowDocument flowdoc = new FlowDocument();
                Paragraph par = new Paragraph();
                par.Inlines.Add(Page);
                flowdoc.Blocks.Add(par);

            }

            var tempresult = Regex.Matches(Page, ClassRegionPattern);

            for (int i = 0; i < tempresult.Count; i++)
            {
                RegionsSource.Add(new ParserOne { RegionName = "н/д", RegionSource = tempresult[i].ToString() });
            }
        }

        public static void GetResultNew()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(MainUrl);
            MessageBox.Show(doc.ToString());
        }

        public ParserOne()
        {
            GetResultNew();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        //public static void Go()
        //{
        //      по нажатию кнопки передача строки куда-то согласно MVVM

        //HTMLDocument cc = (HTMLDocument)browser0.Document;
        //regexx = @"class=.link place-list__item-name.+(pogoda/region/.+)\?via.+</a>";

        ////lass=.link place-list__item-name.{0,40}(pogoda.region.)

        //page = cc.documentElement.innerHTML;

        //FlowDocument doc = new FlowDocument();
        //Paragraph par = new Paragraph();
        //par.Inlines.Add(page);
        //doc.Blocks.Add(par);
        //qq.zxc.Document = doc;

        //qq.Show();

        //resultik = Regex.Match(page, regexx).Groups[1].Value;
        //}

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

        //public string Goo()
        //{
        //    WebClient client = new WebClient();

        //    string pageSource = client.DownloadString(ChildUrl);

        //    string regStr = @"<a class=""link place-list__item-name oNd0aD8s link_js_inited""(\w*)";

        //    string resultSource = Regex.Match(pageSource, regStr).Groups[0].Value;

        //    return pageSource;
        //}



        //public async void Go()
        //{
        //    using (WebClient client = new WebClient())
        //    {
        //        using var context = BrowsingContext.New(Configuration.Default);
        //        context.SetCookie(new Cookie("123"));
        //        using var doc = await context.OpenAsync(MainUrl);
        //        var title = doc.GetElementsByClassName("Text Text_weight_regular Text_typography_body-long-m")[0];
        //        result = title.NodeValue;



        //        client.Encoding = System.Text.Encoding.UTF8;
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        //        var htmlData = client.DownloadData(MainUrl);
        //        string htmlCode = Encoding.UTF8.GetString(htmlData);

        //        result = htmlCode;

        //        //var parts1 = Regex.Split(htmlCode, "nick=upread.ru\">");
        //        //var parts2 = Regex.Split(parts1[1], " ");
        //        //int numberPosition = Convert.ToInt32(Regex.Replace(parts2[0], @"[^\d]+", ""));

        //        //this.Invoke(new MethodInvoker(delegate {
        //        //    label1.Text = Convert.ToString("Позиция: " + numberPosition + " Время: " + System.DateTime.Now.ToLongTimeString());
        //        //}));
        //    }
        //}
    }
}
