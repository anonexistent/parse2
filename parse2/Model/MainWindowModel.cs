using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        private int _temp;
        public int Temp
        {
            get { return _temp; }
            set { _temp = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<MainWindowModel> Cities { get; set; } = new ObservableCollection<MainWindowModel> {
                new MainWindowModel { City = "msk", Temp = 10 },
                new MainWindowModel { City = "orsk", Temp = 20 },
                new MainWindowModel { City = "rostov", Temp = 29 },
                new MainWindowModel { City = "spb", Temp = 0 },
                new MainWindowModel { City = "vladivostok", Temp = 40 },
                new MainWindowModel { City = "apple", Temp = -1 },
                new MainWindowModel { City = "nokia", Temp = 5 },
                new MainWindowModel { City = "ulan-ude", Temp = 11 },
                new MainWindowModel { City = "krasnodar", Temp = 21 }
        };


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
