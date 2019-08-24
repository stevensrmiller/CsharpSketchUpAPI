using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUGroupCreate")]
        static extern int SUGroupCreate(
            ref IntPtr groupRef);

        public static void GroupCreate(
            GroupRef groupRef)
        {
            ThrowOut(
                SUGroupCreate(
                    ref groupRef.intPtr),
                "Could not create group.");
        }
    }
}
