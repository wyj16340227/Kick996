#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.GestureType
    //
    public enum GestureType : int
    {
        None                                     =0,
        Discrete                                 =1,
        Continuous                               =2,
    }

}
#endif
