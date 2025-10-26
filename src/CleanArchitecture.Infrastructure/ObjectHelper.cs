using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure;
public class ObjectHelper
{
    public static dynamic Extract(dynamic source, params string[] properties)
    {
        var result = new ExpandoObject() as IDictionary<string, object>;
        PropertyInfo[] props = source
            .GetType()
            .GetProperties();

        if (properties.Length == 0)
        {
            // convert all properties names in props to properties
            properties = props
                .Select(x => x.Name)
                .ToArray();
        }

        foreach (var property in properties)
        {
            // get property value from source
            var value = props
                .Where(x => x.Name == property)
                .Select(x => x.GetValue(source))
                .SingleOrDefault();

            result.Add(property, value);
        }

        return result;
    }

    // method to join 2 dynamic objects into 1
    public static void Concat(dynamic addTo, dynamic source)
    {
        if (addTo is not (ExpandoObject and IDictionary<string, object> result))
        {
            throw new Exception("addTo must be ExpandoObject");
        }

        ExtractProperties(source);

        void ExtractProperties(dynamic obj)
        {
            if (obj is ExpandoObject and IDictionary<string, object> sourceProperties)
            {
                foreach (var property in sourceProperties)
                {
                    result.Add(property.Key, property.Value);
                }
            }
            else
            {
                PropertyInfo[] props = obj
                    .GetType()
                    .GetProperties();

                foreach (var property in props)
                {
                    result.Add(property.Name, property.GetValue(obj));
                }
            }
        }
    }

    public static string ToJson(dynamic obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}
