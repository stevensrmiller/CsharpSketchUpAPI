using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUGroupGetEntities")]
        static extern int SUGroupGetEntities(
            IntPtr groupRef,
            ref IntPtr entitiesRef);

        public static void GroupGetEntities(
            GroupRef groupRef,
            EntitiesRef entitiesRef)
        {
            ThrowOut(
                SUGroupGetEntities(
                    groupRef.intPtr,
                    ref entitiesRef.intPtr),
                "Could not get group entities.");
        }
    }
}
