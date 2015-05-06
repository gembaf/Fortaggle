namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.ViewModels.ItemGroup;
    using GalaSoft.MvvmLight;
    using System.Collections.ObjectModel;

    public class ItemManageViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private ItemGroupViewModel itemGroupVM;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemManageViewModel(ItemGroupViewModel itemGroupVM)
        {
            this.itemGroupVM = itemGroupVM;
            ItemVMList = itemGroupVM.ItemVMList;
        }

        //--- プロパティ

        #region ObservableCollection<ItemViewModel> ItemVMList 変更通知プロパティ

        public ObservableCollection<ItemViewModel> ItemVMList { get; private set; }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

    }
}