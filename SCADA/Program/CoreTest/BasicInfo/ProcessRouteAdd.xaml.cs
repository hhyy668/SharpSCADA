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
    /// ProcessRouteAdd.xaml 的交互逻辑
    /// </summary>
    public partial class ProcessRouteAdd : Window
    {
        ProcessRouteBLL processrouteBll = Engine.GetProvider<ProcessRouteBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public ProcessRoute processroute = null;
        public ProcessRouteAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            //cmbPoolType.SelectedValuePath = "key";
            //cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && processroute != null)
            {
                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();               
                this.txtProcessRouteID.Text = processroute.ProcessRouteID.ToString();
                this.txtMaterielID.Text = processroute.MaterielID;
                this.txtStepNumber.Text = processroute.StepNumber.ToString();
                this.txtStepName.Text = processroute.StepName;
                this.txtLengthOfStay.Text = processroute.LengthOfStay.ToString();
                this.txtProcessingPoolType.Text = processroute.ProcessingPoolType;

            }
            else
            {
                //cmbPoolType.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && processroute != null)
            {

                processroute.ProcessRouteID = this.txtProcessRouteID.Text.Trim().ToInt();
                processroute.MaterielID = this.txtMaterielID.Text.Trim();
                processroute.StepNumber = this.txtStepNumber.Text.Trim().ToInt();
                processroute.StepName = this.txtStepName.Text.Trim();
                processroute.LengthOfStay = this.txtLengthOfStay.Text.Trim().ToInt();
                processroute.ProcessingPoolType = this.txtProcessingPoolType.Text.Trim();
                if (processrouteBll.Update(processroute))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
            {
                ProcessRoute model = new ProcessRoute();
                model.ProcessRouteID = txtProcessRouteID.Text.Trim().ToInt();
                model.MaterielID = txtMaterielID.Text.Trim();
                model.StepNumber = txtStepNumber.Text.Trim().ToInt();
                model.StepName = txtStepName.Text.Trim();
                model.LengthOfStay = txtLengthOfStay.Text.Trim().ToInt();
                model.ProcessingPoolType = txtProcessingPoolType.Text.Trim();

                if (processrouteBll.Add(model))
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