using Arch.Geometry.Models;
using System.Numerics;

namespace ShapeSharp.Models
{
    public struct Triangle<N> where N : INumber<N>
    {
        public V2<N> P1;
        public V2<N> P2;
        public V2<N> P3;

        public Triangle(V2<N> p1, V2<N> p2, V2<N> p3)
        {
            this.P1 = p1;
            this.P2 = p2;
            this.P3 = p3;
        }
    }
}
