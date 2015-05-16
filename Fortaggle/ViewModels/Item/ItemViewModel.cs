namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using GalaSoft.MvvmLight;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Media;

    public class ItemViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Item item;

        //--- 静的コンストラクタ

        //--- コンストラクタ (+1)

        public ItemViewModel(Item item)
        {
            this.item = item;
            ExecuteFileImage = item.ExecuteFileImage;
        }

        public ItemViewModel()
            : this(new Item())
        {
        }

        //--- プロパティ

        #region string Name 変更通知プロパティ

        public string Name
        {
            get { return item.Name; }
            set
            {
                if (item.Name != value)
                {
                    item.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        #endregion

        #region string FolderPath 変更通知プロパティ

        public string FolderPath
        {
            get { return item.FolderPath; }
            set
            {
                if (item.FolderPath != value)
                {
                    item.FolderPath = value;
                    RaisePropertyChanged("FolderPath");
                }
            }
        }

        #endregion

        #region string ExecuteFilePath 変更通知プロパティ

        public string ExecuteFilePath
        {
            get { return item.ExecuteFilePath; }
            set
            {
                if (item.ExecuteFilePath != value)
                {
                    item.ExecuteFilePath = value;
                    ExecuteFileImage = item.ExecuteFileImage;
                    RaisePropertyChanged("ExecuteFilePath");
                }
            }
        }

        #endregion

        #region ImageSource ExecuteFileImage 変更通知プロパティ

        private ImageSource _ExecuteFileImage;

        public ImageSource ExecuteFileImage
        {
            get { return _ExecuteFileImage; }
            private set
            {
                if (_ExecuteFileImage != value)
                {
                    _ExecuteFileImage = value;
                    RaisePropertyChanged("ExecuteFileImage");
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
                    RaisePropertyChanged("HasViewError");
                }
            }
        }

        #endregion

        //--- public メソッド

        public void Save(ItemGroup itemGroup)
        {
            itemGroup.AddItem(item);
        }

        public void Remove(ItemGroup itemGroup)
        {
            itemGroup.RemoveItem(item);
        }

        public void Update(ItemViewModel itemVM)
        {
            this.Name = itemVM.Name;
            this.FolderPath = itemVM.FolderPath;
            this.ExecuteFilePath = itemVM.ExecuteFilePath;
        }

        public ItemViewModel Clone()
        {
            return new ItemViewModel()
            {
                Name = this.Name,
                FolderPath = this.FolderPath,
                ExecuteFilePath = this.ExecuteFilePath
            };
        }

        public void OpenFolder()
        {
            item.OpenFolder();
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static ObservableCollection<ItemViewModel> Create(List<Item> itemList)
        {
            var itemVMList = new ObservableCollection<ItemViewModel>();
            foreach (Item e in itemList)
            {
                itemVMList.Add(new ItemViewModel(e));
            }
            return itemVMList;
        }
    }
}