using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUVertexGetPosition")]
        static extern int VertexGetPosition(
            IntPtr vertexRef,
            ref Point3D point);

        public static void VertexGetPosition(
            VertexRef vertexRef,
            ref Point3D point)
        {
            ThrowOut(
                VertexGetPosition(
                    vertexRef.intPtr,
                    ref point),
                "Could not get vertex position.");
        }
    }
}
