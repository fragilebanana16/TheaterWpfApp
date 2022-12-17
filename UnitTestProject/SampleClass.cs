using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class SampleClass
    {
        public SampleClass(string str)
        {
            if (null == str)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
