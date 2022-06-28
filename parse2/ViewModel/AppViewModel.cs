using parse2.Model.parser;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace parse2.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public Random uuu = new Random();

        private char[] test = new char[10];
        public char[] Test
        {
            get { return test; }
            set
            {
                test = value;
            }
        }

        private string testtoo;
        public string Testtoo
        {
            get { return testtoo; }
            set
            {
                testtoo = value;
                OnPropertyChanged();
            }
        }

        private string _html;
        public string Html
        {
            get { return _html; }
            set
            {
                _html = value;
                OnPropertyChanged();
            }
        }

        public MenuCommand mcommand { get; set; }

        private WorkerFor1 _norm = new WorkerFor1();
        public WorkerFor1 norm
        {
            get { return _norm; }
            set
            {
                _norm = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ParserOne> RegionsSource { get; set; }

        public AppViewModel()
        {
            //Cities = MainWindowModel.Cities;
            //ParserOne parser = new ParserOne();
            //RegionsSource = ParserOne.RegionsSource;
            //Go();
            mcommand = new MenuCommand(this);

            norm = new WorkerFor1();

        }

        public async void OnExecute(object a)
        {
            try
            {
                //  ACHTUNG!!!!!!!!!!!!!!
                ((WebBrowser)a).Source = new Uri(norm.Selected.Source);
                await Task.Delay(1000);
                var temphtml = (MSHTML.HTMLDocument)((WebBrowser)a).Document;
                string page = temphtml.documentElement.innerHTML;

                string regexTemperature = @"(Текущая .{0,60}). href";
                string regexWind = @"a11y-hidden..(Ветер:.{0,39}\.)./span";
                string regexWater = @"a11y-hidden..(Влажность:.{0,6}\.)";
                string regexPressure = @"a11y-hidden..(Давление:.{0,40}\.)";

                //aria-label="(Текущая .{0,60}).{0,5}data
                //aria-label=.(Текущая .{0,50}). data
                //link fact..basic .{50,120}..(Текущая.{0,60})..data

                Html = "\n" + Regex.Match(page, regexTemperature).Groups[1].Value + "\n" + Regex.Match(page, regexWind).Groups[1].Value + "\n"
                    + Regex.Match(page, regexWater).Groups[1].Value + "\n" + Regex.Match(page, regexPressure).Groups[1].Value + "\n";

                //string ggg = (((MSHTML.HTMLDocument)((WebBrowser)a).Document).documentElement.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public async void Go()
        {
            for (int j = 0; j < 101; j++)
            {
                await Task.Delay(250);
                for (int i = 0; i < test.Length; i++)
                {
                    test[i] = (char)uuu.Next(128);
                }
                Testtoo = string.Join('\0', Test);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
