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
    /// MaterielMain.xaml 的交互逻辑
    /// </summary>
    public partial class MaterielSelect : Window
    {
        MaterielBLL materielBll = Engine.GetProvider<MaterielBLL>();
        public MaterielSelect()
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
            if (this.txtMaterielID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and MaterielID like '%{0}%'", this.txtMaterielID.Text.Trim());
            }
            if (this.txtMaterielType.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and MaterielType like '%{0}%'", this.txtMaterielType.Text.Trim());
            }
            if (this.txtSpec.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Spec like '%{0}%'", this.txtSpec.Text.Trim());
            }
            if (this.txtDepict.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Depict like '%{0}%'", this.txtDepict.Text.Trim());
            }
            if (this.txtSkim.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Skim like '%{0}%'", this.txtSkim.Text.Trim());
            }
            if (this.txtOneWash.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and OneWash like '%{0}%'", this.txtOneWash.Text.Trim());
            }
            if (this.txtPickling.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Pickling like '%{0}%'", this.txtPickling.Text.Trim());
            }
            if (this.txtTwoWash.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and TwoWash like '%{0}%'", this.txtTwoWash.Text.Trim());
            }
            if (this.txtAuxiliary.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Auxiliary like '%{0}%'", this.txtAuxiliary.Text.Trim());
            }
            if (this.txtDry.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Dry like '%{0}%'", this.txtDry.Text.Trim());
            }

            List<Materiel> list = materielBll.GetModelList(strWhere);
            this.MaterielList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Sreach();
        }
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Materiel materiel = MaterielList.SelectedItem as Materiel;
            if (materiel == null)
            {
                MessageBox.Show("请选择行");
                return;
            }
            ProductionOderAdd mainwin = this.Owner as ProductionOderAdd;
            mainwin.SelectGoBack(materiel);
            this.Close();
            //Window mainwin = Application.Current.MainWindow;
            //MessageBox.Show(mainwin.Title, mainwin.Title);
        }


    }
}