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

        #region ItemGroupDialogViewModel ItemGroupDialogVM

        private ItemGroupDialogViewModel _ItemGroupDialogVM;
        public ItemGroupDialogViewModel ItemGroupDialogVM
        {
            get { return _ItemGroupDialogVM; }
            set
            {
                if (_ItemGroupDialogVM != value)
                {
                    _ItemGroupDialogVM = value;
                    RaisePropertyChanged("ItemGroupDialogVM");
                }
            }
        }

        #endregion

        public ObservableCollection<ItemGroupViewModel> ItemGroupVMList { get; private set; }

        #region ItemGroupViewModel SelectedItemGroupVM

        private ItemGroupViewModel _SelectedItemGroupVM;
        public ItemGroupViewModel SelectedItemGroupVM
        {
            get { return _SelectedItemGroupVM; }
            set
            {
                if (_SelectedItemGroupVM != value)
                {
                    _SelectedItemGroupVM = value;
                    RaisePropertyChanged("SelectedItemGroupVM");
                }
            }
        }

        #endregion

        //--- コンストラクタ

        public ItemGroupManageViewModel()
        {
            ItemGroupVMList = ItemGroupViewModel.Create();
            if (ItemGroupVMList.Count > 0)
            {
                SelectedItemGroupVM = ItemGroupVMList.First();
            }
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
                    _ItemGroupDialogOpenCommand = new RelayCommand(() => ItemGroupDialogVM = new ItemGroupDialogViewModel(CloseAction));
                }
                return _ItemGroupDialogOpenCommand;
            }
        }

        private void CloseAction()
        {
            ItemGroupVMList.Add(ItemGroupDialogVM.ItemGroupVM);
            ItemGroupDialogVM = null;
        }

        #endregion
    }
}