namespace Fortaggle.ViewModels.Item
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public class ItemDialogViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Action closeAction;

        //--- 静的コンストラクタ

        //--- コンストラクタ (+2)

        public ItemDialogViewModel(Action closeAction, ItemViewModel itemVM)
        {
            this.closeAction = closeAction;
            ItemVM = itemVM;
        }

        public ItemDialogViewModel(Action closeAction)
            : this(closeAction, new ItemViewModel())
        {
        }

        //--- プロパティ

        #region ItemViewModel ItemVM プロパティ

        public ItemViewModel ItemVM { get; private set; }

        #endregion

        #region ICommand SaveItemCommand コマンド

        private ICommand _SaveItemCommand;
        public ICommand SaveItemCommand
        {
            get
            {
                if (_SaveItemCommand == null)
                {
                    _SaveItemCommand = new RelayCommand(closeAction);
                }
                return _SaveItemCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}