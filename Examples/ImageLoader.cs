using System;

namespace ExLumina.SketchUp.API.Examples
{
    class ImageLoader : Example
    {
        SU.Point3D[] points =
        {
            new SU.Point3D(2, 0, -2),
            new SU.Point3D(2, 0, 2),
            new SU.Point3D(-2, 0, 2),
            new SU.Point3D(-2, 0, -2)
        };

        public ImageLoader(string display) : base(display)
        {

        }

        public override void Run(string path)
        {
            SU.Initialize();

            try
            {
                SU.ImageRepRef suImageRepRef = new SU.ImageRepRef();
                SU.ImageRepCreate(suImageRepRef);
                SU.ImageRepLoadFile(suImageRepRef, "Orange.png");

                long width;
                long height;

                SU.ImageRepGetPixelDimensions(suImageRepRef, out width, out height);

                Console.WriteLine("IMAGE IS {0} x {1}", width, height);

                long padding;

                SU.ImageRepGetRowPadding(suImageRepRef, out padding);

                Console.WriteLine("PADDING IS {0}", padding);

                long dataSize;
                long bitsPerPixel;

                SU.ImageRepGetDataSize(suImageRepRef, out dataSize, out bitsPerPixel);

                Console.WriteLine("DATASIZE = {0}, BPP = {1}", dataSize, bitsPerPixel);

                byte[] pixels = new byte[dataSize];

                SU.ImageRepGetData(suImageRepRef, dataSize, pixels);

                long center = 4 * ((height / 2) * (width + padding) + width / 2);

                Console.WriteLine("CENTER PIXEL = [{0}, {1}, {2}, {3}]", 
                    pixels[center],
                    pixels[center + 1],
                    pixels[center + 2],
                    pixels[center + 3]);

                SU.TextureRef suTextureRef = new SU.TextureRef();

                SU.TextureCreateFromImageRep(suTextureRef, suImageRepRef);

                SU.TextureWriteToFile(suTextureRef, path + @"\TextureCopy.png");

                SU.TextureRelease(suTextureRef);

                SU.ColorOrder suColorOrder = SU.GetColorOrder();

                Console.WriteLine(
                    "RED INDEX = {0}\n" +
                    "GRN INDEX = {1}\n" +
                    "BLU INDEX = {2}\n" +
                    "ALF INDEX = {3}",
                    suColorOrder.redIndex,
                    suColorOrder.greenIndex,
                    suColorOrder.blueIndex,
                    suColorOrder.alphaIndex);

                SU.ImageRepRelease(suImageRepRef);
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEPTION: {0}", e.Message);
            }
            finally
            {
                SU.Terminate();
            }
        }
    }
}
