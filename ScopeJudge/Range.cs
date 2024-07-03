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
        public bool IsNotInRange<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(minValue) >= 0 && actualValue.CompareTo(maxValue) <= 0;
        }

        /// <summary>
        /// 是否在范围内(上下包含)  minValue ≤ actualValue ≤maxValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        public bool IsWithInRange<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
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
        public bool IsWithInRange2<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
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
        public bool IsWithInRange3<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
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
        public bool IsWithInRange4<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(minValue) >= 0 && actualValue.CompareTo(maxValue) < 0;
        }
    }
}
