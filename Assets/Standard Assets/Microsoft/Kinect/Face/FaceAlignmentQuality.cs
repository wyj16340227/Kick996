#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Microsoft.Kinect.Face
{
    //
    // Microsoft.Kinect.Face.FaceAlignmentQuality
    //
    public enum FaceAlignmentQuality : int
    {
        High                                     =0,
        Low                                      =1,
    }

}
#endif
