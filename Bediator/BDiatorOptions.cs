﻿using System.Reflection;

namespace Bediator
{
    public class BDiatorOptions
    {
        public Assembly[] HandlerAssemblies { get; init; } = new Assembly[] {};
    }
}