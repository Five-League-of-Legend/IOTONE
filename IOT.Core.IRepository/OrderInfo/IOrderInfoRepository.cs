﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OrderInfo
{
    public interface IOrderInfoRepository
    {
        /// <summary>
        /// 修改表单
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int UptOrderInfo(IOT.Core.Model.Users a);

        /// <summary>
        /// 显示表单
        /// </summary>
        /// <param name="searchType">查找类型 订单号 买家姓名 买家电话</param>
        /// <param name="searchContent">根据类型判断 查询条件</param>
        /// <param name="sTime">起始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="refundStatus">退款状态</param>
        /// <param name="orderState">订单状态</param>
        /// <param name="userId">用户ID</param>
        /// <param name="CommodityName">商品名称</param>
        /// <param name="SendWay">自提点</param>
        /// <returns></returns>
        List<IOT.Core.Model.ViewOrderInfoAndCommodityCommodity> ShowViewOrderInfo(
            int searchType,string searchContent,
            string sTime,string eTime,int refundStatus,
            int orderState,int userId,string CommodityName,
            int SendWay
            );


    }
}
