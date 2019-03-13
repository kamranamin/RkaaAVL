using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace RkaaAVLS
{
    public class GetUser: ClaimsPrincipal
    {
        public GetUser(ClaimsPrincipal principal)
       : base(principal)
        {
        }
        public int id()
        {
            int id = 0;
            id = Convert.ToInt32(this.FindFirst(ClaimTypes.SerialNumber).Value);
            return id;
        }
    }
}