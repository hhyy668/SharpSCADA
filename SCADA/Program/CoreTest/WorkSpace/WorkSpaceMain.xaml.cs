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
using System.Windows.Threading;

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
        DispatcherTimer timer;

        public WorkSpaceMain()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            Lst.ItemsSource = dataList;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10000);
            timer.Tick += new EventHandler(JobOrderProcess);
            timer.Start();
        }
        /// <summary>
        /// Timer触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JobOrderProcess(object sender, EventArgs e)
        {
            timer.Stop();
            foreach (JobOrderExt item in dataList) {
                ProcessSteps step = item.ProcessSteps.Where(a => a.Statue == (int)JobOrderStatusEnum.Executing).FirstOrDefault();
                if (step.EntTime.Subtract(step.StartTime).TotalMinutes > step.LengthOfStay) {
                    MessageBox.Show("订单" + step.JobOrderID + "步骤" + step.StepName + "需从位置" + step.StationID+"取出");
                    if (item.ProcessSteps.Where(a => a.StepNumber == step.StepNumber + 1).Count()>0){
                        ProcessSteps nextstep = item.ProcessSteps.Where(a => a.StepNumber == step.StepNumber + 1).FirstOrDefault();
                        //寻找空闲行车，优先使用进料航测
                        //航测移动方法（目的地step.stationid）
                        //航测吊起挂具方法（）//更新step.EntTime=now、step.Statue=已完成
                        //航测移动方法（目的地nextstep.ProcessingPoolType，nextstep.StationType）
                        //{
                        //     查找符合条件的目的工位id
                        //     航测移动至目的工位id
                        // }
                        //航测放下挂具方法（）//更新nextstep.startTime=now、step.Statue=执行中
                    }else
                    {
                        MessageBox.Show("目前是最后一步！");
                    }
                }

            }

            timer.Start();
        }

        protected class JobOrderExt: JobOrder
        {
            ProcessStepsBLL processStepsBll = Engine.GetProvider<ProcessStepsBLL>();
            ProductionOderBLL productionoderBll = Engine.GetProvider<ProductionOderBLL>();
            ReciveRecordBLL reciverecordBll = Engine.GetProvider<ReciveRecordBLL>();
            RacksBLL racksBll = Engine.GetProvider<RacksBLL>();
            public JobOrderExt(JobOrder job)
            {
                this.JobOrderID = job.JobOrderID;
                this.ReciveRecordID = job.ReciveRecordID;
                this.RacksID = job.RacksID;
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
                    return processStepsBll.GetModelList(string.Format("JobOrderID='{0}'",this.JobOrderID));
                }
            }
            public ProductionOder ProductionOrder
            {
                get
                {
                    return productionoderBll.GetModel(this.ProductionOderID);
                }
            }
            public ReciveRecord ReciveRecord
            {
                get
                {
                    return reciverecordBll.GetModel(this.ReciveRecordID);
                }
            }
            public Racks Racks
            {
                get
                {
                    return racksBll.GetModel(this.RacksID.ToInt());
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
            Init();
            Lst.ItemsSource = dataList;
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