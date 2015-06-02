namespace Fortaggle.ViewModels.Item
{
    using Fortaggle.Models.Item;
    using GalaSoft.MvvmLight;

    public class ItemStatusViewModel : ViewModelBase
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public ItemStatusViewModel(ItemStatus status, string label)
        {
            Status = status;
            Label = label;
        }

        //--- プロパティ

        #region ItemStatus Status

        public ItemStatus Status { get; set; }

        #endregion

        #region string Label

        private string _Label;

        public string Label
        {
            get { return _Label; }
            set
            {
                if (_Label != value)
                {
                    _Label = value;
                    RaisePropertyChanged("Label");
                }
            }
        }

        #endregion

        #region string DisplayLabel

        public string DisplayLabel
        {
            get { return "ステータス : " + Label; }
        }

        #endregion

        #region bool IsChecked

        public bool IsChecked { get; set; }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

    }
}