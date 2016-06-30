using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RogueLib
{
    public struct LightSource
    {
        public long X { get; set; }
        public long Y { get; set; }
        public int Radius { get; set; }
        public bool LightWalls { get; set; }
    }
}
