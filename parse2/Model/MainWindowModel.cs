using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using parse2.Model.parser;
using System.Collections.ObjectModel;

namespace parse2.Model
{
    internal class MainWindowModel : INotifyPropertyChanged
    {
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value;
                OnPropertyChanged();
            }
        }

        private int _tempr;
        public int Tempr
        {
            get { return _tempr; }
            set { _tempr = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<MainWindowModel> Cities { get; set; } = new ObservableCollection<MainWindowModel> {
                new MainWindowModel { City = "msk", Tempr = 10 },
                new MainWindowModel { City = "orsk", Tempr = 20 },
                new MainWindowModel { City = "rostov", Tempr = 29 },
                new MainWindowModel { City = "spb", Tempr = 0 },
                new MainWindowModel { City = "vladivostok", Tempr = 40 },
                new MainWindowModel { City = "apple", Tempr = -1 },
                new MainWindowModel { City = "nokia", Tempr = 5 },
                new MainWindowModel { City = "ulan-ude", Tempr = 11 },
                new MainWindowModel { City = "krasnodar", Tempr = 21 }
        };


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
