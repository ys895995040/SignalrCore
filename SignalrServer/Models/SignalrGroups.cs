using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrServer.Models
{
    [Serializable]
    public class SignalrGroups
    {
        /// <summary>
        /// 用户组
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopId { get; set; }

        /// <summary>
        /// 链接id
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// 用户组内存集合
        /// </summary>
        public static List<SignalrGroups> UserGroups = new List<SignalrGroups> { };
    }
}
