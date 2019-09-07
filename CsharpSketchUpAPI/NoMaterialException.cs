using System;

namespace ExLumina.SketchUp.API
{
    public class NoMaterialException : Exception
    {
        public NoMaterialException(string msg) : base(msg)
        {

        }
    }
}
