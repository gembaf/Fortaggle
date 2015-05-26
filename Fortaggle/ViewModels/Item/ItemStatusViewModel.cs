namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.Generic;

    public class ItemStatusViewModel : ViewModelBase
    {
        //--- 定数

        private static readonly Dictionary<ItemStatus, string> statusLabelMap = new Dictionary<ItemStatus, string>()
        {
            {ItemStatus.None, "未所持"},
            {ItemStatus.Posession, "未着手"},
            {ItemStatus.Active, "進行中"},
            {ItemStatus.Finish, "完了済"}
        };

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        private ItemStatusViewModel(ItemStatus status)
        {
            Status = status;
            Label = statusLabelMap[status];
        }

        //--- プロパティ

        public ItemStatus Status { get; set; }

        #region string Label

        private string _Label;

        public string Label
        {
            get { return _Label; }
            set
            {
                if (_Label != value)
                {
                    _Label = value;
                    DisplayLabel = "ステータス : " + value;
                    RaisePropertyChanged("Label");
                }
            }
        }

        #endregion

        #region string DisplayLabel

        private string _DisplayLabel;

        public string DisplayLabel
        {
            get { return _DisplayLabel; }
            set
            {
                if (_DisplayLabel != value)
                {
                    _DisplayLabel = value;
                    RaisePropertyChanged("DisplayLabel");
                }
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static IEnumerable<ItemStatusViewModel> Create()
        {
            foreach (ItemStatus status in Enum.GetValues(typeof(ItemStatus)))
            {
                yield return new ItemStatusViewModel(status);
            }
        }
    }
}