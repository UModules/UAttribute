using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UAttribute
{
    [CustomPropertyDrawer(typeof(DynamicIntRangeAttribute))]
    public class DynamicIntRangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            DynamicIntRangeAttribute range = (DynamicIntRangeAttribute)attribute;
            int min = range.MinValue;
            int max = range.MaxValue;

            var targetObject = property.serializedObject.targetObject;

            if (range.IsDynamic)
            {
                if (!string.IsNullOrEmpty(range.MinMethodName))
                {
                    min = GetDynamicValue(targetObject, range.MinMethodName);
                }
                if (!string.IsNullOrEmpty(range.MaxMethodName))
                {
                    max = GetDynamicValue(targetObject, range.MaxMethodName);
                }

                // Ensure min and max are in the correct order
                if (min > max)
                {
                    int temp = min;
                    min = max;
                    max = temp;
                }
            }

            if (property.propertyType == SerializedPropertyType.Integer)
            {
                property.intValue = EditorGUI.IntSlider(position, label, property.intValue, min, max);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use DynamicIntRange with int.");
            }
        }

        private int GetDynamicValue(object targetObject, string methodName)
        {
            MethodInfo method = targetObject.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (method != null)
            {
                return (int)method.Invoke(targetObject, null);
            }

            Debug.LogError($"Method {methodName} not found on {targetObject.GetType().Name}");
            return 0;
        }
    }
}
