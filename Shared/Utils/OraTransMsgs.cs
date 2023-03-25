using DOG.EF.Data;
using DOG.EF.Models;
using DOG.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOG.Shared.Utils
{
    public class OraTransMsgs : IOraTransMsgs
    {
        private DbContextOptions<DOGOracleContext> _dbContextOptions;
        public List<OraTranslateMsg> lstOraTranslateMsgs { get; set; }

        public OraTransMsgs(DbContextOptions<DOGOracleContext> dbContextOptions)
        {
            this._dbContextOptions = dbContextOptions;
            LoadMsgs();
        }

        public void LoadMsgs()
        {
            using (var db = new DOGOracleContext(_dbContextOptions))
            {

                lstOraTranslateMsgs = db.OraTranslateMsgs.ToList();
            }
        }

        public string TranslateMsg(string strMessage)
        {

            foreach (var msg in lstOraTranslateMsgs)
            {
                if (strMessage.ToUpper().Contains(msg.OraConstraintName.ToUpper()))
                {
                    return msg.OraErrorMessage;
                }
            }
            return strMessage;
        }
    }
}
