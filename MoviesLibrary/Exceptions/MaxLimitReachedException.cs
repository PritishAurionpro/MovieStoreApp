using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp3._0.Exceptions
{
    public class MaxLimitReachedException:Exception
    {
        public MaxLimitReachedException(string message):base(message) { }
    }
}
