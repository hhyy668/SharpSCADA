﻿using System;
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
    /// Index.xaml 的交互逻辑
    /// </summary>
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 基础信息管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasicInfo_Click(object sender, RoutedEventArgs e)
        {
            BasicInfo basicMain = new BasicInfo();
            basicMain.Show();
        }
        /// <summary>
        /// 可视监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTag_Click(object sender, RoutedEventArgs e)
        {
            TagMonitor tag = new TagMonitor();
            tag.Show();
        }
    }
}