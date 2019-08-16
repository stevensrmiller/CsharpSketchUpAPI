using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SULoopInputEdgeSetSmooth")]
        static extern int SULoopInputEdgeSetSmooth(
            IntPtr loopInputRef,
            int index,
            bool smooth);

        public static void LoopInputEdgeSetSmooth(
            LoopInputRef loopInputRef,
            int index,
            bool smooth)
        {
            ThrowOut(
                SULoopInputEdgeSetSmooth(
                    loopInputRef.intPtr,
                    index, smooth),
                "Could not set edge smooth.");
        }
    }
}
