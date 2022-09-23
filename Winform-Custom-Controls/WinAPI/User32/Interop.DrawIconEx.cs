// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        public enum DI : uint
        {
            MASK        = 0x0001,
            IMAGE       = 0x0002,
            NORMAL      = 0x0003,
            COMPAT      = 0x0004,
            DEFAULTSIZE = 0x0008,
            NOMIRROR    = 0x0010
        }
    }
}
