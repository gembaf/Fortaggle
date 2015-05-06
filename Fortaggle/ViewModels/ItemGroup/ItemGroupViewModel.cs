namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.Models.ItemGroup;
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

        //--- コンストラクタ (+2)

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            this.itemGroup = itemGroup;
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
                    IsAccept = !HasViewError;
                    RaisePropertyChanged("Name");
                }
            }
        }

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
                    IsAccept = !value;
                    RaisePropertyChanged("HasViewError");
                }
            }
        }

        #endregion

        #region bool IsAccept 変更通知プロパティ

        private bool _IsAccept;
        public bool IsAccept
        {
            get { return _IsAccept; }
            set
            {
                if (_IsAccept != value)
                {
                    _IsAccept = value;
                    RaisePropertyChanged("IsAccept");
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

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static ObservableCollection<ItemGroupViewModel> All()
        {
            return itemGroupVMList;
        }
    }
}