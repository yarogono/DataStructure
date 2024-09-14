using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class ProfileTimeable<T> : Timeable
    {
        public T list;

        public void TimeMe(int n, Action<int> timeMeLogic)
        {
            timeMeLogic(n);
        }
    }
}
