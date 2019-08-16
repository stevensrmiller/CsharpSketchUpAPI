using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUGeometryInputFaceAddInnerLoop")]
        static extern int SUGeometryInputFaceAddInnerLoop(
            IntPtr geometryInputRef,
            int faceIndex,
            ref IntPtr loopInputRef);

        public static void GeometryInputFaceAddInnerLoop(
            GeometryInputRef geometryInputRef,
            int faceIndex,
            LoopInputRef loopInputRef)
        {
            ThrowOut(
                SUGeometryInputFaceAddInnerLoop(
                    geometryInputRef.intPtr,
                    faceIndex,
                    ref loopInputRef.intPtr),
                "Could not add inner loop.");
        }
    }
}
