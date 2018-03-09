using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataService;

namespace CoreTest
{
    /// <summary>
    /// Interaction logic for Guage.xaml
    /// </summary>
    public partial class test : Window
    {
        List<TagNodeHandle> _valueChangedList;
        public test()
        {
            InitializeComponent();
        }
        private void HMI_Loaded(object sender, RoutedEventArgs e)
        {
            lock (this)
            {
                _valueChangedList = cvs1.BindingToServer(App.Server);
            }
        }

        private void HMI_Unloaded(object sender, RoutedEventArgs e)
        {
            lock (this)
            {
                App.Server.RemoveHandles(_valueChangedList);
            }
        }
    }
}
