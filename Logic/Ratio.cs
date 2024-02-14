using ShapeSharp.Models;
using System.Numerics;

namespace ShapeSharp.Logic
{
    public static class Ratio
    {
        public static N Calculate<N>(V2<N> bounds, V2<N> source) where N : INumber<N>
        {
            N ratioX = (bounds.X / source.X);
            N ratioY = (bounds.Y / source.Y);
            return ratioX < ratioY ? ratioX : ratioY;
        }
    }
}
