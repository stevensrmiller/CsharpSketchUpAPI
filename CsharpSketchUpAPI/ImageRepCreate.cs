using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUImageRepCreate")]
        static extern int SUImageRepCreate(
            ref IntPtr imageRepRef);

        public static void ImageRepCreate(
            ImageRepRef imageRepRef)
        {
            ThrowOut(
                SUImageRepCreate(
                    ref imageRepRef.intPtr),
                "Could not create image rep.");
        }
    }
}
