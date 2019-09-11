using ExLumina.SketchUp.API;

namespace ExLumina.Examples.SketchUp.API
{
    class TexturedQuad : Example
    {
        SU.Point3D[] points =
        {
            new SU.Point3D(2, 0, -2),
            new SU.Point3D(2, 0, 2),
            new SU.Point3D(-2, 0, 2),
            new SU.Point3D(-2, 0, -2)
        };

        public TexturedQuad(string display) : base(display)
        {

        }

        public override void Run(string path)
        {
            SU.EntitiesRef entities = SUHelper.Initialize();

            SU.GeometryInputRef geometry = new SU.GeometryInputRef();
            SU.GeometryInputCreate(geometry);

            foreach (SU.Point3D p in points)
            {
                SU.Point3D pc = p;

                pc.x *= SU.MetersToInches;
                pc.y *= SU.MetersToInches;
                pc.z *= SU.MetersToInches;

                SU.GeometryInputAddVertex(geometry, pc);
            }

            SU.LoopInputRef loop = new SU.LoopInputRef();
            SU.LoopInputCreate(loop);

            SU.LoopInputAddVertexIndex(loop, 0);
            SU.LoopInputAddVertexIndex(loop, 1);
            SU.LoopInputAddVertexIndex(loop, 2);
            SU.LoopInputAddVertexIndex(loop, 3);

            long faceIndex;

            SU.GeometryInputAddFace(geometry, loop, out faceIndex);

            SU.MaterialRef material = new SU.MaterialRef();
            SU.MaterialCreate(material);
            SU.MaterialSetName(material, "Placeholder");
            SU.TextureRef texture = new SU.TextureRef();
            SU.TextureCreateFromFile(
                texture,
                "PlaceHolderRGBY.png",
                SU.MetersToInches,
                SU.MetersToInches);
            SU.MaterialSetTexture(material, texture);

            SU.MaterialInput materialInput = new SU.MaterialInput();
            materialInput.materialRef = material;
            materialInput.numUVCoords = 4;

            materialInput.materialRef = material;

            materialInput.SetUVCoords(
                new SU.Point2D(1, 0),
                new SU.Point2D(1, 1),
                new SU.Point2D(0, 1),
                new SU.Point2D(0, 0));

            materialInput.SetVertexIndices(0, 1, 2, 3);

            SU.GeometryInputFaceSetFrontMaterial(geometry, 0, materialInput);

            SU.EntitiesFill(entities, geometry, true);

            SUHelper.Finalize(path + @"\TexturedQuad.skp");
        }
    }
}
