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
    /// PoolAdd.xaml 的交互逻辑
    /// </summary>
    public partial class PoolAdd : Window
    {
        PoolBLL poolBll = Engine.GetProvider<PoolBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public Pool pool = null;
        public PoolAdd()
        {
            InitializeComponent();
           
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            cmbPoolType.SelectedValuePath = "key";
            cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && pool != null)
            {
                KeyValuePair<int, string> item = new KeyValuePair<int, string>(AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt(), pool.PoolType);
                //dic.Add(item);
                cmbPoolType.SelectedItem = item;

                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();
                this.txtPoolCode.Text = pool.PoolCode;

            }
            else
            {
                cmbPoolType.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && pool != null)
            {
                pool.PoolCode = this.txtPoolCode.Text.Trim();
                pool.PoolType = this.cmbPoolType.Text;
                if (poolBll.Update(pool))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
            {
                Pool model = new Pool();
                model.PoolCode = this.txtPoolCode.Text.Trim();
                model.PoolType = this.cmbPoolType.Text;
                if (poolBll.Add(model))
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
