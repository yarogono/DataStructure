using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public interface Timeable
    {
        public void TimeMe(int n, Action<int> timeMeLogic);
    }

    public class Profiler
    {
        private Timeable _timeable;
        private string title;

        public Profiler()
        {
        }

        public Profiler(string title, Timeable timeable)
        {
            this.title = title;
            this._timeable = timeable;
        }
    }
}
