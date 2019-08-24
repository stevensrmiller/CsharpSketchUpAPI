using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUEntitiesGetFaces")]
        static extern int SUEntitiesGetFaces(
            IntPtr entitiesRef,
            long len,
            IntPtr[] faceRefs,
            out long count);

        public static void EntitiesGetFaces(
            EntitiesRef entitiesRef,
            long len,
            FaceRef[] faceRefs,
            out long count)
        {
            IntPtr[] intPtrs = new IntPtr[faceRefs.Length];

            ThrowOut(
                SUEntitiesGetFaces(
                    entitiesRef.intPtr,
                    len,
                    intPtrs,
                    out count),
                "Could not get entities faces.");

            for (int f = 0; f < faceRefs.Length; ++f)
            {
                faceRefs[f] = new FaceRef();
                faceRefs[f].intPtr = intPtrs[f];
            }
        }
    }
}
