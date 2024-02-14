using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Geometry.Models
{
    public struct M3x2<N> where N : INumber<N>
    {
        internal static M3x2<N> _Identity => new(N.One, N.Zero,
                                                 N.Zero, N.One,
                                                 N.Zero, N.Zero);
        public static M3x2<N> Identity { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => _Identity; }

        public N this[int row, int column]
        {
            get
            {
                int value = column + (row * 2);

                if (value >= 0 && value < 6) {
                    return Unsafe.Add(ref this.M11, value);
                }
                throw new IndexOutOfRangeException();
            }
        }

        public N M11;
        public N M12;

        public N M21;
        public N M22;

        public N M31;
        public N M32;

        public M3x2(N m11, N m12, N m21, N m22, N m31, N m32)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M21 = m21;
            this.M22 = m22;
            this.M31 = m31;
            this.M32 = m32;
        }

        public static M3x2<N> operator *(in M3x2<N> x, N y)
        {
            return new M3x2<N>(x.M11 * y,
                                    x.M12 * y,
                                    x.M21 * y,
                                    x.M22 * y,
                                    x.M31 * y,
                                    x.M32 * y);
        }

        public static M3x2<N> operator +(in M3x2<N> x, N y)
        {
            return new M3x2<N>(x.M11 + y,
                                    x.M12 + y,
                                    x.M21 + y,
                                    x.M22 + y,
                                    x.M31 + y,
                                    x.M32 + y);
        }

        public static M3x2<N> operator -(in M3x2<N> x, N y)
        {
            return new M3x2<N>(x.M11 - y,
                                    x.M12 - y,
                                    x.M21 - y,
                                    x.M22 - y,
                                    x.M31 - y,
                                    x.M32 - y);
        }

        public static M3x2<N> operator /(in M3x2<N> x, N y)
        {
            return new M3x2<N>(x.M11 / y,
                                    x.M12 / y,
                                    x.M21 / y,
                                    x.M22 / y,
                                    x.M31 / y,
                                    x.M32 / y);
        }

        public static M3x2<N> operator *(in M3x2<N> x, in M3x2<N> y)
        {
            return new M3x2<N>(x.M11 * y.M11,
                                    x.M12 * y.M12,
                                    x.M21 * y.M21,
                                    x.M22 * y.M22,
                                    x.M31 * y.M31,
                                    x.M32 * y.M32);
        }

        public static M3x2<N> operator +(in M3x2<N> x, in M3x2<N> y)
        {
            return new M3x2<N>(x.M11 + y.M11,
                                    x.M12 + y.M12,
                                    x.M21 + y.M21,
                                    x.M22 + y.M22,
                                    x.M31 + y.M31,
                                    x.M32 + y.M32);
        }

        public static M3x2<N> operator -(in M3x2<N> x, in M3x2<N> y)
        {
            return new M3x2<N>(x.M11 - y.M11,
                                    x.M12 - y.M12,
                                    x.M21 - y.M21,
                                    x.M22 - y.M22,
                                    x.M31 - y.M31,
                                    x.M32 - y.M32);
        }

        public static M3x2<N> operator /(in M3x2<N> x, in M3x2<N> y)
        {
            return new M3x2<N>(x.M11 / y.M11,
                                    x.M12 / y.M12,
                                    x.M21 / y.M21,
                                    x.M22 / y.M22,
                                    x.M31 / y.M31,
                                    x.M32 / y.M32);
        }
    }

    public static class M3x2
    {
        public static M3x2<N> CreateTranslation<N>(N x, N y) where N : INumber<N>
        {
            M3x2<N> result = M3x2<N>._Identity;

            result.M31 = x;
            result.M32 = y;

            return result;
        }

        public static M3x2<float> CreateRotation(float radians)
        {
            float cos = MathF.Cos(radians);
            float sin = MathF.Sin(radians);

            M3x2<float> result = M3x2<float>._Identity;

            result.M11 = cos;
            result.M12 = sin;
            result.M21 = -sin;
            result.M22 = cos;

            return result;
        }

        public static M3x2<double> CreateRotation(double radians)
        {
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);

            M3x2<double> result = M3x2<double>._Identity;

            result.M11 = cos;
            result.M12 = sin;
            result.M21 = -sin;
            result.M22 = cos;

            return result;
        }

        public static M3x2<float> CreateRotation(float radians, V2<float> center) 
        {
            float cos = MathF.Cos(radians);
            float sin = MathF.Sin(radians);

            M3x2<float> result = M3x2<float>._Identity;

            result.M11 = cos;
            result.M12 = sin;
            result.M21 = -sin;
            result.M22 = cos;
            result.M31 = center.X * (1 - cos) + center.Y * sin;
            result.M32 = center.Y * (1 - cos) - center.X * sin;

            return result;
        }

        public static M3x2<double> CreateRotation(double radians, V2<double> center)
        {
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);

            M3x2<double> result = M3x2<double>._Identity;
   
            result.M11 = cos;
            result.M12 = sin;
            result.M21 = -sin;
            result.M22 = cos;
            result.M31 = center.X * (1 - cos) + center.Y * sin;
            result.M32 = center.Y * (1 - cos) - center.X * sin;

            return result;
        }

        public static M3x2<N> CreateScale<N>(V2<N> scale) where N : INumber<N>
        {
            M3x2<N> result = M3x2<N>._Identity;

            result.M11 = scale.X;
            result.M22 = scale.Y; ;

            return result;
        }

        public static M3x2<N> CreateScale<N>(V2<N> scale, V2<N> center) where N : INumber<N>
        {
            M3x2<N> result = M3x2<N>._Identity;

            N tx = center.X * (N.One - scale.X);
            N ty = center.Y * (N.One - scale.Y);

            result.M11 = scale.X;
            result.M22 = scale.Y; ;
            result.M31 = tx;
            result.M32 = ty;

            return result;
        }

        public static M3x2<N> CreateScale<N>(N scaleX, N scaleY, N centerX, N centerY) where N : INumber<N>
        {
            M3x2<N> result = M3x2<N>._Identity;

            N tx = centerX * (N.One - scaleX);
            N ty = centerY * (N.One - scaleY);

            result.M11 = scaleX;
            result.M22 = scaleY; ;
            result.M31 = tx;
            result.M32 = ty;

            return result;
        }

        public static void Transform<N>(Span<V2<N>> vectors, in M3x2<N> matrix) where N : INumber<N>
        {
            for(int i = 0; i < vectors.Length; i++)
            {
                ref V2<N> vector = ref vectors[i];
                N x = vector.X * matrix.M11 + vector.Y * matrix.M21 + matrix.M31;
                N y = vector.X * matrix.M12 + vector.Y * matrix.M22 + matrix.M32;
                vector = new(x, y);
            }
        }

        public static void Transform<N>(ref V2<N> vector, in M3x2<N> matrix) where N : unmanaged, IBinaryFloatingPointIeee754<N>
        {
            N x = vector.X * matrix.M11 + vector.Y * matrix.M21 + matrix.M31;
            N y = vector.X * matrix.M12 + vector.Y * matrix.M22 + matrix.M32;

            vector.X = x;
            vector.Y = y;
        }

        public static V2<N> Transform<N>(V2<N> vector, in M3x2<N> matrix) where N : unmanaged, IBinaryFloatingPointIeee754<N>
        {
            N x = vector.X * matrix.M11 + vector.Y * matrix.M21 + matrix.M31;
            N y = vector.X * matrix.M12 + vector.Y * matrix.M22 + matrix.M32;

            return new(x, y);
        }

        public static Matrix3x2 ToNumericsMatrix(this in M3x2<float> matrix) => new Matrix3x2(matrix.M11, matrix.M12, matrix.M21, matrix.M22, matrix.M31, matrix.M32);
    }
}
