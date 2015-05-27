namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Common;
    using Fortaggle.Models.Item;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
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
            ItemStatusServiceVM = new ItemStatusServiceViewModel(item);
        }

        public ItemViewModel()
            : this(new Item())
        {
        }

        //--- 変更通知プロパティ(モデル)

        #region string Name

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

        #region string Ruby

        public string Ruby
        {
            get { return item.Ruby; }
            set
            {
                if (item.Ruby != value)
                {
                    item.Ruby = value;
                    RaisePropertyChanged("Ruby");
                }
            }
        }

        #endregion

        #region string FolderPath

        public string FolderPath
        {
            get { return item.FolderPath; }
            set
            {
                if (item.FolderPath != value)
                {
                    item.FolderPath = value;
                    RaisePropertyChanged("FolderPath");
                    RaisePropertyChanged("IsExistsFolder");
                }
            }
        }

        #endregion

        #region string ExecuteFilePath

        public string ExecuteFilePath
        {
            get { return item.ExecuteFilePath; }
            set
            {
                if (item.ExecuteFilePath != value)
                {
                    item.ExecuteFilePath = value;
                    RaisePropertyChanged("ExecuteFilePath");
                    RaisePropertyChanged("ExecuteFileImage");
                    RaisePropertyChanged("IsExistsExecuteFile");
                }
            }
        }

        #endregion

        #region DateTime ExecutedAt

        public DateTime ExecutedAt
        {
            get { return item.ExecutedAt; }
            set
            {
                if (item.ExecutedAt != value)
                {
                    item.ExecutedAt = value;
                    RaisePropertyChanged("ExecutedAt");
                    RaisePropertyChanged("DisplayExecutedAt");
                }
            }
        }

        #endregion

        //--- 変更通知プロパティ

        #region ItemStatusServiceViewModel ItemStatusServiceVM

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

        #region ImageSource ExecuteFileImage

        public ImageSource ExecuteFileImage
        {
            get { return ExplorerManager.GetIconImage(ExecuteFilePath); }
        }

        #endregion

        #region bool IsExistsFolder

        public bool IsExistsFolder
        {
            get { return ExplorerManager.IsExistsDirectory(FolderPath); }
        }

        #endregion

        #region bool IsExistsExecuteFile

        public bool IsExistsExecuteFile
        {
            get { return ExplorerManager.IsExistsFile(ExecuteFilePath); }
        }

        #endregion

        #region string DisplayExecutedAt

        public string DisplayExecutedAt
        {
            get
            {
                string strftime = Item.EqualToDefaultExecutedAt(ExecutedAt) ? "なし" : ExecutedAt.ToString("yyyy.MM.dd HH:mm");
                return "最終実行日時 : " + strftime;
            }
        }

        #endregion

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
                    if (value == true)
                    {
                        Name = "";
                    }
                    RaisePropertyChanged("HasViewError");
                }
            }
        }

        #endregion

        //--- コマンド

        #region OpenFolderCommand

        private ICommand _OpenFolderCommand;
        
        public ICommand OpenFolderCommand
        {
            get
            {
                if (_OpenFolderCommand == null)
                {
                    _OpenFolderCommand = new RelayCommand(
                        // Action
                        () =>
                        {
                            OpenFolder();
                        },
                        // CanExecute
                        () =>
                        {
                            return IsExistsFolder;
                        });
                }
                return _OpenFolderCommand;
            }
        }

        #endregion

        #region ExecuteFileCommand

        private ICommand _ExecuteFileCommand;
        
        public ICommand ExecuteFileCommand
        {
            get
            {
                if (_ExecuteFileCommand == null)
                {
                    _ExecuteFileCommand = new RelayCommand(
                        // Action
                        () =>
                        {
                            ExecuteFile();
                        },
                        // CanExecute
                        () =>
                        {
                            return IsExistsExecuteFile;
                        });
                }
                return _ExecuteFileCommand;
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
            this.Ruby = itemVM.Ruby;
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
                Ruby = this.Ruby,
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
            ExecutedAt = DateTime.Now;
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

        public static ImageSource NoImage()
        {
            return ExplorerManager.GetIconImage(null);
        }
    }
}