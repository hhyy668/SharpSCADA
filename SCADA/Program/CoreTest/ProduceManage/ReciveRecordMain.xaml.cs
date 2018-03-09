

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
    /// ReciveRecordMain.xaml 的交互逻辑
    /// </summary>
    public partial class ReciveRecordMain : UserControl
    {
        ReciveRecordBLL reciverecordBll = Engine.GetProvider<ReciveRecordBLL>();
        public ReciveRecordMain()
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
            		            if (this.txtReciveRecordID.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and ReciveRecordID like '%{0}%'", this.txtReciveRecordID.Text.Trim());
		            }
					            if (this.txtProductionOderID.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and ProductionOderID like '%{0}%'", this.txtProductionOderID.Text.Trim());
		            }
					            if (this.txtVehicleID.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and VehicleID like '%{0}%'", this.txtVehicleID.Text.Trim());
		            }
					            if (this.txtDriver.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and Driver like '%{0}%'", this.txtDriver.Text.Trim());
		            }
					            if (this.txtDriverPhone.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and DriverPhone like '%{0}%'", this.txtDriverPhone.Text.Trim());
		            }
					            if (this.txtRoughWeight.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and RoughWeight like '%{0}%'", this.txtRoughWeight.Text.Trim());
		            }
					            if (this.txtTareWeight.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and TareWeight like '%{0}%'", this.txtTareWeight.Text.Trim());
		            }
					            if (this.txtAcceptWeight.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and AcceptWeight like '%{0}%'", this.txtAcceptWeight.Text.Trim());
		            }
					            if (this.txtCreateTime.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and CreateTime like '%{0}%'", this.txtCreateTime.Text.Trim());
		            }
					            if (this.txtCteateUser.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and CteateUser like '%{0}%'", this.txtCteateUser.Text.Trim());
		            }
					            if (this.txtModifyTime.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and ModifyTime like '%{0}%'", this.txtModifyTime.Text.Trim());
		            }
					            if (this.txtModifyUser.Text.Trim() != "")
		            {
		                strWhere= strWhere+ string.Format(" and ModifyUser like '%{0}%'", this.txtModifyUser.Text.Trim());
		            }
			    
            List<ReciveRecord> list = reciverecordBll.GetModelList(strWhere);
            this.ReciveRecordList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Sreach();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ReciveRecordAdd _reciverecordForm = new ReciveRecordAdd();
            _reciverecordForm.EditMode = EditModeEnum.Add;
            _reciverecordForm.ShowDialog();
            Sreach();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ReciveRecord bc = ReciveRecordList.SelectedItem as ReciveRecord;
            if (bc == null) {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (reciverecordBll.Delete(bc.ReciveRecordID))
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
            ReciveRecordAdd _reciverecordForm = new ReciveRecordAdd();
            _reciverecordForm.EditMode = EditModeEnum.Modify;
            ReciveRecord reciverecord = ReciveRecordList.SelectedItem as ReciveRecord;
            if (reciverecord == null)
            {
                MessageBox.Show("请选择要修改的行");
                return;
            }
            _reciverecordForm.reciverecord = reciverecord;
            _reciverecordForm.ShowDialog();
            Sreach();
        }

    }
}