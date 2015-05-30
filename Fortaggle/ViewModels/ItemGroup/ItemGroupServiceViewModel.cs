namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.Models.Item;
    using Fortaggle.ViewModels.Common;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
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
            ItemGroupVMList = InitializeItemGroupVMList(ItemGroupService.All());
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

        private ObservableCollection<ItemGroupViewModel> _ItemGroupVMList;

        public ObservableCollection<ItemGroupViewModel> ItemGroupVMList
        {
            get { return _ItemGroupVMList; }
            set
            {
                if (_ItemGroupVMList != value)
                {
                    _ItemGroupVMList = value;
                    RaisePropertyChanged("ItemGroupVMList");
                }
            }
        }

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
                    RaisePropertyChanged("SelectedItemGroupVM");
                    RaisePropertyChanged("IsSelect");
                }
            }
        }

        #endregion

        #region bool IsSelect

        public bool IsSelect
        {
            get { return SelectedItemGroupVM != null; }
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
                                    ItemGroupVMList.Add(ItemGroupDialogVM.ItemGroupVM);
                                    //ItemGroupDialogVM.ItemGroupVM.Save();
                                    ItemGroupVMListCollectionChanged();
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
                                    ItemGroupVMListCollectionChanged();
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
                                    //SelectedItemGroupVM.Remove();
                                    ItemGroupVMList.Remove(SelectedItemGroupVM);
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

        public void Save()
        {
            ItemGroupService itemGroupService = new ItemGroupService();

            foreach (ItemGroupViewModel itemGroupVM in ItemGroupVMList)
            {
                itemGroupService.Add(itemGroupVM.CreateItemGroup());
            }


            itemGroupService.Save();
        }

        //--- protected メソッド

        //--- private メソッド

        private ObservableCollection<ItemGroupViewModel> InitializeItemGroupVMList(List<ItemGroup> itemGroupList)
        {
            var itemGroupVMList = new ObservableCollection<ItemGroupViewModel>();
            foreach (ItemGroup itemGroup in itemGroupList)
            {
                itemGroupVMList.Add(new ItemGroupViewModel(itemGroup));
            }
            return OrderByRuby(itemGroupVMList);
        }

        private ObservableCollection<ItemGroupViewModel> OrderByRuby(ObservableCollection<ItemGroupViewModel> collection)
        {
            return new ObservableCollection<ItemGroupViewModel>(collection.OrderBy(
                n =>
                {
                    return string.IsNullOrEmpty(n.Ruby) ? n.Name : n.Ruby;
                }));
        }

        private void ItemGroupVMListCollectionChanged()
        {
            ItemGroupVMList = OrderByRuby(ItemGroupVMList);
        }

        //--- static メソッド
    }
}