using GalaSoft.MvvmLight;

namespace Fortaggle.ViewModel.ItemGroup
{
    public class ItemGroupManageViewModel : ViewModelBase
    {
        #region 静的プロパティ

        public static string Label
        {
            get { return "アイテム一覧"; }
        }
        
        #endregion

        #region プロパティ

        #region ItemGroupListViewModel ItemGroupList

        public ItemGroupListViewModel ItemGroupList { get; private set; }

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

        #region コンストラクタ

        public ItemGroupManageViewModel()
        {
            ItemGroupList = new ItemGroupListViewModel(ItemGroupSelectAction);
            ItemGroupSelectAction();
        }

        #endregion

        #region private メソッド

        private void ItemGroupSelectAction()
        {
            if (ItemGroupList != null)
            {
                ItemGroupDetail = new ItemGroupDetailViewModel(ItemGroupList.SelectedItemGroup);
            }
        }

        #endregion
    }
}