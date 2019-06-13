#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.TrackingConfidence
    //
    public enum TrackingConfidence : int
    {
        Low                                      =0,
        High                                     =1,
    }

}
#endif
