using GalaSoft.MvvmLight;

namespace Fortaggle.ViewModel.ItemGroup
{
    using Fortaggle.Model.ItemGroup;

    public class ItemGroupViewModel : ViewModelBase
    {
        #region プロパティ

        public string Name
        {
            get { return itemGroup.Name; }
        }

        #endregion

        #region private 変数

        private ItemGroup itemGroup;

        #endregion

        #region コンストラクタ

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            this.itemGroup = itemGroup;
        }

        #endregion
    }
}