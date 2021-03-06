﻿using ExLumina.SketchUp.API;

namespace ExLumina.Examples.SketchUp.API
{
    class TwoQuadsUnweldedEdge : Example
    {
        SU.Point3D[] points =
        {
            new SU.Point3D(2, 0, -2),
            new SU.Point3D(2, 0, 2),
            new SU.Point3D(-2, 0, 2),
            new SU.Point3D(-2, 0, -2),
            new SU.Point3D(2, 2, 2),
            new SU.Point3D(-2, 2, 2),
            new SU.Point3D(-2, 0, 2),
            new SU.Point3D(2, 0, 2)
        };

        public TwoQuadsUnweldedEdge(string display) : base(display)
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

            loop = new SU.LoopInputRef();
            SU.LoopInputCreate(loop);

            SU.LoopInputAddVertexIndex(loop, 4);
            SU.LoopInputAddVertexIndex(loop, 5);
            SU.LoopInputAddVertexIndex(loop, 6);
            SU.LoopInputAddVertexIndex(loop, 7);

            SU.GeometryInputAddFace(geometry, loop, out faceIndex);

            SU.EntitiesFill(entities, geometry, false);

            SUHelper.Finalize(path + @"\TwoQuadsUnweldedEdge.skp");
        }
    }
}
