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
    }
}
