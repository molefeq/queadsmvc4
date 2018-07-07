using System.Collections.Generic;
using System.Security.Principal;

namespace QueAdsMvc4.Presentation.MvcExtensions
{
    public class CustomPrincipal : IPrincipal
    {
        private IIdentity _Identity;
        private List<string> _Roles;
        private string _UserName;

        public CustomPrincipal(IIdentity ident, List<string> roles, string userName)
        {
            this._Identity = ident;
            this._Roles = roles;
            this._UserName = userName;
        }

        public IIdentity Identity
        {
            get { return _Identity; }
        }

        public string UserName
        {
            get { return _UserName; }
        }

        public bool IsInRole(string role)
        {
            return _Roles.Contains(role);
        }

    }
}
