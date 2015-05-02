namespace Fortaggle.ViewModels.ItemGroup
{
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
                    RaisePropertyChanged("SelectedItemGroupVM");
                }
            }
        }

        #endregion

        #region ICommand ItemGroupDialogOpenCommand コマンド

        private ICommand _ItemGroupDialogOpenCommand;
        public ICommand ItemGroupDialogOpenCommand
        {
            get
            {
                if (_ItemGroupDialogOpenCommand == null)
                {
                    _ItemGroupDialogOpenCommand = new RelayCommand(
                        () =>
                        {
                            ItemGroupDialogVM = new ItemGroupDialogViewModel(
                                () =>
                                {
                                    ItemGroupDialogVM.ItemGroupVM.AddSelf();
                                    ItemGroupDialogVM = null;
                                });
                        });
                }
                return _ItemGroupDialogOpenCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}