namespace ExLumina.SketchUp.API.Examples
{
    class RedQuad : Example
    {
        SU.Point3D[] points =
        {
            new SU.Point3D(2, 0, -2),
            new SU.Point3D(2, 0, 2),
            new SU.Point3D(-2, 0, 2),
            new SU.Point3D(-2, 0, -2)
        };

        public RedQuad(string display) : base(display)
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

            int faceIndex;

            SU.GeometryInputAddFace(geometry, loop, out faceIndex);

            SU.MaterialRef material = new SU.MaterialRef();
            SU.MaterialCreate(material); 
            SU.MaterialSetName(material, "Pure Red");
            SU.MaterialSetColor(material, new SU.Color { red = 0xFF, alpha = 0xFF });
            SU.MaterialInput materialInput = new SU.MaterialInput();
            materialInput.materialRef = material;
            SU.GeometryInputFaceSetFrontMaterial(geometry, 0, materialInput);

            SU.EntitiesFill(entities, geometry, true);

            SUHelper.Finalize(path + @"\RedQuad.skp");
        }
    }
}
