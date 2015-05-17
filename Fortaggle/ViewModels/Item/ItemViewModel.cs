﻿namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using Fortaggle.Models.XML;
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
            ItemStatusServiceVM = new ItemStatusServiceViewModel(item);
            IsExistsFolder = ExplorerManager.IsExistsDirectory(FolderPath);
            IsExistsExecuteFile = ExplorerManager.IsExistsFile(ExecuteFilePath);
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
                    IsExistsFolder = ExplorerManager.IsExistsDirectory(value);
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
                    IsExistsExecuteFile = ExplorerManager.IsExistsFile(value);
                    RaisePropertyChanged("ExecuteFilePath");
                }
            }
        }

        #endregion

        #region ItemStatusServiceViewModel ItemStatusServiceVM 変更通知プロパティ

        private ItemStatusServiceViewModel _ItemStatusServiceVM;

        public ItemStatusServiceViewModel ItemStatusServiceVM
        {
            get { return _ItemStatusServiceVM; }
            set
            {
                if (_ItemStatusServiceVM != value)
                {
                    _ItemStatusServiceVM = value;
                    RaisePropertyChanged("ItemStatusServiceVM");
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

        #region bool IsExistsFolder 変更通知プロパティ

        private bool _IsExistsFolder;

        public bool IsExistsFolder
        {
            get { return _IsExistsFolder; }
            set
            {
                if (_IsExistsFolder != value)
                {
                    _IsExistsFolder = value;
                    RaisePropertyChanged("IsExistsFolder");
                }
            }
        }

        #endregion

        #region bool IsExistsExecuteFile 変更通知プロパティ

        private bool _IsExistsExecuteFile;

        public bool IsExistsExecuteFile
        {
            get { return _IsExistsExecuteFile; }
            set
            {
                if (_IsExistsExecuteFile != value)
                {
                    _IsExistsExecuteFile = value;
                    RaisePropertyChanged("IsExistsExecuteFile");
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
            this.ItemStatusServiceVM = itemVM.ItemStatusServiceVM;
            this.item.Status = itemVM.ItemStatusServiceVM.SelectedItemStatusVM.Status;
        }

        public ItemViewModel Clone()
        {
            return new ItemViewModel()
            {
                Name = this.Name,
                FolderPath = this.FolderPath,
                ExecuteFilePath = this.ExecuteFilePath,
                ItemStatusServiceVM = this.ItemStatusServiceVM.Clone()
            };
        }

        public void OpenFolder()
        {
            item.OpenFolder();
        }

        public void ExecuteFile()
        {
            item.ExecuteFile();
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