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
    public partial class ProduceMange : Window
    {
        public ProduceMange()
        {
            InitializeComponent();
        }

        private void btnProductionOrder_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            ProductionOderMain demo = new ProductionOderMain();
            this.stackPanel1.Children.Add(demo);
        }
        private void btnReciveRecord_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            ReciveRecordMain demo = new ReciveRecordMain();
            this.stackPanel1.Children.Add(demo);
        }
        
        private void btnJobOrder_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            JobOrderMain demo = new JobOrderMain();
            this.stackPanel1.Children.Add(demo);
        }

        private void btnProcessSteps_Click(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            ProcessStepsMain demo = new ProcessStepsMain();
            this.stackPanel1.Children.Add(demo);
        }
   }
}
