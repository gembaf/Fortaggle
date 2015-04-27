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

        public ItemGroupListViewModel ItemGroupList { get; private set; }

        public ItemGroupDetailViewModel ItemGroupDetail { get; private set; }
        
        #endregion

        #region コンストラクタ

        public ItemGroupManageViewModel()
        {
            ItemGroupList = new ItemGroupListViewModel();
            ItemGroupDetail = new ItemGroupDetailViewModel();
        }

        #endregion
    }
}