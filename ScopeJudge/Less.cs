using System;

namespace ScopeJudge
{
    /// <summary>
    /// 小于判断
    /// </summary>
    public  class Less
    {
        /// <summary>
        /// 小于 actualValue ＜ conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        public static bool LessThan<T>(T actualValue, T conditionValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(conditionValue) < 0;
        }

        /// <summary>
        /// 小于等于 actualValue ≤ conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        public static bool LessThanOrEqual<T>(T actualValue, T conditionValue) where T : IComparable<T>
        {
            return actualValue.CompareTo(conditionValue) <= 0;
        }

    }
}
