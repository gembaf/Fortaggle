namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Common;
    using Fortaggle.Models.Item;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
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
            ExecuteFileImage = ExplorerManager.GetIconImage(ExecuteFilePath);
            ItemStatusServiceVM = new ItemStatusServiceViewModel(item);
            IsExistsFolder = ExplorerManager.IsExistsDirectory(FolderPath);
            IsExistsExecuteFile = ExplorerManager.IsExistsFile(ExecuteFilePath);
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
                    IsExistsFolder = ExplorerManager.IsExistsDirectory(value);
                    RaisePropertyChanged("FolderPath");
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
                    ExecuteFileImage = ExplorerManager.GetIconImage(value);
                    IsExistsExecuteFile = ExplorerManager.IsExistsFile(value);
                    RaisePropertyChanged("ExecuteFilePath");
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

        #region bool IsExistsFolder

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

        #region bool IsExistsExecuteFile

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