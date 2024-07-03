using System;

namespace ScopeJudge
{
    /// <summary>
    /// 范围判断
    /// </summary>
    public class Range
    {
        /// <summary>
        /// 是否不在范围内  actualValue ＜ minValue 或者 actualValue ＞ maxValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        public static bool IsNotInRange<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(maxValue) > 0 || actualValue.CompareTo(minValue) < 0;
        }

        /// <summary>
        /// 是否在范围内(上下包含)  minValue ≤ actualValue ≤maxValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        public static bool IsInRange<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(minValue) >= 0 && actualValue.CompareTo(maxValue) <= 0;
        }

        /// <summary>
        /// 是否在范围内(上下不包含)  minValue ＜ actualValue ＜ maxValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        public static bool IsInRange2<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(minValue) > 0 && actualValue.CompareTo(maxValue) < 0;
        }

        /// <summary>
        /// 是否在范围内(下包含)  minValue ≤ actualValue ＜ maxValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        public static bool IsInRange3<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(minValue) > 0 && actualValue.CompareTo(maxValue) <= 0;
        }

        /// <summary>
        /// 是否在范围内(上包含)  minValue ＜ actualValue ≤ maxValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        public static bool IsInRange4<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(minValue) >= 0 && actualValue.CompareTo(maxValue) < 0;
        }
    }
}
