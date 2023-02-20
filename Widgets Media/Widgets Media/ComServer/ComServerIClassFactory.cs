using COMServer;
using System;
using System.Runtime.InteropServices;

namespace COMServer;

[ComImport]
[ComVisible(false)]
[Guid(MetodosNativos.IID_IClassFactory)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IClassFactory
{
    [PreserveSig]
    int CreateInstance(IntPtr outer, ref Guid iid, out IntPtr result);

    [PreserveSig]
    int LockServer(bool fLock);
}
