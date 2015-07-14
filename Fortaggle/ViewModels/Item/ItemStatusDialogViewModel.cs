namespace Fortaggle.ViewModels.Item
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public class ItemStatusDialogViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Action closeAction;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemStatusDialogViewModel(Action closeAction, ItemStatusServiceViewModel itemStatusServiceVM)
        {
            this.closeAction = closeAction;
            ItemStatusServiceVM = itemStatusServiceVM;
        }

        //--- プロパティ

        #region ItemStatusServiceViewModel ItemStatusServiceVM

        public ItemStatusServiceViewModel ItemStatusServiceVM { get; set; }

        #endregion

        //--- コマンド

        #region WhereItemStatusCommand

        private ICommand _WhereItemStatusCommand;

        public ICommand WhereItemStatusCommand
        {
            get
            {
                if (_WhereItemStatusCommand == null)
                {
                    _WhereItemStatusCommand = new RelayCommand(closeAction);
                }
                return _WhereItemStatusCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}