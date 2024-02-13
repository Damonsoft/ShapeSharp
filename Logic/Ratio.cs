using Arch.Geometry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Geometry.Logic
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
