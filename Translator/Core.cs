using HarmonyLib;
using MelonLoader;
using Translator;

[assembly: MelonInfo(typeof(Core), "Translator", "0.0.5", "funlennysub")]
[assembly: MelonGame("Pigeons at Play", "Mycopunk")]

namespace Translator;

[HarmonyPatch(typeof(Upgrade))]
class UpgradePatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Upgrade.Name), MethodType.Getter)]
    static void NamePostfix(ref string __result)
    {
        if (__result == null) return;
        __result = __result.Replace("<font=H>", "").Replace("</font>", "");
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Upgrade.Description), MethodType.Getter)]
    static void DescriptionPostfix(ref string __result)
    {
        if (__result == null) return;
        __result = __result.Replace("<font=H>", "").Replace("</font>", "");
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Upgrade.GetStatList))]
    static void StatListPostfix(int seed, ref string __result)
    {
        if (__result == null) return;
        __result = __result.Replace("<font=H>", "").Replace("</font>", "");
    }
}

[HarmonyPatch(typeof(Pigeon.Movement.Player))]
class PlayerPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Pigeon.Movement.Player.UpdateStackDisplay))]
    [HarmonyPatch(new[]
        {
            typeof(UnityEngine.Object), typeof(string), typeof(UnityEngine.Sprite), typeof(UnityEngine.Color),
            typeof(int),
            typeof(bool), typeof(float)
        }
    )]
    static void Prefix(Pigeon.Movement.Player __instance, UnityEngine.Object id, ref string name,
        UnityEngine.Sprite icon, UnityEngine.Color color, int stacks, bool updateName, float timeoutDuration)
    {
        name = name.Replace("<font=H>", "").Replace("</font>", "");
    }
}

public class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"Initialized!");
    }
}