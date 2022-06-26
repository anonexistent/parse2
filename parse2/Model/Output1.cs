using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace parse2.Model
{
    public class Output1 : INotifyPropertyChanged  //  города
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnChange();
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnChange();
            }
        }
        private string _source;
        public string Source
        {
            get { return _source; }
            set
            {
                _source = value;
                OnChange();
            }
        }
        private int _regid;
        public int RegId
        {
            get { return _regid; }
            set
            {
                _regid = value;
                OnChange();
            }
        }

        static SqlDataAdapter sql;
        static DataTable dt;

        public static ObservableCollection<Output1> Cities { get; set; } = new ObservableCollection<Output1>();

        private const string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwzl\source\repos\databaseWork\databaseWork\Database1.mdf;Integrated Security=True";
        public static void Worker()
        {
            using (SqlConnection con = new SqlConnection())
            {
                int tempid = 0;
                string tempname = string.Empty;
                string tempsource = string.Empty;
                int tempregid = 0;
                //  11375, 10842, 10946, 10645
                sql = new SqlDataAdapter("select * from YaWeatherCities where RegId=11235", constr);
                dt = new DataTable();
                sql.Fill(dt);
                //foreach (DataRow item in dt.Rows)
                //{

                //    MessageBox.Show($"{item.ItemArray[0]} — {item.ItemArray[1]} — {item.ItemArray[2]} — {item.ItemArray[3]}");
                //}
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempid = int.Parse(dt.Rows[i].ItemArray[0].ToString());
                    tempname = dt.Rows[i].ItemArray[1].ToString();
                    tempsource = dt.Rows[i].ItemArray[2].ToString();
                    tempregid = int.Parse(dt.Rows[i].ItemArray[3].ToString());

                    Cities.Add(new Output1 { Id = tempid, Name = tempname, Source = tempsource, RegId = tempregid });
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnChange([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
