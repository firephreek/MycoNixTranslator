using HarmonyLib;
using MelonLoader;
using Translator;

[assembly: MelonInfo(typeof(Core), "Translator", "0.0.2", "funlennysub")]
[assembly: MelonGame("Pigeons at Play", "Mycopunk")]

namespace Translator;

[HarmonyPatch(typeof(Il2Cpp.Upgrade))]
class UpgradePath
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
}

public class Core : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"Initialized!");
    }
}