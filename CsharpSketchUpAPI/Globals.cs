using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        private const string LIB = "SketchUpAPI";

        public const double MetersToInches = 39.37007874;

        public const int LengthFormat_Decimal = 0;
        public const int LengthFormat_Architectural = 1;
        public const int LengthFormat_Engineering = 2;
        public const int LengthFormat_Fractional = 3;

        public const int MaterialColorizeType_Shift = 0;
        public const int MaterialColorizeType_Tint = 1;

        public const int MaterialType_Colored = 0;
        public const int MaterialType_Textured = 1;
        public const int MaterialType_ColorizedTexture = 2;

        public const int ModelUnits_Inches = 0;
        public const int ModelUnits_Feet = 1;
        public const int ModelUnits_Millimeters = 2;
        public const int ModelUnits_Centimeters = 3;
        public const int ModelUnits_Meters = 4;

        public const int ModelVersion_SU3 = 0;
        public const int ModelVersion_SU4 = 1;
        public const int ModelVersion_SU5 = 2;
        public const int ModelVersion_SU6 = 3;
        public const int ModelVersion_SU7 = 4;
        public const int ModelVersion_SU8 = 5;
        public const int ModelVersion_SU2013 = 6;
        public const int ModelVersion_SU2014 = 7;
        public const int ModelVersion_SU2015 = 8;
        public const int ModelVersion_SU2016 = 9;
        public const int ModelVersion_SU2017 = 10;
        public const int ModelVersion_SU2018 = 11;
        public const int ModelVersion_SU2019 = 12;

        public const int ErrorNone = 0;
        public const int ErrorNullPointerInput = 1;
        public const int ErrorInvalidInput = 2;
        public const int ErrorNullPointerOutput = 3;
        public const int ErrorInvalidOutput = 4;
        public const int ErrorOverwriteValid = 5;
        public const int ErrorGeneric = 6;
        public const int ErrorSerialization = 7;
        public const int ErrorOutOfRange = 8;
        public const int ErrorNoData = 9;
        public const int ErrorInsufficientSize = 10;
        public const int ErrorUnknownException = 11;
        public const int ErrorModelInvalid = 12;
        public const int ErrorModelVersion = 13;
        public const int ErrorLayerLocked = 14;
        public const int ErrorDuplicate = 15;
        public const int ErrorPartialSuccess = 16;
        public const int ErrorUnsupported = 17;
        public const int ErrorInvalidArgument = 18;
        public const int ErrorEntityLocked = 19;
        public const int ErrorInvalidOperation = 20;

        public abstract class IntPtrRef
        {
            internal IntPtr intPtr;
        }

        public class CameraRef : IntPtrRef { }
        public class ComponentDefinitionRef : IntPtrRef { }
        public class ComponentInstanceRef : IntPtrRef { }
        public class EdgeRef : IntPtrRef { }
        public class EntitiesRef : IntPtrRef { }
        public class FaceRef : IntPtrRef { }
        public class GeometryInputRef : IntPtrRef { }
        public class GroupRef : IntPtrRef { }
        public class ImageRepRef : IntPtrRef { }
        public class LoopInputRef : IntPtrRef { }
        public class LoopRef : IntPtrRef { }
        public class MaterialRef : IntPtrRef { }
        public class ModelRef : IntPtrRef { }
        public class OptionsManagerRef : IntPtrRef { }
        public class OptionsProviderRef : IntPtrRef { }
        public class StringRef : IntPtrRef { }
        public class StylesRef : IntPtrRef { }
        public class TextureRef : IntPtrRef { }
        public class TextureWriterRef : IntPtrRef { }
        public class TypedValueRef : IntPtrRef { }
        public class UVHelperRef : IntPtrRef { }
        public class VertexRef : IntPtrRef { }

        static void ThrowOut(
            int errCode,
            string msg)
        {
            ThrowOut(
                errCode,
                msg,
                s => throw new SketchUpException(s));

        }

        static void ThrowOut(
            int errCode,
            string msg,
            Action<string> thrower)
        {
            string suMsg;

            switch (errCode)
            {
                case ErrorNone:
                    return;

                case ErrorNullPointerInput:
                    suMsg = "A pointer for a required input was NULL.";
                    break;

                case ErrorInvalidInput:
                    suMsg = "An API object input to the function was not created properly.";
                    break;

                case ErrorNullPointerOutput:
                    suMsg = "A pointer for a required output was NULL.";
                    break;

                case ErrorInvalidOutput:
                    suMsg = "An API object to be written with output from the function was not created properly.";
                    break;

                case ErrorOverwriteValid:
                    suMsg = "Indicates that an input object reference already references an object where it was expected to be SU_INVALID.";
                    break;

                case ErrorGeneric:
                    suMsg = "Indicates an unspecified error.";
                    break;

                case ErrorSerialization:
                    suMsg = "Indicate an error occurred during loading or saving of a file.";
                    break;

                case ErrorOutOfRange:
                    suMsg = "An input contained a value that was outside the range of allowed values.";
                    break;

                case ErrorNoData:
                    suMsg = "The requested operation has no data to return to the user. This usually occurs when a request is made for data that is only available conditionally.";
                    break;

                case ErrorInsufficientSize:
                    suMsg = "Indicates that the size of an output parameter is insufficient.";
                    break;

                case ErrorUnknownException:
                    suMsg = "An unknown exception occurred.";
                    break;

                case ErrorModelInvalid:
                    suMsg = "The model requested is invalid and cannot be loaded.";
                    break;

                case ErrorModelVersion:
                    suMsg = "The model cannot be loaded or saved due to an invalid version";
                    break;

                case ErrorLayerLocked:
                    suMsg = "The layer that is being modified is locked.";
                    break;

                case ErrorDuplicate:
                    suMsg = "The user requested an operation that would result in duplicate data.";
                    break;

                case ErrorPartialSuccess:
                    suMsg = "The requested operation was not fully completed but it returned an intermediate successful result.";
                    break;

                case ErrorUnsupported:
                    suMsg = "The requested operation is not supported.";
                    break;

                case ErrorInvalidArgument:
                    suMsg = "An argument contains invalid information.";
                    break;

                case ErrorEntityLocked:
                    suMsg = "The entity being modified is locked.";
                    break;

                case ErrorInvalidOperation:
                    suMsg = "The requested operation is invalid.";
                    break;

                default:
                    suMsg = "Unrecognized error code.";
                    break;
            }

            thrower($"Error {errCode}\n" + msg +  "\n" + suMsg);

            //throw new Exception(
            //    $"Error: {errCode}\n" +
            //    msg + "\n" +
            //    suMsg);
        }
    }
}
