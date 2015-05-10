namespace Fortaggle.ViewModels.Item
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Fortaggle.ViewModels.Common;
    using System;
    using System.IO;
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
                    _SaveItemCommand = new RelayCommand(closeAction, () => !ItemVM.HasViewError);
                }
                return _SaveItemCommand;
            }
        }

        #endregion

        #region ICommand FolderBrowserDialogCommand コマンド

        private ICommand _FolderBrowserDialogCommand;

        public ICommand FolderBrowserDialogCommand
        {
            get
            {
                if (_FolderBrowserDialogCommand == null)
                {
                    _FolderBrowserDialogCommand = new RelayCommand(
                        () =>
                        {
                            FolderBrowserDialog dialog = new FolderBrowserDialog();
                            if (dialog.ShowDialog() != null)
                            {
                                ItemVM.FolderPath = dialog.SelectedPath;
                            }
                        });
                }
                return _FolderBrowserDialogCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}