namespace Fortaggle.ViewModels.Common
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public class ConfirmDialogViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Action acceptAction;
        private Action cancelAction;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ConfirmDialogViewModel(string message, Action acceptAction, Action cancelAction)
        {
            Message = message;
            this.acceptAction = acceptAction;
            this.cancelAction = cancelAction;
        }

        //--- プロパティ

        #region string Message プロパティ

        public string Message { get; private set; }

    	#endregion

        #region ICommand AcceptCommand コマンド

        private ICommand _AcceptCommand;
        public ICommand AcceptCommand
        {
            get
            {
                if (_AcceptCommand == null)
                {
                    _AcceptCommand = new RelayCommand(acceptAction);
                }
                return _AcceptCommand;
            }
        }

        #endregion

        #region ICommand CancelCommand コマンド

        private ICommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new RelayCommand(cancelAction);
                }
                return _CancelCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}