using System;

namespace ScopeJudge
{
    /// <summary>
    /// 等于/不等于判断
    /// </summary>
    public class Equal
    {
        /// <summary>
        /// 等于 actualValue = conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue"></param>
        /// <param name="conditionValue"></param>
        /// <returns></returns>
        public static bool Equals<T>(T actualValue, T conditionValue) where T : IEquatable<T>
        {
            return actualValue.Equals(conditionValue);
        }

        /// <summary>
        /// 不等于 actualValue != conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue"></param>
        /// <param name="conditionValue"></param>
        /// <returns></returns>
        public static bool NotEquals<T>(T actualValue, T conditionValue) where T : IEquatable<T>
        {
            return !actualValue.Equals(conditionValue);
        }
    }
}
