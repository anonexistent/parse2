using System.Windows;
using System.Windows.Controls;

namespace parse2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.parser.ParserOne a = new Model.parser.ParserOne();

            //MessageBox.Show(a.Goo());

            View.SecondWindow qq = new View.SecondWindow();

            browser0.Navigate("https://2ip.ru/");
        }
    }
}
