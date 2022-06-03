using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace DtcStatusVisualizer.Utility
{
    public static class EnumerationManager
    {
        public static Dictionary<Enum, string> GetValues(Type enumeration)
        {
            Array wArray = Enum.GetValues(enumeration);

            Dictionary<Enum, string> wFinalArray = new Dictionary<Enum, string>();

            foreach (Enum? wValue in wArray)
            {
                if (null != wValue)
                {
                    FieldInfo? fi = enumeration?.GetField(wValue.ToString());
                    if (null != fi)
                    {
                        if (fi.GetCustomAttributes(typeof(BrowsableAttribute), true) is BrowsableAttribute[] wBrowsableAttributes && wBrowsableAttributes.Length > 0)
                        {
                            //  If the Browsable attribute is false
                            if (wBrowsableAttributes[0].Browsable == false)
                            {
                                // Do not add the enumeration to the list.
                                continue;
                            }
                        }

                        if (fi.GetCustomAttributes(typeof(DescriptionAttribute), true) is DescriptionAttribute[] wDescriptions && wDescriptions.Length > 0)
                        {
                            wFinalArray.Add((Enum)Enum.Parse(enumeration!, fi.Name), wDescriptions[0].Description);
                        }
                        else
                            wFinalArray.Add((Enum)Enum.Parse(enumeration!, fi.Name), wValue.ToString());
                    }
                }
            }

            return wFinalArray;
        }
    }
}
