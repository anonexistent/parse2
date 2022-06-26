using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using parse2.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using parse2.Model.parser;

namespace parse2.ViewModel
{
    internal class AppViewModel : INotifyPropertyChanged
    {
        public Random uuu = new Random();
        private MainWindowModel _selectedCity;
        public MainWindowModel selectedcity
        {
            get { return _selectedCity; }
            set { _selectedCity = value;
                OnPropertyChanged();
            }
        }

        private int _click;
        public int click
        {
            get { return _click; }
            set
            {
                _click = value;
                OnPropertyChanged();
            }
        }

        private char[] test = new char[10];
        public char[] Test
        {
            get { return test; }
            set { test = value;
            }
        }

        private string testtoo;
        public string Testtoo
        {
            get { return testtoo; }
            set { testtoo = value;
                OnPropertyChanged();
            }
        }



        public MenuCommand mcommand { get; set; }
        public WorkerFor1 norm { get; private set; }
        public ObservableCollection<MainWindowModel> Cities { get; set; }
        public ObservableCollection<ParserOne> RegionsSource { get;set; }

        public AppViewModel()
        {
            Cities = MainWindowModel.Cities;
            //ParserOne parser = new ParserOne();
            RegionsSource = ParserOne.RegionsSource;
            //Go();
            mcommand = new MenuCommand(this);
            norm = new WorkerFor1();
        }

        public void OnExecute()
        {
            MessageBox.Show("gfesrdtgkyuijouy");
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
        private void OnPropertyChanged([CallerMemberName] string propname="")
        {
            if(PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
