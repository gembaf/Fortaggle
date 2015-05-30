namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using Fortaggle.ViewModels.Common;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using System.Windows.Media;

    public class ItemServiceViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemServiceViewModel(List<Item> itemList)
        {
            ItemVMList = InitializeItemVMList(itemList);
        }

        //--- プロパティ

        //--- 変更通知プロパティ

        #region ObservableCollection<ItemViewModel> ItemVMList

        private ObservableCollection<ItemViewModel> _ItemVMList;

        public ObservableCollection<ItemViewModel> ItemVMList
        {
            get { return _ItemVMList; }
            set
            {
                if (_ItemVMList != value)
                {
                    _ItemVMList = value;
                    RaisePropertyChanged("ItemVMList");
                }
            }
        }

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
                    RaisePropertyChanged("SelectedItemVM");
                    RaisePropertyChanged("IsSelect");
                }
            }
        }

        #endregion

        #region ImageSource ExecuteFileImage

        public ImageSource ExecuteFileImage
        {
            get
            {
                var itemVM = ItemVMList.Count == 0 ? null : ItemVMList.FirstOrDefault(e => e.IsExistsExecuteFile);
            	return itemVM == null ? ItemViewModel.NoImage() : itemVM.ExecuteFileImage;
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

        public bool IsSelect
        {
            get { return SelectedItemVM != null; }
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
                                    ItemVMList.Add(ItemDialogVM.ItemVM);
                                    ItemVMListCollectionChanged();
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
                                    ItemVMListCollectionChanged();
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
                                    ItemVMList.Remove(SelectedItemVM);
                                    ItemVMListCollectionChanged();
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

        //--- public メソッド

        public List<Item> CreateItemList()
        {
            List<Item> itemList = new List<Item>();

            foreach (ItemViewModel itemVM in ItemVMList)
            {
                itemList.Add(itemVM.CreateItem());
            }

            return itemList;
        }

        //--- protected メソッド

        //--- private メソッド

        private ObservableCollection<ItemViewModel> InitializeItemVMList(List<Item> itemList)
        {
            var itemVMList = new ObservableCollection<ItemViewModel>();
            foreach (Item item in itemList)
            {
                itemVMList.Add(new ItemViewModel(item));
            }
            return OrderByRuby(itemVMList);
        }

        private ObservableCollection<ItemViewModel> OrderByRuby(ObservableCollection<ItemViewModel> collection)
        {
            return new ObservableCollection<ItemViewModel>(collection.OrderBy(
                n =>
                {
                    return string.IsNullOrEmpty(n.Ruby) ? n.Name : n.Ruby;
                }));
        }

        private void ItemVMListCollectionChanged()
        {
            ItemVMList = OrderByRuby(ItemVMList);
            RaisePropertyChanged("ExecuteFileImage");
        }

        //--- static メソッド
    }
}