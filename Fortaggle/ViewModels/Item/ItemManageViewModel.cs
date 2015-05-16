namespace Fortaggle.ViewModels.Item
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

        #region ObservableCollection<ItemViewModel> ItemVMList 変更通知プロパティ

        public ObservableCollection<ItemViewModel> ItemVMList { get; private set; }

        #endregion

        #region ItemViewModel SelectedItemVM  変更通知プロパティ

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

        #region ItemDialogViewModel ItemDialogVM 変更通知プロパティ

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

        #region ConfirmDialogViewModel ConfirmDialogVM 変更通知プロパティ

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

        #region bool IsSelect 変更通知プロパティ

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

        #region ICommand NewItemDialogCommand コマンド

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

        #region ICommand EditItemDialogCommand コマンド

        private ICommand _EditItemDialogCommand;

        public ICommand EditItemDialogCommand
        {
            get
            {
                if (_EditItemDialogCommand == null)
                {
                    _EditItemDialogCommand = new RelayCommand(
                        () =>
                        {
                            ItemDialogVM = new ItemDialogViewModel(
                                () =>
                                {
                                    SelectedItemVM.Update(ItemDialogVM.ItemVM);
                                    ItemDialogVM = null;
                                },
                                SelectedItemVM.Clone());
                        });
                }
                return _EditItemDialogCommand;
            }
        }

        #endregion

        #region ICommand DeleteItemDialogCommand コマンド

        private ICommand _DeleteItemDialogCommand;

        public ICommand DeleteItemDialogCommand
        {
            get
            {
                if (_DeleteItemDialogCommand == null)
                {
                    _DeleteItemDialogCommand = new RelayCommand(
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
                        });
                }
                return _DeleteItemDialogCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

    }
}