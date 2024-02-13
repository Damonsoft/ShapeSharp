using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Geometry.Models
{
    public struct V3<N> where N : INumber<N>
    {
        public N this[int index]
        {
            get
            {
                if (index >=0 && index < 3)
                {
                    return Unsafe.Add(ref X, index);
                }
                throw new IndexOutOfRangeException();
            }
        }

        public N X;
        public N Y;
        public N Z;

        public V3(N x, N y, N z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static V3<N> operator *(in V3<N> left, N right)
        {
            return new(left.X * right, left.Y * right, left.Z * right);
        }

        public static V3<N> operator +(in V3<N> left, N right)
        {
            return new(left.X + right, left.Y + right, left.Z + right);
        }

        public static V3<N> operator -(in V3<N> left, N right)
        {
            return new(left.X - right, left.Y - right,left.Z - right);
        }

        public static V3<N> operator /(in V3<N> left, N right)
        {
            return new(left.X / right, left.Y / right, left.Z / right);
        }

        public static V3<N> operator *(in V3<N> left, in V3<N> right)
        {
            return new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static V3<N> operator +(in V3<N> left, in V3<N> right)
        {
            return new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static V3<N> operator -(in V3<N> left, in V3<N> right)
        {
            return new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static V3<N> operator /(in V3<N> left, in V3<N> right)
        {
            return new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }
    }
}
