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
    /// ReciveRecordAdd.xaml 的交互逻辑
    /// </summary>
    public partial class ReciveRecordAdd : Window
    {
        ReciveRecordBLL reciverecordBll = Engine.GetProvider<ReciveRecordBLL>();
        UtilityBLL utilityBll = Engine.GetProvider<UtilityBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public ReciveRecord reciverecord = null;
        public ReciveRecordAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && reciverecord != null)
            {            
                	this.txtReciveRecordID.Text = reciverecord.ReciveRecordID.ToString();    
					this.txtProductionOderID.Text = reciverecord.ProductionOderID.ToString();    
					this.txtCorrosionDegree.Text = reciverecord.CorrosionDegree;
                this.txtCorrosionMsg.Text = reciverecord.CorrosionMsg;
                this.txtSpecialProcessLengthOfStay.Text = reciverecord.SpecialProcessLengthOfStay.ToString();
                this.txtVehicleID.Text = reciverecord.VehicleID;
                this.txtDriver.Text = reciverecord.Driver;    
					this.txtDriverPhone.Text = reciverecord.DriverPhone;    
					this.txtRoughWeight.Text = reciverecord.RoughWeight.ToString();    
					this.txtTareWeight.Text = reciverecord.TareWeight.ToString();    
					this.txtAcceptWeight.Text = reciverecord.AcceptWeight.ToString();     			                
            }
            else
            {
                this.txtReciveRecordID.Text = utilityBll.GenerateSeq(SequenceType.RR);
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {          
            if (EditMode == EditModeEnum.Modify && reciverecord != null)
            {               
					reciverecord.ProductionOderID = this.txtProductionOderID.Text.Trim().ToInt(); 
					reciverecord.VehicleID = this.txtVehicleID.Text.Trim();
                reciverecord.CorrosionDegree= txtCorrosionDegree.Text;
                 reciverecord.CorrosionMsg= this.txtCorrosionMsg.Text;
                reciverecord.SpecialProcessLengthOfStay= this.txtSpecialProcessLengthOfStay.Text.ToInt() ;
                reciverecord.Driver = this.txtDriver.Text.Trim(); 
					reciverecord.DriverPhone = this.txtDriverPhone.Text.Trim(); 
					reciverecord.RoughWeight = this.txtRoughWeight.Text.Trim().ToDecimal(); 
					reciverecord.TareWeight = this.txtTareWeight.Text.Trim().ToDecimal(); 
					reciverecord.AcceptWeight = this.txtAcceptWeight.Text.Trim().ToDecimal(); 
					reciverecord.ModifyTime = DateTime.Now;
                    reciverecord.ModifyUser = ""; //this.txtModifyUser.Text.Trim(); 
				if (reciverecordBll.Update(reciverecord))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
            }
            else
            {
                ReciveRecord model = new ReciveRecord();
                model.ReciveRecordID = txtReciveRecordID.Text.Trim();
				model.ProductionOderID = txtProductionOderID.Text.Trim().ToInt();
                model.CorrosionDegree = txtCorrosionDegree.Text;
                model.CorrosionMsg = this.txtCorrosionMsg.Text;
                model.SpecialProcessLengthOfStay = this.txtSpecialProcessLengthOfStay.Text.ToInt();
                model.VehicleID = txtVehicleID.Text.Trim();
				model.Driver = txtDriver.Text.Trim();
				model.DriverPhone = txtDriverPhone.Text.Trim();
				model.RoughWeight = txtRoughWeight.Text.Trim().ToDecimal();
				model.TareWeight = txtTareWeight.Text.Trim().ToDecimal();
				model.AcceptWeight = txtAcceptWeight.Text.Trim().ToDecimal();
				model.CreateTime = DateTime.Now;
                model.CteateUser =  ""; //this.txtCteateUser.Text.Trim(); 
				model.ModifyTime =  DateTime.Now;
				model.ModifyUser =  ""; //this.txtModifyUser.Text.Trim(); 
				                
                if (reciverecordBll.Add(model))
                {
                    MessageBox.Show("添加成功");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void SelectGoBack(ProductionOder productionoder)
        {
            this.txtProductionOderID.Text = productionoder.ProductionOderID.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProductionOderSelect();//Windows窗体
            window.Owner = this;
            window.Show();
        }

        private void txtCorrosionDegree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (txtCorrosionDegree.SelectedValue.ToString())
            {
                case "A":
                    txtCorrosionMsg.Text = "大面积覆盖粘着的氧化皮，而几乎没有铁锈的钢材表面";
                    txtSpecialProcessLengthOfStay.Text = "0";
                    txtSpecialProcessLengthOfStay.Background = Brushes.AliceBlue;
                    txtSpecialProcessLengthOfStay.IsReadOnly = false;
                break;
                case "B":
                    txtCorrosionMsg.Text = "已开始锈蚀，且氧化皮已开始剥落的钢材表面";
                    txtSpecialProcessLengthOfStay.Text = "0";
                    txtSpecialProcessLengthOfStay.Background = Brushes.AliceBlue;
                    txtSpecialProcessLengthOfStay.IsReadOnly = false;
                    break;
                case "C":
                    txtCorrosionMsg.Text = "氧化皮已因为锈蚀而剥落或者可以刮除，但在正常视力观察下仅见到少量点蚀的钢材表面";
                    txtSpecialProcessLengthOfStay.Text = "0";
                    txtSpecialProcessLengthOfStay.Background = Brushes.AliceBlue;
                    txtSpecialProcessLengthOfStay.IsReadOnly = false;
                    break;
                case "D":
                    txtCorrosionMsg.Text = "氧化皮已因锈蚀而剥离，在正常视力观察下，已可见普遍发生点蚀的钢材表面";
                    txtSpecialProcessLengthOfStay.Text = "10";
                    txtSpecialProcessLengthOfStay.IsReadOnly = true;
                    break;
                default:
                    txtCorrosionMsg.Text = "";
                    break;
            }
        }
    }
}