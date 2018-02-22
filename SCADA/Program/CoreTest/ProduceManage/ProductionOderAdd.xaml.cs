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
    /// ProductionOderAdd.xaml 的交互逻辑
    /// </summary>
    public partial class ProductionOderAdd : Window
    {
        ProductionOderBLL productionoderBll = Engine.GetProvider<ProductionOderBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public ProductionOder productionoder = null;
        public ProductionOderAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            //cmbPoolType.SelectedValuePath = "key";
            //cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && productionoder != null)
            {
                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();               
                this.txtProductionOderID.Text = productionoder.ProductionOderID.ToString();
                this.txtProductionOderCode.Text = productionoder.ProductionOderCode;
                this.txtCustomerName.Text = productionoder.CustomerName;
                this.txtMaterielID.Text = productionoder.MaterielID;
                this.txtNumber.Text = productionoder.Number.ToString();
                this.txtCreateTime.Text = productionoder.CreateTime.ToString();
                this.txtCteateUser.Text = productionoder.CteateUser;
                this.txtModifyTime.Text = productionoder.ModifyTime.ToString();
                this.txtModifyUser.Text = productionoder.ModifyUser;

            }
            else
            {
                //cmbPoolType.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && productionoder != null)
            {

                productionoder.ProductionOderID = this.txtProductionOderID.Text.Trim().ToInt();
                productionoder.ProductionOderCode = this.txtProductionOderCode.Text.Trim();
                productionoder.CustomerName = this.txtCustomerName.Text.Trim();
                productionoder.MaterielID = this.txtMaterielID.Text.Trim();
                productionoder.Number = this.txtNumber.Text.Trim().ToInt();
                productionoder.CreateTime = this.txtCreateTime.Text.Trim().ToDateTime();
                productionoder.CteateUser = this.txtCteateUser.Text.Trim();
                productionoder.ModifyTime = this.txtModifyTime.Text.Trim().ToDateTime();
                productionoder.ModifyUser = this.txtModifyUser.Text.Trim();
                if (productionoderBll.Update(productionoder))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
            {
                ProductionOder model = new ProductionOder();
                model.ProductionOderID = txtProductionOderID.Text.Trim().ToInt();
                model.ProductionOderCode = txtProductionOderCode.Text.Trim();
                model.CustomerName = txtCustomerName.Text.Trim();
                model.MaterielID = txtMaterielID.Text.Trim();
                model.Number = txtNumber.Text.Trim().ToInt();
                model.CreateTime = txtCreateTime.Text.Trim().ToDateTime();
                model.CteateUser = txtCteateUser.Text.Trim();
                model.ModifyTime = txtModifyTime.Text.Trim().ToDateTime();
                model.ModifyUser = txtModifyUser.Text.Trim();

                if (productionoderBll.Add(model))
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