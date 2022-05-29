using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Utiilities.Exceptions
{
    class SampleSourceKTExceptions : Exception
    {
        public SampleSourceKTExceptions()
        {
        }

        public SampleSourceKTExceptions(string message)
            : base(message)
        {
        }

        public SampleSourceKTExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
