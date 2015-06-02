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

        //--- 静的コンストラクタ

        //--- コンストラクタ (+1)

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            Name = itemGroup.Name;
            Ruby = itemGroup.Ruby;
            ItemServiceVM = new ItemServiceViewModel(itemGroup.ItemList);
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

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        #endregion

        #region string Ruby

        private string _Ruby;

        public string Ruby
        {
            get { return _Ruby; }
            set
            {
                if (_Ruby != value)
                {
                    _Ruby = value;
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

        public ItemGroup CreateItemGroup()
        {
            return new ItemGroup()
            {
                Name = this.Name,
                Ruby = this.Ruby,
                ItemList = ItemServiceVM.CreateItemList()
            };
        }

        public ItemGroupViewModel Clone()
        {
            return new ItemGroupViewModel()
            {
                Name = this.Name,
                Ruby = this.Ruby
            };
        }

        public bool IsContainCorrectItemStatus(ItemStatusServiceViewModel itemStatusServiceVM)
        {
            return ItemServiceVM.WhereItemStatus(itemStatusServiceVM) != 0;
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}