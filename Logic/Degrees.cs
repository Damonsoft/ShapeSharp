using System.Numerics;
using System.Runtime.CompilerServices;

namespace ShapeSharp.Logic
{
    public static class Degrees
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRadians(float degrees) => degrees * (float)(Math.PI / 180d);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToRadians(double degrees) => degrees * (Math.PI / 180d);
    }
}
