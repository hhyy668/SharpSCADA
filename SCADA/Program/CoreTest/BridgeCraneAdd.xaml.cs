using Business;
using Easy4net.Entity;
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
    /// BridgeCraneAdd.xaml 的交互逻辑
    /// </summary>
    public partial class BridgeCraneAdd : Window
    {
        BridgeCraneBLL bridgeCraneBll = Engine.GetProvider<BridgeCraneBLL>();
        public BridgeCraneAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BridgeCrane model = new BridgeCrane();
            model.BridgeCraneName = txtBridgeCraneName.Text.Trim();
            model.BridgeCraneStatus = 1;
            if (bridgeCraneBll.Add(model))
            {
                MessageBox.Show("添加成功");
                this.Close();
                return;
            }
        }
    }
}
