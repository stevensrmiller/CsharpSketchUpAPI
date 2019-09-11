using ExLumina.SketchUp.API;

namespace ExLumina.Examples.SketchUp.API
{
    public static class SUHelper
    {
        static SU.ModelRef model;

        public static SU.EntitiesRef Initialize()
        {
            SU.Initialize();
            model = new SU.ModelRef();
            SU.ModelCreate(model);
            SU.EntitiesRef entities = new SU.EntitiesRef();
            SU.ModelGetEntities(model, entities);

            return entities;
        }

        public static void Finalize(string path)
        {
            SU.StylesRef styles = new SU.StylesRef();
            SU.ModelGetStyles(model, styles);
            SU.StylesAddStyle(styles, "base.style", true);

            SU.CameraRef camera = new SU.CameraRef();

            SU.ModelGetCamera(model, camera);

            SU.CameraSetOrientation(
                camera,
                new SU.Point3D(10 * SU.MetersToInches, -10 * SU.MetersToInches, 10 * SU.MetersToInches),
                new SU.Point3D(0, 0, 0),
                new SU.Vector3D(0, 0, 1));


            SU.ModelSaveToFileWithVersion(model, path, SU.ModelVersion_SU2017);
            SU.ModelRelease(model);
            SU.Terminate();
        }

        internal static void ModelAddComponentDefinitions(SU.ComponentDefinitionRef[] defs)
        {
            SU.ModelAddComponentDefinitions(model, defs.Length, defs);
        }
    }
}
