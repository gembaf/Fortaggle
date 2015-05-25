﻿namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using Fortaggle.ViewModels.Common;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using System.Windows.Media;

    public class ItemServiceViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private ItemGroup itemGroup;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemServiceViewModel(ItemGroup itemGroup)
        {
            this.itemGroup = itemGroup;
            ItemVMList = ItemViewModel.Create(itemGroup.ItemList);
            ItemVMList = new ObservableCollection<ItemViewModel>(ItemVMList.OrderBy(
                n =>
                {
                    return string.IsNullOrEmpty(n.Ruby) ? n.Name : n.Ruby;
                }));
            ExecuteFileImage = SelectExecuteFileImage();
            ItemVMList.CollectionChanged += ItemVMListCollectionChanged;
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

        #region ImageSource ExecuteFileImage

        private ImageSource _ExecuteFileImage;

        public ImageSource ExecuteFileImage
        {
            get { return _ExecuteFileImage; }
            set
            {
                if (_ExecuteFileImage != value)
                {
                    _ExecuteFileImage = value;
                    RaisePropertyChanged("ExecuteFileImage");
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
                                    ItemDialogVM.ItemVM.Save(itemGroup);
                                    ItemVMList.Add(ItemDialogVM.ItemVM);
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
                                    SelectedItemVM.Remove(itemGroup);
                                    ItemVMList.Remove(SelectedItemVM);
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

        //--- protected メソッド

        //--- private メソッド

        private ImageSource SelectExecuteFileImage()
        {
            var itemVM = ItemVMList.Count == 0 ? null : ItemVMList.FirstOrDefault(e => e.IsExistsExecuteFile);
            return itemVM == null ? ItemViewModel.NoImage() : itemVM.ExecuteFileImage;
        }

        private void ItemVMListCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ExecuteFileImage = SelectExecuteFileImage();
        }

        //--- static メソッド

    }
}