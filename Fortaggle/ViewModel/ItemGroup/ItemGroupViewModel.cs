using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Fortaggle.ViewModel.ItemGroup
{
    using Fortaggle.Model.Item;

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

        public ItemGroupViewModel()
            : this(new ItemGroup())
        {
        }

        //--- public static メソッド

        public static ObservableCollection<ItemGroupViewModel> Create()
        {
            var collections = new ObservableCollection<ItemGroupViewModel>();
            foreach (ItemGroup e in ItemGroup.All())
            {
                collections.Add(new ItemGroupViewModel(e));
            }
            return collections;
        }

        //--- public メソッド

        public void CreateModel()
        {
            ItemGroup.Add(itemGroup);
        }
    }
}