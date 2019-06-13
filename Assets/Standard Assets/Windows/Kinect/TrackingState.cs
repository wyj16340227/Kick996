#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.TrackingState
    //
    public enum TrackingState : int
    {
        NotTracked                               =0,
        Inferred                                 =1,
        Tracked                                  =2,
    }

}
#endif
