using Arch.Geometry.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Geometry.Models
{
    public struct Circle<N> where N : INumber<N>
    {
        public static  Circle<N> Empty => new Circle<N>(N.Zero, N.Zero, N.Zero);

        public readonly V2<N> Center { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(CenterX, CenterY); }

        public N CenterX;
        public N CenterY;
        public N Radius;

        public Circle(N centerX, N centerY, N radius)
        {
            this.CenterX = centerX;
            this.CenterY = centerY;
            this.Radius = radius;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Rect<N> Bounds()
        {
            return new(CenterX - Radius, CenterY - Radius, CenterX + Radius, CenterY + Radius);
        }
    }

    public static class Circle
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRadians(double degrees) => (float)(degrees * (Math.PI / 180d));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(double degrees) => (float)Math.Sin(degrees * (Math.PI / 180d));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(double degrees) => (float)Math.Cos(degrees * (Math.PI / 180d));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(double radius, double degrees) => (float)(radius * Math.Sin(degrees * (Math.PI / 180d)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(double radius, double degrees) => (float)(radius * Math.Cos(degrees * (Math.PI / 180d)));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V2<float> Map(double radius, double degrees) => new(Sin(radius, degrees), Cos(radius, degrees));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V2<float> PointAt(this in Circle<float> circle, float radians) => new(circle.CenterX + circle.Radius * MathF.Cos(radians), circle.CenterY + circle.Radius * MathF.Sin(radians));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Circle<N> Create<N>(N x, N y, N size) where N : INumber<N>
        {
            N two = N.One + N.One;

            return new(x + size / two, y + size / two, size / two);
        }
    }
}
