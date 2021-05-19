using IOT.Core.IRepository.Colonel;
using IOT.Core.IRepository.Colonel.ColonelManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColonelController : ControllerBase
    {
        private IColonelRepository _colonelRepository;
        private IColonelManagementRepository _colonelManagementRepository;
        public ColonelController(IColonelRepository colonelRepository, IColonelManagementRepository colonelManagementRepository)
        {
            _colonelRepository = colonelRepository;
            _colonelManagementRepository = colonelManagementRepository;
        }

        /// <summary>
        /// 团长集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowColonel")]
        public IActionResult GetShowColonel()
        {
            List<Model.Colonel> colonels = _colonelRepository.ShowColonel();

            return Ok(colonels);
        }

        /// <summary>
        /// 团长审核and管理显示搜索
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowColonelList")]
        public IActionResult GetShowColonelList(int CheckStatus = -1, string nm = "")
        {
            List<Model.ViewColonelAndManager> colonels = _colonelManagementRepository.ShowColonelList(CheckStatus, nm);

            return Ok(colonels);
        }


        /// <summary>
        /// 团长审核修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptColonel_CheckStatus")]
        public int UptColonel_CheckStatus(Model.ColonelManagement colonelManagement)
        {
            int i = _colonelManagementRepository.UptColonel_CheckStatus(colonelManagement);
            return i;
        }

        /// <summary>
        /// 编辑团长
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptColonel")]
        public int UptColonel(Model.Colonel colonel)
        {
            int i = _colonelManagementRepository.UptColonel(colonel);
            return i;
        }

        /// <summary>
        /// 编辑团长商品
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Upt_Commodity_Colonel")]
        public int Upt_Commodity_Colonel(Model.Colonel colonel)
        {
            int i = _colonelManagementRepository.Upt_Commodity_Colonel(colonel);
            return i;
        }

        /// <summary>
        /// 添加核销员
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddUsers")]
        public int AddUsers(Model.Users a)
        {
            int i = _colonelManagementRepository.AddUsers(a);
            return i;
        }

        /// <summary>
        /// 显示核销员
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowUsers")]
        public IActionResult GetShowUsers(int ColonelID)
        {

            List<Model.Users> users = _colonelManagementRepository.ShowUsers(ColonelID);

            return Ok(users);
        }

    }
}
