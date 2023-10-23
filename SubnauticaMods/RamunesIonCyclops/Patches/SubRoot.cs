

using HarmonyLib;
using UnityEngine;

namespace Ramune.RamunesIonCyclops.Patches
{
    [HarmonyPatch(typeof(SubRoot))]
    public static class SubRootPatch
    {
        public static Renderer[] LeftDoorRenderers, RightDoorRenderers;
        public static Renderer MainRoomRenderer;

        [HarmonyPatch(nameof(SubRoot.Update)), HarmonyPostfix]
        public static void Update(SubRoot __instance)
        {
            if(!__instance.isCyclops) return;
        }

        public static void MainRoom()
        {

        }

        public static void Cockpit()
        {

        }

        public static void MiscOrUI()
        {

        }
    }
}