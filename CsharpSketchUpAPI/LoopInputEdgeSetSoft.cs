using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SULoopInputEdgeSetSoft")]
        static extern int SULoopInputEdgeSetSoft(
            IntPtr loopInputRef,
            int index,
            bool soft);

        public static void LoopInputEdgeSetSoft(
            LoopInputRef loopInputRef,
            int index, 
            bool soft)
        {
            ThrowOut(
                SULoopInputEdgeSetSoft(
                    loopInputRef.intPtr,
                    index,
                    soft),
                "Could not set edge soft.");
        }
    }
}
