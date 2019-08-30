using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUEntitiesGetGroups")]
        static extern int SUEntitiesGetGroups(
            IntPtr entitiesRef,
            long len,
            IntPtr[] groupRefs,
            out long count);

        public static void EntitiesGetGroups(
            EntitiesRef entitiesRef,
            long len,
            GroupRef[] groupRefs,
            out long count)
        {
            IntPtr[] intPtrs = new IntPtr[groupRefs.Length];

            ThrowOut(
                SUEntitiesGetGroups(
                    entitiesRef.intPtr,
                    len,
                    intPtrs,
                    out count),
                "Could not get entities groups.");

            for (int g = 0; g < groupRefs.Length; ++g)
            {
                groupRefs[g] = new GroupRef();
                groupRefs[g].intPtr = intPtrs[g];
            }
        }
    }
}
