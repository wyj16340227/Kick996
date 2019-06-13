#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.FrameCapturedStatus
    //
    public enum FrameCapturedStatus : int
    {
        Unknown                                  =0,
        Queued                                   =1,
        Dropped                                  =2,
    }

}
#endif
