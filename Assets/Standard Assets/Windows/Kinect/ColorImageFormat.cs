#if !(UNITY_WSA_10_0 && NETFX_CORE)
using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.ColorImageFormat
    //
    public enum ColorImageFormat : int
    {
        None                                     =0,
        Rgba                                     =1,
        Yuv                                      =2,
        Bgra                                     =3,
        Bayer                                    =4,
        Yuy2                                     =5,
    }

}
#endif
