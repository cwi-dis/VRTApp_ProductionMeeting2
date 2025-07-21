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
