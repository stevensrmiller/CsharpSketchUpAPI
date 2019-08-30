using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUFaceGetOuterLoop")]
        static extern int FaceGetOuterLoop(
            IntPtr faceRef,
            ref IntPtr loopRef);

        public static void FaceGetOuterLoop(
            FaceRef faceRef,
            LoopRef loopRef)
        {
            ThrowOut(
                FaceGetOuterLoop(
                    faceRef.intPtr,
                    ref loopRef.intPtr),
                "Could not get outer loop.");
        }
    }
}
