using GalaSoft.MvvmLight;

namespace Fortaggle.ViewModels.TagGroup
{
    public class TagGroupListViewModel : ViewModelBase
    {
        //--- 静的プロパティ

        public static string Label
        {
            get { return "タグ一覧"; }
        }

        public TagGroupListViewModel()
        {
        }
    }
}