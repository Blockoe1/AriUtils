/*****************************************************************************
// File Name : SerializeInterfaceDrawer.cs
// Author : Arcadia Koederitz
// Creation Date : 10/04/2026
// Last Modified : 10/04/2026
//
// Brief Description : Property Drawer that handles displaying options for serialzied interfaces.
*****************************************************************************/
using UnityEditor;
using UnityEngine;

namespace AriUtils.Editor
{
    [CustomPropertyDrawer(typeof(SerializedInterface<>))]
    public class SerializeInterfaceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //Debug.Log("GUI");
            EditorGUI.BeginProperty(position, label, property);
            SerializedProperty _referenceType = property.FindPropertyRelative(nameof(_referenceType));

            position = EditorGUI.PrefixLabel(position, label);

            Rect typeToggleRect = position;
            typeToggleRect.xMax = typeToggleRect.xMin + typeToggleRect.height;
            _referenceType.boolValue = EditorGUI.Toggle(typeToggleRect, _referenceType.boolValue);

            position.xMin += typeToggleRect.width + EditorGUIUtility.standardVerticalSpacing;

            if (_referenceType.boolValue)
            {
                // Handle Managed Property type.
                DrawClassDropdown(position, property, label);
            }
            else
            {
                // Handle Object property type.
                DrawUnityObjectField(position, property, label);
            }
            EditorGUI.EndProperty();
        }

        #region Unity Object Field
        private void DrawUnityObjectField(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedInterface intFace = property.boxedValue as SerializedInterface;
            SerializedProperty _objectReferenceValue = property.FindPropertyRelative(nameof(_objectReferenceValue));
            _objectReferenceValue.objectReferenceValue = EditorGUI.ObjectField(position, _objectReferenceValue.objectReferenceValue, intFace.InterfaceType, true);
        }
        #endregion

        #region ClassField
        private void DrawClassDropdown(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty _managedReferenceValue = property.FindPropertyRelative(nameof(_managedReferenceValue));
        }
        #endregion

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty _referenceType = property.FindPropertyRelative(nameof(_referenceType));
            if (_referenceType.boolValue)
            {
                // Handle Managed Property type.
                return base.GetPropertyHeight(property, label);
            }
            else
            {
                return base.GetPropertyHeight(property, label);
            }
        }
    }
}