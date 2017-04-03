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
        List<int> args2 = new List<int>();


        public void FillSource(List<string> l)
        {
            sourceComplete = l;
        }

        public void ResetSource()
        {
            sourceComplete.Clear();
        }
    }
}
