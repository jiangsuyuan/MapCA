using PutGameFrame.Base;
using System;
using PutGameFrame.Map;
using System.Collections.Generic;

namespace PutGameFrame
{
    //游戏管理
    public class GameManager
    {
        #region 单例模式
        private static GameManager _instance;
        private static object _synobj = new object();
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_synobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new GameManager();
                        }
                    }
                }
                return _instance;
            }
        }
        private GameManager() { }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nut"></param>
        public void Initialize(int rows, int cols, int nut)
        {
            //初始化地图
            BasePGObject.Initialize(rows, cols, nut);
            //初始化城镇

            //初始化NPC

            //初始化任务

            //初始化动物

            //初始化物品

        }
        /// <summary>
        /// 开始运行
        /// </summary>
        public void Begin()
        {
            BasePGObject.BeginTimeTick();
        }
        /// <summary>
        /// 获取地图
        /// </summary>
        /// <returns></returns>
        public List<SingleMap> GetMap()
        {
            return BasePGObject.map.mapList;
        }











    }
}
