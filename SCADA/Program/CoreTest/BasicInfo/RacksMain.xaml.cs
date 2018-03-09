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
    /// RacksMain.xaml 的交互逻辑
    /// </summary>
    public partial class RacksMain : UserControl
    {
        RacksBLL racksBll = Engine.GetProvider<RacksBLL>();
        public RacksMain()
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
            if (this.txtRacksID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and RacksID like '%{0}%'", this.txtRacksID.Text.Trim());
            }
            if (this.txtRacksName.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and RacksName like '%{0}%'", this.txtRacksName.Text.Trim());
            }
            if (this.txtRacksType.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and RacksType like '%{0}%'", this.txtRacksType.Text.Trim());
            }
            if (this.txtRacksStatus.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and RacksStatus like '%{0}%'", this.txtRacksStatus.Text.Trim());
            }
            if (this.txtJobOrderID.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and JobOrderID like '%{0}%'", this.txtJobOrderID.Text.Trim());
            }
            if (this.txtUseTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and UseTime like '%{0}%'", this.txtUseTime.Text.Trim());
            }
            if (this.txtCreateTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and CreateTime like '%{0}%'", this.txtCreateTime.Text.Trim());
            }
            if (this.txtCteateUser.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and CteateUser like '%{0}%'", this.txtCteateUser.Text.Trim());
            }
            if (this.txtModifyTime.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ModifyTime like '%{0}%'", this.txtModifyTime.Text.Trim());
            }
            if (this.txtModifyUser.Text.Trim() != "")
            {
                strWhere = strWhere + string.Format(" and ModifyUser like '%{0}%'", this.txtModifyUser.Text.Trim());
            }

            List<Racks> list = racksBll.GetModelList(strWhere);
            this.RacksList.DataContext = list;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Sreach();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            RacksAdd _racksForm = new RacksAdd();
            _racksForm.EditMode = EditModeEnum.Add;
            _racksForm.ShowDialog();
            Sreach();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Racks bc = RacksList.SelectedItem as Racks;
            if (bc == null)
            {
                MessageBox.Show("请选择要删除的行");
                return;
            }
            if (racksBll.Delete(bc.RacksID))
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
            RacksAdd _racksForm = new RacksAdd();
            _racksForm.EditMode = EditModeEnum.Modify;
            Racks racks = RacksList.SelectedItem as Racks;
            if (racks == null)
            {
                MessageBox.Show("请选择要修改的行");
                return;
            }
            _racksForm.racks = racks;
            _racksForm.ShowDialog();
            Sreach();
        }

    }
}