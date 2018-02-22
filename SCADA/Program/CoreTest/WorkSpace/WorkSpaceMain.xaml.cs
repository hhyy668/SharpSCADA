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
    public partial class WorkSpaceMain : Window
    {
        JobOrderBLL joborderBll = Engine.GetProvider<JobOrderBLL>();
        //ProcessStepsBLL processStepsBll = Engine.GetProvider<ProcessStepsBLL>();
        protected List<JobOrderExt> dataList = new List<JobOrderExt>();

        public WorkSpaceMain()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            Lst.ItemsSource = dataList;
        }


        private void AddJobOrder()
        {
            int num = 6;
            CheckBox[] check = new CheckBox[num];
            Thickness th = new Thickness();
            th.Bottom = 10;
            th.Left = 10;
            th.Right = 10;
            th.Top = 10;
            for (int i = 0; i < check.Length; i++)
            {
                check[i] = new CheckBox();
                //设置checkbox属性
                check[i].Margin = th;
                check[i].Content = i + 1;

                //this.AddJobOrderBlock.Children.Add(check[i]);
            }
        }


        protected class JobOrderExt: JobOrder
        {
            ProcessStepsBLL processStepsBll = Engine.GetProvider<ProcessStepsBLL>();
            ProductionOderBLL productionoderBll = Engine.GetProvider<ProductionOderBLL>();
            public JobOrderExt(JobOrder job)
            {
                this.JobOrderID = job.JobOrderID;
                this.JobOrderCode = job.JobOrderCode;
                this.ProductionOderID = job.ProductionOderID;
                this.Status = job.Status;
                this.StartTime = job.StartTime;
                this.EndTime = job.EndTime;
                this.Number = job.Number;
                this.CreateTime = job.CreateTime;
                this.CteateUser = job.CteateUser;
                this.ModifyTime = job.ModifyTime;
                this.ModifyUser = job.ModifyUser;
            }    
            public List<ProcessSteps> ProcessSteps
            {
                get
                {
                    return processStepsBll.GetModelList(string.Format("JobOrderID={0}",this.JobOrderID));
                }
            }
            public ProductionOder ProductionOrder
            {
                get
                {
                    return productionoderBll.GetModel(this.ProductionOderID);
                }
            }
        }
        void Init()
        {
            List<JobOrder> list = joborderBll.GetModelList(string.Format("Status={0}", (int)JobOrderStatusEnum.Executing));
            List<JobOrderExt> listext = new List<JobOrderExt>();
            foreach (var item in list)
            {
                listext.Add(new JobOrderExt(item));
            }
            dataList = listext;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobOrderAdd _joborderForm = new JobOrderAdd();
            _joborderForm.EditMode = EditModeEnum.Add;
            _joborderForm.ShowDialog();
        }
        
        private void Button_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("sss");
            dataList.RemoveAt(1);
        }

        private void StackPanel_TouchEnter(object sender, TouchEventArgs e)
        {
            MessageBox.Show("ttt");
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ddd");
            dataList.RemoveAt(1);
        }
    }

}