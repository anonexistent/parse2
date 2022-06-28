using parse2.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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

        private string _search = "";
        public string search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnChanged("search");
                OnChanged("serched_cis");
            }
        }


        public ObservableCollection<Output1> cis { get; set; }

        private ObservableCollection<Output1> _serched_cis;
        public ObservableCollection<Output1> serched_cis
        {
            get
            {
                if (search == "") return cis;
                //      !! LINQ! !!!
                else return new ObservableCollection<Output1>(cis.Where(x => x.Name.ToLower().StartsWith(search.ToLower())));
                /*(ObservableCollection<Output1>)(from x in cis where x.Name.ToUpper().StartsWith(search) select x);*/
            }
        }

        public WorkerFor1()
        {
            Output1.Worker();
            cis = Output1.Cities;
            selected = new Output1();
        }





        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}