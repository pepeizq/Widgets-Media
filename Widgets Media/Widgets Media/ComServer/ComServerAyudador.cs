using System;
using System.Runtime.InteropServices;

namespace COMServer;

internal static class Ayudador
{
    public static Guid GetGuidFromType(Type t)
    {
        if (t == null)
            throw new ArgumentNullException("Type object cannot be null.", "t");

        object[] attributes = t.GetCustomAttributes(typeof(GuidAttribute), false);

        if (attributes.Length < 1)
            throw new ArgumentException("No GUID attribute specified on the type " + t.Name);

        GuidAttribute attr = (GuidAttribute)attributes[0];
        return new Guid(attr.Value);
    }

}