namespace Fortaggle.ViewModels.ItemGroup
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public class ItemGroupDialogViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Action closeAction;

        //--- 静的コンストラクタ

        //--- コンストラクタ (+2)

        public ItemGroupDialogViewModel(Action closeAction, ItemGroupViewModel itemGroupVM)
        {
            this.closeAction = closeAction;
            ItemGroupVM = itemGroupVM;
        }

        public ItemGroupDialogViewModel(Action closeAction)
            : this(closeAction, new ItemGroupViewModel())
        {
        }

        //--- プロパティ

        #region ItemGroupViewModel ItemGroupVM プロパティ

        public ItemGroupViewModel ItemGroupVM { get; private set; }

        #endregion

        #region ICommand SaveItemGroupCommand コマンド

        private ICommand _SaveItemGroupCommand;
        public ICommand SaveItemGroupCommand
        {
            get
            {
                if (_SaveItemGroupCommand == null)
                {
                    _SaveItemGroupCommand = new RelayCommand(closeAction, () => !ItemGroupVM.HasViewError);
                }
                return _SaveItemGroupCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}