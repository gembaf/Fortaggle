namespace Fortaggle.ViewModels
{
    using Fortaggle.ViewModels.ItemGroup;
    using GalaSoft.MvvmLight;

    public class MainItemViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public MainItemViewModel()
        {
            ItemGroupServiceVM = new ItemGroupServiceViewModel();
        }

        //--- プロパティ

        #region string Label 静的プロパティ

        public static string Label
        {
            get { return "アイテム一覧"; }
        }

        #endregion

        #region ItemGroupServiceViewModel ItemGroupServiceVM

        public ItemGroupServiceViewModel ItemGroupServiceVM { get; private set; }

        #endregion

        //--- public メソッド

        public void Save()
        {
            ItemGroupServiceVM.Save();
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}