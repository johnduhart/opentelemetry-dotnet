﻿// <copyright file="AttributesExtensions.cs" company="OpenTelemetry Authors">
// Copyright 2018, OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System.Collections.Generic;
using Xunit;

namespace OpenTelemetry.Tests
{
    using System.Linq;
    using OpenTelemetry.Trace.Export;

    internal static class AttributesExtensions
    {
        public static object GetValue(this Attributes attributes, string key)
        {
            return attributes.AttributeMap.FirstOrDefault(kvp => kvp.Key == key).Value;
        }

        public static void AssertAreSame(this Attributes attributes,
            IEnumerable<KeyValuePair<string, object>> expectedAttributes)
        {
            var keyValuePairs = expectedAttributes as KeyValuePair<string, object>[] ?? expectedAttributes.ToArray();
            Assert.Equal(attributes.AttributeMap.Count(), keyValuePairs.Count());

            foreach (var attr in attributes.AttributeMap)
            {
                Assert.Contains(attr, keyValuePairs);
            }
        }
    }
}
