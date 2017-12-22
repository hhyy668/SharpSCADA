/************************************************************
* Copyright ©2012 孤独工作室 All Rights Reserved
* Author: 孤独求醉(125700652@qq.com)
* Create: 2013-06-26 14:38:07
* **********************************************************/

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace WindowsDemo
{
    public static class GridControlHelper
    {
        #region 格式化GridControl
        /// <summary>
        /// 格式化GridControl
        /// </summary>
        /// <param name="pGridControl"></param>
        public static void FormatGridControl(GridControl pGridControl)
        {
            pGridControl.UseEmbeddedNavigator = true;
            BaseView bv = pGridControl.MainView;
            GridView gv = bv as GridView;
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsNavigation.AutoFocusNewRow = true;
            gv.OptionsNavigation.AutoMoveRowFocus = true;
            gv.OptionsNavigation.EnterMoveNextColumn = true;
            gv.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gv.BestFitColumns();
            SetTextOption(gv);

            //显示行号
            gv.CustomDrawRowIndicator += gv_CustomDrawRowIndicator;
        }
        #endregion

        
        #region 显示行号
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void gv_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region 设置抬头对齐方式
        /// <summary>
        /// 设置抬头对齐方式
        /// </summary>
        /// <param name="pGridView"></param>
        private static void SetTextOption(GridView pGridView)
        {
            int iColumnsCount = pGridView.Columns.Count;
            for (int i = 0; i < iColumnsCount; i++)
            {
                pGridView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }
        #endregion
        
    }
}
