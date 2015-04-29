using Fortaggle.ViewModel.ItemGroup;
using Fortaggle.ViewModel.Ranking;
using Fortaggle.ViewModel.TagGroup;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace Fortaggle.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //--- 変更通知プロパティ

        #region ViewModelBase SelectedPage

        private ViewModelBase _SelectedPage;
        public ViewModelBase SelectedPage
        {
            get { return _SelectedPage; }
            set
            {
                if (_SelectedPage != value)
                {
                    _SelectedPage = value;
                    RaisePropertyChanged("SelectedPage");
                }
            }
        }

        #endregion

        //--- プロパティ

        public List<ViewModelBase> Pages { get; private set; }

        //--- コンストラクタ

        public MainViewModel()
        {
            Pages = new List<ViewModelBase>() {
                new ItemGroupManageViewModel(),
                new TagGroupListViewModel(),
                new RankingViewModel()
            };
            SelectedPage = Pages.First();
        }

        //--- デストラクタ

        ~MainViewModel()
        {
            Fortaggle.Model.Item.ItemGroup.Save();
        }
    }
}