using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace parse2.Model.parser
{
    internal class ParserOne
    {
        //погода в россии - список областей
        private string MainUrl = @"yandex.ru/pogoda/region/225";

        private ObservableCollection<MainWindowModel> Work()
        {
            ObservableCollection<MainWindowModel> result = new ObservableCollection<MainWindowModel>();

            WebClient client = new WebClient();

            string source = client.DownloadString(MainUrl);

            return new ObservableCollection<MainWindowModel>();
        }

        public void Go()
        {

        }
    }
}
