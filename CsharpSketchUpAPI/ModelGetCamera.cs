using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUModelGetCamera")]
        static extern int SUModelGetCamera(
            IntPtr modelRef,
            ref IntPtr cameraRef);

        public static void ModelGetCamera(
            ModelRef modelRef,
            CameraRef cameraRef)
        {
            ThrowOut(
                SUModelGetCamera(
                    modelRef.intPtr,
                    ref cameraRef.intPtr),
                "Could not get camera.");
        }
    }
}
