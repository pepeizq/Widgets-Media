using Microsoft.Windows.Widgets.Providers;
using System.Collections.Generic;
using System;

public class WidgetProveedorBase : IWidgetProvider
{
    private record WidgetCreacionInfo
    (
        string WidgetNombre, Func<WidgetContext, string, IWidget> Factory
    );

    public static T CrearWidget<T>(WidgetContext contexto, string estado)
        where T : WidgetBase, new()
    {
        string widgetId = contexto.Id;
        T nuevoWidget = new T() { ID = widgetId, Estado = estado };

        WidgetUpdateRequestOptions actualizarOpciones = new WidgetUpdateRequestOptions(widgetId)
        {
            Template = nuevoWidget.CogerPlantilla(widgetId),
            CustomState = nuevoWidget.Estado
        };

        WidgetManager.GetDefault().UpdateWidget(actualizarOpciones);
        return nuevoWidget;
    }

    static IDictionary<string, WidgetCreacionInfo> _widgetRegistro = new Dictionary<string, WidgetCreacionInfo>();

    public static void RegistrarWidget<TWidget>(string widgetNombre)
        where TWidget : WidgetBase, new()
    {
        _widgetRegistro[widgetNombre] = new WidgetCreacionInfo(widgetNombre, (contexto, estado) => CrearWidget<TWidget>(contexto, estado));
    }

    IDictionary<string, IWidget> _widgetsFuncionando = new Dictionary<string, IWidget>();

    protected WidgetProveedorBase()
    {
        RecoverRunningWidgets();
    }

    public IWidget InitializeWidgetInternal(WidgetContext contexto, string estado)
    {
        string widgetNombre = contexto.DefinitionId;
        string widgetId = contexto.Id;

        if (_widgetRegistro.TryGetValue(widgetNombre, out var creation))
        {
            IWidget widgetImpl = creation.Factory(contexto, estado);
            _widgetsFuncionando[widgetId] = widgetImpl;
            return widgetImpl;
        }

        return default;
    }

    public IWidget FindRunningWidget(string widgetId)
    {
        return _widgetsFuncionando.TryGetValue(widgetId, out var widget) ? widget : default;
    }

    public void CreateWidget(WidgetContext widgetContext)
    {
        _ = InitializeWidgetInternal(widgetContext, "");
    }

    public void DeleteWidget(string widgetId, string customState)
    {
        _widgetsFuncionando.Remove(widgetId);
    }

    public void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs)
    {
        var widgetId = actionInvokedArgs.WidgetContext.Id;
        if (FindRunningWidget(widgetId) is { } runningWidget)
        {
            runningWidget.OnActionInvoked(actionInvokedArgs);
        }
    }

    public void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs)
    {
        var widgetContext = contextChangedArgs.WidgetContext;
        var widgetId = widgetContext.Id;

        if (FindRunningWidget(widgetId) is { } runningWidget)
        {
            runningWidget.OnWidgetContextChanged(contextChangedArgs);
        }
    }

    public void Activate(WidgetContext contexto)
    {
        var widgetId = contexto.Id;
        if (FindRunningWidget(widgetId) is { } widgetFuncionando)
        {
            widgetFuncionando.Activar();
        }
    }

    public void Deactivate(string widgetId)
    {
        if (FindRunningWidget(widgetId) is { } widgetFuncionando)
        {
            widgetFuncionando.Desactivar();
        }
    }

    void RecoverRunningWidgets()
    {
        try
        {
            WidgetManager widgetManager = WidgetManager.GetDefault();

            if (widgetManager != null) 
            {
                if (widgetManager.GetWidgetInfos() != null)
                {
                    foreach (WidgetInfo widgetInfo in widgetManager.GetWidgetInfos())
                    {
                        var widgetContext = widgetInfo.WidgetContext;
                        var widgetId = widgetContext.Id;
                        var customState = widgetInfo.CustomState;

                        if (FindRunningWidget(widgetId) is null)
                        {
                            InitializeWidgetInternal(widgetContext, customState);
                        }
                    }
                }                   
            }          
        }
        catch
        {

        }
    }
}