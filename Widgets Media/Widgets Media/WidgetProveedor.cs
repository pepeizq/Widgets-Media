using System.Runtime.InteropServices;

[Guid("B346D60C-42FC-4D9F-AB57-DC263E64F244")]
public class WidgetProveedor : WidgetProveedorBase
{
    static WidgetProveedor()
    {
        RegistrarWidget<WidgetMedia>("Media");
    }

    public void Test()
    {
        RegistrarWidget<WidgetMedia>("Media");
    }
}