

namespace RamuneLib.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool TryGetComponentInChildren<T>(this GameObject gameObject, out T component, bool includeInactive = false) where T : Component
        {
            component = null;

            if(gameObject == null)
                return false;

            return (component = includeInactive ? gameObject.GetComponentInChildren<T>(true) : gameObject.GetComponentInChildren<T>()) != null;
        }


        public static bool TryGetComponents<T>(this GameObject gameObject, out T[] components) where T : Component
        {
            components = null;

            if(gameObject == null)
                return false;

            return(components = gameObject.GetComponents<T>()).Length > 0;
        }


        public static bool TryGetComponentsInChildren<T>(this GameObject gameObject, out T[] components, bool includeInactive = false) where T : Component
        {
            components = null;

            if(gameObject == null)
                return false;

            return(components = includeInactive ? gameObject.GetComponentsInChildren<T>(true) : gameObject.GetComponentsInChildren<T>()).Length > 0;
        }
    }
}