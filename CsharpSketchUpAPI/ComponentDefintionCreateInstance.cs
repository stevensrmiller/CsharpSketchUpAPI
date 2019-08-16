using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUComponentDefinitionCreateInstance")]
        static extern int SUComponentDefinitionCreateInstance(
            IntPtr compDefRef,
            ref IntPtr instanceRef);

        public static void ComponentDefinitionCreateInstance(
            ComponentDefinitionRef compDefRef,
            ComponentInstanceRef instanceRef)
        {
            ThrowOut(
                SUComponentDefinitionCreateInstance(
                    compDefRef.intPtr,
                    ref instanceRef.intPtr),
                "Could not create instance.");
        }
    }
}
