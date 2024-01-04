

namespace RamuneLib.Utils
{
    public static class PingUtils
    {
        public static Dictionary<string, PingInstance> CachedPings = new();


        public enum PingColor
        {
            Blue,
            Orange,
            Red,
            Cyan,
            Yellow,
        }


        /// <summary>
        /// Create a new ping instance and add it to the CachedPings dictionary.
        /// </summary>
        /// <param name="id">Unique identifier for the ping.</param>
        /// <param name="label">Label for the ping</param>
        /// <param name="color">Color of the ping using the games existing ping color set</param>
        /// <param name="type">Type of the ping, e.g. seamoth, cyclops, signal..</param>
        /// <param name="visible">Initial visibility state of the ping</param>
        /// <returns>The created PingInstance.</returns>
        public static PingInstance Create(string id, string label, PingColor color, PingType type, bool visible = true)
        {
            if (CachedPings.ContainsKey(id))
                throw new ArgumentException($"Ping with ID '{id}' already exists in cache");

            PingInstance ping = new();
            ping.SetColor((int)color);
            ping.SetLabel(label);
            ping.SetType(type);
            ping.SetVisible(visible);

            CachedPings.Add(id, ping);
            return ping;
        }


        public static PingInstance WithParent(this PingInstance ping, Transform parent)
        {
            ping.transform.parent = parent;
            return ping;
        }


        public static PingInstance Get(string id)
        {
            return CachedPings.ContainsKey(id) ? CachedPings[id] : null;
        }


        public static void Remove(string id)
        {
            if(CachedPings.ContainsKey(id))
            {
                PingInstance ping = CachedPings[id];
                GameObject.Destroy(ping);
                CachedPings.Remove(id);
            }
        }


        public static void Clear()
        {
            foreach(var ping in CachedPings.Values)
                GameObject.Destroy(ping);
            
            CachedPings.Clear();
        }
    }
}