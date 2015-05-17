namespace Fortaggle.ViewModels
{
    using Fortaggle.ViewModels.ItemGroup;
    using Fortaggle.ViewModels.Ranking;
    using Fortaggle.ViewModels.TagGroup;
    using GalaSoft.MvvmLight;
    using System.Collections.Generic;
    using System.Linq;

    public class MainViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

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
            Fortaggle.Models.Item.ItemGroupService.WriteXml();
        }

        //--- プロパティ

        #region List<ViewModelBase> Pages

        public List<ViewModelBase> Pages { get; private set; }

        #endregion

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

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}