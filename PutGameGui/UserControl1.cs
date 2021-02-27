using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PutGameFrame.Map;

namespace PutGameGui
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1(int trows, int tcols)
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            rows = trows;
            cols = tcols;
        }
        /// <summary>
        /// 设置值
        /// </summary>
        public void setValue(List<SingleMap> map)
        {
            _map = map;
            this.Refresh();
        }

        private List<SingleMap> _map = null;


        //行
        private int rows = 100;
        //列
        private int cols = 50;
        //绘制
        public void Draw(Graphics g)
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Brush brush = Brushes.Orange;
                    if(_map != null)
                    {
                        if (_map[i * rows + j].topo == Topography.plain)
                        {
                            brush = Brushes.Orange;
                        }
                        else if (_map[i * rows + j].topo == Topography.hill)
                        {
                            brush = Brushes.DarkGreen;
                        }
                        else if (_map[i * rows + j].topo == Topography.water)
                        {
                            brush = Brushes.DarkBlue;
                        }

                    }


                    if (i % 2 == 1)
                    {
                        g.FillPie(brush, j * this.Width / (rows + 0.5f) + this.Width / 2 / (rows + 0.5f), i * this.Height / cols,
                            this.Width / (rows + 0.5f), this.Height / cols, 0, 360);
                    }
                    else
                    {
                        g.FillPie(brush, j * this.Width / (rows + 0.5f), i * this.Height / cols,
                            this.Width / (rows + 0.5f), this.Height / cols , 0, 360);
                    }
                }
            }
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void UserControl1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
