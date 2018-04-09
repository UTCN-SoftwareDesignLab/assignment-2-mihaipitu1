using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Role
    {
        private string rolename;
        private List<Right> rights;

        public Role(string role, List<Right> rights)
        {
            SetRolename(role);
            SetRights(rights);
        }

        public string GetRolename()
        {
            return rolename;
        }
        public void SetRolename(string rolename)
        {
            this.rolename = rolename;
        }
        public string RoleName
        {
            get { return GetRolename(); }
            set { SetRolename(value); }
        }

        public List<Right> GetRights()
        {
            return rights;
        }
        public void SetRights(List<Right> rights)
        {
            this.rights = rights;
        }
    }
}
