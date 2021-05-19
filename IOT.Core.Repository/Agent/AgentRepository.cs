using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Agent;

namespace IOT.Core.Repository.Agent
{
    //public class ActivityRepository : IActivityRepository
    public class AgentRepository : IAgentRepository
    {
        
        public int AddAgent(Model.Agent a)
        {
            string sql = $"insert into Agent values (null,'{a.AgentName}', '{a.Icon}', '{a.BCImg}', '{a.BackgroudColor}', '{a.Fans}', {a.AgentState}, {a.One}, {a.Two}, {a.Three},'{a.Explaina}')";
           return DapperHelper.Execute(sql);
        }

        public int DelAgent(string id)
        {
            string sql = $"delete from Agent where AgentId={id}";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Agent> ShowAgent()
        {
            string sql = "select * from Agent";
            return DapperHelper.GetList<Model.Agent>(sql);
          
        }

        public int UptAgent(Model.Agent a)
        {
            string sql = $"update set Agent values (null,'{a.AgentName}', '{a.Icon}', '{a.BCImg}', '{a.BackgroudColor}', '{a.Fans}', {a.AgentState}, {a.One}, {a.Two}, {a.Three},'{a.Explaina}')";
            return DapperHelper.Execute(sql);
        }
    }
}
