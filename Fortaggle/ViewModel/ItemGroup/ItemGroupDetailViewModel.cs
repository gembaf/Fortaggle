using GalaSoft.MvvmLight;

namespace Fortaggle.ViewModel.ItemGroup
{
    public class ItemGroupDetailViewModel : ViewModelBase
    {
        public string Name
        {
            get { return itemGroup.Name; }
        }

        private ItemGroupViewModel itemGroup;

        public ItemGroupDetailViewModel(ItemGroupViewModel itemGroup)
        {
            this.itemGroup = itemGroup;
        }
    }
}