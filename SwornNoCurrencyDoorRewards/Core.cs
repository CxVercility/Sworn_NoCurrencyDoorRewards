using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using HarmonyLib;

[assembly: MelonInfo(typeof(SwornNoCurrencyDoorRewards.Core), "SwornNoCurrencyDoorRewards", "1.0.0", "Vercility", null)]
[assembly: MelonGame("Windwalk Games", "SWORN")]

namespace SwornNoCurrencyDoorRewards
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
    }
}

[HarmonyPatch(typeof(PathGenerator), "GeneratePaths")]
class Patch2
{
    static void Postfix(Il2CppReferenceArray<ExpeditionManager.Path> __result)
    {
        if (__result.Length < 2)
        {
            return;
        }
        var random = new Random();


        var path0Type = __result[0].rewardType;
        if (path0Type == RewardType.FairyEmber ||
            path0Type == RewardType.Silk ||
            path0Type == RewardType.Moonstone)
        {
            __result[0].rewardType = random.Next(2) == 0 ? RewardType.Paragon : RewardType.ParagonLevelUp;
        }


        var path1Type = __result[1].rewardType;
        if (path1Type == RewardType.FairyEmber ||
            path1Type == RewardType.Silk ||
            path1Type == RewardType.Moonstone)
        {
            __result[1].rewardType = random.Next(2) == 0 ? RewardType.Paragon : RewardType.ParagonLevelUp;
        }

    }
}