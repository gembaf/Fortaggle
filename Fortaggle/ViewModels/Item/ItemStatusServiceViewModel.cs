namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using GalaSoft.MvvmLight;
    using System.Collections.Generic;
    using System.Linq;

    public class ItemStatusServiceViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Item item;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemStatusServiceViewModel(Item item)
        {
            this.item = item;
            ItemStatusVMList = ItemStatusViewModel.Create();
            SelectedItemStatusVM = ItemStatusVMList.FirstOrDefault<ItemStatusViewModel>((itemStatusVM) => itemStatusVM.Status == item.Status);
        }

        //--- プロパティ

        #region IEnumerable<ItemStatusViewModel> ItemStatusVMList

        public IEnumerable<ItemStatusViewModel> ItemStatusVMList { get; private set; }

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

        public ItemStatusServiceViewModel Clone()
        {
            return new ItemStatusServiceViewModel(item);
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}