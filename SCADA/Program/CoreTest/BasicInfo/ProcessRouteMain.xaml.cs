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
    /// ProcessRouteMain.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessRouteMain : UserControl
    {
        ProcessRouteBLL processrouteBll = Engine.GetProvider<ProcessRouteBLL>();
        public ProcessRouteMain()
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
            if (this.txtProcessRouteID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ProcessRouteID like '%{0}%'", this.txtProcessRouteID.Text.Trim());
            }
            if (this.txtMaterielID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and MaterielID like '%{0}%'", this.txtMaterielID.Text.Trim());
            }
            if (this.txtStepNumber.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and StepNumber like '%{0}%'", this.txtStepNumber.Text.Trim());
            }
            if (this.txtStepName.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and StepName like '%{0}%'", this.txtStepName.Text.Trim());
            }
            if (this.txtLengthOfStay.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and LengthOfStay like '%{0}%'", this.txtLengthOfStay.Text.Trim());
            }
            if (this.txtProcessingPoolType.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ProcessingPoolType like '%{0}%'", this.txtProcessingPoolType.Text.Trim());
            }

            List<ProcessRoute> list = processrouteBll.GetModelList(strWhere);
            this.ProcessRouteList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Sreach();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProcessRouteAdd _processrouteForm = new ProcessRouteAdd();
            _processrouteForm.EditMode = EditModeEnum.Add;
            _processrouteForm.ShowDialog();
            Sreach();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ProcessRoute bc = ProcessRouteList.SelectedItem as ProcessRoute;
            if (bc == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (processrouteBll.Delete(bc.ProcessRouteID))
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
            ProcessRouteAdd _processrouteForm = new ProcessRouteAdd();
            _processrouteForm.EditMode = EditModeEnum.Modify;
            ProcessRoute processroute = ProcessRouteList.SelectedItem as ProcessRoute;
            if (processroute == null)
            {
                MessageBox.Show("请选择要修改的行");
                return;
            }
            _processrouteForm.processroute = processroute;
            _processrouteForm.ShowDialog();
            Sreach();
        }

    }
}