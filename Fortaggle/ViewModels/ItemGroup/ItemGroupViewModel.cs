namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.Models.Item;
    using Fortaggle.ViewModels.Common;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class ItemGroupViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private static ObservableCollection<ItemGroupViewModel> itemGroupVMList;

        private ItemGroup itemGroup;

        //--- 静的コンストラクタ

        static ItemGroupViewModel()
        {
            itemGroupVMList = new ObservableCollection<ItemGroupViewModel>();
            foreach (ItemGroup e in ItemGroup.All())
            {
                itemGroupVMList.Add(new ItemGroupViewModel(e));
            }
        }

        //--- コンストラクタ (+2)

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            this.itemGroup = itemGroup;
        }

        public ItemGroupViewModel()
            : this(new ItemGroup())
        {
        }

        //--- プロパティ

        #region string Name 変更通知プロパティ

        public string Name
        {
            get { return itemGroup.Name; }
            set
            {
                if (itemGroup.Name != value)
                {
                    itemGroup.Name = value;
                    IsAccept = !HasViewError;
                    RaisePropertyChanged("Name");
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

        #region bool HasViewError 変更通知プロパティ

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

        #region bool IsAccept 変更通知プロパティ

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

        #region ICommand ConfirmDialogOpenCommand コマンド

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

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static ObservableCollection<ItemGroupViewModel> All()
        {
            return itemGroupVMList;
        }
    }
}