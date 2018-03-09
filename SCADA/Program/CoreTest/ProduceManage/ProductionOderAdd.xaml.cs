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
        MaterielBLL materielBll = Engine.GetProvider<MaterielBLL>();
        UtilityBLL utilityBll = Engine.GetProvider<UtilityBLL>();
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
                this.txtProductionOderCode.Text = productionoder.ProductionOderCode;
                this.txtCustomerName.Text = productionoder.CustomerName;
                this.txtMaterielID.Text = productionoder.MaterielID;
                this.txtMaterielType.Text = productionoder.MaterielType;
                this.txtNumber.Text = productionoder.Number.ToString();

            }
            else
            {
                this.txtProductionOderCode.Text = utilityBll.GenerateSeq(SequenceType.PR);
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && productionoder != null)
            {
                //productionoder.ProductionOderCode = this.txtProductionOderCode.Text.Trim();
                productionoder.CustomerName = this.txtCustomerName.Text.Trim();
                productionoder.MaterielID = this.txtMaterielID.Text.Trim();
                productionoder.MaterielType = this.txtMaterielType.Text.Trim();
                productionoder.Number = this.txtNumber.Text.ToDecimal();
                productionoder.ModifyTime = DateTime.Now;
                productionoder.ModifyUser = ""; //this.txtModifyUser.Text.Trim(); 
                if (productionoderBll.Update(productionoder))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
            }
            else
            {
                ProductionOder model = new ProductionOder();
                model.ProductionOderCode = txtProductionOderCode.Text.Trim();
                model.CustomerName = txtCustomerName.Text.Trim();
                model.MaterielID = txtMaterielID.Text.Trim();
                model.MaterielType = txtMaterielType.Text.Trim();
                model.Number = txtNumber.Text.ToDecimal();
                model.CreateTime = DateTime.Now;
                model.CteateUser =  ""; //this.txtCteateUser.Text.Trim(); 
                model.ModifyTime = DateTime.Now;
                model.ModifyUser = ""; //this.txtModifyUser.Text.Trim(); 

                if (productionoderBll.Add(model))
                {
                    MessageBox.Show("添加成功");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void SelectGoBack(Materiel materiel)
        {
            this.txtMaterielID.Text = materiel.MaterielID.ToString();
            this.txtMaterielType.Text = materiel.MaterielType.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MaterielSelect();//Windows窗体
            window.Owner = this;
            window.Show();
        }
    }

}