using GalaSoft.MvvmLight;

namespace Fortaggle.ViewModel.ItemGroup
{
    using Fortaggle.Model.ItemGroup;

    public class ItemGroupViewModel : ViewModelBase
    {
        //--- プロパティ

        public string Name
        {
            get { return itemGroup.Name; }
            set { itemGroup.Name = value; }
        }

        //--- private 変数

        private ItemGroup itemGroup;

        //--- コンストラクタ

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            this.itemGroup = itemGroup;
        }

        public ItemGroupViewModel() : this(new ItemGroup())
        {
        }
    }
}