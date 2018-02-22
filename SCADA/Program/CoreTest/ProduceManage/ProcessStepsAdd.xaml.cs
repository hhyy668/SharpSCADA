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
    /// ProcessStepsAdd.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessStepsAdd : Window
    {
        ProcessStepsBLL processstepsBll = Engine.GetProvider<ProcessStepsBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public ProcessSteps processsteps = null;
        public ProcessStepsAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            //cmbPoolType.SelectedValuePath = "key";
            //cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && processsteps != null)
            {
                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();               
                this.txtProcessStepsID.Text = processsteps.ProcessStepsID.ToString();
                this.txtJobOrderID.Text = processsteps.JobOrderID.ToString();
                this.txtStepNumber.Text = processsteps.StepNumber.ToString();
                this.txtStepName.Text = processsteps.StepName;
                this.txtLengthOfStay.Text = processsteps.LengthOfStay.ToString();
                this.txtProcessingPoolType.Text = processsteps.ProcessingPoolType;
                this.txtStartTime.Text = processsteps.StartTime.ToString();
                this.txtEntTime.Text = processsteps.EntTime.ToString();
                this.txtStatue.Text = processsteps.Statue.ToString();
                this.txtStationID.Text = processsteps.StationID.ToString();

            }
            else
            {
                //cmbPoolType.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && processsteps != null)
            {

                processsteps.ProcessStepsID = this.txtProcessStepsID.Text.Trim().ToInt();
                processsteps.JobOrderID = this.txtJobOrderID.Text.Trim().ToInt();
                processsteps.StepNumber = this.txtStepNumber.Text.Trim().ToInt();
                processsteps.StepName = this.txtStepName.Text.Trim();
                processsteps.LengthOfStay = this.txtLengthOfStay.Text.Trim().ToInt();
                processsteps.ProcessingPoolType = this.txtProcessingPoolType.Text.Trim();
                processsteps.StartTime = this.txtStartTime.Text.Trim().ToDateTime();
                processsteps.EntTime = this.txtEntTime.Text.Trim().ToDateTime();
                processsteps.Statue = this.txtStatue.Text.Trim().ToInt();
                processsteps.StationID = this.txtStationID.Text.Trim().ToInt();
                if (processstepsBll.Update(processsteps))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
            {
                ProcessSteps model = new ProcessSteps();
                model.ProcessStepsID = txtProcessStepsID.Text.Trim().ToInt();
                model.JobOrderID = txtJobOrderID.Text.Trim().ToInt();
                model.StepNumber = txtStepNumber.Text.Trim().ToInt();
                model.StepName = txtStepName.Text.Trim();
                model.LengthOfStay = txtLengthOfStay.Text.Trim().ToInt();
                model.ProcessingPoolType = txtProcessingPoolType.Text.Trim();
                model.StartTime = txtStartTime.Text.Trim().ToDateTime();
                model.EntTime = txtEntTime.Text.Trim().ToDateTime();
                model.Statue = txtStatue.Text.Trim().ToInt();
                model.StationID = txtStationID.Text.Trim().ToInt();

                if (processstepsBll.Add(model))
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