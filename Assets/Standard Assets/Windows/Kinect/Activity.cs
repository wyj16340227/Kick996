#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.Activity
    //
    public enum Activity : int
    {
        EyeLeftClosed                            =0,
        EyeRightClosed                           =1,
        MouthOpen                                =2,
        MouthMoved                               =3,
        LookingAway                              =4,
    }

}
#endif
