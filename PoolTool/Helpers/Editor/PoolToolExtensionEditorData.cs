using System;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public static class PoolToolExtensionEditorData
    {
        public static string GetCleanName(Type input)
        {
            if (input == typeof(PE05_AutoDestroyInactivePoolObjects))
                return "Auto Pool Cleanup";

            if (input == typeof(PE00_Logger))
                return "Logger";

            if (input == typeof(PE02_StaticPoolAccess))
                return "Static Access For The Pool";

            if (input == typeof(PE07_InstantiationCallback))
                return "Unity Event 1 - On Instantiation";

            if (input == typeof(PE08_ObjectCallCallback))
                return "Unity Event 2 - On Call";

            if (input == typeof(PE09_ObjectReturnCallback))
                return "Unity Event 3 - On Return";

            if (input == typeof(PE10_DestructionCallback))
                return "Unity Event 4 - On Destroy";

            if (input == typeof(PE04_AutoReturnPoolObjectExtension))
                return "Auto-Return Timer";

            if (input == typeof(PE06_PooledObjectNameOverride))
                return "Name Override";

            if (input == typeof(PE03_PoolCap))
                return "Pool Cap";

            if (input == typeof(PE01_InitialPopulator))
                return "Initial Populate";

            return input.Name;
        }

        public static string GetDescription(Type input)
        {
            if (input == typeof(PE05_AutoDestroyInactivePoolObjects))
                return "Auto destroy inactive objects in this pool after a certain number of seconds.";

            if (input == typeof(PE00_Logger))
                return "Log values for the pool.";

            if (input == typeof(PE02_StaticPoolAccess))
                return "Gain access to this pool from code based on a string, rather than an instance.";

            if (input == typeof(PE07_InstantiationCallback))
                return "Set up a Unity event for when this pool instantiates a new object.";

            if (input == typeof(PE08_ObjectCallCallback))
                return "Set up a Unity event for when an object is called from this pool.";

            if (input == typeof(PE09_ObjectReturnCallback))
                return "Set up a Unity event for when an object is returned to this pool.";

            if (input == typeof(PE10_DestructionCallback))
                return "Set up a Unity event for when this pool destroys an object.";

            if (input == typeof(PE04_AutoReturnPoolObjectExtension))
                return "Auto return a GameObject maintained by this pool after a predefined timer.";

            if (input == typeof(PE06_PooledObjectNameOverride))
                return "Override \"(Clone)\" in the name of a pooled object with a more informative " +
                    "\"(Pooled by <Name of this GameObject>)\"";

            if (input == typeof(PE03_PoolCap))
                return "Set a maximum number of objects this pool will have inside it at any given time.";

            if (input == typeof(PE01_InitialPopulator))
                return "Set a number of objects this pool will instantiate at start.";

            return "No description defined.";
        }
    }
}