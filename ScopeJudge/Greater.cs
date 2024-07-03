using System;

namespace ScopeJudge
{
    /// <summary>
    /// 大于判断
    /// </summary>
    internal class Greater
    {
        /// <summary>
        /// 大于 actualValue ＞ conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        public static bool GreaterThan<T>(T actualValue, T conditionValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(conditionValue) > 0;
        }

        /// <summary>
        /// 大于等于 actualValue ≥ conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        public static bool GreatThanOrEqual<T>(T actualValue, T conditionValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(conditionValue) >= 0;
        }

        /// <summary>
        /// 大于 actualValue ＞ conditionValue * multiple
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="maxValue">大值</param>
        /// <param name="multiple">倍数</param>
        /// <returns></returns>
        public static bool GreaterThan<T>(T actualValue, T maxValue,int multiple) where T : struct, IComparable<T>
        {
            return actualValue.CompareTo(Multiple(maxValue,multiple)) > 0;
        }

        /// <summary>
        /// 大于等于 actualValue ≥ conditionValue * multiple
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="maxValue">条件值</param>
        /// <param name="multiple">倍数</param>
        /// <returns></returns>
        public static bool GreatThanOrEqual<T>(T actualValue, T maxValue, int multiple) where T : struct, IComparable<T>
        {
            return actualValue.CompareTo(Multiple(maxValue, multiple)) > 0;
        }

        private static T Multiple<T>(T value, int multiplier) where T : struct, IComparable<T>
        {
            // 使用dynamic来避免编译时类型检查，允许运行时类型转换和操作
            dynamic dynValue = value;

            // 根据类型进行不同的操作
            switch (dynValue)
            {
                case int intValue:
                    return (T)(object)(intValue * multiplier);
                case double doubleValue:
                    return (T)(object)(doubleValue * multiplier);
                case decimal decimalValue:
                    return (T)(object)(decimalValue * multiplier);
                case float floatValue:
                    return (T)(object)(floatValue * multiplier);
                default:
                    throw new InvalidOperationException("Multiple method is not supported for type " + typeof(T).Name);
            }
        }
    }
}
