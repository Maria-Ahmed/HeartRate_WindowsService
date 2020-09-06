using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k164057_Q2
{
    class UserDetail
    {
        public string datetime { get; set; }
        public value Value { get; set; } // a class whose return type is value

        public UserDetail()
        {
            Value = new value();
        }
    }
}
