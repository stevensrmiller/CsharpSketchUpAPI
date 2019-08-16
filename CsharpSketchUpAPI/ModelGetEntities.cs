using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUModelGetEntities")]
        static extern int SUModelGetEntities(
            IntPtr modelRef,
            ref IntPtr entitiesRef);

        public static void ModelGetEntities(
            ModelRef modelRef,
            EntitiesRef entitiesRef)
        {
            ThrowOut(
                SUModelGetEntities(
                    modelRef.intPtr,
                    ref entitiesRef.intPtr),
                "Could not get entities.");
        }
    }
}
