namespace Fortaggle.Models.Item
{
    /// <summary>
    /// Itemの状態
    /// </summary>
    public enum ItemStatus
    {
        /// <summary>
        /// 未所持
        /// </summary>
        None,
        /// <summary>
        /// 未着手(所持)
        /// </summary>
        Posession,
        /// <summary>
        /// 進行中
        /// </summary>
        Active,
        /// <summary>
        /// 完了済
        /// </summary>
        Finish
    }
}
