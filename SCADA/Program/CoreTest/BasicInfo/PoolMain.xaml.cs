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
    /// PoolMain.xaml 的交互逻辑
    /// </summary>
    public partial class PoolMain : UserControl
    {
        PoolBLL poolBll = Engine.GetProvider<PoolBLL>();
        public PoolMain()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IDictionary<int, string> dic = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            KeyValuePair<int, string> item=new KeyValuePair<int, string>(0, "全部");
            dic.Add(item);
            cmbPoolType.ItemsSource = dic;
            cmbPoolType.SelectedValuePath = "key";
            cmbPoolType.DisplayMemberPath = "Value";
            cmbPoolType.SelectedItem = item;
            //cmbPoolType.SelectedIndex = 0;
            Sreach("");
        }

        private void Sreach(string strName)
        {
            string strWhere = "";
            if (strName != "")
            {
                strWhere= string.Format(" PoolType like '%{0}%'", strName);
            }
            List<Pool> list = poolBll.GetModelList(strWhere);
            this.PoolList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.cmbPoolType.Text.Trim().Replace("全部","");
            Sreach(strName);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PoolAdd _poolForm = new PoolAdd();
            _poolForm.EditMode = EditModeEnum.Add;
            _poolForm.ShowDialog();
            Sreach(this.cmbPoolType.Text.Trim().Replace("全部", ""));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Pool pool = PoolList.SelectedItem as Pool;
            if (pool == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (poolBll.Delete(pool.PoolID))
            {
                MessageBox.Show("删除成功");
                string strName = this.cmbPoolType.Text.Trim().Replace("全部", "");
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
            PoolAdd _poolForm = new PoolAdd();
            _poolForm.EditMode = EditModeEnum.Modify;
            Pool pool = PoolList.SelectedItem as Pool;
            if (pool == null)
            {
                MessageBox.Show("请选择要修改的行");
                return;
            }
            _poolForm.pool= pool;
            _poolForm.ShowDialog();
            Sreach(this.cmbPoolType.Text.Trim().Replace("全部", ""));
        }
    }
}
