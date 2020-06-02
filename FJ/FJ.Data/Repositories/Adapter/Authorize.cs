using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJ.Data.Repositories.Adapter
{
    public partial class AdapterFJRepository
    {
        public bool CheckAuthorizeFunction(int loginId, int authorizeFunctionCode)
        {
            var checkAuthorize
                = from user in AccountRepository.GetAll(t => t.AccountId == loginId)
                  where user.IdentityCode >= authorizeFunctionCode
                  select 1;

            if (checkAuthorize.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
