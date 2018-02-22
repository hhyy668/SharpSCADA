



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
    /// StationAdd.xaml 的交互逻辑
    /// </summary>
    public partial class StationAdd : Window
    {
        StationBLL stationBll = Engine.GetProvider<StationBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public Station station = null;
        public StationAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            //cmbPoolType.SelectedValuePath = "key";
            //cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && station != null)
            {
                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();               
                		        	this.txtStationID.Text = station.StationID.ToString();    
						        	this.txtPoolID.Text = station.PoolID.ToString();    
						        	this.txtStationType.Text = station.StationType;    
						        	this.txtStationStatus.Text = station.StationStatus.ToString();    
				                
            }
            else
            {
                //cmbPoolType.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {          
            if (EditMode == EditModeEnum.Modify && station != null)
            {
                
                					station.StationID = this.txtStationID.Text.Trim().ToInt(); 
									station.PoolID = this.txtPoolID.Text.Trim().ToInt(); 
									station.StationType = this.txtStationType.Text.Trim(); 
									station.StationStatus = this.txtStationStatus.Text.Trim().ToInt(); 
				                if (stationBll.Update(station))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
            {
                Station model = new Station();
                					model.StationID = txtStationID.Text.Trim().ToInt();
									model.PoolID = txtPoolID.Text.Trim().ToInt();
									model.StationType = txtStationType.Text.Trim();
									model.StationStatus = txtStationStatus.Text.Trim().ToInt();
				                
                if (stationBll.Add(model))
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