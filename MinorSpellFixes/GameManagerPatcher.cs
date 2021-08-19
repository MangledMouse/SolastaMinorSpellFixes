using HarmonyLib;
using SolastaModApi;
using UnityModManagerNet;

namespace MinorSpellFixes.Patches
{
    class GameManagerPatcher
    {
        [HarmonyPatch(typeof(GameManager), "BindPostDatabase")]
        internal static class GameManager_BindPostDatabase_Patch
        {
            internal static void Postfix()
            {
                MinorSpellFixes.Main.ModEntryPoint();
            }
        }
    }
}
