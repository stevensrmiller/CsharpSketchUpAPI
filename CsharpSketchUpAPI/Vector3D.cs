namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        public struct Vector3D
        {
            public double x;
            public double y;
            public double z;

            public Vector3D(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
    }
}
