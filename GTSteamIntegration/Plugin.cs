using BepInEx;

namespace GTSteamIntegration
{
    [BepInPlugin("pl2w.gtsteamintegration", "GTSteamIntegration", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            GorillaTagger.OnPlayerSpawned(delegate
            {
                gameObject.AddComponent<SteamHandler>();
            });
        }
    }
}
