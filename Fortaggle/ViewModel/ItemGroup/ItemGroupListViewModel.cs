using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace Fortaggle.ViewModel.ItemGroup
{
    using Fortaggle.Model.ItemGroup;
using System;
    
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
                    ItemGroupDetail = new ItemGroupDetailViewModel(value);
                    RaisePropertyChanged("SelectedItemGroup");
                }
            }
        }

        #endregion

        #region ItemGroupDetailViewModel ItemGroupDetail

        private ItemGroupDetailViewModel _ItemGroupDetail;
        public ItemGroupDetailViewModel ItemGroupDetail
        {
            get { return _ItemGroupDetail; }
            set
            {
                if (_ItemGroupDetail != value)
                {
                    _ItemGroupDetail = value;
                    RaisePropertyChanged("ItemGroupDetail");
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
            Collections = GetItemGroupListViewModel();
            SelectedItemGroup = Collections.First();
        }

        #endregion

        #region private メソッド

        private List<ItemGroupViewModel> GetItemGroupListViewModel()
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