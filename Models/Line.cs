using Arch.Geometry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeSharp.Models
{
    public struct Line<N> where N : INumber<N>
    {
        public V2<N> Source;
        public V2<N> Target;

        public Line(V2<N> source, V2<N> target)
        {
            this.Source = source;
            this.Target = target;
        }
    }
}
