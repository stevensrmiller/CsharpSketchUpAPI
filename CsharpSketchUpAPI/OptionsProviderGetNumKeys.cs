using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUOptionsProviderGetNumKeys")]
        static extern int SUOptionsProviderGetNumKeys(
            IntPtr opProvRef,
            out int num);

        public static void OptionsProviderGetNumKeys(OptionsProviderRef opProvRef, out int num)
        {
            ThrowOut(
                SUOptionsProviderGetNumKeys(
                    opProvRef.intPtr,
                    out num),
                "Could not get num keys.");
        }
    }
}
