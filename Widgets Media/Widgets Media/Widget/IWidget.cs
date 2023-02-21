using Microsoft.Windows.Widgets.Providers;

public interface IWidget
{
    string? ID { get; }
    string? Estado { get; }

    bool Activado { get; }

    void Activar();
    void Desactivar();
    void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs);
    void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs);
    string CogerPlantilla(string id);
}