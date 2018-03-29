using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using SignalrServer.Hubs;
using SignalrServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SignalrServer.Controllers
{
    [Produces("application/json")]
    [Route("api/MRSoftPush")]
    public class MRSoftPushController : Controller
    {
        private IHubContext<SignalrHubs> hubContext;
        public MRSoftPushController(IServiceProvider service)
        {
            hubContext = service.GetService<IHubContext<SignalrHubs>>();
        }

        [HttpGet]
        public string Get()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff");
        }

        /// <summary>
        /// 单个connectionid推送
        /// </summary>
        /// <param name="groups"></param>
        /// <returns></returns>
        [HttpPost,Route("AnyOne")]
        public IActionResult AnyOne([FromBody]IEnumerable<SignalrGroups> groups)
        {
            if (groups != null && groups.Any())
            {
                var ids = groups.Select(c=>c.ShopId);
                var list = SignalrGroups.UserGroups.Where(c=>ids.Contains(c.ShopId));
                foreach (var item in list)
                    hubContext.Clients.Client(item.ConnectionId).InvokeAsync("AnyOne", $"{item.ConnectionId}: {item.Content}");
            }
            return Ok();
        }

        /// <summary>
        /// 全部推送
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet,Route("EveryOne")]
        public IActionResult EveryOne(string message)
        {
            hubContext.Clients.All.InvokeAsync("EveryOne", $"{message}");
            return Ok();
        }

        /// <summary>
        /// 组推送
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        [HttpPost,Route("AnyGroups")]
        public IActionResult AnyGroups([FromBody]SignalrGroups group)
        {
            if (group != null)
            {
                hubContext.Clients.Group(group.GroupName).InvokeAsync("AnyGroups", $"{group.Content}");
            }
            return Ok();
        }

        /// <summary>
        /// 多参数接收方式
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet,Route("MoreParamsRequest")]
        public IActionResult MoreParamsRequest(string message)
        {
            hubContext.Clients.All.InvokeAsync("MoreParamsRequest", message, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"));
            return Ok();
        }
    }
}