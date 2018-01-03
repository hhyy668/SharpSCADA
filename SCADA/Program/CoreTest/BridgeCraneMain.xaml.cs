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
            //string sql = "select ROW_NUMBER() over(order by BridgeCraneID) as rows,* from BridgeCrane where 1=1";
            if (strName != "")
            {
                strWhere= string.Format(" BridgeCraneName like '%{0}%'", strName);
            }
            List<BridgeCrane> list = bridgeCraneBll.GetModelList(strWhere);
            this.BridgeCraneList.DataContext = list;
            //DataSet _ds = new DataSet();
            //_ds.Clear();
            //_ds = DataHelper.Instance.ExecuteDataset(sql);
            //if (_ds != null && _ds.Tables.Count > 0)
            //{
            //    this.BridgeCraneList.DataContext = _ds.Tables[0];
            //}
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.txtBridgeCraneName.Text.Trim();
            Sreach(strName);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BridgeCraneAdd _bridgeCrane = new BridgeCraneAdd();
            _bridgeCrane.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BridgeCrane bc = BridgeCraneList.SelectedItem as BridgeCrane;
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

    }
}
