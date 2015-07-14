namespace Fortaggle.ViewModels
{
    using Fortaggle.Models.Item;
    using Fortaggle.ViewModels.Item;
    using Fortaggle.ViewModels.ItemGroup;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
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

        #region ItemStatusDialogViewModel ItemStatusDialogVM

        private ItemStatusDialogViewModel _ItemStatusDialogVM;

        public ItemStatusDialogViewModel ItemStatusDialogVM
        {
            get { return _ItemStatusDialogVM; }
            set
            {
                if (_ItemStatusDialogVM != value)
                {
                    _ItemStatusDialogVM = value;
                    RaisePropertyChanged("ItemStatusDialogVM");
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
                            ItemStatusDialogVM = new ItemStatusDialogViewModel(
                                () =>
                                {
                                    ItemGroupServiceVM.WhereItemStatus(ItemStatusServiceVM);
                                    ItemStatusDialogVM = null;
                                },
                                ItemStatusServiceVM);
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