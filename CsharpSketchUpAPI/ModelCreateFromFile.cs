using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUModelCreateFromFile")]
        static extern int SUModelCreateFromFile(
            ref IntPtr modelRef,
            string name);

        public static void ModelCreateFromFile(
            ModelRef modelRef,
            string name)
        {
            ThrowOut(
                SUModelCreateFromFile(
                    ref modelRef.intPtr,
                    name),
                "Could not create model from file.");
        }
    }
}
