// Copyright 2016 Tom Deseyn <tom.deseyn@gmail.com>
// This software is made available under the MIT License
// See COPYING for details

using System;

namespace Tmds.DBus
{
    /// <summary>
    /// The mutability of a property
    /// </summary>
    [Flags]
    public enum PropertyAccess
    {
        /// <summary>
        /// Allows the property to only be read
        /// </summary>
        Read = 0x01,
        /// <summary>
        /// Allows the property to only be written to
        /// </summary>
        Write = 0x02,
        /// <summary>
        /// Allows the property to be read and written
        /// </summary>
        ReadWrite = 0x03,
    }
}
