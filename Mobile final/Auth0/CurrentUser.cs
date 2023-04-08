using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final.Auth0
{
    public class CurrentUser
    {
        public string Username { get; set; }
        public string AuthenticationID { get; set; }
        //potential could add a device id so someone doesn't have to login every time

        public CurrentUser()
        {

        }
    }
}
