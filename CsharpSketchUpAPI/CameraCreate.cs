using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUCameraCreate")]
        static extern int SUCameraCreate(
            ref IntPtr cameraRef);

        public static void CameraCreate(
            CameraRef cameraRef)
        {
            ThrowOut(
                SUCameraCreate(
                    ref cameraRef.intPtr),
                "Could not create camera.");
        }
    }
}
