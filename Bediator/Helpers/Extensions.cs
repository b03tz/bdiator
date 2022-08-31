using System;

namespace Bediator.Helpers
{
    public static class Extensions
    {
        public static bool IsAssignableTo(this Type type, Type assignableType)
            => assignableType.IsAssignableFrom(type);
    }
}