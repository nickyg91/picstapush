using System;
using System.Linq;

namespace Picstapush.Utilities.MappingHelpers
{
    public static class ObjectMapper
    {
        public static TOut Map<TIn, TOut, TInterface>(TIn from)
        {
            var interfaceProperties = typeof(TInterface).GetProperties();
            var activator = Activator.CreateInstance<TOut>();
            var inProps = from.GetType().GetProperties().ToDictionary(x => x.Name, x => x);

            foreach (var property in interfaceProperties)
            {
                var inProp = inProps[property.Name];
                if (inProp == null)
                {
                    throw new ArgumentException($"Could not map {typeof(TIn).Name} to {typeof(TOut).Name}: Missing property {property.Name}.");
                }
                activator.GetType().GetProperty(inProp.Name).SetValue(activator, inProp.GetValue(from));
            }
            return activator;
        }
    }
}
