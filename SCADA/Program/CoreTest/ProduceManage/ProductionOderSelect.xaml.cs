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
    public partial class ProductionOderSelect : Window
    {
        ProductionOderBLL productionoderBll = Engine.GetProvider<ProductionOderBLL>();

        public ProductionOderSelect()
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
   
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            ProductionOder productionoder = ProductionOderList.SelectedItem as ProductionOder;
            if (productionoder == null)
            {
                MessageBox.Show("请选择行");
                return;
            }
            ReciveRecordAdd mainwin =this.Owner as ReciveRecordAdd;
            mainwin.SelectGoBack(productionoder);
            this.Close();
            //Window mainwin = Application.Current.MainWindow;
            //MessageBox.Show(mainwin.Title, mainwin.Title);
        }
        
    }
}