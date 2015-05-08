﻿namespace Fortaggle.ViewModels.Item
{
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

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

    }
}