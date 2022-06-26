using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using parse2.Model;

namespace parse2.ViewModel
{
    public class WorkerFor1 : INotifyPropertyChanged
    {
        private Output1 selected;
        public Output1 Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnChanged();
            }
        }

        public ObservableCollection<Output1> cis { get; set; }

        public WorkerFor1()
        {
            Output1.Worker();
            cis = Output1.Cities;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}