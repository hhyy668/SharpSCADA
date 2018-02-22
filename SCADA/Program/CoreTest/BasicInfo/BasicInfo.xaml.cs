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

namespace CoreTest
{
    /// <summary>
    /// BasicInfo.xaml 的交互逻辑
    /// </summary>
    public partial class BasicInfo : Window
    {
        public BasicInfo()
        {
            InitializeComponent();
        }

        private void btnBridgeCrane_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            BridgeCraneMain demo = new BridgeCraneMain();
            this.stackPanel1.Children.Add(demo);
        }

        private void btnPool_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            PoolMain demo = new PoolMain();
            this.stackPanel1.Children.Add(demo);
        }

        private void btnStation_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            StationMain demo = new StationMain();
            this.stackPanel1.Children.Add(demo);
        }

        private void btnRacks_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            RacksMain demo = new RacksMain();
            this.stackPanel1.Children.Add(demo);
        }

        private void Materiel_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            MaterielMain demo = new MaterielMain();
            this.stackPanel1.Children.Add(demo);           
        }

        private void ProcessRoute_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            ProcessRouteMain demo = new ProcessRouteMain();
            this.stackPanel1.Children.Add(demo);
            
        }
    }
}
