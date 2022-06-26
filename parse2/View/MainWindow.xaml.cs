using System.Windows;

namespace parse2
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

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
