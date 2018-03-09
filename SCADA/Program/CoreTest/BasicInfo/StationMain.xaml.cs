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
    /// StationMain.xaml 的交互逻辑
    /// </summary>
    public partial class StationMain : UserControl
    {
        StationBLL stationBll = Engine.GetProvider<StationBLL>();
        public StationMain()
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
            if (this.txtStationID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and StationID like '%{0}%'", this.txtStationID.Text.Trim());
            }
            if (this.txtPoolID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and PoolID like '%{0}%'", this.txtPoolID.Text.Trim());
            }
            if (this.txtStationType.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and StationType like '%{0}%'", this.txtStationType.Text.Trim());
            }
            if (this.txtStationStatus.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and StationStatus like '%{0}%'", this.txtStationStatus.Text.Trim());
            }

            List<Station> list = stationBll.GetModelList(strWhere);
            this.StationList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Sreach();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StationAdd _stationForm = new StationAdd();
            _stationForm.EditMode = EditModeEnum.Add;
            _stationForm.ShowDialog();
            Sreach();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Station bc = StationList.SelectedItem as Station;
            if (bc == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (stationBll.Delete(bc.StationID))
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
            StationAdd _stationForm = new StationAdd();
            _stationForm.EditMode = EditModeEnum.Modify;
            Station station = StationList.SelectedItem as Station;
            if (station == null)
            {
                MessageBox.Show("请选择要修改的行");
                return;
            }
            _stationForm.station = station;
            _stationForm.ShowDialog();
            Sreach();
        }

    }
}