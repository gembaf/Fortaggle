using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using Fortaggle.Views.ValidationRules;
using System.Windows.Input;
using Fortaggle.ViewModels.Common;
using GalaSoft.MvvmLight.Command;

namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.Models.Item;

    public class ItemGroupViewModel : ViewModelBase
    {
        //--- private static 変数

        private static ObservableCollection<ItemGroupViewModel> itemGroupVMList;

        //--- プロパティ

        public string Name
        {
            get { return itemGroup.Name; }
            set {
                if (itemGroup.Name != value)
                {
                    itemGroup.Name = value;
                    IsAccept = !HasViewError;
                    RaisePropertyChanged("Name");
                }
            }
        }

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
                    IsAccept = !value;
                    RaisePropertyChanged("HasViewError");
                }
            }
        }

        #endregion

        #region bool IsAccept

        private bool _IsAccept;
        public bool IsAccept
        {
            get { return _IsAccept; }
            set
            {
                if (_IsAccept != value)
                {
                    _IsAccept = value;
                    RaisePropertyChanged("IsAccept");
                }
            }

        }

        #endregion

        //--- private 変数

        private ItemGroup itemGroup;

        //--- static コンストラクタ

        static ItemGroupViewModel()
        {
            itemGroupVMList = new ObservableCollection<ItemGroupViewModel>();
            foreach (ItemGroup e in ItemGroup.All())
            {
                itemGroupVMList.Add(new ItemGroupViewModel(e));
            }
        }

        //--- コンストラクタ

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            this.itemGroup = itemGroup;
        }

        public ItemGroupViewModel()
            : this(new ItemGroup())
        {
        }

        //--- public static メソッド

        public static ObservableCollection<ItemGroupViewModel> All()
        {
            return itemGroupVMList;
        }

        //--- public メソッド

        public void CreateModel()
        {
            ItemGroup.Add(itemGroup);
        }

        public void RemoveSelf()
        {
            ItemGroup.Remove(itemGroup);
            itemGroupVMList.Remove(this);
        }

        //--- コマンド

        #region ICommand ConfirmDialogOpenCommand

        private ICommand _ConfirmDialogOpenCommand;
        public ICommand ConfirmDialogOpenCommand
        {
            get
            {
                if (_ConfirmDialogOpenCommand == null)
                {
                    _ConfirmDialogOpenCommand = new RelayCommand(
                        () =>
                        {
                            ConfirmDialogVM = new ConfirmDialogViewModel(
                                // Message
                                itemGroup.Name + " を削除しますか？",
                                // AcceptAction
                                () =>
                                {
                                    RemoveSelf();
                                    ConfirmDialogVM = null;
                                },
                                // CancelAction
                                () =>
                                {
                                    ConfirmDialogVM = null;
                                });
                        });
                }
                return _ConfirmDialogOpenCommand;
            }
        }

        #endregion
    }
}