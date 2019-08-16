using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUOptionsManagerGetNumOptionsProviders")]
        static extern int SUOptionsManagerGetNumOptionsProviders(
            IntPtr opMgrRef,
            out int num);

        public static void OptionsManagerGetNumOptionsProviders(
            OptionsManagerRef opMgrRef,
            out int num)
        {
            ThrowOut(
                SUOptionsManagerGetNumOptionsProviders(
                    opMgrRef.intPtr, 
                    out num),
                "Could not get num options providers.");
        }
    }
}
