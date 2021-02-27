using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PutGameFrame.Map
{



    //地图（六边形网格）
    public class BigMap
    {
        public BigMap(int rows, int cols, int nut)
        {
            //初始化元胞自动机
            _rows = rows;
            _cols = cols;
            _nut = nut;

            Initialize();
        }

        public List<SingleMap> mapList = new List<SingleMap>();

        /// <summary>
        /// 行
        /// </summary>
        private int _rows = 0;
        /// <summary>
        /// 列
        /// </summary>
        private int _cols = 0;
        /// <summary>
        /// 随机数种子
        /// </summary>
        private int _nut = 0;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            Random rd = new Random(_nut);// + i * cols + j);
            mapList.Clear();
            for (int i = 0; i < _cols; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    SingleMap sm = new SingleMap();

                    int num = rd.Next(0, 100);
                    if (num < 15)
                    {
                        sm.topo = Topography.water;
                    }
                    else if (num > 90)
                    {
                        sm.topo = Topography.hill;
                    }
                    else
                    {
                        sm.topo = Topography.plain;
                    }
                    mapList.Add(sm);
                }
            }
        }


        /// <summary>
        /// 迭代
        /// </summary>
        public void iterMap()
        {
            for (int i = 0; i < mapList.Count; i++)
            {
                iterSingleMap(i);
            }
        }
        /// <summary>
        /// 迭代中处理单块地图
        /// </summary>
        private void iterSingleMap(int index)
        {
            int rowIndex = (int)Math.Floor(index / (double)_rows);
            int colIndex = index % _rows;

            List<int> aroundList = GetAroundIndexs(rowIndex, colIndex);

            int hillNum = 0;
            int waterNum = 0;
            int plainNum = 0;
            for (int i = 0; i < aroundList.Count; i++)
            {
                if (mapList[aroundList[i]].topo == Topography.hill)
                {
                    hillNum++;
                }
                else if (mapList[aroundList[i]].topo == Topography.water)
                {
                    waterNum++;
                }
                else
                {
                    plainNum++;
                }
            }

            if (aroundList.Count < 6)
            {
                mapList[index].topo = Topography.water;
            }
            else
            {

                if (mapList[index].topo == Topography.hill)
                {
                    if (waterNum > 0 && waterNum <= 5)
                    {
                        mapList[index].topo = Topography.plain;
                    }
                    else if (plainNum == 6)
                    {
                        mapList[index].topo = Topography.plain;
                    }
                }
                else if (mapList[index].topo == Topography.water)
                {
                    if (plainNum >= 5)
                    {
                        mapList[index].topo = Topography.plain;
                    }
                    else if (plainNum <= 3 && hillNum == 1 && plainNum != 0)
                    {
                        mapList[index].topo = Topography.plain;
                    }
                    else if (plainNum == 1 && hillNum <= 2 && hillNum != 0)
                    {
                        mapList[index].topo = Topography.plain;
                    }
                    else if(waterNum == 0 && hillNum > 0)
                    {
                        mapList[index].topo = Topography.hill;
                    }

                }
                else if (mapList[index].topo == Topography.plain)
                {
                    if (waterNum >= 3 && hillNum <= 1)
                    {
                        mapList[index].topo = Topography.water;
                    }
                    else if (hillNum >= 2 && waterNum <= 1)
                    {
                        mapList[index].topo = Topography.hill;
                    }
                }
            }
        }
        /// <summary>
        /// 存储周围情况（左上角开始顺时针备用）
        /// </summary>
        /// <returns></returns>
        private List<int> GetAroundIndexs(int rowIndex, int colIndex)
        {
            List<int> aroundList = new List<int>();
            if (rowIndex != 0)
            {
                //左上
                if (rowIndex % 2 == 0)
                {
                    if (colIndex != 0)
                    {
                        aroundList.Add((rowIndex - 1) * _rows + colIndex - 1);
                    }
                }
                else
                {
                    aroundList.Add((rowIndex - 1) * _rows + colIndex);
                }
                //右上
                if (rowIndex % 2 == 0)
                {
                    aroundList.Add((rowIndex - 1) * _rows + colIndex);
                }
                else
                {
                    if (colIndex != _rows - 1)
                    {
                        aroundList.Add((rowIndex - 1) * _rows + colIndex + 1);
                    }
                }

            }
            if (colIndex != _rows - 1)
            {
                //右
                aroundList.Add(rowIndex * _rows + colIndex + 1);
            }
            if (rowIndex != _cols - 1)
            {
                //右下
                if (rowIndex % 2 == 0)
                {
                    aroundList.Add((rowIndex + 1) * _rows + colIndex);
                }
                else
                {
                    if (colIndex != _rows - 1)
                    {
                        aroundList.Add((rowIndex + 1) * _rows + colIndex + 1);
                    }
                }
                //左下
                if (rowIndex % 2 == 0)
                {
                    if (colIndex != 0)
                    {
                        aroundList.Add((rowIndex + 1) * _rows + colIndex - 1);
                    }
                }
                else
                {
                    aroundList.Add((rowIndex + 1) * _rows + colIndex);
                }
            }
            if (colIndex != 0)
            {
                //左
                aroundList.Add(rowIndex * _rows + colIndex - 1);
            }
            return aroundList;
        }


    }
}
