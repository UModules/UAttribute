using UnityEngine;

namespace UAttribute
{
    public class DynamicIntRangeAttribute : PropertyAttribute
    {
        public string MinMethodName { get; private set; }
        public string MaxMethodName { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public bool IsDynamic { get; private set; }

        // Constructor for dynamic range using method names
        public DynamicIntRangeAttribute(string minMethodName, string maxMethodName)
        {
            MinMethodName = minMethodName;
            MaxMethodName = maxMethodName;
            IsDynamic = true;
        }

        // Constructor for static range using direct values
        public DynamicIntRangeAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            IsDynamic = false;
        }

        // Constructor for mixed range using method name and direct value
        public DynamicIntRangeAttribute(string minMethodName, int maxValue)
        {
            MinMethodName = minMethodName;
            MaxValue = maxValue;
            IsDynamic = true;
        }

        // Constructor for mixed range using direct value and method name
        public DynamicIntRangeAttribute(int minValue, string maxMethodName)
        {
            MinValue = minValue;
            MaxMethodName = maxMethodName;
            IsDynamic = true;
        }
    }
}
