using parse2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.ComponentModel;

namespace parse2.ViewModel
{
    internal class CityViewModel : DependencyObject
    {
        public string CityFilter
        {
            get { return (string)GetValue(CityFilterProperty); }
            set { SetValue(CityFilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CityFilter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CityFilterProperty =
            DependencyProperty.Register("CityFilter", typeof(string), typeof(MainWindowModel), new PropertyMetadata(""));



        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(CityViewModel), new PropertyMetadata(null));

        public CityViewModel()
        {
            Items = CollectionViewSource.GetDefaultView(MainWindowModel.Cities);
        }
    }
}
