using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SULoopGetVertices")]
        static extern int SULoopGetVertices(
            IntPtr loopRef,
            long len,
            IntPtr[] vertexRefs,
            out long count);

        public static void LoopGetVertices(
            LoopRef loopRef,
            long len,
            VertexRef[] vertexRefs,
            out long count)
        {
            IntPtr[] intPtrs = new IntPtr[vertexRefs.Length];

            ThrowOut(
                SULoopGetVertices(
                    loopRef.intPtr,
                    len,
                    intPtrs,
                    out count),
                "Could not get loop vertices.");

            for (int v = 0; v < vertexRefs.Length; ++v)
            {
                vertexRefs[v] = new VertexRef();
                vertexRefs[v].intPtr = intPtrs[v];
            }
        }
    }
}
