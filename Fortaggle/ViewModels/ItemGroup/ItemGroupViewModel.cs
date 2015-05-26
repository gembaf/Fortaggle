namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.Models.Item;
    using Fortaggle.ViewModels.Item;
    using GalaSoft.MvvmLight;
    using System.Collections.ObjectModel;
    using System.Windows.Media;
    using System.Linq;

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
            ItemServiceVM = new ItemServiceViewModel(itemGroup);
        }

        public ItemGroupViewModel()
            : this(new ItemGroup())
        {
        }

        //--- プロパティ

        #region ItemServiceViewModel ItemServiceVM

        public ItemServiceViewModel ItemServiceVM { get; private set; }

        #endregion

        //--- 変更通知プロパティ(モデル)

        #region string Name

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

        #region string Ruby

        public string Ruby
        {
            get { return itemGroup.Ruby; }
            set
            {
                if (itemGroup.Ruby != value)
                {
                    itemGroup.Ruby = value;
                    RaisePropertyChanged("Ruby");
                }
            }
        }

        #endregion

        //--- 変更通知プロパティ

        #region bool HasViewError

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
            this.Ruby = itemGroupVM.Ruby;
        }

        public ItemGroupViewModel Clone()
        {
            return new ItemGroupViewModel()
            {
                Name = this.Name,
                Ruby = this.Ruby
            };
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