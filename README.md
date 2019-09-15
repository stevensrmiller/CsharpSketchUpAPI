# CsharpSketchUpAPI

C# SketchUp C API wrapper

A pure C# implementation of a wrapper allowing C# code to call SketchUp C API functions.

Not all API functions are wrapped. However, with priority having gone to those needed to create models useable in Unity games, wrappers exist that allow this much:

- Creation of SketchUp model files.
- Organization of components into a tree hierarchy.
- Translation, rotation, and scaling of components, relative to their hierarchy parents.
- Assignment of texture-mapping coordinates.
- Creating materials.
- Naming components and their instances in a model.
- Positioning the SketchUp camera in the model space.
- Assignment of a SketchUp style from a file.

Note
----
To use this library, you must also have the two SketchUp C API
dynamic-link libraries, SketchUpAPI.dll, and SketchUpCommonPreferences.dll.
Authorized SketchUp developers can download these from the [SketchUp Developer Center][devcenter].
Developers (like us) can also distribute applications with these libraries. However,
a question arose recently in the SketchUp developer forums as to the propriety of
posting these libraries in public GitHub repositories. A SketchUp team member
understandably advised holding off from doing that until we get explicit permission
from Trimble, SketchUp's owner. Until then, if you need these libraries and can't
get them elsewhere, contact us directly at info@exlumina.com.

[devcenter]:
  https://extensions.sketchup.com/en/developer_center/sketchup_sdk
