using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Easy4net.Entity;
using LieBaoModels;
using DevExpress.XtraGrid.Views.Grid;

namespace WindowsDemo.ManageForm
{
    public partial class OrderProductionForm : DevExpress.XtraEditors.XtraForm
    {
        public OrderProductionForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.Load += new System.EventHandler(this.OrderProductionForm_Load);
        }
                //窗体加载事件
        private void OrderProductionForm_Load(object sender, EventArgs e)
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
                    sName += "[" + this.gvUserControl.GetRowCellValue((iSelectRow[i]), "OrderID").ToString() + "] ";
                }

                if (MessageBox.Show("确定删除" + sName + " 的记录吗？", "删除提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int j = 0; j < iSelectRow.Length; j++)
                    {
                        object o = this.gvUserControl.GetRow(iSelectRow[j]);
                        LB_OrderProduction entity = o as LB_OrderProduction;
                        DataBaseHelper.GetDB().LB_OrderProduction.Delete(entity);
                    }
                }

                LoadGridControlList();
            }
        }

        //初始化新增行
        private void gvUserControl_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //gvUserControl.SetRowCellValue(e.RowHandle, "ItemPre", "");
            //gvUserControl.SetRowCellValue(e.RowHandle, "ItemID", "");
            //gvUserControl.SetRowCellValue(e.RowHandle, "ItemName", "");
            //gvUserControl.SetRowCellValue(e.RowHandle, "ItemGroup", "");
            //gvUserControl.SetRowCellValue(e.RowHandle, "DataType",0);
            //gvUserControl.SetRowCellValue(e.RowHandle, "ItemValue", "");
            //gvUserControl.SetRowCellValue(e.RowHandle, "ReMark", "");

        }

        //保存新增数据
        private void gvUserControl_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            LB_OrderProduction entity = e.Row as LB_OrderProduction;
            if (entity.CreatTime.ToString("yyyy/M/d H:mm:ss") == "0001/1/1 0:00:00")
            {
                this.gvUserControl.UpdateCurrentRow();
                entity.CreatTime = DateTime.Now;
                entity.ChangeTime = DateTime.Now;
                entity.Status = 1;
                DataBaseHelper.GetDB().LB_OrderProduction.Insert(entity);
                LoadGridControlList();
            }
            entity.ChangeTime = DateTime.Now;
            DataBaseHelper.GetDB().LB_OrderProduction.Update(entity);
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
            if (gv.GetRowCellValue(e.RowHandle, "OrderID") == null ||
                gv.GetRowCellValue(e.RowHandle, "RecipeID") == null ||
                gv.GetRowCellValue(e.RowHandle, "ProductionOutput") == null)
            {
                e.Valid = false;
                e.ErrorText = "是个撒到过类型不可为空";
            }

            
        }

        #region 自定义方法区
        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadGridControlList()
        {
            List<LB_OrderProduction> data = DataBaseHelper.GetDB().LB_OrderProduction.FindAll().OrderByOrderID().ToList<LB_OrderProduction>();
            BindingList<LB_OrderProduction> temp = new BindingList<LB_OrderProduction>(data);
            this.gcUserControl.DataSource = temp;
            //根据总行数设置行号宽度
            this.gvUserControl.IndicatorWidth = 28 + (data.Count().ToString().Length - 1) * 7;
        }
        #endregion
        #endregion

    }
}