using UnityEngine;
using VRT.Pilots.Common;

namespace VRT.Pilots.MediaScape
{
    public class MediaScapeController : PilotController
    {
        [Tooltip("Enable costume in this scene (in stead of normal user representation")]
        public bool enableCostume = false;
        [Tooltip("Try to use Kinect Azure skeletons for costume animation (otherwise use controllers)")]
        public bool useKinectSkeletons = false;
        [Tooltip("Keep pointcloud head (in stead of cartoon head) when in costume mode")]
        public bool enablePointcloudHead = false;
        [Tooltip("Enable fadein/fadeout at beginning and end of scene")]
        public bool enableFade = true;
        [Tooltip("Text to show on the fadein")]
        public string fadeInText = "";
     

        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
            if (enableFade && CameraFader.Instance != null)
            {
                CameraFader.Instance.SetText(fadeInText);
                StartCoroutine(CameraFader.Instance.FadeIn());
            }
        }
    }
}