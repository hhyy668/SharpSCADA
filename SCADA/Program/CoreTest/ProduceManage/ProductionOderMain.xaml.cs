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
    /// ProductionOderMain.xaml 的交互逻辑
    /// </summary>
    public partial class ProductionOderMain : UserControl
    {
        ProductionOderBLL productionoderBll = Engine.GetProvider<ProductionOderBLL>();
        public ProductionOderMain()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sreach();
        }

        private void Sreach()
        {
            string strWhere = " 1=1 ";
            if (this.txtProductionOderID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ProductionOderID like '%{0}%'", this.txtProductionOderID.Text.Trim());
            }
            if (this.txtProductionOderCode.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ProductionOderCode like '%{0}%'", this.txtProductionOderCode.Text.Trim());
            }
            if (this.txtCustomerName.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and CustomerName like '%{0}%'", this.txtCustomerName.Text.Trim());
            }
            if (this.txtMaterielID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and MaterielID like '%{0}%'", this.txtMaterielID.Text.Trim());
            }
            if (this.txtNumber.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Number like '%{0}%'", this.txtNumber.Text.Trim());
            }
            if (this.txtCreateTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and CreateTime like '%{0}%'", this.txtCreateTime.Text.Trim());
            }
            if (this.txtCteateUser.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and CteateUser like '%{0}%'", this.txtCteateUser.Text.Trim());
            }
            if (this.txtModifyTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ModifyTime like '%{0}%'", this.txtModifyTime.Text.Trim());
            }
            if (this.txtModifyUser.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ModifyUser like '%{0}%'", this.txtModifyUser.Text.Trim());
            }

            List<ProductionOder> list = productionoderBll.GetModelList(strWhere);
            this.ProductionOderList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Sreach();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductionOderAdd _productionoderForm = new ProductionOderAdd();
            _productionoderForm.EditMode = EditModeEnum.Add;
            _productionoderForm.ShowDialog();
            Sreach();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ProductionOder bc = ProductionOderList.SelectedItem as ProductionOder;
            if (bc == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (productionoderBll.Delete(bc.ProductionOderID))
            {
                MessageBox.Show("删除成功");
                Sreach();
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
            ProductionOderAdd _productionoderForm = new ProductionOderAdd();
            _productionoderForm.EditMode = EditModeEnum.Modify;
            ProductionOder productionoder = ProductionOderList.SelectedItem as ProductionOder;
            if (productionoder == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            _productionoderForm.productionoder = productionoder;
            _productionoderForm.ShowDialog();
            Sreach();
        }

    }
}