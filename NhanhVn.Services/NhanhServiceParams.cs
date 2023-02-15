using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhanhVn.Services
{
    public class NhanhServiceParams
    {
        public string Version { get; set; }

        public NhanhServiceParams(string version, string appId, string businessId, string accessToken)
        {
            Version = version;
            AppId = appId;
            BusinessId = businessId;
            AccessToken = accessToken;
        }

        public string AppId { get; set; }
        public string BusinessId { get; set; }
        public string AccessToken { get; set; }
    }
}
