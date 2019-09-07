using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [StructLayout(LayoutKind.Sequential, Pack = 8)]
        public struct Transformation
        {
            public double m11;
            public double m21;
            public double m31;
            public double m41;
            public double m12;
            public double m22;
            public double m32;
            public double m42;
            public double m13;
            public double m23;
            public double m33;
            public double m43;
            public double m14;
            public double m24;
            public double m34;
            public double m44;

            unsafe public double this[int r, int c]
            {
                get
                {
                    fixed (double* m = &m11)
                    {
                        return m[c * 4 + r];
                    }
                }
            }
        }
    }
}
