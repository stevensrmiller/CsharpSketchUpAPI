using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUGroupSetDescription")]
        static extern int SUGroupSetDescription(
            IntPtr groupRef,
            string description);

        public static void GroupSetDescription(
            GroupRef groupRef,
            string description)
        {
            // There is no SUGroupSetDescription function, so skip
            // this until we think of something better to do.
#if false
            ThrowOut(
                SUGroupSetDescription(
                    groupRef.intPtr,
                    description),
                "Could not set group description.");
#endif
        }
    }
}
