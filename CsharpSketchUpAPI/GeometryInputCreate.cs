using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUGeometryInputCreate")]
        static extern int SUGeometryInputCreate(
            ref IntPtr geometryInputlRef);

        public static void GeometryInputCreate(
            GeometryInputRef geometryInputRef)
        {
            ThrowOut(
                SUGeometryInputCreate(
                    ref geometryInputRef.intPtr),
                "Could not create geometry input.");
        }
    }
}
