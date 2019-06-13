#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBeamMode
    //
    public enum AudioBeamMode : int
    {
        Automatic                                =0,
        Manual                                   =1,
    }

}
#endif
