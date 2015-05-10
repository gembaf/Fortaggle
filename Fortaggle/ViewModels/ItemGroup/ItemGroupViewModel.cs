namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.Models.ItemGroup;
    using Fortaggle.ViewModels.Item;
    using GalaSoft.MvvmLight;
    using System.Collections.ObjectModel;

    public class ItemGroupViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private static ObservableCollection<ItemGroupViewModel> itemGroupVMList;

        private ItemGroup itemGroup;

        //--- 静的コンストラクタ

        static ItemGroupViewModel()
        {
            itemGroupVMList = new ObservableCollection<ItemGroupViewModel>();
            foreach (ItemGroup e in ItemGroupService.All())
            {
                itemGroupVMList.Add(new ItemGroupViewModel(e));
            }
        }

        //--- コンストラクタ (+1)

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            this.itemGroup = itemGroup;
            ItemVMList = ItemViewModel.Create(itemGroup.ItemList);
        }

        public ItemGroupViewModel()
            : this(new ItemGroup())
        {
        }

        //--- プロパティ

        #region string Name 変更通知プロパティ

        public string Name
        {
            get { return itemGroup.Name; }
            set
            {
                if (itemGroup.Name != value)
                {
                    itemGroup.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        #endregion

        #region ObservableCollection<ItemViewModel> ItemVMList 変更通知プロパティ

        public ObservableCollection<ItemViewModel> ItemVMList { get; private set; }

        #endregion

        #region bool HasViewError 変更通知プロパティ

        private bool _HasViewError;
        public bool HasViewError
        {
            get { return _HasViewError; }
            set
            {
                if (_HasViewError != value)
                {
                    _HasViewError = value;
                    RaisePropertyChanged("HasViewError");
                }
            }
        }

        #endregion

        //--- public メソッド

        public void Save()
        {
            ItemGroupService.Add(itemGroup);
            itemGroupVMList.Add(this);
        }

        public void Remove()
        {
            ItemGroupService.Remove(itemGroup);
            itemGroupVMList.Remove(this);
        }

        public void Update(ItemGroupViewModel itemGroupVM)
        {
            this.Name = itemGroupVM.Name;
        }

        public ItemGroupViewModel Clone()
        {
            return new ItemGroupViewModel()
            { 
                Name = this.Name
            };
        }

        public void AddItemVM(ItemViewModel itemVM)
        {
            itemVM.Save(itemGroup);
            ItemVMList.Add(itemVM);
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static ObservableCollection<ItemGroupViewModel> All()
        {
            return itemGroupVMList;
        }
    }
}