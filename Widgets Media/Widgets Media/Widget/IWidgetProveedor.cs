using Microsoft.Windows.Widgets.Providers;

public interface IWidgetProveedor
{
    void CrearWidget(WidgetContext contexto);

    void BorrarWidget(string id, string estado);

    void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs);

    void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs);

    void Activar(WidgetContext contexto);

    void Desactivar(string id);
}
