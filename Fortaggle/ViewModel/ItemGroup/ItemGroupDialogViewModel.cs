using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace Fortaggle.ViewModel.ItemGroup
{
    public class ItemGroupDialogViewModel : ViewModelBase
    {
        //--- プロパティ

        public ItemGroupViewModel ItemGroup { get; private set; }

        //--- private 変数

        private Action closeAction;

        //--- コンストラクタ

        public ItemGroupDialogViewModel(Action closeAction, ItemGroupViewModel itemGroup)
        {
            this.closeAction = closeAction;
            ItemGroup = itemGroup;
        }

        public ItemGroupDialogViewModel(Action closeAction)
            : this(closeAction, new ItemGroupViewModel())
        {
        }

        //--- コマンド

        #region ICommand SaveItemGroupCommand

        private ICommand _SaveItemGroupCommand;
        public ICommand SaveItemGroupCommand
        {
            get
            {
                if (_SaveItemGroupCommand == null)
                {
                    _SaveItemGroupCommand = new RelayCommand(CloseAction);
                }
                return _SaveItemGroupCommand;
            }
        }

        private void CloseAction()
        {
            ItemGroup.CreateModel();
            closeAction();
        }

        #endregion
    }
}