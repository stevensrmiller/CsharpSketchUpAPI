using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUOptionsManagerGetOptionsProviderByName")]
        static extern int SUOptionsManagerGetOptionsProviderByName(
            IntPtr managerRef,
            string name,
            ref IntPtr providerRef);

        public static void OptionsManagerGetOptionsProviderByName(
            OptionsManagerRef managerRef,
            string name,
            OptionsProviderRef providerRef)
        {
            ThrowOut(
                SUOptionsManagerGetOptionsProviderByName(
                    managerRef.intPtr,
                    name, ref providerRef.intPtr),
                "Could not get provider.");
        }
    }
}
