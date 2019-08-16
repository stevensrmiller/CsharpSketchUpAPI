using System;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        private const string LIB =
            @"D:\Program Files\SketchUp API\binaries\sketchup\x64\SketchUpAPI";

        public const double MetersToInches = 39.37007874;

        public const int LengthFormat_Decimal = 0;
        public const int LengthFormat_Architectural = 1;
        public const int LengthFormat_Engineering = 2;
        public const int LengthFormat_Fractional = 3;

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

        public abstract class IntPtrRef
        {
            internal IntPtr intPtr;
        }

        public class CameraRef : IntPtrRef { }
        public class ComponentDefinitionRef : IntPtrRef { }
        public class ComponentInstanceRef : IntPtrRef { }
        public class EntitiesRef : IntPtrRef { }
        public class FaceRef : IntPtrRef { }
        public class GeometryInputRef : IntPtrRef { }
        public class LoopInputRef : IntPtrRef { }
        public class MaterialRef : IntPtrRef { }
        public class ModelRef : IntPtrRef { }
        public class OptionsManagerRef : IntPtrRef { }
        public class OptionsProviderRef : IntPtrRef { }
        public class StringRef : IntPtrRef { }
        public class StylesRef : IntPtrRef { }
        public class TextureRef : IntPtrRef { }
        public class TypedValueRef : IntPtrRef { }

        static void ThrowOut(
            int errCode,
            string msg)
        {
            string suMsg;

            switch (errCode)
            {
                case 0: // SU_ERROR_NONE 	
                    return;

                case 1: // SU_ERROR_NULL_POINTER_INPUT 	
                    suMsg = "A pointer for a required input was NULL.";
                    break;

                case 2: // SU_ERROR_INVALID_INPUT 	
                    suMsg = "An API object input to the function was not created properly.";
                    break;

                case 3: // SU_ERROR_NULL_POINTER_OUTPUT 	
                    suMsg = "A pointer for a required output was NULL.";
                    break;

                case 4: // SU_ERROR_INVALID_OUTPUT 	
                    suMsg = "An API object to be written with output from the function was not created properly.";
                    break;

                case 5: // SU_ERROR_OVERWRITE_VALID 	
                    suMsg = "Indicates that an input object reference already references an object where it was expected to be SU_INVALID.";
                    break;

                case 6: // SU_ERROR_GENERIC 	
                    suMsg = "Indicates an unspecified error.";
                    break;

                case 7: // SU_ERROR_SERIALIZATION 	
                    suMsg = "Indicate an error occurred during loading or saving of a file.";
                    break;

                case 8: // SU_ERROR_OUT_OF_RANGE 	
                    suMsg = "An input contained a value that was outside the range of allowed values.";
                    break;

                case 9: // SU_ERROR_NO_DATA 	
                    suMsg = "The requested operation has no data to return to the user. This usually occurs when a request is made for data that is only available conditionally.";
                    break;

                case 10: // SU_ERROR_INSUFFICIENT_SIZE 	
                    suMsg = "Indicates that the size of an output parameter is insufficient.";
                    break;

                case 11: // SU_ERROR_UNKNOWN_EXCEPTION 	
                    suMsg = "An unknown exception occurred.";
                    break;

                case 12: // SU_ERROR_MODEL_INVALID 	
                    suMsg = "The model requested is invalid and cannot be loaded.";
                    break;

                case 13: // SU_ERROR_MODEL_VERSION 	
                    suMsg = "The model cannot be loaded or saved due to an invalid version";
                    break;

                case 14: // SU_ERROR_LAYER_LOCKED 	
                    suMsg = "The layer that is being modified is locked.";
                    break;

                case 15: // SU_ERROR_DUPLICATE 	
                    suMsg = "The user requested an operation that would result in duplicate data.";
                    break;

                case 16: // SU_ERROR_PARTIAL_SUCCESS 	
                    suMsg = "The requested operation was not fully completed but it returned an intermediate successful result.";
                    break;

                case 17: // SU_ERROR_UNSUPPORTED 	
                    suMsg = "The requested operation is not supported.";
                    break;

                case 18: // SU_ERROR_INVALID_ARGUMENT 	
                    suMsg = "An argument contains invalid information.";
                    break;

                case 19: // SU_ERROR_ENTITY_LOCKED 	
                    suMsg = "The entity being modified is locked.";
                    break;

                case 20: // SU_ERROR_INVALID_OPERATION 	
                    suMsg = "The requested operation is invalid.";
                    break;
                default:
                    suMsg = "Unrecognized error code.";
                    break;
            }

            throw new Exception(
                $"Error: {errCode}\n" +
                msg + "\n" +
                suMsg);
        }
    }
}
