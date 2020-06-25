using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PersonManagement.Models
{
    public class SessionHelper
    {
        public static string Get(string LoginName)
        {
            if (HttpContext.Current.Session[LoginName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[LoginName].ToString();
            }
        }
    }
}