using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;

namespace Fortaggle.ViewModel.ItemGroup
{
    using Fortaggle.Model.ItemGroup;

    public class ItemGroupListViewModel : ViewModelBase
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

        public List<ItemGroupViewModel> Collections { get; private set; }

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

        //--- private 変数

        private ItemGroupList itemGroupList;

        //--- コンストラクタ

        public ItemGroupListViewModel()
        {
            itemGroupList = new ItemGroupList();
            Collections = GetItemGroupListViewModel();
            SelectedItemGroup = Collections.First();
        }

        //--- private メソッド

        private List<ItemGroupViewModel> GetItemGroupListViewModel()
        {
            var collections = new List<ItemGroupViewModel>();
            foreach (ItemGroup e in itemGroupList.Collections)
            {
                collections.Add(new ItemGroupViewModel(e));
            }
            return collections;
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
                    _ItemGroupDialogOpenCommand = new RelayCommand(() =>
                        ItemGroupDialog = new ItemGroupDialogViewModel(() =>
                            ItemGroupDialog = null
                        )
                    );
                }
                return _ItemGroupDialogOpenCommand;
            }
        }

        #endregion
    }
}