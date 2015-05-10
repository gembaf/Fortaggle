﻿namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.ItemGroup;
    using GalaSoft.MvvmLight;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ItemViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Item item;

        //--- 静的コンストラクタ

        //--- コンストラクタ (+1)

        public ItemViewModel(Item item)
        {
            this.item = item;
        }

        public ItemViewModel()
            : this(new Item())
        {
        }

        //--- プロパティ

        #region string Name 変更通知プロパティ

        public string Name
        {
            get { return item.Name; }
            set
            {
                if (item.Name != value)
                {
                    item.Name = value;
                    IsAccept = !HasViewError;
                    RaisePropertyChanged("Name");
                }
            }
        }

        #endregion

        #region string FolderPath 変更通知プロパティ

        public string FolderPath
        {
            get { return item.FolderPath; }
            set
            {
                if (item.FolderPath != value)
                {
                    item.FolderPath = value;
                    RaisePropertyChanged("FolderPath");
                }
            }
        }

        #endregion

        #region bool HasViewError 変更通知プロパティ

        private bool _HasViewError;
        public bool HasViewError
        {
            get { return _HasViewError; }
            set
            {
                if (_HasViewError != value)
                {
                    _HasViewError = value;
                    IsAccept = !value;
                    RaisePropertyChanged("HasViewError");
                }
            }
        }

        #endregion

        #region bool IsAccept 変更通知プロパティ

        private bool _IsAccept;
        public bool IsAccept
        {
            get { return _IsAccept; }
            set
            {
                if (_IsAccept != value)
                {
                    _IsAccept = value;
                    RaisePropertyChanged("IsAccept");
                }
            }

        }

        #endregion

        //--- public メソッド

        public void Save(ItemGroup itemGroup)
        {
            itemGroup.AddItem(item);
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static ObservableCollection<ItemViewModel> Create(List<Item> itemList)
        {
            var itemVMList = new ObservableCollection<ItemViewModel>();
            foreach (Item e in itemList)
            {
                itemVMList.Add(new ItemViewModel(e));
            }
            return itemVMList;
        }
    }
}