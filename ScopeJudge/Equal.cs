using System;

namespace ScopeJudge
{
    public class Equal
    {
        public static bool Equals(decimal actualValue, decimal conditionValue)
        {
            return actualValue.Equals(conditionValue);
        }

        /// <summary>
        /// 等于
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
        /// 不等于
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
