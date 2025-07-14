using HarmonyLib;
using MelonLoader;
using Translator;

[assembly: MelonInfo(typeof(Core), "Translator", "0.0.3", "funlennysub")]
[assembly: MelonGame("Pigeons at Play", "Mycopunk")]

namespace Translator;

[HarmonyPatch(typeof(Il2Cpp.Upgrade))]
class UpgradePatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Il2Cpp.Upgrade.Name), MethodType.Getter)]
    static void NamePostfix(ref string __result)
    {
        __result = __result.Replace("<font=H>", "").Replace("</font>", "");
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Il2Cpp.Upgrade.Description), MethodType.Getter)]
    static void DescriptionPostfix(ref string __result)
    {
        __result = __result.Replace("<font=H>", "").Replace("</font>", "");
    }

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Il2Cpp.Upgrade.GetStatList))]
    static void StatList(int __0, ref string __result)
    {
        __result = __result.Replace("<font=H>", "").Replace("</font>", "");
    }
}

[HarmonyPatch(typeof(Il2Cpp.StackDisplay))]
class StackDisplayPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Il2Cpp.StackDisplay.title), MethodType.Getter)]
    static void NamePostfix(ref string __result)
    {
        __result = __result.Replace("<font=H>", "").Replace("</font>", "");
    }
}

public class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"Initialized!");
    }
}