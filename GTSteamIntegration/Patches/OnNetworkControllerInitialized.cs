using GorillaNetworking;
using HarmonyLib;

namespace GTSteamIntegration.Patches
{
    [HarmonyPatch(typeof(GorillaComputer), nameof(GorillaComputer.OnConnectedToMasterStuff)), HarmonyWrapSafe]
    public class OnNetworkControllerInitialized
    {
        public static void Postfix()
        {
            SteamHandler.OnConnectedToServers();
        }
    }
}
