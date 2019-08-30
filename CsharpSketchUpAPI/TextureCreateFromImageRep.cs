using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUTextureCreateFromImageRep")]
        static extern int SUTextureCreateFromImageRep(
            ref IntPtr textureRef,
            IntPtr imageRepRef);

        public static void TextureCreateFromImageRep(
            TextureRef textureRef,
            ImageRepRef imageRepRef)
        {
            ThrowOut(
                SUTextureCreateFromImageRep(
                    ref textureRef.intPtr,
                    imageRepRef.intPtr),
                "Could not create texture from image rep.");
        }
    }
}
