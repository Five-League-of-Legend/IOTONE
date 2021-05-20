﻿using IOT.Core.IRepository.Colonel;
using IOT.Core.IRepository.Colonel.Brokerage;
using IOT.Core.IRepository.Colonel.ColonelGrade;
using IOT.Core.IRepository.Colonel.ColonelManagement;
using IOT.Core.IRepository.Colonel.GroupPurchase;
using IOT.Core.IRepository.Colonel.Path;
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
        private IColonelGradeRepository _colonelGradeRepository;
        private IGroupPurchaseRepository _groupPurchaseRepository;
        private IPathRepository _pathRepository;
        private IBrokerageRepository _brokerageRepository;

        public ColonelController(
            IColonelRepository colonelRepository,
            IColonelManagementRepository colonelManagementRepository,
            IColonelGradeRepository colonelGradeRepository,
            IGroupPurchaseRepository groupPurchaseRepository,
            IPathRepository pathRepository,
            IBrokerageRepository brokerageRepository
            )
        {
            _colonelRepository = colonelRepository;
            _colonelManagementRepository = colonelManagementRepository;
            _colonelGradeRepository = colonelGradeRepository;
            _groupPurchaseRepository = groupPurchaseRepository;
            _pathRepository = pathRepository;
            _brokerageRepository = brokerageRepository;
        }

        //-------------------------------------------------------------------------------------------------
        //5.20

        /// <summary>
        /// 显示团长等级      根据团长等级ID反填
        /// </summary>
        /// <param name="CGId">团长等级ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowColonelGrade")]
        public IActionResult GetShowColonelGrade(int CGId = -1)
        {
            List<Model.ColonelGrade> colonelGrades = _colonelGradeRepository.ShowColonelGrade(CGId);

            return Ok(colonelGrades);
        }

        /// <summary>
        /// 编辑团长等级
        /// </summary>
        /// <param name="colonelGrade">团长等级</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptColonelGrade")]
        public int UptColonelGrade(Model.ColonelGrade colonelGrade)
        {
            int i = _colonelGradeRepository.UptColonelGrade(colonelGrade);
            return i;
        }

        /// <summary>
        /// 删除团长等级
        /// </summary>
        /// <param name="CGId">团长等级Id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/DelColonelGrade")]
        public int DelColonelGrade(int CGId)
        {
            int i = _colonelGradeRepository.DelColonelGrade(CGId);
            return i;
        }

        /// <summary>
        /// 添加团购配置
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddGroupPurchase")]
        public int AddGroupPurchase(Model.GroupPurchase gp)
        {
            int i = _groupPurchaseRepository.AddGroupPurchase(gp);
            return i;
        }

        // 路线             ------

        /// <summary>
        /// 显示路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetShowPath")]
        public IActionResult GetShowPath(int PathID = -1)
        {
            List<Model.Path>  paths = _pathRepository.ShowPath(PathID);

            return Ok(paths);
        }
        
        /// <summary>
        /// 添加路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddPath")]
        public int AddPath(Model.Path path)
        {
            int i = _pathRepository.AddPath(path);
            return i;
        }

        /// <summary>
        /// 删除路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/DelPath")]
        public int DelPath(int PathID)
        {
            int i = _pathRepository.DelPath(PathID);
            return i;
        }

        /// <summary>
        /// 修改路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptPath")]
        public int UptPath(Model.Path path)
        {
            int i = _pathRepository.UptPath(path);
            return i;
        }

        //--------------------------------------------------------------------------------------------------
        //5.19
        #region

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

        #endregion
    }
}
