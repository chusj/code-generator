namespace ScopeJudge
{
    interface IScope
    {
        /// <summary>
        /// 小于
        /// </summary>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        bool LessThan(decimal actualValue, decimal conditionValue);

        /// <summary>
        /// 小于等于
        /// </summary>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        bool LessThanOrEqual(decimal actualValue, decimal conditionValue);

        /// <summary>
        /// 大于
        /// </summary>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        bool GreaterThan(decimal actualValue, decimal conditionValue);

        /// <summary>
        /// 大于等于
        /// </summary>
        /// <param name="actualValue">实际值</param>
        /// <param name="conditionValue">条件值</param>
        /// <returns></returns>
        bool GreatThanOrEqual(decimal actualValue, decimal conditionValue);

        /// <summary>
        /// 等于
        /// </summary>
        /// <param name="actualValue"></param>
        /// <param name="conditionValue"></param>
        /// <returns></returns>
        bool Equal(decimal actualValue, decimal conditionValue);

        /// <summary>
        /// 不等于
        /// </summary>
        /// <param name="actualValue"></param>
        /// <param name="conditionValue"></param>
        /// <returns></returns>
        bool NotEqual(decimal actualValue, decimal conditionValue);

        /// <summary>
        /// 范围
        /// </summary>
        /// <param name="actualValue">实际值</param>
        /// <param name="minValue">小值</param>
        /// <param name="maxValue">大值</param>
        /// <returns></returns>
        bool Range(decimal actualValue, decimal minValue, decimal maxValue);

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
    }
}
