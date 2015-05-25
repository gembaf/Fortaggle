namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.ViewModels.Common;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class ItemGroupServiceViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemGroupServiceViewModel()
        {
            ItemGroupVMList = ItemGroupViewModel.All();
            if (ItemGroupVMList.Count > 0)
            {
                SelectedItemGroupVM = ItemGroupVMList.First();
            }
        }

        //--- プロパティ

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
                    }
                    else
                    {
                        IsSelect = false;
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
                        // Action
                        () =>
                        {
                            ItemGroupDialogVM = new ItemGroupDialogViewModel(
                                () =>
                                {
                                    SelectedItemGroupVM.Update(ItemGroupDialogVM.ItemGroupVM);
                                    ItemGroupDialogVM = null;
                                },
                                SelectedItemGroupVM.Clone());
                        },
                        // CanExecute
                        () =>
                        {
                            return IsSelect;
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
                        // Action
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
                        },
                        // CanExecute
                        () =>
                        {
                            return IsSelect;
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