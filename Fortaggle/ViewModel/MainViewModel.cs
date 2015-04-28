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
        #region 変更通知プロパティ

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

        #endregion

        #region プロパティ

        public List<ViewModelBase> Pages { get; private set; }

        #endregion

        #region コンストラクタ

        public MainViewModel()
        {
            Pages = new List<ViewModelBase>() {
                new ItemGroupManageViewModel(),
                new TagGroupManageViewModel(),
                new RankingViewModel()
            };
            SelectedPage = Pages.First();
        }

        #endregion

    }
}