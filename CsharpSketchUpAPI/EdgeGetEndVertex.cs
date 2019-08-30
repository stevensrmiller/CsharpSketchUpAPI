using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUEdgeGetEndVertex")]
        static extern int EdgeGetEndVertex(
            IntPtr edgeRef,
            ref IntPtr vertexRef);

        public static void EdgeGetEndVertex(
            EdgeRef edgeRef,
            VertexRef vertexRef)
        {
            ThrowOut(
                EdgeGetEndVertex(
                    edgeRef.intPtr,
                    ref vertexRef.intPtr),
                "Could not get end vertex.");
        }
    }
}
