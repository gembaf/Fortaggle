using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace Fortaggle.ViewModels.Common
{
    public class ConfirmDialogViewModel : ViewModelBase
    {
        //--- プロパティ

        public string Message { get; private set; }

        //--- private 変数

        private Action acceptAction;
        private Action cancelAction;

        //--- コンストラクタ

        public ConfirmDialogViewModel(string message, Action acceptAction, Action cancelAction)
        {
            Message = message;
            this.acceptAction = acceptAction;
            this.cancelAction = cancelAction;
        }

        //--- コマンド

        #region ICommand AcceptCommand

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

        #region ICommand CancelCommand

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
    }
}