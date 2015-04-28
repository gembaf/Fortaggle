using GalaSoft.MvvmLight;
using System;

namespace Fortaggle.ViewModel.ItemGroup
{
    public class ItemGroupDialogViewModel : ViewModelBase
    {
        #region private 変数

        private Action closeAction;

        #endregion

        #region コンストラクタ

        public ItemGroupDialogViewModel(Action closeAction)
        {
            this.closeAction = closeAction;
        }

        #endregion
    }
}