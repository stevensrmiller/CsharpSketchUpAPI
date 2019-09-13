using ExLumina.SketchUp.API;
using System;

namespace ExLumina.Examples.SketchUp.API
{
    class SixQuadFan : Example
    {
        SU.Point3D[] bladePoints =
        {
            new SU.Point3D(.5, 0, 1),
            new SU.Point3D(1, 0, 2),
            new SU.Point3D(-1, 0, 2),
            new SU.Point3D(-.5, 0, 1)
        };

        public SixQuadFan(string display) : base(display)
        {

        }

        public override void Run(string path)
        {
            SU.EntitiesRef entities = SUHelper.Initialize();

            // Create two Component Definitions.

            SU.ComponentDefinitionRef fanCD = new SU.ComponentDefinitionRef();
            SU.ComponentDefinitionCreate(fanCD);
            SU.ComponentDefinitionSetName(fanCD, "Fan");
            SU.ComponentDefinitionSetDescription(fanCD, "A six-bladed fan on the Y axis");

            SU.ComponentDefinitionRef bladeCD = new SU.ComponentDefinitionRef();
            SU.ComponentDefinitionCreate(bladeCD);
            SU.ComponentDefinitionSetName(bladeCD, "Fan Blade");
            SU.ComponentDefinitionSetDescription(bladeCD, "Trapezoidal blade offset from axis");

            // Add CDs to the model.)

            SU.ComponentDefinitionRef[] defs = new SU.ComponentDefinitionRef[2];
            defs[0] = fanCD;
            defs[1] = bladeCD;

            SUHelper.ModelAddComponentDefinitions(defs);

            // The Fan CD only has instances of the blade, and no
            // geometry of its own. Create the blade geometry and
            // put it into the blade's entities.


            SU.GeometryInputRef bladeGeo = new SU.GeometryInputRef();
            SU.GeometryInputCreate(bladeGeo);

            foreach (SU.Point3D p in bladePoints)
            {
                SU.Point3D pc;

                pc = p;

                pc.x *= SU.MetersToInches;
                pc.y *= SU.MetersToInches;
                pc.z *= SU.MetersToInches;

                SU.GeometryInputAddVertex(bladeGeo, pc);
            }

            SU.LoopInputRef loop = new SU.LoopInputRef();
            SU.LoopInputCreate(loop);

            SU.LoopInputAddVertexIndex(loop, 0);
            SU.LoopInputAddVertexIndex(loop, 1);
            SU.LoopInputAddVertexIndex(loop, 2);
            SU.LoopInputAddVertexIndex(loop, 3);

            long faceIndex;

            SU.GeometryInputAddFace(bladeGeo, loop, out faceIndex);

            SU.EntitiesRef bladeEnts = new SU.EntitiesRef();
            SU.ComponentDefinitionGetEntities(bladeCD, bladeEnts);
            SU.EntitiesFill(bladeEnts, bladeGeo, true);

            // Add six instances of the blade to the fan definition.

            for (int i = 0; i < 6; ++i)
            {
                AddBlade(
                    i,
                    fanCD, 
                    bladeCD,
                    (15.0 / 360.0) * 2 * Math.PI,
                    2 * i * Math.PI / 6);
            }

            // Add one instance of the fan to the model.

            SU.ComponentInstanceRef fi = new SU.ComponentInstanceRef();
            SU.ComponentDefinitionCreateInstance(fanCD, fi);

            SU.EntitiesAddInstance(entities, fi, null);

            SUHelper.Finalize(path + @"\SixQuadFan.skp");
        }

        void AddBlade(
            int n,
            SU.ComponentDefinitionRef parent,
            SU.ComponentDefinitionRef child,
            double twist,
            double spin)
        {
            // Instance the child.

            SU.ComponentInstanceRef ci = new SU.ComponentInstanceRef();
            SU.ComponentDefinitionCreateInstance(child, ci);

            // Set its transform.

            SU.Transformation twistTrans = new SU.Transformation();
            SU.TransformationRotation(
                ref twistTrans,
                new SU.Point3D { x = 0, y = 0, z = 0 },
                new SU.Vector3D { x = 0, y = 0, z = 1 },
                twist);

            SU.Transformation spinTrans = new SU.Transformation();
            SU.TransformationRotation(
                ref spinTrans,
                new SU.Point3D { x = 0, y = 0, z = 0 },
                new SU.Vector3D { x = 0, y = 1, z = 0 },
                spin);

            SU.Transformation trans = new SU.Transformation();

            SU.TransformationMultiply(ref spinTrans, ref twistTrans, ref trans);

            SU.ComponentInstanceSetTransform(ci, trans);

            SU.ComponentInstanceSetName(ci, $"Blade #{n}");

            SU.EntitiesRef parentEnts = new SU.EntitiesRef();
            SU.ComponentDefinitionGetEntities(parent, parentEnts);
            SU.EntitiesAddInstance(parentEnts, ci, null);
        }
    }
}
