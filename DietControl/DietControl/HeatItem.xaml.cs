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
    /// HeatItem.xaml 的互動邏輯
    /// </summary>
    public partial class HeatItem : UserControl
    {
        public HeatItem()
        {
            InitializeComponent();
        }

        public event EventHandler DeleteItem;

        // 封裝屬性：價格數值
        public int itemHeatValue
        {
            get
            {
                try
                {
                    return int.Parse(FoodHeat.Text);
                }
                // 失敗後要求用家輸入數字
                catch
                {
                    if (FoodHeat.Text != "")
                    {

                        MessageBox.Show("請輸入數字");
                    }
                    return 0;
                }
            }
            set
            {
                FoodHeat.Text = value.ToString();
            }
        }

        // 鍵盤事件
        private void AddItem_MouseDown(object sender, KeyEventArgs e)
        {
            if (FoodHeat.Text == "" && e.Key == Key.Back)
            {
                DeleteItem(this, null);
            }
        }
    }
}
