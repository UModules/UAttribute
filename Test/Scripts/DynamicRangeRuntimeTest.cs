using UnityEngine;

namespace UAttribute.Test
{
    public class DynamicRangeRuntimeTest : MonoBehaviour
    {
        [SerializeField] private int min;
        [SerializeField] private int max;
        [Space]
        [SerializeField, DynamicIntRange(nameof(GetMin), nameof(GetMax))] private int value;

        private int GetMin() => min;
        private int GetMax() => max;
    }
}