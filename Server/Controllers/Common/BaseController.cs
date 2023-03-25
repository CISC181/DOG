using DOG.EF.Data;
using Microsoft.AspNetCore.Mvc;
using DOG.Shared.Utils;

namespace DOG.Server.Controllers.Common
{
    public class BaseController : Controller
    {

        protected DOGOracleContext _context;
        protected readonly OraTransMsgs _OraTranslateMsgs;

        public BaseController(DOGOracleContext DBcontext,
    OraTransMsgs _OraTransMsgs)
        {
            _context = DBcontext;
            _OraTranslateMsgs = _OraTransMsgs;
        }
    }
}
