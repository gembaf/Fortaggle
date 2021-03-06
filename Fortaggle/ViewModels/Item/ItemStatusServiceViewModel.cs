﻿namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ItemStatusServiceViewModel : ViewModelBase
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

        //--- コンストラクタ (+1)

        public ItemStatusServiceViewModel(Item item)
        {
            ItemStatusVMList = InitializeItemStatusVMList();
            SelectedItemStatusVM = ItemStatusVMList.FirstOrDefault<ItemStatusViewModel>((itemStatusVM) => itemStatusVM.Status == item.Status);
        }

        public ItemStatusServiceViewModel()
            : this(new Item())
        {
        }

        //--- プロパティ

        #region List<ItemStatusViewModel> ItemStatusVMList

        public List<ItemStatusViewModel> ItemStatusVMList { get; private set; }

        #endregion

        #region List<ItemStatusViewModel> CheckedItemStatusVMList

        public List<ItemStatusViewModel> CheckedItemStatusVMList
        {
            get
            {
                var list = ItemStatusVMList.Where(e => e.IsChecked);
                return new List<ItemStatusViewModel>(list);
            }
        }

        #endregion

        //--- 変更通知プロパティ

        #region ItemStatusViewModel SelectedItemStatusVM

        private ItemStatusViewModel _SelectedItemStatusVM;

        public ItemStatusViewModel SelectedItemStatusVM
        {
            get { return _SelectedItemStatusVM; }
            set
            {
                if (_SelectedItemStatusVM != value)
                {
                    _SelectedItemStatusVM = value;
                    RaisePropertyChanged("SelectedItemStatusVM");
                }
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        private List<ItemStatusViewModel> InitializeItemStatusVMList()
        {
            var list = new List<ItemStatusViewModel>();
            foreach (ItemStatus status in Enum.GetValues(typeof(ItemStatus)))
            {
                list.Add(new ItemStatusViewModel(status, statusLabelMap[status]));
            }
            return list;
        }

        //--- static メソッド
    }
}