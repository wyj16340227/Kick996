#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.Expression
    //
    public enum Expression : int
    {
        Neutral                                  =0,
        Happy                                    =1,
    }

}
#endif
