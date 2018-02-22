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
    /// JobOrderAdd.xaml 的交互逻辑
    /// </summary>
    public partial class JobOrderAdd : Window
    {
        JobOrderBLL joborderBll = Engine.GetProvider<JobOrderBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public JobOrder joborder = null;
        public JobOrderAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            //cmbPoolType.SelectedValuePath = "key";
            //cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && joborder != null)
            {
                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();               
                this.txtJobOrderID.Text = joborder.JobOrderID.ToString();
                this.txtJobOrderCode.Text = joborder.JobOrderCode;
                this.txtProductionOderID.Text = joborder.ProductionOderID.ToString();
                this.txtStatus.Text = joborder.Status.ToString();
                this.txtStartTime.Text = joborder.StartTime.ToString();
                this.txtEndTime.Text = joborder.EndTime.ToString();
                this.txtNumber.Text = joborder.Number.ToString();
                this.txtCreateTime.Text = joborder.CreateTime.ToString();
                this.txtCteateUser.Text = joborder.CteateUser;
                this.txtModifyTime.Text = joborder.ModifyTime.ToString();
                this.txtModifyUser.Text = joborder.ModifyUser;

            }
            else
            {
                //cmbPoolType.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && joborder != null)
            {

                joborder.JobOrderID = this.txtJobOrderID.Text.Trim().ToInt();
                joborder.JobOrderCode = this.txtJobOrderCode.Text.Trim();
                joborder.ProductionOderID = this.txtProductionOderID.Text.Trim().ToInt();
                joborder.Status = this.txtStatus.Text.Trim().ToInt();
                joborder.StartTime = this.txtStartTime.Text.Trim().ToDateTime();
                joborder.EndTime = this.txtEndTime.Text.Trim().ToDateTime();
                joborder.Number = this.txtNumber.Text.Trim().ToInt();
                joborder.CreateTime = this.txtCreateTime.Text.Trim().ToDateTime();
                joborder.CteateUser = this.txtCteateUser.Text.Trim();
                joborder.ModifyTime = this.txtModifyTime.Text.Trim().ToDateTime();
                joborder.ModifyUser = this.txtModifyUser.Text.Trim();
                if (joborderBll.Update(joborder))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
            {
                JobOrder model = new JobOrder();
                model.JobOrderID = txtJobOrderID.Text.Trim().ToInt();
                model.JobOrderCode = txtJobOrderCode.Text.Trim();
                model.ProductionOderID = txtProductionOderID.Text.Trim().ToInt();
                model.Status = txtStatus.Text.Trim().ToInt();
                model.StartTime = txtStartTime.Text.Trim().ToDateTime();
                model.EndTime = txtEndTime.Text.Trim().ToDateTime();
                model.Number = txtNumber.Text.Trim().ToInt();
                model.CreateTime = txtCreateTime.Text.Trim().ToDateTime();
                model.CteateUser = txtCteateUser.Text.Trim();
                model.ModifyTime = txtModifyTime.Text.Trim().ToDateTime();
                model.ModifyUser = txtModifyUser.Text.Trim();

                if (joborderBll.Add(model))
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