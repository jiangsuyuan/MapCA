using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PutGameFrame.Map
{
    //地形
    public enum Topography
    {
        /// <summary>
        /// 水面
        /// </summary>
        water,
        /// <summary>
        /// 平原
        /// </summary>
        plain,
        /// <summary>
        /// 山地
        /// </summary>
        hill
    }

    //扩展地形
    public enum TopographyExtend
    {
        /// <summary>
        /// 森林
        /// </summary>
        forest,
        /// <summary>
        /// 草原
        /// </summary>
        grass,
        /// <summary>
        /// 沙漠
        /// </summary>
        desert,
        /// <summary>
        /// 冰原
        /// </summary>
        ice,
        /// <summary>
        /// 农田
        /// </summary>
        farm,

        ///// <summary>
        ///// 洞穴
        ///// </summary>
        //hole
    }

    /// <summary>
    /// 河流
    /// </summary>
    public enum river
    {
        /// <summary>
        /// 有河流
        /// </summary>
        hisRiver,
        /// <summary>
        /// 无河流
        /// </summary>
        noRiver
    }

    public enum AAA
    {
        /// <summary>
        /// 城
        /// </summary>
        city,
        /// <summary>
        /// 镇
        /// </summary>
        town,
        /// <summary>
        /// 村
        /// </summary>
        village,
        /// <summary>
        /// 空
        /// </summary>
        none
    }

    //单个地图单元
    public class SingleMap
    {
        public Topography topo = Topography.plain;
        public TopographyExtend topoext = TopographyExtend.farm;
    }
}
