using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSim
{
    class SourceManager
    {
        List<string> sourceComplete = new List<string>();
        List<int> args1 = new List<int>();


        public void FillSource(List<string> l)
        {
            sourceComplete = l;
            foreach (string line in sourceComplete)
            {
                Console.WriteLine(line);
                string sArg1 = line.Substring(5, 4);

                if (sArg1 != "    ")
                {
                    args1.Add(Convert.ToInt32(sArg1, 16));
                }
            }
        }

        public void ResetSource()
        {
            sourceComplete.Clear();
        }
    }
}
