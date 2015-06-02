namespace Fortaggle.ViewModels.Item
{
    using GalaSoft.MvvmLight;
    using System;

    public class ItemStatusDialogViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Action closeAction;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemStatusDialogViewModel(Action closeAction)
        {
            this.closeAction = closeAction;
            ItemStatusServiceVM = new ItemStatusServiceViewModel();
        }

        //--- プロパティ

        #region ItemStatusServiceViewModel ItemStatusServiceVM

        public ItemStatusServiceViewModel ItemStatusServiceVM { get; set; }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}