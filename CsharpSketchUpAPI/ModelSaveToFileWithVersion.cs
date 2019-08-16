using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUModelSaveToFileWithVersion")]
        static extern int SUModelSaveToFileWithVersion(
            IntPtr modelRef,
            string name,
            int version);

        public static void ModelSaveToFileWithVersion(
            ModelRef modelRef,
            string name,
            int version)
        {
            ThrowOut(
                SUModelSaveToFileWithVersion(
                    modelRef.intPtr,
                    name, version),
                "Could not save model with version.");
        }
    }
}
