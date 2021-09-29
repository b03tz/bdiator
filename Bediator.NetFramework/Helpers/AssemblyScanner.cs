using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;

namespace Bediator.Helpers
{
    public class AssemblyScanner
    {
        public Dictionary<Type, List<Type>> GetHandlers<THandlerType, TMessageType>(Assembly[]? assemblies = null)
        {
            var handlerDictionary = new Dictionary<Type, List<Type>>();
            var messageType = typeof(TMessageType);

            var assembliesToScan = AppDomain.CurrentDomain.GetAssemblies();
            if (assemblies != null && assemblies.Length > 0)
            {
                assembliesToScan = assemblies;
            }

            foreach (Assembly a in assembliesToScan
                .Where(a => (!a.FullName?.StartsWith("System") ?? false) &&
                            (!a.FullName?.StartsWith("Microsoft") ?? false) &&
                            (!a.FullName?.StartsWith("mscorlib") ?? false)))
            {
                foreach (var handleAssemblyType in this.HandleAssemblyTypes(a.GetTypes(), messageType,
                    typeof(THandlerType)))
                {
                    handlerDictionary.Add(handleAssemblyType.Key, handleAssemblyType.Value);
                }
            }

            return handlerDictionary;
        }

        private Dictionary<Type, List<Type>> HandleAssemblyTypes(IEnumerable<Type> types, Type messageType,
            Type handlerType)
        {
            var handlerDictionary = new Dictionary<Type, List<Type>>();
            var handlerInterfaceName = handlerType.Name;

            if (messageType == null)
                throw new Exception("Message type cannot be null");

            foreach (Type type in types)
            {
                if (type.IsInterface)
                    continue;

                if (!type.GetInterfaces().Any())
                    continue;

                var interfaces = type.GetInterfaces();

                foreach (var typeInterface in interfaces)
                {
                    var interfaceName = type.GetInterfaces()[0].Name;

                    if (handlerInterfaceName != interfaceName)
                    {
                        continue;
                    }

                    var arguments = typeInterface.GetGenericArguments();

                    if (!arguments.Any())
                        continue;

                    if (!arguments[0].GetInterfaces().Any(messageType.IsAssignableFrom) && arguments[0].BaseType != messageType)
                        continue;

                    if (!handlerDictionary.ContainsKey(arguments[0]))
                        handlerDictionary[arguments[0]] = new List<Type>();

                    handlerDictionary[arguments[0]].Add(type);
                }
            }

            return handlerDictionary;
        }
    }
}