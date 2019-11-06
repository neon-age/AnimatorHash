using UnityEditor;
using UnityEngine;

namespace Neonagee.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(AnimatorHash))]
    public class AnimatorHashDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var propertyName = property.FindPropertyRelative("property");
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();
            propertyName.stringValue = EditorGUI.TextField(position, label, propertyName.stringValue);
            if (EditorGUI.EndChangeCheck())
            {
                property.FindPropertyRelative("hash").intValue = Animator.StringToHash(propertyName.stringValue);
            }
            EditorGUI.EndProperty();
        }
    }
}
