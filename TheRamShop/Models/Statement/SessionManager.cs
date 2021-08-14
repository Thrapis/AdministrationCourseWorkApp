using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace TheRamShop.Models.Statement
{
    public class SessionManager
    {
        HttpSessionStateBase Session;

        public SessionManager(HttpSessionStateBase session)
        {
            Session = session;
        }

        public void AddValue(string name, object value)
        {
            Session[name] = value;
        }

        public object GetValue(string name)
        {
            return Session[name];
        }

        public bool HasValue(string name)
        {
            foreach (var el in Session.Keys)
            {
                if (el is string && (string)el == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}