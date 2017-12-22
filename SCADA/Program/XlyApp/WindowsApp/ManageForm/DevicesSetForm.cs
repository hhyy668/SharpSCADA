using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LieBaoModels;
using DevExpress.XtraGrid.Views.Grid;

namespace WindowsDemo.ManageForm
{
    public partial class DevicesSetForm : DevExpress.XtraEditors.XtraForm
    {
        public DevicesSetForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
        }
                //窗体加载事件
        private void DevicesSetForm_Load(object sender, EventArgs e)
        {
            //格式化GridControl
            GridControlHelper.FormatGridControl(this.gcUserControl);
            //支持多选
            this.gvUserControl.OptionsSelection.MultiSelect = true;
            //加载数据
            LoadGridControlList();

            //初始化新增行
            this.gvUserControl.InitNewRow += gvUserControl_InitNewRow;
            //行更新或插入数据
            this.gvUserControl.RowUpdated += gvUserControl_RowUpdated;
            //删除数据
            this.gvUserControl.KeyDown += gvUserControl_KeyDown;
            //数据验证错误提示方式
            this.gvUserControl.InvalidRowException += gvUserControl_InvalidRowException;
            //验证数据正确性
            this.gvUserControl.ValidateRow += gvUserControl_ValidateRow;
        }

        //删除选中的行
        private void gvUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int[] iSelectRow = this.gvUserControl.GetSelectedRows();
                string sName = "";
                for (int i = 0; i < iSelectRow.Length; i++)
                {
                    sName += "[" + this.gvUserControl.GetRowCellValue((iSelectRow[i]), "UserControlName").ToString() + "] ";
                }

                if (MessageBox.Show("确定删除" + sName + " 的记录吗？", "删除提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int j = 0; j < iSelectRow.Length; j++)
                    {
                        object o = this.gvUserControl.GetRow(iSelectRow[j]);
                        LieBaoModels.UserControl entity = o as LieBaoModels.UserControl;
                        DataBaseHelper.GetDB().UserControl.Delete(entity);
                    }
                }

                LoadGridControlList();
            }
        }

        //初始化新增行
        private void gvUserControl_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvUserControl.SetRowCellValue(e.RowHandle, "UserControlName", "");
            gvUserControl.SetRowCellValue(e.RowHandle, "UserControJson", "");
            gvUserControl.SetRowCellValue(e.RowHandle, "JsonLenth", 0);
            gvUserControl.SetRowCellValue(e.RowHandle, "ReMark", "");

        }

        //保存新增数据
        private void gvUserControl_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            LieBaoModels.UserControl entity = e.Row as LieBaoModels.UserControl;
            if (entity.CreatTime.ToString("yyyy/M/d H:mm:ss") == "0001/1/1 0:00:00")
            {
                this.gvUserControl.UpdateCurrentRow();
                entity.CreatTime = DateTime.Now;
                entity.ChangeTime = DateTime.Now;
                entity.Status = 1;
                DataBaseHelper.GetDB().UserControl.Insert(entity);
                LoadGridControlList();
            }
            entity.ChangeTime = DateTime.Now;
            DataBaseHelper.GetDB().UserControl.Update(entity);
        }

        //数据验证错误提示方式
        private void gvUserControl_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }

        //验证数据正确性
        private void gvUserControl_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gv = sender as GridView;
            if (gv.GetRowCellValue(e.RowHandle, "UserControlName") == null || gv.GetRowCellValue(e.RowHandle, "UserControJson") == null || gv.GetRowCellValue(e.RowHandle, "JsonLenth") == null)
            {
                e.Valid = false;
                e.ErrorText = "控件名称、数据点定义、数据点数量不可为空";
            }

            if (gv.GetRowCellValue(e.RowHandle, "UserControlName").ToString() == "")
            {
                e.Valid = false;
                gv.SetColumnError(gv.Columns["UserControlName"], "控件名称不能为空");
                e.ErrorText = "控件名称不能为空";
            }
            if (gv.GetRowCellValue(e.RowHandle, "UserControJson").ToString() == "")
            {
                e.Valid = false;
                gv.SetColumnError(gv.Columns["UserControJson"], "数据点定义不能为空");
                e.ErrorText = "数据点定义不能为空";
            }
            if (gv.GetRowCellValue(e.RowHandle, "JsonLenth").ToString().ToInt() == 0)
            {
                e.Valid = false;
                gv.SetColumnError(gv.Columns["JsonLenth"], "数据点数量必须大于0");
                e.ErrorText = "数据点数量必须大于0";
            }
        }

        #region 自定义方法区
        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadGridControlList()
        {
            List<LieBaoModels.UserControl> data = DataBaseHelper.GetDB().UserControl.FindAllByStatus(1).OrderByCreatTime().ToList<LieBaoModels.UserControl>();
            BindingList<LieBaoModels.UserControl> temp = new BindingList<LieBaoModels.UserControl>(data);
            this.gcUserControl.DataSource = temp;
            //根据总行数设置行号宽度
            this.gvUserControl.IndicatorWidth = 28 + (data.Count().ToString().Length - 1) * 7;
        }
        #endregion
        #endregion



    }
}