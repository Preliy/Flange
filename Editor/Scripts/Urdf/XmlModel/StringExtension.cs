// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System;
using System.Globalization;
using UnityEngine;

namespace Preliy.Flange.Editor.XmlModel
{
    public static class StringExtension
    {
        /// <summary>
        /// Parses a space-delimited "x y z" string into a Vector3, 
        /// using invariant-culture float parsing.
        /// </summary>
        /// <param name="xyz">
        /// A string containing three floats separated by spaces, e.g. "1.0 2.5 -3.2".
        /// </param>
        /// <returns>The corresponding Vector3.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="xyz"/> is null or empty.</exception>
        /// <exception cref="FormatException">If it doesn’t contain exactly three parts or any part isn’t a valid float.</exception>
        public static Vector3 Parse(string xyz)
        {
            if (string.IsNullOrWhiteSpace(xyz))
            {
                throw new ArgumentNullException(nameof(xyz), "Input cannot be null or whitespace.");
            }

            var parts = xyz.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                throw new FormatException($"Expected 3 space-delimited values, got {parts.Length}: \"{xyz}\"");
            }

            try
            {
                var x = float.Parse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture);
                var y = float.Parse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture);
                var z = float.Parse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture);
                return new Vector3(x, y, z);
            }
            catch (FormatException fe)
            {
                throw new FormatException($"Failed to parse one of the floats in \"{xyz}\"", fe);
            }
        }
        
        /// <summary>
        /// Tries to parse a space-delimited "x y z" string into a Vector3.
        /// </summary>
        /// <param name="xyz">Input string.</param>
        /// <param name="result">The parsed Vector3 on success; Vector3.Zero on failure.</param>
        /// <returns>True if parsing succeeded; false otherwise.</returns>
        public static bool TryParse(string xyz, out Vector3 result)
        {
            result = Vector3.zero;

            if (string.IsNullOrWhiteSpace(xyz))
            {
                return false;
            }

            var parts = xyz.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3) return false;

            var okX = float.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float x);
            var okY = float.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float y);
            var okZ = float.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out float z);

            if (okX && okY && okZ)
            {
                result = new Vector3(x, y, z);
                return true;
            }

            return false;
        }
    }
}
