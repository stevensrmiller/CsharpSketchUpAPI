using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUModelCreate")]
        static extern int SUModelCreate(
            ref IntPtr modelRef);

        public static void ModelCreate(
            ModelRef modelRef)
        {
            ThrowOut(
                SUModelCreate(
                    ref modelRef.intPtr),
                "Could not create model.");
        }
    }
}
