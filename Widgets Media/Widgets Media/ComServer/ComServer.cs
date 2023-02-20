using COMServer;
using System;
using static COMServer.MetodosNativos;

public sealed class ComServer<TInterface, TImplementation>
    where TImplementation : TInterface, new()
{
    private ComServer() { }

    private static ComServer<TInterface, TImplementation> _instance = new ComServer<TInterface, TImplementation>();

    public static ComServer<TInterface, TImplementation> Instance
    {
        get { return _instance; }
    }

    private object syncRoot = new object();

    private bool _bRunning = false;

    public void Run()
    {
        lock (syncRoot) 
        {
            if (_bRunning)
                return;

            _bRunning = true;
        }

        try
        {
            var widget_provider_clsid = Ayudador.GetGuidFromType(typeof(TImplementation));

            int hResult = MetodosNativos.CoRegisterClassObject(
                ref widget_provider_clsid,
                new TypedClassFactory<TInterface, TImplementation>(),
                MetodosNativos.CLSCTX.LOCAL_SERVER,
                MetodosNativos.REGCLS.MULTIPLEUSE,
                out var widgetProviderFactory);

            if (hResult != 0)
            {
                throw new ApplicationException(
                    "CoRegisterClassObject failed w/err 0x" + hResult.ToString("X"));
            }

            IntPtr evt = MetodosNativos.CreateEvent(IntPtr.Zero, true, false, IntPtr.Zero);

            hResult = MetodosNativos.CoWaitForMultipleObjects(
                CWMO_FLAGS.CWMO_DISPATCH_CALLS | CWMO_FLAGS.CWMO_DISPATCH_WINDOW_MESSAGES,
                0xFFFFFFFF, 1, new IntPtr[] { evt }, out uint index
                );

            if (hResult != 0)
            {
                if (widgetProviderFactory != 0)
                {
                    MetodosNativos.CoRevokeClassObject(widgetProviderFactory);
                }
            }

        }
        finally
        {
            lock (syncRoot) // Ensure thread-safe
            {
                _bRunning = false;
            }
        }
    }
}