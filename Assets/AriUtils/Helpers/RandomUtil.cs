/*****************************************************************************
// File Name : Helpers.cs
// Author : Arcadia Koederitz
// Creation Date : May 27, 2025
//
// Brief Description : Set of static helper functions that have common utility across multiple projects.
*****************************************************************************/
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace AriUtils
{
    public static class RandomUtil
    {
        /// <summary>
        /// Generates a random true/false outcome based on a given percentage chance.
        /// </summary>
        /// <param name="chance">The percentage chance of a true.  Int value between 0 and 100.</param>
        /// <returns>True if the roll was successful, false if not.</returns>
        public static bool PercentageChance(int chance)
        {
            return chance > Random.Range(0, 100);
        }

        /// <summary>
        /// Sets the alpha value of a color.
        /// </summary>
        /// <param name="color">The color to modify.</param>
        /// <param name="alpha">The alpha value to set.</param>
        public static Color SetAlpha(this Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }

        /// <summary>
        /// Converts a bool to an int value, either 1 or 0.
        /// </summary>
        /// <remarks>
        /// Useful for saving boolean values if bool values are not supported (like with PlayerPrefs)
        /// </remarks>
        /// <param name="value">The boolean value to convert to an integer.</param>
        /// <returns>1 if true, 0 if false.</returns>
        public static int ToInt(bool value)
        {
            return value ? 1 : 0;
        }
    }

}