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
    /// ProcessStepsMain.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessStepsMain : UserControl
    {
        ProcessStepsBLL processstepsBll = Engine.GetProvider<ProcessStepsBLL>();
        public ProcessStepsMain()
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
            if (this.txtProcessStepsID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ProcessStepsID like '%{0}%'", this.txtProcessStepsID.Text.Trim());
            }
            if (this.txtJobOrderID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and JobOrderID like '%{0}%'", this.txtJobOrderID.Text.Trim());
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
            if (this.txtStartTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and StartTime like '%{0}%'", this.txtStartTime.Text.Trim());
            }
            if (this.txtEntTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and EntTime like '%{0}%'", this.txtEntTime.Text.Trim());
            }
            if (this.txtStatue.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Statue like '%{0}%'", this.txtStatue.Text.Trim());
            }
            if (this.txtStationID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and StationID like '%{0}%'", this.txtStationID.Text.Trim());
            }

            List<ProcessSteps> list = processstepsBll.GetModelList(strWhere);
            this.ProcessStepsList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Sreach();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProcessStepsAdd _processstepsForm = new ProcessStepsAdd();
            _processstepsForm.EditMode = EditModeEnum.Add;
            _processstepsForm.ShowDialog();
            Sreach();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ProcessSteps bc = ProcessStepsList.SelectedItem as ProcessSteps;
            if (bc == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (processstepsBll.Delete(bc.ProcessStepsID))
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
            ProcessStepsAdd _processstepsForm = new ProcessStepsAdd();
            _processstepsForm.EditMode = EditModeEnum.Modify;
            ProcessSteps processsteps = ProcessStepsList.SelectedItem as ProcessSteps;
            if (processsteps == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            _processstepsForm.processsteps = processsteps;
            _processstepsForm.ShowDialog();
            Sreach();
        }

    }
}