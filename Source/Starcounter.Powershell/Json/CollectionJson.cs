// Copyright (c) 2015 The Starcounter.Powershell authors.
// Use of this source code is governed by the MIT license.
// See the LICENSE file for more information.

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Starcounter.Powershell.Json
{
    /// <summary>
    /// Represents a generic collection of items returned from the administrator API.
    /// By convention, it is an object that wraps a list called "Items".
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    [DataContract]
    class CollectionJson<T>
    {
        [DataMember]
        public List<T> Items { get; set; }
    }
}
