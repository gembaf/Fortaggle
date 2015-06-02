namespace Fortaggle.ViewModels
{
    using Fortaggle.ViewModels.Common;
    using Fortaggle.ViewModels.Item;
    using Fortaggle.ViewModels.ItemGroup;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    public class MainItemViewModel : ViewModelBase
    {
        //--- 定数

        private static readonly ItemStatusServiceViewModel ItemStatusServiceVM = new ItemStatusServiceViewModel();

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public MainItemViewModel()
        {
            ItemGroupServiceVM = new ItemGroupServiceViewModel();
        }

        //--- プロパティ

        #region string Label 静的プロパティ

        public static string Label
        {
            get { return "アイテム一覧"; }
        }

        #endregion

        #region ItemGroupServiceViewModel ItemGroupServiceVM

        public ItemGroupServiceViewModel ItemGroupServiceVM { get; private set; }

        #endregion

        //--- 変更通知プロパティ

        #region CheckboxDialogViewModel CheckboxDialogVM

        private CheckboxDialogViewModel _CheckboxDialogVM;

        public CheckboxDialogViewModel CheckboxDialogVM
        {
            get { return _CheckboxDialogVM; }
            set
            {
                if (_CheckboxDialogVM != value)
                {
                    _CheckboxDialogVM = value;
                    RaisePropertyChanged("CheckboxDialogVM");
                }
            }
        }

        #endregion

        //--- コマンド

        #region SelectItemStatusDialogCommand

        private ICommand _SelectItemStatusDialogCommand;

        public ICommand SelectItemStatusDialogCommand
        {
            get
            {
                if (_SelectItemStatusDialogCommand == null)
                {
                    _SelectItemStatusDialogCommand = new RelayCommand(
                        () =>
                        {
                            CheckboxDialogVM = new CheckboxDialogViewModel(
                                () =>
                                {
                                    CheckboxDialogVM = null;
                                },
                                ItemStatusServiceVM.ItemStatusVMList);
                        });
                }
                return _SelectItemStatusDialogCommand;
            }
        }

        #endregion

        //--- public メソッド

        public void Save()
        {
            ItemGroupServiceVM.Save();
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}