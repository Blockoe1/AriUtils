/*****************************************************************************
// File Name : EditorUtils.cs
// Author : Arcadia Koederitz
// Creation Date : 10/04/2026
// Last Modified : 10/04/2026
//
// Brief Description : Set of common editor utility functions.
*****************************************************************************/
using System;
using UnityEditor;
using UnityEngine;

namespace AriUtils.Editor
{
    public static class EditorUtils
    {
        /// <summary>
        /// Checks if two types are the same or if they are subclasses of each other.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool IsClassOrSubclass(Type t1, Type t2)
        {
            return t1 == t2 || t1.IsSubclassOf(t2) || t2.IsSubclassOf(t1);
        }


        /// <summary>
        /// Loops through the child properties in a given SerializedProperty and calls a propertyFunc on 
        /// copies of the property.
        /// </summary>
        /// <param name="propertyFunc">The function to call on copies of the base property's children.</param>
        /// <param name="baseProperty">The base property to run the function on the children of.</param>
        public static void LoopForProperties(Action<SerializedProperty> propertyFunc, SerializedProperty baseProperty)
        {
            // Not sure why we need to copy the property.
            SerializedProperty copy = baseProperty.Copy();
            SerializedProperty end = copy.GetEndProperty();

            // Tracks if the loop should enter child properties. Only need to enter children the first loop, as
            // further children will be drawn automatically.
            bool enterChildren = true;
            // Loop over all the properties in the copy until we hit the end property.
            while (copy.NextVisible(enterChildren) && !SerializedProperty.EqualContents(copy, end))
            {
                //Skip the default m_Script property
                if (copy.name.Equals("m_Script", StringComparison.Ordinal))
                {
                    enterChildren = false;
                    continue;
                }

                propertyFunc(copy);

                enterChildren = false;
            }
        }
    }
}
