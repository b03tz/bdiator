﻿using System.Reflection;

namespace Bediator
{
    public class BDiatorOptions
    {
        public Assembly[] HandlerAssemblies { get; set; } = new Assembly[] {};
        public HandlerNotFoundAction HandlerNotFoundAction { get; set; } = HandlerNotFoundAction.ThrowException;
    }

    public enum HandlerNotFoundAction
    {
        Ignore,
        ThrowException
    }
}