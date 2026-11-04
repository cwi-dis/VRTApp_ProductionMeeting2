using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Workaround: in built players (not in the Editor) the project-wide Input Actions
/// (VR2GatherInputActions) are not enabled, so the HUD show/hide action, locomotion,
/// snap turn etc. never fire. This enables them once, before the first scene loads.
///
/// Workaround tracked in cwi-dis/VRTApp_ProductionMeeting2#27, blocked on cwi-dis/VR2Gather#389:
/// remove this file when the app is on a VR2Gather release with the fix for #389.
/// </summary>
public static class EnableProjectWideInputActions
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Enable()
    {
        var actions = InputSystem.actions;
        if (actions == null)
        {
            Debug.LogWarning("EnableProjectWideInputActions: no project-wide Input Actions asset");
            return;
        }
        if (!actions.enabled)
        {
            Debug.Log($"EnableProjectWideInputActions: enabling {actions.name} (workaround, was not enabled)");
            actions.Enable();
        }
    }
}
