using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Geometry.Logic
{
    public static class Degrees
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRadians(float degrees) => degrees * (float)(Math.PI / 180);
    }
}
