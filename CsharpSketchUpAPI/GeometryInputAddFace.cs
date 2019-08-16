using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUGeometryInputAddFace")]
        static extern int SUGeometryInputAddFace(
            IntPtr geometryInputRef,
            ref IntPtr loopInputRef,
            ref int index);

        public static void GeometryInputAddFace(
            GeometryInputRef geometryInputRef,
            LoopInputRef loopInputRef,
            ref int index)
        {
            ThrowOut(
                SUGeometryInputAddFace(
                    geometryInputRef.intPtr,
                    ref loopInputRef.intPtr, 
                    ref index),
                "Could not add face.");
        }
    }
}
