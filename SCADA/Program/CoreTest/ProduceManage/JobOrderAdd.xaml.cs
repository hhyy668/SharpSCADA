using Business;
using Easy4net.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// 数据项
    /// </summary>
    public class DataItem
    {
        public IDictionary<int, string> PoolType { get; set; }
        public IDictionary<int, string> JobOrderStatus { get; set; }
        public IDictionary<int, string> StationType { get; set; }
    }
    /// <summary>
    /// JobOrderAdd.xaml 的交互逻辑
    /// </summary>
    public partial class JobOrderAdd : Window
    {
        JobOrderBLL joborderBll = Engine.GetProvider<JobOrderBLL>();
        ProductionOderBLL productionoderBll = Engine.GetProvider<ProductionOderBLL>();
        ReciveRecordBLL reciverecordBll = Engine.GetProvider<ReciveRecordBLL>();
        MaterielBLL materielBll = Engine.GetProvider<MaterielBLL>();
        ProcessStepsBLL processstepsBll = Engine.GetProvider<ProcessStepsBLL>();
        RacksBLL racksBll = Engine.GetProvider<RacksBLL>();
        UtilityBLL utilityBll = Engine.GetProvider<UtilityBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        string JobOrderID = "";
        ObservableCollection<ProcessSteps> stepslist = new ObservableCollection<ProcessSteps>();
        ProductionOder po = null;
        ReciveRecord rr = null;
        Racks racks = null;
        public JobOrderAdd()
        {
            InitializeComponent();
            DataItem dataitem = new DataItem();
            dataitem.PoolType=AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            dataitem.JobOrderStatus = AttributesHelper.GetEnumValueDesc<JobOrderStatusEnum>();
            dataitem.StationType = AttributesHelper.GetEnumValueDesc<StationTypeEnum>();
            this.DataContext = dataitem;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
            //初始化加载订单数据源
            ProductionOderLst.ItemsSource = productionoderBll.GetModelList("");
            //初始化加载挂具数据源
            RacksLst.ItemsSource=racksBll.GetModelList("");
            JobOrderID = utilityBll.GenerateSeq(SequenceType.JO);
        }
        //选择订单
        private void ProductionOderLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            po = ProductionOderLst.SelectedItem as ProductionOder;
        }
        //选择订单后下一步
        private void btnPONext_Click(object sender, RoutedEventArgs e)
        {
            if (po==null)
            {
                MessageBox.Show("请选择订单");
                return;
            }
            //根据订单加载对应检验单数据源
            ReciveRecordLst.ItemsSource = reciverecordBll.GetModelList(string.Format("ProductionOderID={0}", po.ProductionOderID));
            tabControl.SelectedIndex = 1;
        }
        //选择检验单
        private void ReciveRecordLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rr = ReciveRecordLst.SelectedItem as ReciveRecord;
        }
        //选择检验单后下一步
        private void btnRRNext_Click(object sender, RoutedEventArgs e)
        {
            if (rr == null)
            {
                MessageBox.Show("请选择验收单");
                return;
            }
            tabControl.SelectedIndex = 2;
        }
        private void RacksLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            racks = RacksLst.SelectedItem as Racks;
        }
        
        //选择挂具后下一步
        private void btnRackNext_Click(object sender, RoutedEventArgs e)
        {
            if (racks == null)
            {
                MessageBox.Show("请选择挂具");
                return;
            }
            stepslist.Clear();//每次重新选择条件后再次进入工艺路线生成时清空原来历史数据
            Materiel materiel = materielBll.GetModel(po.MaterielID.ToInt());
            if (po != null && rr != null && materiel != null)
            {
                tabControl.SelectedIndex = 3;
                ProcessSteps ps1 = new ProcessSteps();
                ps1.JobOrderID = JobOrderID;
                ps1.StepName = "进料";
                ps1.StepNumber = 1;
                ps1.ProcessingPoolType = AttributesHelper.GetEnumDescription<PoolTypeEnum>(PoolTypeEnum.InPool);
                ps1.StationType = materiel.StationType;
                ps1.LengthOfStay = 1;
                ps1.Statue = (int)JobOrderStatusEnum.Executing;
                stepslist.Add(ps1);
                int i = 0;
                if (rr.CorrosionDegree == "D")
                {
                    i++;
                    ProcessSteps psx = new ProcessSteps();
                    psx.JobOrderID = JobOrderID;
                    psx.StepName = "废酸";
                    psx.StepNumber = 1 + i;
                    psx.ProcessingPoolType =AttributesHelper.GetEnumDescription<PoolTypeEnum>(PoolTypeEnum.StrongPicklingPool);
                    psx.StationType = materiel.StationType;
                    psx.LengthOfStay = rr.SpecialProcessLengthOfStay;
                    psx.Statue = 1;
                    stepslist.Add(psx);
                }
                ProcessSteps ps2 = new ProcessSteps();
                ps2.JobOrderID = JobOrderID;
                ps2.StepName = "酸洗";
                ps2.StepNumber = 2 + i;
                ps2.ProcessingPoolType = AttributesHelper.GetEnumDescription<PoolTypeEnum>(PoolTypeEnum.PicklingPool) ;
                ps2.StationType = materiel.StationType;
                ps2.LengthOfStay = materiel.Pickling;
                ps2.Statue = (int)JobOrderStatusEnum.UnDone;
                stepslist.Add(ps2);

                ProcessSteps ps3 = new ProcessSteps();
                ps3.JobOrderID = JobOrderID;
                ps3.StepName = "出料";
                ps3.StepNumber = 3 + i;
                ps3.ProcessingPoolType = AttributesHelper.GetEnumDescription<PoolTypeEnum>(PoolTypeEnum.OutPool);
                ps3.StationType = materiel.StationType;
                ps3.LengthOfStay = 1;
                ps3.Statue = (int)JobOrderStatusEnum.UnDone;
                stepslist.Add(ps3);

                this.ListProcessSteps.ItemsSource = stepslist;
            }
            else
            {
                MessageBox.Show("订单、检验单或材料类型有异常");
                return;
            }
        }
        private void btnDebNext_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 4;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text.ToInt() <= 0)
            {
                MessageBox.Show("请输入正确的处理数量");
                return;
            }
            JobOrder model = new JobOrder();
                model.JobOrderID = JobOrderID;
                model.ReciveRecordID = rr.ReciveRecordID;
                model.RacksID = racks.RacksID.ToString();
                model.ProductionOderID = po.ProductionOderID;
                model.Status = (int)JobOrderStatusEnum.Executing;
                model.StartTime = DateTime.Now;
                model.Number = txtNumber.Text.Trim().ToInt();
                model.CreateTime = DateTime.Now;
                model.CteateUser = ""; //this.txtCteateUser.Text.Trim(); 
                model.ModifyTime = DateTime.Now;
                model.ModifyUser = ""; //this.txtModifyUser.Text.Trim(); 

                if (stepslist.Count > 0)
                {
                    if (joborderBll.Add(model))
                    {
                        stepslist.Where(a => a.StepNumber == 1).FirstOrDefault<ProcessSteps>().StartTime = DateTime.Now;
                        if (processstepsBll.Add(stepslist.ToList()))
                        {
                            MessageBox.Show("任务单添加成功并开始处理");
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("任务单生成步骤出现异常，请联系管理员排查");
                        }
                    }
                }
                else {
                    MessageBox.Show("加工步骤设置不正确");
                }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void yc_Click(object sender, RoutedEventArgs e)
        {
            ProcessSteps ps = ListProcessSteps.SelectedItem as ProcessSteps;
            foreach (ProcessSteps item in stepslist)
            {
                if (item.StepNumber > ps.StepNumber)
                {
                    item.StepNumber = item.StepNumber - 1;
                }
            }
            stepslist.Remove(ps);
            this.ListProcessSteps.ItemsSource = null;
            this.ListProcessSteps.ItemsSource = stepslist;
        }

        private void fz_Click(object sender, RoutedEventArgs e)
        {
            ProcessSteps psnew = new ProcessSteps();
            ProcessSteps ps = ListProcessSteps.SelectedItem as ProcessSteps;
            psnew.JobOrderID = ps.JobOrderID;
            psnew.StepName = ps.StepName;
            psnew.StepNumber = ps.StepNumber + 1;
            psnew.ProcessingPoolType = ps.ProcessingPoolType;
            psnew.StationType = ps.StationType;
            psnew.LengthOfStay = ps.LengthOfStay;
            psnew.Statue = (int)JobOrderStatusEnum.UnDone;

            foreach (ProcessSteps item in stepslist)
            {
                if (item.StepNumber > ps.StepNumber)
                {
                    item.StepNumber = item.StepNumber + 1;
                }
            }
            stepslist.Add(psnew);
            this.ListProcessSteps.ItemsSource = null;
            this.ListProcessSteps.ItemsSource = stepslist;
            Sort("StepNumber", ListSortDirection.Ascending);
        }
        /// <summary>
        /// 模拟点击列头
        /// </summary>
        /// <param name="c">列名</param>
        /// <param name="d">方向</param>
        private void Sort(string c, ListSortDirection d)
        {
            ICollectionView v = CollectionViewSource.GetDefaultView(ListProcessSteps.ItemsSource);
            v.SortDescriptions.Clear();
            v.SortDescriptions.Add(new SortDescription(c, d));
            v.Refresh();
            this.ListProcessSteps.ColumnFromDisplayIndex(0).SortDirection = d;
        }

        private void Reduce_Click(object sender, RoutedEventArgs e)
        {
            ProcessSteps ps = ListProcessSteps.SelectedItem as ProcessSteps;
            ps.LengthOfStay--;
            this.ListProcessSteps.ItemsSource = null;
            this.ListProcessSteps.ItemsSource = stepslist;
        }

        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            ProcessSteps ps = ListProcessSteps.SelectedItem as ProcessSteps;
            ps.LengthOfStay++;
            this.ListProcessSteps.ItemsSource = null;
            this.ListProcessSteps.ItemsSource = stepslist;
        }
    }
}