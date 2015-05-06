namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using GalaSoft.MvvmLight;
    using System.Collections.ObjectModel;

    public class ItemViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        private static ObservableCollection<ItemViewModel> itemVMList;

        private Item item;

        //--- 静的コンストラクタ

        static ItemViewModel()
        {
            itemVMList = new ObservableCollection<ItemViewModel>();
            foreach (Item e in Item.All())
            {
                itemVMList.Add(new ItemViewModel(e));
            }
        }

        //--- コンストラクタ

        public ItemViewModel(Item item)
        {
            this.item = item;
        }

        //--- プロパティ

        #region string Name 変更通知プロパティ

        public string Name
        {
            get { return item.Name; }
            set
            {
                if (item.Name != value)
                {
                    item.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static ObservableCollection<ItemViewModel> All()
        {
            return itemVMList;
        }
    }
}