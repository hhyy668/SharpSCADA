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
    /// MaterielAdd.xaml 的交互逻辑
    /// </summary>
    public partial class MaterielAdd : Window
    {
        MaterielBLL materielBll = Engine.GetProvider<MaterielBLL>();
        public EditModeEnum EditMode = EditModeEnum.Modify;
        public Materiel materiel = null;
        public MaterielAdd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbPoolType.ItemsSource = AttributesHelper.GetEnumValueDesc<PoolTypeEnum>();
            //cmbPoolType.SelectedValuePath = "key";
            //cmbPoolType.DisplayMemberPath = "Value";
            if (EditMode == EditModeEnum.Modify && materiel != null)
            {
                //cmbPoolType.SelectedIndex = AttributesHelper.GetEnumKeyByDescription<PoolTypeEnum>(pool.PoolType).ToInt();               
                this.txtMaterielID.Text = materiel.MaterielID.ToString();
                this.txtMaterielType.Text = materiel.MaterielType;
                this.txtSpec.Text = materiel.Spec;
                this.txtDepict.Text = materiel.Depict;
                this.txtSkim.Text = materiel.Skim.ToString();
                this.txtOneWash.Text = materiel.OneWash.ToString();
                this.txtPickling.Text = materiel.Pickling.ToString();
                this.txtTwoWash.Text = materiel.TwoWash.ToString();
                this.txtAuxiliary.Text = materiel.Auxiliary.ToString();
                this.txtDry.Text = materiel.Dry.ToString();

            }
            else
            {
                //cmbPoolType.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode == EditModeEnum.Modify && materiel != null)
            {

                materiel.MaterielID = this.txtMaterielID.Text.Trim().ToInt();
                materiel.MaterielType = this.txtMaterielType.Text.Trim();
                materiel.Spec = this.txtSpec.Text.Trim();
                materiel.Depict = this.txtDepict.Text.Trim();
                materiel.Skim = this.txtSkim.Text.Trim().ToInt();
                materiel.OneWash = this.txtOneWash.Text.Trim().ToInt();
                materiel.Pickling = this.txtPickling.Text.Trim().ToInt();
                materiel.TwoWash = this.txtTwoWash.Text.Trim().ToInt();
                materiel.Auxiliary = this.txtAuxiliary.Text.Trim().ToInt();
                materiel.Dry = this.txtDry.Text.Trim().ToInt();
                if (materielBll.Update(materiel))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                    return;
                }
            }
            else
            {
                Materiel model = new Materiel();
                model.MaterielID = txtMaterielID.Text.Trim().ToInt();
                model.MaterielType = txtMaterielType.Text.Trim();
                model.Spec = txtSpec.Text.Trim();
                model.Depict = txtDepict.Text.Trim();
                model.Skim = txtSkim.Text.Trim().ToInt();
                model.OneWash = txtOneWash.Text.Trim().ToInt();
                model.Pickling = txtPickling.Text.Trim().ToInt();
                model.TwoWash = txtTwoWash.Text.Trim().ToInt();
                model.Auxiliary = txtAuxiliary.Text.Trim().ToInt();
                model.Dry = txtDry.Text.Trim().ToInt();

                if (materielBll.Add(model))
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