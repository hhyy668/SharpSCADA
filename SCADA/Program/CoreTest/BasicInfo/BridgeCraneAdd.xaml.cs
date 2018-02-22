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
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public BridgeCrane bridgecrane = null;
        public BridgeCraneAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            //cmbPoolType.SelectedValuePath = "key";
            //cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && bridgecrane != null)
            {
                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();
                this.txtBridgeCraneName.Text = bridgecrane.BridgeCraneName;
                
            }
            else
            {
                //cmbPoolType.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {          
            if (EditMode == EditModeEnum.Modify && bridgecrane != null)
            {
                bridgecrane.BridgeCraneName = this.txtBridgeCraneName.Text.Trim();
                if (bridgeCraneBll.Update(bridgecrane))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
