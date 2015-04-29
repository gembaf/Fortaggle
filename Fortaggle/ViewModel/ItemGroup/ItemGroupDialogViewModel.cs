using GalaSoft.MvvmLight;
using System;

namespace Fortaggle.ViewModel.ItemGroup
{
    public class ItemGroupDialogViewModel : ViewModelBase
    {
        //--- private 変数

        private Action closeAction;

        //--- コンストラクタ

        public ItemGroupDialogViewModel(Action closeAction)
        {
            this.closeAction = closeAction;
        }
    }
}