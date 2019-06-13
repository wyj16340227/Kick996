#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.Appearance
    //
    public enum Appearance : int
    {
        WearingGlasses                           =0,
    }

}
#endif
