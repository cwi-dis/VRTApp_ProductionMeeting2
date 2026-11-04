using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRT.UserRepresentation.PointCloud;
using VRT.Pilots.Common;
using VRT.Pilots.MediaScape;
using Cwipc;

public class EnableMediascapeExtras : MonoBehaviour
{
    public GameObject MediaScape_extras;
    public GameObject PointcloudGO;
    public GameObject MarieAntoinette;
    public GameObject avatarHeadLondon;
    public GameObject avatarHeadParis;
    public GameObject leftHand;
    public GameObject RightHand;
    public GameObject VRRigSkeleton;
    public GameObject VRRigControllers;
    [Tooltip("Only enable costume for visible representations only")]
    public bool butOnlyWhenVisible = true;

    PlayerTrackingTargets subscribedTargets;
    SizeAdjust subscribedSizeAdjust;

    void Awake()
    {
        WireCostumeToPlayer();
    }

    void OnDestroy()
    {
        if (subscribedTargets != null && subscribedSizeAdjust != null)
        {
            subscribedTargets.ViewAdjusted -= subscribedSizeAdjust.AdjustHeight;
        }
    }

    /// <summary>
    /// Connect the costume rigging (SyncSkeletonToVRRig) and costume sizing (SizeAdjust) to the
    /// head/neck/hand transforms of the player we are part of, the same way VR2Gather's
    /// PlayerRepresentationWirer does for avatars. These used to be prefab overrides pointing into
    /// the player rig, which broke when VR2Gather replaced that rig.
    /// Done in Awake because SizeAdjust.Start() needs SourceTop. The player's hand models are not
    /// hidden: the costume has no hands of its own.
    /// </summary>
    void WireCostumeToPlayer()
    {
        var targets = GetComponentInParent<PlayerTrackingTargets>();
        if (targets == null)
        {
            Debug.LogWarning($"{name}: EnableMediascapeExtras: no PlayerTrackingTargets in parent hierarchy, costume not rigged");
            return;
        }
        var sync = GetComponentInChildren<SyncSkeletonToVRRig>(true);
        if (sync != null)
        {
            sync.head.vrTarget = targets.head;
            sync.neck.vrTarget = targets.neck;
            sync.leftHand.vrTarget = targets.leftHand;
            sync.rightHand.vrTarget = targets.rightHand;
        }
        else
        {
            Debug.LogWarning($"{name}: EnableMediascapeExtras: no SyncSkeletonToVRRig, costume not rigged");
        }
        var sizeAdjust = GetComponentInChildren<SizeAdjust>(true);
        if (sizeAdjust != null)
        {
            // Measure at the neck, like PlayerRepresentationWirer (VR2Gather #356)
            sizeAdjust.SourceTop = targets.neck.gameObject;
            sizeAdjust.SourceBottom = targets.gameObject;
            targets.ViewAdjusted += sizeAdjust.AdjustHeight;
            subscribedTargets = targets;
            subscribedSizeAdjust = sizeAdjust;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MediaScapeController ctrl = (MediaScapeController)MediaScapeController.Instance;
        PlayerControllerBase playerManager = GetComponent<PlayerControllerBase>();
        if (playerManager == null) playerManager = GetComponentInParent<PlayerControllerBase>();
        if (playerManager.isVisible || butOnlyWhenVisible == false)
        {
            if (ctrl.enableCostume)
            {
                // There should be a better way to determine whether or not to use skeleton data...
                bool useSkeletons = ctrl.useKinectSkeletons;
#if VRT_WITH_KINECT_SKELETONS
                if (useSkeletons)
                {
                    // Enable skeleton grabbing, if the capturer supports it.
                    PointCloudPipelineSelf pc_pipeline = PointcloudGO?.GetComponentInChildren<PointCloudPipelineSelf>();
                    var pc_reader = pc_pipeline.GetReader() as AsyncKinectReader;
                    if (pc_reader == null)
                    {
                        useSkeletons = false;
                        Debug.LogWarning("EnableMediaScapeExtras: point reader does not support skeletons. Revert to controllers.");
                    }
                    else
                    {
                        pc_reader.SetWantSkeleton(true);
                    }
                }
#endif
                // Enable the correct input parameters for controlling the costume
                // (either the skeleton-based parameters or the controller-based parameters)
                VRRigControllers?.SetActive(!useSkeletons);
                VRRigSkeleton?.SetActive(useSkeletons);

                MediaScape_extras.SetActive(true);
                if (ctrl.enablePointcloudHead)
                {
                    // We are using the costume with pointcloud heads.
                    // On the sender side we need to enable "Marie Antoinette mode", where we filter
                    // the pointcloud (immedeately after capture) to contain only the head.
                    // On the receiver side we don't need to do anything.
                    // This will give the correct rendition both for self-view (in the mirrors) and
                    // for other-view.
                    MarieAntoinette.SetActive(true);
                    avatarHeadParis.SetActive(false);
                    avatarHeadLondon.SetActive(false);
                }
                else
                {
                    // We are using the costume with cartoon heads.
                    // Pause the pointcloud pipeline (both sender and receiver) and set the correct head
                    // based on our user name.
                    PointCloudPipelineBase pcPipeline = PointcloudGO?.GetComponent<PointCloudPipelineBase>();
                    pcPipeline?.PausePlayback(true);

                    //move this code here to make the avatar head available in 3d avatar representation
                    if (playerManager.userName == "London")
                    {
                        avatarHeadLondon.SetActive(true);
                        avatarHeadParis.SetActive(false);
                    }
                    else if (playerManager.userName == "Paris")
                    {
                        avatarHeadLondon.SetActive(false);
                        avatarHeadParis.SetActive(true);
                    }
                    else
                    {
                        Debug.LogWarning($"Cannot select avatar head for username {playerManager.userName}");
                    }
                }

            }
            else
            { //rest of the scenes
                MediaScape_extras.SetActive(false);
            }
        }
        else //SPECTATOR
        {   //disable hands and costume

            MediaScape_extras.SetActive(false);
            leftHand?.SetActive(false);
            RightHand?.SetActive(false);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
