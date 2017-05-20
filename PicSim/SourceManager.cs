using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSim
{
    class SourceManager
    {
        private List<string> sourceComplete = new List<string>();
        private List<int> args1 = new List<int>();
        private List<int> highlightIndex = new List<int>();

        public int getIndexInCode(int i)
        {
            return highlightIndex[i];
        }
        public List<string> GetSourceComplete()
        {
            return sourceComplete;
        }

        public List<int> GetArgs1()
        {
            return args1;
        }

        public int GetSingleArg1(int pc)
        {
            return args1[pc];
        }

        public void FillSource(List<string> l)
        {
            sourceComplete = l;
            int c = 0;
            foreach (string line in sourceComplete)
            {
                
                string sArg1 = line.Substring(5, 4);

                if (sArg1 != "    ")
                {
                    args1.Add(Convert.ToInt32(sArg1, 16));
                    highlightIndex.Add(c);
                }

                c++;
            }
        }

        public void ResetSource()
        {
            sourceComplete.Clear();
            args1.Clear();
        }
    }
}
