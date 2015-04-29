using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Fortaggle.ViewModel.ItemGroup
{
    public class ItemGroupManageViewModel : ViewModelBase
    {
        //--- 静的プロパティ

        public static string Label
        {
            get { return "アイテム一覧"; }
        }

        //--- プロパティ

        #region ItemGroupDialogViewModel ItemGroupDialog

        private ItemGroupDialogViewModel _ItemGroupDialog;
        public ItemGroupDialogViewModel ItemGroupDialog
        {
            get { return _ItemGroupDialog; }
            set
            {
                if (_ItemGroupDialog != value)
                {
                    _ItemGroupDialog = value;
                    RaisePropertyChanged("ItemGroupDialog");
                }
            }
        }

        #endregion

        public ObservableCollection<ItemGroupViewModel> Collections { get; private set; }

        #region ItemGroupViewModel SelectedItemGroup

        private ItemGroupViewModel _SelectedItemGroup;
        public ItemGroupViewModel SelectedItemGroup
        {
            get { return _SelectedItemGroup; }
            set
            {
                if (_SelectedItemGroup != value)
                {
                    _SelectedItemGroup = value;
                    ItemGroupDetail = new ItemGroupDetailViewModel(value);
                    RaisePropertyChanged("SelectedItemGroup");
                }
            }
        }

        #endregion

        #region ItemGroupDetailViewModel ItemGroupDetail

        private ItemGroupDetailViewModel _ItemGroupDetail;
        public ItemGroupDetailViewModel ItemGroupDetail
        {
            get { return _ItemGroupDetail; }
            set
            {
                if (_ItemGroupDetail != value)
                {
                    _ItemGroupDetail = value;
                    RaisePropertyChanged("ItemGroupDetail");
                }
            }
        }

        #endregion

        //--- コンストラクタ

        public ItemGroupManageViewModel()
        {
            Collections = ItemGroupViewModel.Create();
            SelectedItemGroup = Collections.First();
        }

        //--- コマンド

        #region ICommand ItemGroupDialogOpenCommand

        private ICommand _ItemGroupDialogOpenCommand;
        public ICommand ItemGroupDialogOpenCommand
        {
            get
            {
                if (_ItemGroupDialogOpenCommand == null)
                {
                    _ItemGroupDialogOpenCommand = new RelayCommand(() => ItemGroupDialog = new ItemGroupDialogViewModel(CloseAction));
                }
                return _ItemGroupDialogOpenCommand;
            }
        }

        private void CloseAction()
        {
            Collections.Add(ItemGroupDialog.ItemGroup);
            ItemGroupDialog = null;
        }

        #endregion
    }
}