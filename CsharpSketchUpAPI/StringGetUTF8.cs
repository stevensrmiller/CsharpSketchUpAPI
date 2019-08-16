using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUStringGetUTF8")]
        static extern int SUStringGetUTF8(
            IntPtr stringRef,
            int req,
            byte[] buff,
            out int ret);

        public static void StringGetUTF8(
            StringRef stringRef,
            int req,
            byte[] buff,
            out int ret)
        {
            ThrowOut(
                SUStringGetUTF8(
                    stringRef.intPtr,
                    req,
                    buff,
                    out ret),
                "Could not get UTF8 string");
        }
    }
}
