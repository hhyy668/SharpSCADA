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
    /// RacksAdd.xaml 的交互逻辑
    /// </summary>
    public partial class RacksAdd : Window
    {
        RacksBLL racksBll = Engine.GetProvider<RacksBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public Racks racks = null;
        public RacksAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            //cmbPoolType.SelectedValuePath = "key";
            //cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && racks != null)
            {
                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();               
                this.txtRacksID.Text = racks.RacksID.ToString();
                this.txtRacksName.Text = racks.RacksName;
                this.txtRacksType.Text = racks.RacksType.ToString();
                this.txtRacksStatus.Text = racks.RacksStatus.ToString();
                this.txtJobOrderID.Text = racks.JobOrderID.ToString();
                this.txtUseTime.Text = racks.UseTime.ToString();
                this.txtCreateTime.Text = racks.CreateTime.ToString();
                this.txtCteateUser.Text = racks.CteateUser;
                this.txtModifyTime.Text = racks.ModifyTime.ToString();
                this.txtModifyUser.Text = racks.ModifyUser;

            }
            else
            {
                //cmbPoolType.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && racks != null)
            {

                racks.RacksID = this.txtRacksID.Text.Trim().ToInt();
                racks.RacksName = this.txtRacksName.Text.Trim();
                racks.RacksType = this.txtRacksType.Text.Trim().ToInt();
                racks.RacksStatus = this.txtRacksStatus.Text.Trim().ToInt();
                racks.JobOrderID = this.txtJobOrderID.Text.Trim().ToInt();
                racks.UseTime = this.txtUseTime.Text.Trim().ToDateTime();
                racks.CreateTime = this.txtCreateTime.Text.Trim().ToDateTime();
                racks.CteateUser = this.txtCteateUser.Text.Trim();
                racks.ModifyTime = this.txtModifyTime.Text.Trim().ToDateTime();
                racks.ModifyUser = this.txtModifyUser.Text.Trim();
                if (racksBll.Update(racks))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
            {
                Racks model = new Racks();
                model.RacksID = txtRacksID.Text.Trim().ToInt();
                model.RacksName = txtRacksName.Text.Trim();
                model.RacksType = txtRacksType.Text.Trim().ToInt();
                model.RacksStatus = txtRacksStatus.Text.Trim().ToInt();
                model.JobOrderID = txtJobOrderID.Text.Trim().ToInt();
                if (!txtUseTime.Text.Trim().IsNullOrEmpty())
                {
                    model.UseTime = txtUseTime.Text.Trim().ToDateTime();
                }
                model.CreateTime = DateTime.Now;
                model.CteateUser = txtCteateUser.Text.Trim();
                model.ModifyTime = DateTime.Now;
                model.ModifyUser = txtModifyUser.Text.Trim();

                if (racksBll.Add(model))
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