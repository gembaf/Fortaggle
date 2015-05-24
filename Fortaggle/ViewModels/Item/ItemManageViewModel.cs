﻿namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.ViewModels.Common;
    using Fortaggle.ViewModels.ItemGroup;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class ItemManageViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private ItemGroupViewModel itemGroupVM;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemManageViewModel(ItemGroupViewModel itemGroupVM)
        {
            this.itemGroupVM = itemGroupVM;
            ItemVMList = itemGroupVM.ItemVMList;
        }

        //--- プロパティ

        //--- 変更通知プロパティ

        #region ObservableCollection<ItemViewModel> ItemVMList

        public ObservableCollection<ItemViewModel> ItemVMList { get; private set; }

        #endregion

        #region ItemViewModel SelectedItemVM

        private ItemViewModel _SelectedItemVM;

        public ItemViewModel SelectedItemVM
        {
            get { return _SelectedItemVM; }
            set
            {
                if (_SelectedItemVM != value)
                {
                    _SelectedItemVM = value;
                    IsSelect = value != null;
                    RaisePropertyChanged("SelectedItemVM");
                }
            }
        }

        #endregion

        #region ItemDialogViewModel ItemDialogVM

        private ItemDialogViewModel _ItemDialogVM;

        public ItemDialogViewModel ItemDialogVM
        {
            get { return _ItemDialogVM; }
            set
            {
                if (_ItemDialogVM != value)
                {
                    _ItemDialogVM = value;
                    RaisePropertyChanged("ItemDialogVM");
                }
            }
        }

        #endregion

        #region ConfirmDialogViewModel ConfirmDialogVM

        private ConfirmDialogViewModel _ConfirmDialogVM;

        public ConfirmDialogViewModel ConfirmDialogVM
        {
            get { return _ConfirmDialogVM; }
            set
            {
                if (_ConfirmDialogVM != value)
                {
                    _ConfirmDialogVM = value;
                    RaisePropertyChanged("ConfirmDialogVM");
                }
            }
        }

        #endregion

        #region bool IsSelect

        private bool _IsSelect;

        public bool IsSelect
        {
            get { return _IsSelect; }
            set
            {
                if (_IsSelect != value)
                {
                    _IsSelect = value;
                    RaisePropertyChanged("IsSelect");
                }
            }
        }

        #endregion

        //--- コマンド

        #region NewItemDialogCommand

        private ICommand _NewItemDialogCommand;

        public ICommand NewItemDialogCommand
        {
            get
            {
                if (_NewItemDialogCommand == null)
                {
                    _NewItemDialogCommand = new RelayCommand(
                        () =>
                        {
                            ItemDialogVM = new ItemDialogViewModel(
                                () =>
                                {
                                    itemGroupVM.AddItemVM(ItemDialogVM.ItemVM);
                                    ItemDialogVM = null;
                                });
                        });
                }
                return _NewItemDialogCommand;
            }
        }

        #endregion

        #region EditItemDialogCommand

        private ICommand _EditItemDialogCommand;

        public ICommand EditItemDialogCommand
        {
            get
            {
                if (_EditItemDialogCommand == null)
                {
                    _EditItemDialogCommand = new RelayCommand(
                        // Action
                        () =>
                        {
                            ItemDialogVM = new ItemDialogViewModel(
                                () =>
                                {
                                    SelectedItemVM.Update(ItemDialogVM.ItemVM);
                                    ItemDialogVM = null;
                                },
                                SelectedItemVM.Clone());
                        },
                        // CanExecute
                        () =>
                        {
                            return IsSelect;
                        });
                }
                return _EditItemDialogCommand;
            }
        }

        #endregion

        #region DeleteItemDialogCommand

        private ICommand _DeleteItemDialogCommand;

        public ICommand DeleteItemDialogCommand
        {
            get
            {
                if (_DeleteItemDialogCommand == null)
                {
                    _DeleteItemDialogCommand = new RelayCommand(
                        // Action
                        () =>
                        {
                            ConfirmDialogVM = new ConfirmDialogViewModel(
                                // Message
                                SelectedItemVM.Name + " を削除しますか？",
                                // AcceptAction
                                () =>
                                {
                                    itemGroupVM.RemoveItemVM(SelectedItemVM);
                                    ConfirmDialogVM = null;
                                },
                                // CancelAction
                                () =>
                                {
                                    ConfirmDialogVM = null;
                                });
                        },
                        // CanExecute
                        () =>
                        {
                            return IsSelect;
                        });
                }
                return _DeleteItemDialogCommand;
            }
        }

        #endregion

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
                            SelectedItemVM.OpenFolder();
                        },
                        // CanExecute
                        () =>
                        {
                            return IsSelect && SelectedItemVM.IsExistsFolder;
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
                            SelectedItemVM.ExecuteFile();
                        },
                        // CanExecute
                        () =>
                        {
                            return IsSelect && SelectedItemVM.IsExistsExecuteFile;
                        });
                }
                return _ExecuteFileCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

    }
}