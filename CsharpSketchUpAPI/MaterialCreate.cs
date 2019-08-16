using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUMaterialCreate")]
        static extern int SUMaterialCreate(
            ref IntPtr materialRef);

        public static void MaterialCreate(
            MaterialRef materialRef)
        {
            ThrowOut(
                SUMaterialCreate(
                    ref materialRef.intPtr),
                "Could not create material.");
        }
    }
}
