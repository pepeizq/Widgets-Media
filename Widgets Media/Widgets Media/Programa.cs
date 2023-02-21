using Microsoft.UI.Dispatching;
using Microsoft.Windows.Widgets.Providers;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using Widgets_Media;
using Microsoft.UI.Xaml;

public class Programa
{
    [STAThread]
    static async Task Main(string[] args)
    {
        WinRT.ComWrappersSupport.InitializeComWrappers();

        if (args?.Any(x => x.Contains("RegisterProcessAsComServer")) ?? false)
        {
            ComServer<IWidgetProvider, WidgetProveedor>.Instance.Run();
        }
        else
        {
            try
            {
                Application.Start((p) =>
                {
                    DispatcherQueueSynchronizationContext contexto = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
                    SynchronizationContext.SetSynchronizationContext(contexto);
                    new App();
                });
            }
            catch { }
        }
    }

}
