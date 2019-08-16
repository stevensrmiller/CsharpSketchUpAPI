using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUModelAddMaterials")]
        static extern int SUModelAddMaterials(
            IntPtr modelRef,
            int len,
            IntPtr[] materialRefs);

        public static void ModelAddMaterials(
            ModelRef modelRef,
            int len,
            MaterialRef[] materialRefs)
        {
            IntPtr[] intPtrs = new IntPtr[materialRefs.Length];

            for (int m = 0; m < intPtrs.Length; ++m)
            {
                intPtrs[m] = materialRefs[m].intPtr;
            }

            ThrowOut(
                SUModelAddMaterials(
                    modelRef.intPtr,
                    len,
                    intPtrs),
                "Could not add materials.");
        }
    }
}
