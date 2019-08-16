using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUOptionsManagerGetOptionsProviderNames")]
        static extern int SUOptionsManagerGetOptionsProviderNames(
            IntPtr opMgrRef,
            int len,
            IntPtr[] stringRef,
            out int retrieved);

        public static void OptionsManagerGetOptionsProviderNames(
            OptionsManagerRef opMgrRef,
            int len,
            StringRef[] strings,
            out int retrieved)
        {
            IntPtr[] intPtrs = new IntPtr[strings.Length];

            ThrowOut(
                SUOptionsManagerGetOptionsProviderNames(
                    opMgrRef.intPtr,
                    len,
                    intPtrs,
                    out retrieved),
                "Could not get proider names.");

            for (int s = 0; s < strings.Length; ++s)
            {
                strings[s].intPtr = intPtrs[s];
            }
        }
    }
}
