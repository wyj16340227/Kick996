#if !(UNITY_WSA_10_0 && NETFX_CORE)
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace Helper
{
    internal interface INativeWrapper
    {
        System.IntPtr nativePtr { get; }
    }
}
#endif
