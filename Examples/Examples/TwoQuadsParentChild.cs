using ExLumina.SketchUp.API;

namespace ExLumina.Examples.SketchUp.API
{
    class TwoQuadsParentChild : Example
    {
        SU.Point3D[] parentPoints =
        {
            new SU.Point3D(1, 0, -1),
            new SU.Point3D(1, 0, 1),
            new SU.Point3D(-1, 0, 1),
            new SU.Point3D(-1, 0, -1)
        };

        SU.Point3D[] childPoints =
        {
            new SU.Point3D(1,-1, 0),
            new SU.Point3D(1, 1, 0),
            new SU.Point3D(-1, 1, 0),
            new SU.Point3D(-1, -1, 0)
        };

        public TwoQuadsParentChild(string display) : base(display)
        {

        }

        public override void Run(string path)
        {
            SU.EntitiesRef entities = SUHelper.Initialize();

            SU.GeometryInputRef geometry = new SU.GeometryInputRef();
            SU.GeometryInputCreate(geometry);

            foreach (SU.Point3D p in parentPoints)
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

            SU.EntitiesFill(entities, geometry, false);

            // Now the child.

            SU.ComponentDefinitionRef cd = new SU.ComponentDefinitionRef();
            SU.ComponentDefinitionCreate(cd);

            // Add CD to the model.)

            SU.ComponentDefinitionRef[] defs = new SU.ComponentDefinitionRef[1];
            defs[0] = cd;

            // You leave this out and SketchUp will add the definitions to the model
            // itself when it opens the model. But it will prompt you on close to save
            // the "changes" it thinks that adding the definitions made.

            SUHelper.ModelAddComponentDefinitions(defs);

            // Get the CD's Entities.

            SU.EntitiesRef cdEnts = new SU.EntitiesRef();
            SU.ComponentDefinitionGetEntities(cd, cdEnts);

            // Define a Geometry for the CD.

            geometry = new SU.GeometryInputRef();
            SU.GeometryInputCreate(geometry);

            foreach (SU.Point3D p in childPoints)
            {
                SU.Point3D pc = p;

                pc.x *= SU.MetersToInches;
                pc.y *= SU.MetersToInches;
                pc.z *= SU.MetersToInches;

                SU.GeometryInputAddVertex(geometry, pc);
            }

            loop = new SU.LoopInputRef();
            SU.LoopInputCreate(loop);

            SU.LoopInputAddVertexIndex(loop, 0);
            SU.LoopInputAddVertexIndex(loop, 1);
            SU.LoopInputAddVertexIndex(loop, 2);
            SU.LoopInputAddVertexIndex(loop, 3);

            SU.GeometryInputAddFace(geometry, loop, out faceIndex);
            
            // Fill the CD's Entities with the Geometry.

            SU.EntitiesFill(cdEnts, geometry, true);

            SU.ComponentDefinitionSetName(cd, "Quad in XY");
            SU.ComponentDefinitionSetDescription(cd, "A flat square with normal on positive Z");

            // Create an instance of the CD.

            SU.ComponentInstanceRef ci = new SU.ComponentInstanceRef();
            SU.ComponentDefinitionCreateInstance(cd, ci);

            SU.ComponentInstanceSetName(ci, "Child Quad");

            SU.EntitiesAddInstance(entities, ci, null);
            SUHelper.Finalize(path + @"\TwoQuadsParentChild.skp");
        }
    }
}
