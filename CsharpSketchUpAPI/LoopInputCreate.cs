using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SULoopInputCreate")]
        static extern int SULoopInputCreate(
            ref IntPtr loopInputRef);

        public static void LoopInputCreate(
            LoopInputRef loopInputRef)
        {
            ThrowOut(
                SULoopInputCreate(
                    ref loopInputRef.intPtr),
                "Could not loop input.");
        }
    }
}
