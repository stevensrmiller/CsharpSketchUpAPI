# SketchUpAPI
C# SketchUp C API wrapper

A pure C# implementation of a wrapper allowing C# code to call SketchUp C API functions.

Not all API functions are wrapped. However, with priority having gone to those needed to create models useable in Unity games, wrappers exist that allow this much:

Creation of SketchUp model files.
Organization of components into a tree hierarchy.
Translation, rotation, and scaling of components, relative to their hierarchy parents.
Assignment of texture-mapping coordinates.
Creating materials.
Naming components and their instances in a model.
Positioning the SketchUp camera in the model space.
Assignment of a SketchUp style from a file.

