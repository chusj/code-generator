using System;

namespace ScopeJudge
{
    public class Scope : IScope
    {
        public bool Equals<T>(T actualValue, T conditionValue) where T : IEquatable<T>
        {
            return Equal.Equals(actualValue, conditionValue);
        }

        public bool GreaterThan<T>(T actualValue, T conditionValue) where T : IComparable<T>
        {
            return Greater.GreaterThan(actualValue, conditionValue);
        }

        public bool GreatThanOrEqual<T>(T actualValue, T conditionValue) where T : IComparable<T>
        {
            return Greater.GreatThanOrEqual(actualValue, conditionValue);
        }

        public bool IsInRange<T>(T actualValue, T minValue, T maxValue, int rangeType = 1) where T : IComparable<T>
        {
            if (rangeType == 2)
            {
                return Range.IsInRange2(actualValue, minValue, maxValue);
            }
            else if (rangeType == 3)
            {
                return Range.IsInRange3(actualValue, minValue, maxValue);
            }
            else if (rangeType == 4)
            {
                return Range.IsInRange4(actualValue, minValue, maxValue);
            }
            else //if (rangeType == 1)
            {
                return Range.IsInRange(actualValue, minValue, maxValue);
            }
        }

        public bool IsNotInRange<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
        {
            return Range.IsNotInRange(actualValue, minValue, maxValue);
        }

        public bool LessThan<T>(T actualValue, T conditionValue) where T : IComparable<T>
        {
            return Less.LessThan(actualValue, conditionValue);
        }

        public bool LessThanOrEqual<T>(T actualValue, T conditionValue) where T : IComparable<T>
        {
            return Less.LessThanOrEqual(actualValue, conditionValue);
        }

        public bool NotEquals<T>(T actualValue, T conditionValue) where T : IEquatable<T>
        {
            return Equal.NotEquals(actualValue, conditionValue);
        }
    }
}
