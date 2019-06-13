#if !(UNITY_WSA_10_0 && NETFX_CORE)
using UnityEditor;
using UnityEditor.Callbacks;
using System;

public static class KinectFacePostBuildCopyPluginData
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget target, string path)
    {
        KinectCopyPluginDataHelper.CopyPluginData (target, path, "NuiDatabase");
    }
}
#endif
