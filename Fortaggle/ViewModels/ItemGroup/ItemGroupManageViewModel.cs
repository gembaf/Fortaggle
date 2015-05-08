namespace Fortaggle.ViewModels.ItemGroup
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

        #region ItemGroupDialogViewModel ItemGroupDialogVM 変更通知プロパティ

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

        #region ObservableCollection<ItemGroupViewModel> ItemGroupVMList 変更通知プロパティ

        public ObservableCollection<ItemGroupViewModel> ItemGroupVMList { get; private set; }

        #endregion

        #region ItemGroupViewModel SelectedItemGroupVM  変更通知プロパティ

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
                    }
                    RaisePropertyChanged("SelectedItemGroupVM");
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

        #region ItemManageViewModel ItemManageVM 変更通知プロパティ

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

        #region ICommand NewItemGroupDialogCommand コマンド

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

        #region ICommand EditItemGroupDialogOpenCommand コマンド

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

        #region ICommand DeleteItemGroupCommand コマンド

        private ICommand _DeleteItemGroupCommand;

        public ICommand DeleteItemGroupCommand
        {
            get
            {
                if (_DeleteItemGroupCommand == null)
                {
                    _DeleteItemGroupCommand = new RelayCommand(
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
                return _DeleteItemGroupCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}