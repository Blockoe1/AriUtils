/*****************************************************************************
// File Name : IDSelectorDrawer.cs
// Author : Arcadia Koederitz
// Creation Date : 10/25/2026
// Last Modified : 10/25/2026
//
// Brief Description : Property Drawer that draws a dropdown for selecting an item from a collection and storing 
// it's ID of any type in this property.
*****************************************************************************/
using System;
using UnityEditor;
using UnityEngine;

namespace AriUtils.Editor
{
    [CustomPropertyDrawer(typeof(IDSelectorAttribute))]
    public class IDSelectorDrawer : PropertyDrawer
    {
        private bool initialized;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            GUIContent[] displayedOptions = new GUIContent[5];


            int index = -1; // Get the index from the array of possible IDs.
            if(index == -1) { index = 0; }
            index = EditorGUI.Popup(position, label, index, displayedOptions);


            EditorGUI.EndProperty();
        }
    }
}
