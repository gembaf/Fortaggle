﻿namespace Fortaggle.ViewModels.Item
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

        public ItemStatus Status { get; private set; }

        public string Label { get; private set; }

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