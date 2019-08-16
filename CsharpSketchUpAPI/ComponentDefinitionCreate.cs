using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUComponentDefinitionCreate")]
        static extern int SUComponentDefinitionCreate(
            ref IntPtr compDefRef);

        public static void ComponentDefinitionCreate(
            ComponentDefinitionRef compDefRef)
        {
            ThrowOut(
                SUComponentDefinitionCreate(
                    ref compDefRef.intPtr),
                "Could not create comp def.");
        }
    }
}
