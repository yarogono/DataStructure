using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static DataStructure.Profiler;

namespace DataStructure
{
    public class ProfileListAdd
    {

        public static void Main(string[] args)
        {
            ProfileArrayListAddEnd();
            //ProfileArrayListAddBeginning();
            //ProfileLinkedListAddBeginning();
            //ProfileLinkedListAddEnd();
        }

        public static void ProfileArrayListAddEnd()
        {
            MyArrayList<string> list = new MyArrayList<string>();

            Timeable profileTimeable = new ProfileTimeable<MyArrayList<string>>()
            {
                list = list
            };

            profileTimeable.TimeMe(10, (n) =>
            {
                for (int i = 0; i < n; i++)
                {
                    list.Add("a string");
                }
            });

            int startN = 4000;
            int endMillis = 1000;
            RunProfiler("ArrayList add end", profileTimeable, startN, endMillis);
        }

        public static void ProfileLinkedListAddBeginning()
        {
            throw new NotImplementedException();
        }

        public static void ProfileArrayListAddBeginning()
        {
            throw new NotImplementedException();
        }

        public static void ProfileLinkedListAddEnd()
        {
            throw new NotImplementedException();
        }

        public static void RunProfiler(String title, Timeable timeable, int startN, int endMillis)
        {
            Profiler profiler = new Profiler(title, timeable);
            //XYSeries series = profiler.timingLoop(startN, endMillis);
            //profiler.plotResults(series);
        }
    }
}
