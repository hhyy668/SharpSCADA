using Business;
using DatabaseLib;
using Easy4net.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoreTest
{
    /// <summary>
    /// BridgeCraneMain.xaml 的交互逻辑
    /// </summary>
    public partial class BridgeCraneMain : UserControl
    {
        BridgeCraneBLL bridgeCraneBll = Engine.GetProvider<BridgeCraneBLL>();
        public BridgeCraneMain()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sreach("");
        }

        private void Sreach(string strName)
        {
            string strWhere = "";
            if (strName != "")
            {
                strWhere= string.Format(" BridgeCraneName like '%{0}%'", strName);
            }
            List<BridgeCrane> list = bridgeCraneBll.GetModelList(strWhere);
            this.BridgeCraneList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.txtBridgeCraneName.Text.Trim();
            Sreach(strName);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BridgeCraneAdd _bridgecraneForm = new BridgeCraneAdd();
            _bridgecraneForm.EditMode = EditModeEnum.Add;
            _bridgecraneForm.ShowDialog();
            Sreach(this.txtBridgeCraneName.Text.Trim());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BridgeCrane bc = BridgeCraneList.SelectedItem as BridgeCrane;
            if (bc == null) {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (bridgeCraneBll.Delete(bc.BridgeCraneID))
            {
                MessageBox.Show("删除成功");
                string strName = this.txtBridgeCraneName.Text.Trim();
                Sreach(strName);
                return;
            }
            else
            {
                MessageBox.Show("删除失败");
                return;
            }
        }
        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            BridgeCraneAdd _bridgecraneForm = new BridgeCraneAdd();
            _bridgecraneForm.EditMode = EditModeEnum.Modify;
            BridgeCrane bridgecrane = BridgeCraneList.SelectedItem as BridgeCrane;
            if (bridgecrane == null)
            {
                MessageBox.Show("请选择要修改的行");
                return;
            }
            _bridgecraneForm.bridgecrane = bridgecrane;
            _bridgecraneForm.ShowDialog();
            Sreach(this.txtBridgeCraneName.Text.Trim());
        }

    }
}
