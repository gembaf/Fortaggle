namespace Fortaggle.ViewModels.Common
{
    using GalaSoft.MvvmLight;
    using System;
	using System.Collections.Generic;

    public class CheckboxDialogViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private Action closeAction;

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public CheckboxDialogViewModel(Action closeAction, IEnumerable<ViewModelBase> list)
        {
            this.closeAction = closeAction;
            VMList = new List<ViewModelBase>(list);
        }

        //--- プロパティ

        #region List<ViewModelBase>

        public List<ViewModelBase> VMList { get; set; }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}