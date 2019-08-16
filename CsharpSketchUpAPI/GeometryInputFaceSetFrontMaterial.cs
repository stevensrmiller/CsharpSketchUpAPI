using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUGeometryInputFaceSetFrontMaterial")]
        static extern int SUGeometryInputFaceSetFrontMaterial(
            IntPtr geometryRef,
            int faceIndex,
            ref MaterialInputStruct materialInput);

        public static void GeometryInputFaceSetFrontMaterial(
            GeometryInputRef geometryRef,
            int faceIndex,
            MaterialInput materialInput)
        {
            MaterialInputStruct mis = materialInput.materialInputStruct();

            ThrowOut(
                SUGeometryInputFaceSetFrontMaterial(
                    geometryRef.intPtr,
                    faceIndex, 
                    ref mis),
                "Could not set front material.");
        }
    }
}
