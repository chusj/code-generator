using System;

namespace ScopeJudge
{
    interface IScope
    {
        /// <summary>
        /// 等于 actualValue = conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue"></param>
        /// <param name="conditionValue"></param>
        /// <returns></returns>
        bool Equals<T>(T actualValue, T conditionValue) where T : IEquatable<T>;

        /// <summary>
        /// 不等于 actualValue != conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue"></param>
        /// <param name="conditionValue"></param>
        /// <returns></returns>
        bool NotEquals<T>(T actualValue, T conditionValue) where T : IEquatable<T>;

        /// <summary>
        /// 大于 actualValue ＞ conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        bool GreaterThan<T>(T actualValue, T conditionValue) where T : IComparable<T>;

        /// <summary>
        /// 大于 actualValue ＞ maxValue * 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="maxValue">条件值</param>
        /// <param name="multiple">倍数</param>
        /// <returns></returns>
        bool GreaterThan<T>(T actualValue, T maxValue,int multiple) where T : struct, IComparable<T>;

        /// <summary>
        /// 大于等于 actualValue ≥ conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        bool GreatThanOrEqual<T>(T actualValue, T conditionValue) where T : IComparable<T>;

        /// <summary>
        /// 小于 actualValue ＜ conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        bool LessThan<T>(T actualValue, T conditionValue) where T : IComparable<T>;

        /// <summary>
        /// 小于等于 actualValue ≤ conditionValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        bool LessThanOrEqual<T>(T actualValue, T conditionValue) where T : IComparable<T>;

        /// <summary>
        /// 是否不在范围内  actualValue ＜ minValue 或者 actualValue ＞ maxValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        bool IsNotInRange<T>(T actualValue, T minValue, T maxValue) where T : IComparable<T>;

        /// <summary>
        /// 是否在范围内(上下包含)  minValue ≤ actualValue ≤maxValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actualValue">实际值</param>
        /// <param name="rangeType">范围类型 1.大小值都包含(默认情况) 2.大小值都不包含 3.包含小值 4.包含大值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        bool IsInRange<T>(T actualValue, T minValue, T maxValue, int rangeType = 1) where T : IComparable<T>;

        /* 文字类包含业务不提取公共方法
        
        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="content"></param>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        bool Contain(string content, string keyWords);

        /// <summary>
        /// 不包含
        /// </summary>
        /// <param name="content"></param>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        bool NotContain(string content, string keyWords);

        */
    }
}
