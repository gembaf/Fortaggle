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
            Name = item.Name;
            Ruby = item.Ruby;
            FolderPath = item.FolderPath;
            ExecuteFilePath = item.ExecuteFilePath;
            ExecutedAt = item.ExecutedAt;
            ItemStatusServiceVM = new ItemStatusServiceViewModel(item);
        }

        public ItemViewModel()
            : this(new Item())
        {
        }

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

        #region string FolderPath

        private string _FolderPath;

        public string FolderPath
        {
            get { return _FolderPath; }
            set
            {
                if (_FolderPath != value)
                {
                    _FolderPath = value;
                    RaisePropertyChanged("FolderPath");
                    RaisePropertyChanged("IsExistsFolder");
                }
            }
        }

        #endregion

        #region string ExecuteFilePath

        private string _ExecuteFilePath;

        public string ExecuteFilePath
        {
            get { return _ExecuteFilePath; }
            set
            {
                if (_ExecuteFilePath != value)
                {
                    _ExecuteFilePath = value;
                    RaisePropertyChanged("ExecuteFilePath");
                    RaisePropertyChanged("ExecuteFileImage");
                    RaisePropertyChanged("IsExistsExecuteFile");
                }
            }
        }

        #endregion

        #region DateTime ExecutedAt

        private DateTime _ExecutedAt;

        public DateTime ExecutedAt
        {
            get { return _ExecutedAt; }
            set
            {
                if (_ExecutedAt != value)
                {
                    _ExecutedAt = value;
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

        public Item CreateItem()
        {
            return new Item()
            {
                Name = this.Name,
                Ruby = this.Ruby,
                FolderPath = this.FolderPath,
                ExecuteFilePath = this.ExecuteFilePath,
                Status = this.ItemStatusServiceVM.SelectedItemStatusVM.Status,
                ExecutedAt = this.ExecutedAt
            };
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

        public static ImageSource NoImage()
        {
            return ExplorerManager.GetIconImage(null);
        }
    }
}