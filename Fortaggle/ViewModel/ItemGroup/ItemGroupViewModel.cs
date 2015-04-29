using GalaSoft.MvvmLight;

namespace Fortaggle.ViewModel.ItemGroup
{
    using Fortaggle.Model.ItemGroup;

    public class ItemGroupViewModel : ViewModelBase
    {
        //--- プロパティ

        public string Name
        {
            get { return ItemGroup.Name; }
            set { ItemGroup.Name = value; }
        }

        public ItemGroup ItemGroup { get; set; }

        //--- コンストラクタ

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            ItemGroup = itemGroup;
        }

        public ItemGroupViewModel() : this(new ItemGroup())
        {
        }
    }
}