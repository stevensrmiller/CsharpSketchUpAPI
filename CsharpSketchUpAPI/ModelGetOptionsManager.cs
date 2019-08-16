using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUModelGetOptionsManager")]
        static extern int SUModelGetOptionsManager(
            IntPtr modelRef,
            ref IntPtr managerRef);

        public static void ModelGetOptionsManager(
            ModelRef modelRef,
            OptionsManagerRef managerRef)
        {
            ThrowOut(
                SUModelGetOptionsManager(
                    modelRef.intPtr,
                    ref managerRef.intPtr),
                "Could not get options manager.");
        }
    }
}
