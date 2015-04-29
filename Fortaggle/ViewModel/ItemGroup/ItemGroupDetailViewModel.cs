using GalaSoft.MvvmLight;

namespace Fortaggle.ViewModel.ItemGroup
{
    public class ItemGroupDetailViewModel : ViewModelBase
    {
        //--- プロパティ

        public string Name
        {
            get { return itemGroup.Name; }
        }

        //--- private 変数
        
        private ItemGroupViewModel itemGroup;

        //--- コンストラクタ

        public ItemGroupDetailViewModel(ItemGroupViewModel itemGroup)
        {
            this.itemGroup = itemGroup;
        }
    }
}