using System;
using System.Runtime.InteropServices;
using WinRT;

namespace COMServer;

internal class TypedClassFactory<TInterface, TImplementation>
    : IClassFactory
    where TImplementation : TInterface, new()
{
    public int CreateInstance(IntPtr outer, ref Guid iid,
        out IntPtr result)
    {
        if (outer != IntPtr.Zero)
        {
            Marshal.ThrowExceptionForHR(MetodosNativos.CLASS_E_NOAGGREGATION);
        }

        result = MarshalInspectable<TInterface>.FromManaged(new TImplementation());

        return 0;   
    }

    public int LockServer(bool fLock)
    {
        return 0;  
    }
}