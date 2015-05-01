using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using Fortaggle.Views.ValidationRules;

namespace Fortaggle.ViewModels.ItemGroup
{
    using Fortaggle.Models.Item;

    public class ItemGroupViewModel : ViewModelBase
    {
        //--- プロパティ

        public string Name
        {
            get { return itemGroup.Name; }
            set {
                if (itemGroup.Name != value)
                {
                    itemGroup.Name = value;
                    IsAccept = !HasViewError;
                    RaisePropertyChanged("Name");
                }
            }
        }

        #region bool HasViewError

        private bool _HasViewError;
        public bool HasViewError
        {
            get { return _HasViewError; }
            set
            {
                if (_HasViewError != value)
                {
                    _HasViewError = value;
                    IsAccept = !value;
                    RaisePropertyChanged("HasViewError");
                }
            }
        }

        #endregion

        #region bool IsAccept

        private bool _IsAccept;
        public bool IsAccept
        {
            get { return _IsAccept; }
            set
            {
                if (_IsAccept != value)
                {
                    _IsAccept = value;
                    RaisePropertyChanged("IsAccept");
                }
            }

        }

        #endregion

        //--- private 変数

        private ItemGroup itemGroup;

        //--- コンストラクタ

        public ItemGroupViewModel(ItemGroup itemGroup)
        {
            this.itemGroup = itemGroup;
        }

        public ItemGroupViewModel()
            : this(new ItemGroup())
        {
        }

        //--- public static メソッド

        public static ObservableCollection<ItemGroupViewModel> Create()
        {
            var collections = new ObservableCollection<ItemGroupViewModel>();
            foreach (ItemGroup e in ItemGroup.All())
            {
                collections.Add(new ItemGroupViewModel(e));
            }
            return collections;
        }

        //--- public メソッド

        public void CreateModel()
        {
            ItemGroup.Add(itemGroup);
        }
    }
}