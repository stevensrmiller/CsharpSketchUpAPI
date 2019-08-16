using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUTextureCreateFromFile")]
        static extern int SUTextureCreateFromFile(
            ref IntPtr textureRef,
            string path,
            double sScale,
            double tScale);

        // Note that scales are ignored when you assign UV coords to vertices.

        public static void TextureCreateFromFile(
            TextureRef textureRef,
            string path,
            double sScale,
            double tScale)
        {
            ThrowOut(
                SUTextureCreateFromFile(
                    ref textureRef.intPtr,
                    path,
                    sScale,
                    tScale),
                "Could not create texture from file.");
        }
    }
}
