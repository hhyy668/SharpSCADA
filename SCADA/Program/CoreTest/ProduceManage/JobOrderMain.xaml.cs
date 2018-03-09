

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
    /// JobOrderMain.xaml 的交互逻辑
    /// </summary>
    public partial class JobOrderMain : UserControl
    {
        JobOrderBLL joborderBll = Engine.GetProvider<JobOrderBLL>();
        public JobOrderMain()
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
            if (this.txtJobOrderID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and JobOrderID like '%{0}%'", this.txtJobOrderID.Text.Trim());
            }
            if (this.txtRacksID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and RacksID like '%{0}%'", this.txtRacksID.Text.Trim());
            }
            if (this.txtRacksID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and RacksID like '%{0}%'", this.txtRacksID.Text.Trim());
            }
            if (this.txtProductionOderID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ProductionOderID like '%{0}%'", this.txtProductionOderID.Text.Trim());
            }
            if (this.txtStatus.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and Status like '%{0}%'", this.txtStatus.Text.Trim());
            }
            if (this.txtStartTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and StartTime like '%{0}%'", this.txtStartTime.Text.Trim());
            }
            if (this.txtEndTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and EndTime like '%{0}%'", this.txtEndTime.Text.Trim());
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

            List<JobOrder> list = joborderBll.GetModelList(strWhere);
            this.JobOrderList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Sreach();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobOrderAdd _joborderForm = new JobOrderAdd();
            _joborderForm.EditMode = EditModeEnum.Add;
            _joborderForm.ShowDialog();
            Sreach();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            JobOrder bc = JobOrderList.SelectedItem as JobOrder;
            if (bc == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (joborderBll.Delete(bc.JobOrderID))
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

    }
}