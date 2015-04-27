﻿using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace Fortaggle.ViewModel.ItemGroup
{
    using Fortaggle.Model.ItemGroup;
    
    public class ItemGroupListViewModel : ViewModelBase
    {
        #region プロパティ

        public List<ItemGroupViewModel> Collections { get; private set; }

        #region ItemGroupViewModel SelectedItemGroup

        private ItemGroupViewModel _SelectedItemGroup;
        public ItemGroupViewModel SelectedItemGroup
        {
            get { return _SelectedItemGroup; }
            set
            {
                if (_SelectedItemGroup != value)
                {
                    _SelectedItemGroup = value;
                    RaisePropertyChanged("SelectedItemGroup");
                }
            }
        }

        #endregion

        #endregion

        #region private 変数

        private ItemGroupList itemGroupList;

        #endregion

        #region コンストラクタ

        public ItemGroupListViewModel()
        {
            itemGroupList = new ItemGroupList();
            Collections = Load();
            SelectedItemGroup = Collections.First();
        }

        #endregion

        #region private メソッド

        private List<ItemGroupViewModel> Load()
        {
            var collections = new List<ItemGroupViewModel>();
            foreach (ItemGroup e in itemGroupList.Collections)
            {
                collections.Add(new ItemGroupViewModel(e));
            }
            return collections;
        }

        #endregion
    }
}