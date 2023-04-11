using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFunctionCollapse.Model
{
    internal interface IWaveField
    {
        //public bool Collapse();

        public int[,] GetWaveArray();

        public bool Collapse();

    }
}
