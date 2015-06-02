namespace Fortaggle.ViewModels.Item
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

        private Item item;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemStatusServiceViewModel(Item item)
        {
            this.item = item;
            ItemStatusVMList = InitializeItemStatusVMList();
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

        private IEnumerable<ItemStatusViewModel> InitializeItemStatusVMList()
        {
            foreach (ItemStatus status in Enum.GetValues(typeof(ItemStatus)))
            {
                yield return new ItemStatusViewModel(status, statusLabelMap[status]);
            }
        }

        //--- static メソッド
    }
}