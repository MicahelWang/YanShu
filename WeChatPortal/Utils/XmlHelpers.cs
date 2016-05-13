using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WeChatPortal.Utils
{
    public static class XmlHelpers
    {
        private static readonly Type[] WriteTypes =
        {
            typeof (string),
            typeof (Enum),
            typeof (DateTime),
            typeof (DateTime?),
            typeof (DateTimeOffset),
            typeof (DateTimeOffset?),
            typeof (int),
            typeof (int?),
            typeof (decimal),
            typeof (decimal?),
            typeof (Guid),
            typeof (Guid?)
        };

        public static bool IsSimpleType(this Type type)
        {
            return type.IsPrimitive || WriteTypes.Contains(type);
        }

        public static object ToXml(this object input, bool allowNull = false)
        {
            if (input==null)
            {
                return null;
            }
            var type = input.GetType();
            var rootName = type.GetTypeName("xml");
            return input.ToXml(allowNull, rootName);
        }

        public static object ToXml(this object input, bool allowNull, string elementName, string childName = "item")
        {
            elementName = XmlConvert.EncodeName(elementName);
            if (input != null)
            {
                var type = input.GetType();
                if (input is IEnumerable && !type.IsSimpleType())
                {
                    object elements;
                    if (input is IEnumerable<object>)
                    {
                        elements = (input as IEnumerable<object>)
                            .Select(m => m.ToXml(allowNull, childName))
                            .ToArray();
                    }
                    else if (input is Array)
                    {
                        elements = (from object item in (input as Array)
                                    select CreateElement(item.GetType(), childName, item))
                                    .ToArray();
                    }
                    else
                    {
                        elements = null;
                    }
                    var root = new XElement(elementName);
                    root.Add(elements);
                    return root;
                }
                else
                {
                    var ret = new XElement(elementName);
                    var props = type.GetProperties();
                    var elements = from prop in props
                                   let name = XmlConvert.EncodeName(prop.Name)
                                   let val = prop.GetValue(input, null)
                                   let value = prop.PropertyType.IsSimpleType()
                                       ? CreateElement(prop.PropertyType, name, val)
                                       : val.ToXml(allowNull, prop.GetElementName(name),
                                       prop.GetElementItemName(name))
                                   where value != null
                                   select value;

                    ret.Add(elements);
                    return ret;
                }
            }
            if (allowNull)
            {
                return new XElement(elementName); ;
            }
            return null;
        }



        private static XElement CreateElement(Type type, string name, object value)
        {
            if (type == typeof(string))
            {
                XCData content = new XCData(value.ToString());
                return new XElement(name, content);
            }
            return new XElement(name, value);
        }


        private static string GetElementItemName(this PropertyInfo type, string name)
        {
            var attribute = type.GetCustomAttributes<XmlArrayItemAttribute>().FirstOrDefault();
            return attribute == null ? name : attribute.ElementName;
        }

        private static string GetElementName(this PropertyInfo type, string name)
        {
            var attribute = type.GetCustomAttributes<XmlElementAttribute>().FirstOrDefault();
            return attribute == null ? name : attribute.ElementName;
        }

        private static string GetTypeName(this Type type, string name)
        {
            var attribute = type.GetCustomAttributes<XmlRootAttribute>().FirstOrDefault();
            return attribute == null ? name : attribute.ElementName;
        }
    }
}