﻿using System;
using System.Runtime.InteropServices;

namespace ExLumina.SketchUp.API
{
    public static partial class SU
    {
        [DllImport(LIB, EntryPoint = "SUComponentDefinitionGetEntities")]
        static extern int SUComponentDefinitionGetEntities(
            IntPtr compDefRef,
            ref IntPtr entitiesRef);

        public static void ComponentDefinitionGetEntities(
            ComponentDefinitionRef compDefRef,
            EntitiesRef entitiesRef)
        {
            ThrowOut(
                SUComponentDefinitionGetEntities(
                    compDefRef.intPtr, 
                    ref entitiesRef.intPtr),
                "Could not get comp def entities.");
        }
    }
}
