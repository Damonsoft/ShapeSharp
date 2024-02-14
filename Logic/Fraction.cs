using ShapeSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeSharp.Logic
{
    public static class Fraction
    {
        public static V2<N> Reduce<N>(N numerator, N denominator) where N : INumber<N>
        {
            N k = Euclidean.GCD(numerator, denominator);

            return new(numerator / k, denominator / k);
        }
    }
}
