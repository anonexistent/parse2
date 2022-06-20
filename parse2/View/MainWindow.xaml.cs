using MSHTML;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
        public string resultik { get; set; }

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
            HTMLDocument cc = (HTMLDocument)browser0.Document;
            regexx = @"class=.link place-list__item-name.+(pogoda/region/.+)\?via.+</a>";

            //lass=.link place-list__item-name.{0,40}(pogoda.region.)

            page = cc.documentElement.innerHTML;

            FlowDocument doc = new FlowDocument();
            Paragraph par = new Paragraph();
            par.Inlines.Add(page);
            doc.Blocks.Add(par);
            qq.zxc.Document = doc;

            qq.Show();

            resultik = Regex.Match(page, regexx).Groups[1].Value;


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
    }
}
