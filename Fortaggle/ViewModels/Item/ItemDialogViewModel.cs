namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Common;
    using Fortaggle.ViewModels.Common;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
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

        #region ItemViewModel ItemVM

        public ItemViewModel ItemVM { get; private set; }

        #endregion

        //--- コマンド

        #region SaveItemCommand

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

        #region FolderBrowserDialogCommand

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
                            if (dialog.ShowDialog() == true)
                            {
                                ItemVM.FolderPath = dialog.SelectedPath;
                            }
                        });
                }
                return _FolderBrowserDialogCommand;
            }
        }

        #endregion

        #region OpenFileDialogCommand

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
                            var dialog = new OpenFileDialog();
                            if (dialog.ShowDialog() == true)
                            {
                                ItemVM.ExecuteFilePath = dialog.FileName;
                            }
                        });
                }
                return _OpenFileDialogCommand;
            }
        }

        #endregion

        #region SetFolderPathCommand

        private ICommand _SetFolderPathCommand;

        public ICommand SetFolderPathCommand
        {
            get
            {
                if (_SetFolderPathCommand == null)
                {
                    _SetFolderPathCommand = new RelayCommand<object>(
                        (parameter) =>
                        {
                            var filePath = (parameter as string[])[0];
                            FileInfo file = new FileInfo(filePath);
                            if (!ExplorerManager.IsExistsDirectory(file.FullName))
                            {
                                System.Windows.Forms.MessageBox.Show("フォルダを選択してください");
                                return;
                            }
                            ItemVM.FolderPath = file.FullName;
                            if (string.IsNullOrEmpty(ItemVM.Name))
                            {
                                ItemVM.Name = file.Name;
                            }
                        });
                }
                return _SetFolderPathCommand;
            }
        }

        #endregion

        #region SetExecuteFilePathCommand

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
                            var filePath = (parameter as string[])[0];
                            if (!ExplorerManager.IsExistsFile(filePath))
                            {
                                System.Windows.Forms.MessageBox.Show("実行可能なファイルを選択してください");
                                return;
                            }
                            ItemVM.ExecuteFilePath = filePath;
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