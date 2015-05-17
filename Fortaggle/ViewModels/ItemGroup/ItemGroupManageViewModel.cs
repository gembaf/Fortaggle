﻿namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.ViewModels.Common;
    using Fortaggle.ViewModels.Item;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class ItemGroupManageViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemGroupManageViewModel()
        {
            ItemGroupVMList = ItemGroupViewModel.All();
            if (ItemGroupVMList.Count > 0)
            {
                SelectedItemGroupVM = ItemGroupVMList.First();
            }
        }

        //--- プロパティ

        #region string Label 静的プロパティ

        public static string Label
        {
            get { return "アイテム一覧"; }
        }

        #endregion

        //--- 変更通知プロパティ

        #region ItemGroupDialogViewModel ItemGroupDialogVM

        private ItemGroupDialogViewModel _ItemGroupDialogVM;

        public ItemGroupDialogViewModel ItemGroupDialogVM
        {
            get { return _ItemGroupDialogVM; }
            set
            {
                if (_ItemGroupDialogVM != value)
                {
                    _ItemGroupDialogVM = value;
                    RaisePropertyChanged("ItemGroupDialogVM");
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

        #region ObservableCollection<ItemGroupViewModel> ItemGroupVMList

        public ObservableCollection<ItemGroupViewModel> ItemGroupVMList { get; private set; }

        #endregion

        #region ItemGroupViewModel SelectedItemGroupVM 

        private ItemGroupViewModel _SelectedItemGroupVM;

        public ItemGroupViewModel SelectedItemGroupVM
        {
            get { return _SelectedItemGroupVM; }
            set
            {
                if (_SelectedItemGroupVM != value)
                {
                    _SelectedItemGroupVM = value;
                    if (value != null)
                    {
                        IsSelect = true;
                        ItemManageVM = new ItemManageViewModel(value);
                    }
                    else
                    {
                        IsSelect = false;
                        ItemManageVM = null;
                    }
                    RaisePropertyChanged("SelectedItemGroupVM");
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

        #region ItemManageViewModel ItemManageVM

        private ItemManageViewModel _ItemManageVM;

        public ItemManageViewModel ItemManageVM
        {
            get { return _ItemManageVM; }
            set
            {
                if (_ItemManageVM != value)
                {
                    _ItemManageVM = value;
                    RaisePropertyChanged("ItemManageVM");
                }
            }
        }

        #endregion

        //--- コマンド

        #region NewItemGroupDialogCommand

        private ICommand _NewItemGroupDialogCommand;

        public ICommand NewItemGroupDialogCommand
        {
            get
            {
                if (_NewItemGroupDialogCommand == null)
                {
                    _NewItemGroupDialogCommand = new RelayCommand(
                        () =>
                        {
                            ItemGroupDialogVM = new ItemGroupDialogViewModel(
                                () =>
                                {
                                    ItemGroupDialogVM.ItemGroupVM.Save();
                                    ItemGroupDialogVM = null;
                                });
                        });
                }
                return _NewItemGroupDialogCommand;
            }
        }

        #endregion

        #region EditItemGroupDialogCommand

        private ICommand _EditItemGroupDialogCommand;

        public ICommand EditItemGroupDialogCommand
        {
            get
            {
                if (_EditItemGroupDialogCommand == null)
                {
                    _EditItemGroupDialogCommand = new RelayCommand(
                        () =>
                        {
                            ItemGroupDialogVM = new ItemGroupDialogViewModel(
                                () =>
                                {
                                    SelectedItemGroupVM.Update(ItemGroupDialogVM.ItemGroupVM);
                                    ItemGroupDialogVM = null;
                                },
                                SelectedItemGroupVM.Clone());
                        });
                }
                return _EditItemGroupDialogCommand;
            }
        }

        #endregion

        #region DeleteItemGroupDialogCommand

        private ICommand _DeleteItemGroupDialogCommand;

        public ICommand DeleteItemGroupDialogCommand
        {
            get
            {
                if (_DeleteItemGroupDialogCommand == null)
                {
                    _DeleteItemGroupDialogCommand = new RelayCommand(
                        () =>
                        {
                            ConfirmDialogVM = new ConfirmDialogViewModel(
                                // Message
                                SelectedItemGroupVM.Name + " を削除しますか？",
                                // AcceptAction
                                () =>
                                {
                                    SelectedItemGroupVM.Remove();
                                    ConfirmDialogVM = null;
                                },
                                // CancelAction
                                () =>
                                {
                                    ConfirmDialogVM = null;
                                });
                        });
                }
                return _DeleteItemGroupDialogCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}