using System;
using System.ComponentModel;
using System.Reflection;

namespace Sisgtfhka.Enums
{
    public class Enums
    {
        public enum NotificationType
        {
          [Description("Error")]
          error,
          [Description("Exitoso")]
          success,
          [Description("Advertencia")]
          warning,
          [Description("Información")]
          info
        }

        public static string GetEnumDescription(Enum value)
        {
          FieldInfo fi = value.GetType().GetField(value.ToString());

          DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

          if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
          else
            return value.ToString();
        }
  }
}