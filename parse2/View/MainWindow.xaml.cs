using MSHTML;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace parse2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            browser0.Source = new System.Uri(@"https://pogoda.yandex.ru/region/225");
            
        }

        public string page { get; set; }
        public string regexx { get; set; }
        public MatchCollection resultik { get; set; }

        View.SecondWindow qq = new View.SecondWindow();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.parser.ParserOne a = new Model.parser.ParserOne();

            //MessageBox.Show(a.Goo());
            
            //qq.Show();            
            
            browser0.Navigate("https://2ip.ru/");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //      ссылки на области / края

            HTMLDocument cc = (HTMLDocument)browser0.Document;
            regexx = @"class=.link place-list__item-name.+pogoda/region/\?via.+</a>";

            string regex2 = @"lass=.link place-list__item-name.{0,40}(pogoda.region.\d+)";

            page = cc.documentElement.innerHTML;

            FlowDocument doc = new FlowDocument();
            Paragraph par = new Paragraph();
            par.Inlines.Add(page);
            doc.Blocks.Add(par);
            qq.zxc.Document = doc;

            qq.Show();

            resultik = Regex.Matches(page, regex2);

            foreach (var item in resultik)
            {
                MessageBox.Show(item.ToString());
            }
        }

        private async void TryParseTwo()
        {
            //var config = Configuration.Default.WithDefaultLoader();
            //var address = "https://yandex.ru/";
            //var context = BrowsingContext.New(config);
            //var document = await context.OpenAsync(address);
            //var cellSelector = "tr.vevent td:nth-child(3)";

            ////      document.all.(представленеи результатов) - нужны {AngleSharp.Html.Dom.HtmlAnchorElement}.inner/outerHtml, text
            ////"<div class=\"desk-notif-card__login-new-item-icon\"></div><div class=\"desk-notif-card__login-new-item-title\">Диск</div>"           ------      inner
            ////"<a class=\"home-link desk-notif-card__login-new-item desk-notif-card__login-new-item_disk home-link_black_yes\" href=\"https://passport.yandex.ru/auth?origin=home_disk&amp;retpath=https%3A%2F%2Fdisk.yandex.ru%2F%3Fsource%3Ddomik-main&amp;backpath=https%3A%2F%2Fyandex.ru\" target=\"_blank\" rel=\"noopener\"><div class=\"desk-notif-card__login-new-item-icon\"></div><div class=\"desk-notif-card__login-new-item-title\">Диск</div></a>"
            
            //var io = document.All.Select(m=>m.InnerHtml);     //  !!!!!!
            //var cells = document.QuerySelectorAll(cellSelector);

            //var titles = cells.Select(m => m.InnerHtml);

            //FlowDocument doc = new FlowDocument();
            //Paragraph par = new Paragraph();

            //var r = document.DocumentElement.ClassList;


            //MessageBox.Show(string.Join('\0',titles));

            //var parser = new HtmlParser();
            //var uio = await parser.ParseDocumentAsync(@"https://pogoda.yandex.ru/region/225");
            //var iop = uio.QuerySelectorAll("class");


            //par.Inlines.Add(uio);
            //doc.Blocks.Add(par);
            //qq.zxc.Document = doc;
            //qq.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            string resultik2 = string.Empty;
            string str = "Собака ела суп, ger342 4 gfddf!!";
            string f = @"мальчик (\w+)";
            Regex rr = new Regex(f);
            resultik2 = rr.Match(str).ToString();

            aa.Text=resultik2;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TryParseTwo();
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{

        //    //      сработает пару раз, если повезет

        //    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"https://pogoda.yandex.ru/region/225");
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream stream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(stream);

        //    page = reader.ReadToEnd();

        //    reader.Close();
        //    stream.Close();

        //    FlowDocument doc = new FlowDocument();
        //    Paragraph par = new Paragraph();
        //    par.Inlines.Add(page);
        //    doc.Blocks.Add(par);
        //    qq.zxc.Document = doc;

        //    qq.Show();
        //}
    }
}
