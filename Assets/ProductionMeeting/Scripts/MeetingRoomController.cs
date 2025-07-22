using UnityEngine;
using VRT.Pilots.Common;
using VRT.Core;
using UnityEngine.SceneManagement;

namespace VRT.Pilots.ProductionMeeting
{
    public class MeetingRoomController : PilotController
    {
       
        public GameObject sceneChange;


        public void LoadSceneName()
        {

                if (sceneChange == null)
                {
                    Debug.LogWarning("sceneChange is not assigned.");
                    return;
                }

                 Transform sceneOptions = sceneChange.transform.Find("ExampleSceneUI");
                if (sceneOptions == null)
                {
                    Debug.LogWarning("ExampleSceneUI not found under sceneChange.");
                    return;
                }

                Transform mediascape = sceneOptions.Find("Mediascape");
                if (mediascape != null && mediascape.gameObject.activeSelf)
                {
                    if (SceneManager.GetActiveScene().name != "MediaScape_Stage")
                        LoadNewScene("MediaScape_Stage");
                    return;
                }

                Transform vrlobby = sceneOptions.Find("VRLobby");
                if (vrlobby != null && vrlobby.gameObject.activeSelf)
                {
                    if (SceneManager.GetActiveScene().name != "VRLobby")
                        LoadNewScene("TractionLobby");
                    return;
                }

                Transform culture = sceneOptions.Find("5Dculture");
                if (culture != null && culture.gameObject.activeSelf)
                {
                    if (SceneManager.GetActiveScene().name != "5DCultureHistoricalNew")
                        LoadNewScene("5DCultureHistoricalNew");
                    return;
                }

                Transform meeting = sceneOptions.Find("Meeting");
                if (meeting != null && meeting.gameObject.activeSelf)
                {
                    if (SceneManager.GetActiveScene().name != "MeetingRoom")
                        LoadNewScene("MeetingRoom");
                    return;
                }

                Transform training = sceneOptions.Find("Training");
                if (meeting != null && meeting.gameObject.activeSelf)
                {
                    if (SceneManager.GetActiveScene().name != "Training")
                        LoadNewScene("Training");
                    return;
                }

            
        }

    } 


}

