﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.RoleManage;

namespace IOT.Core.Repository.RoleManage
{
    public class RoleManageRepository : IRoleManageRepository
    {
        public int AddRoleManage(Model.RoleManage a)
        {
            string sql = $"insert into RoleManage values (null,'{a.HobOne}','{a.HobTwo}','{a.HobThree}','{a.Four}')";
            return DapperHelper.Execute(sql);
        }
    }
}
