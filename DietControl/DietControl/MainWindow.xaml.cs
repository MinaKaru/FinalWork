using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DietControl
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 新增按鈕按下事件
        private void AddItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 產生項目
            HeatItem item = new HeatItem();
            item.DeleteItem += new EventHandler(DeleteItem);

            // 放到清單中
            HeatList.Children.Add(item);

    
        }
            // 刪除事件
            private void DeleteItem(object sender, EventArgs e)
            {
                HeatList.Children.Remove((HeatItem)sender);
            }

        private void ENTER_MouseDown(object sender, MouseButtonEventArgs e)
        {

            // 建立空的數字
            int Ctotal = 0;
            int ends = 0;

            int i = 0;
            bool result = int.TryParse(AllHeat.Text, out i);
           
            // 計算每一個項目
            foreach (HeatItem HeatItems in HeatList.Children)
            {
                // 相加
                Ctotal += HeatItems.itemHeatValue;
            }
            ends = i - Ctotal;

            // 顯示
            BeLeftHeat.Text = ends.ToString();

            if (ends < 0)
            {
                double endsover = -ends;

                double hour = endsover / 400;

                MessageBox.Show("您需要慢跑" + hour + "小時 , 才能消耗這些熱量 !", "警告 ! 攝取過量 !");
            }
        }
    }
    }

