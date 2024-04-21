using GorillaNetworking;
using Photon.Pun;
using Steamworks;

namespace GTSteamIntegration
{
    public class SteamHandler : MonoBehaviourPunCallbacks
    {
        protected Callback<GameRichPresenceJoinRequested_t> m_GameRichPresenceJoinRequested;

        public SteamHandler()
        {
            m_GameRichPresenceJoinRequested = Callback<GameRichPresenceJoinRequested_t>.Create(OnGameRichPresenceJoinRequested);
        }

        public static void OnConnectedToServers()
        {
            string launchCmd;
            if (SteamApps.GetLaunchCommandLine(out launchCmd, 260) > 0)
                PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(launchCmd);
        }

        void OnGameRichPresenceJoinRequested(GameRichPresenceJoinRequested_t param)
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(param.m_rgchConnect);
        }

        public override void OnJoinedRoom()
        {
            SteamFriends.SetRichPresence("connect", PhotonNetwork.CurrentRoom.Name);
        }

        public override void OnLeftRoom()
        {
            SteamFriends.ClearRichPresence();
        }
    }
}
