using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUFaceCreate")]
        static extern int SUFaceCreate(
            ref IntPtr faceRef,
            Point3D[] vertices,
            ref IntPtr outerLoop);

        // It's possible that the vertices passed in the array are stored by reference, which would
        // cause problems if they are moved or collected by the GC. We haven't tested this yet, but
        // it seems likely that they are copied by member value, as that's what testing shows that
        // SUGeometryInputAddVertex does. Most likely, you won't use this function anyway.

        public static void FaceCreate(
            FaceRef faceRef,
            Point3D[] vertices,
            LoopInputRef outerLoop)
        {
            ThrowOut(
                SUFaceCreate(
                    ref faceRef.intPtr,
                    vertices,
                    ref outerLoop.intPtr),
                "Could not create face.");
        }
    }
}
