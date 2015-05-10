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

        #region ICommand OpenFileDialogCommand コマンド

        private ICommand _OpenFileDialogCommand;

        public ICommand OpenFileDialogCommand
        {
            get
            {
                if (_OpenFileDialogCommand == null)
                {
                    _OpenFileDialogCommand = new RelayCommand(
                        () =>
                        {
                            var dialog = new System.Windows.Forms.OpenFileDialog();
                            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                ItemVM.ExecuteFilePath = dialog.FileName;
                            }
                        });
                }
                return _OpenFileDialogCommand;
            }
        }

        #endregion

        #region ICommand SetFolderPathCommand コマンド

        private ICommand _SetFolderPathCommand;

        public ICommand SetFolderPathCommand
        {
            get
            {
                if (_SetExecuteFilePathCommand == null)
                {
                    _SetExecuteFilePathCommand = new RelayCommand<object>(
                        (parameter) =>
                        {
                            // var files = parameter as FileInfo[];
                            var files = parameter as string[];
                            ItemVM.FolderPath = files[0];
                        });
                }
                return _SetExecuteFilePathCommand;
            }
        }

        #endregion

        #region ICommand SetExecuteFilePathCommand コマンド

        private ICommand _SetExecuteFilePathCommand;

        public ICommand SetExecuteFilePathCommand
        {
            get
            {
                if (_SetExecuteFilePathCommand == null)
                {
                    _SetExecuteFilePathCommand = new RelayCommand<object>(
                        (parameter) =>
                        {
                            // var files = parameter as FileInfo[];
                            var files = parameter as string[];
                            ItemVM.ExecuteFilePath = files[0];
                        });
                }
                return _SetExecuteFilePathCommand;
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}