using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Activity
{
    public interface IActivityRepository:IBaseRepository<Model.Activity>
    {
        int Uptdate(Model.Activity Model);
        int UptZt(int aid);
    }
}
