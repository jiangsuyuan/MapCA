using System;
using System.Collections.Generic;
using System.Threading;
using PutGameFrame.Map;

namespace PutGameFrame.Base
{
    //基类
    public class BasePGObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BasePGObject(int timePiece)
        {
            this.PieceNumber = timePiece;
            objList.Add(this);
        }
        /// <summary>
        /// 析构函数
        /// </summary>
        ~BasePGObject()
        {
            objList.Remove(this);
        }

        #region 地图
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize(int rows, int cols ,int nut)
        {
            //初始化地图
            map = new BigMap(rows, cols, nut);
            map.iterMap();
        }
        /// <summary>
        /// 地图
        /// </summary>
        public static BigMap map = null;

        #endregion

        #region 公共计时器
        /// <summary>
        /// 当前时间
        /// </summary>
        private static Int64 currentTime = 0;
        /// <summary>
        /// 单个时间片毫秒数
        /// </summary>
        private static int SinglePieceTime = 100;
        /// <summary>
        /// 当前线程
        /// </summary>
        private static Thread timeThread = null;
        /// <summary>
        /// 是否暂停
        /// </summary>
        private static bool isPush = false;
        /// <summary>
        /// 开始
        /// </summary>
        public static void BeginTimeTick()
        {
            if (timeThread == null)
            {
                timeThread = new Thread(UpdateAll);
                timeThread.IsBackground = true;
                timeThread.Start();
            }
        }
        /// <summary>
        /// 暂停/取消暂停
        /// </summary>
        /// <param name="push"></param>
        public static void Push(bool push)
        {
            isPush = push;
        }

        /// <summary>
        /// 更新全部
        /// </summary>
        private static void UpdateAll()
        {
            while(true)
            {
                if (!isPush)
                {
                    currentTime++;
                    foreach (var obj in objList)
                    {
                        obj.TimeCompute();
                    }
                }
                Thread.Sleep(SinglePieceTime);
            }
        }
        //对象列表
        private static List<BasePGObject> objList = new List<BasePGObject>();
        //时间片计数
        private int PieceNumber = 5;
        //当前时间片
        private int currentPieceNumber = 0;
        /// <summary>
        /// 时间计算
        /// </summary>
        private void TimeCompute()
        {
            currentPieceNumber++;
            if(currentPieceNumber >= PieceNumber)
            {
                Update();
                Console.WriteLine(currentTime);
            }
        }
        #endregion

        /// <summary>
        /// 更新子类
        /// </summary>
        public virtual void Update()
        { }

    }
}
