using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Right
    {
        private string rightname;

        public Right(string right)
        {
            SetRightname(right);
        }

        public string GetRightname()
        {
            return rightname;
        }
        public void SetRightname(string rightname)
        {
            this.rightname = rightname;
        }
    }
}
