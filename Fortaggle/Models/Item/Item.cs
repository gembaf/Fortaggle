namespace Fortaggle.Models.ItemGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Item
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ

        public Item(string name)
        {
            Name = name;
        }

        public Item()
            : this(null)
        {
        }

        //--- プロパティ

        public string Name { get; set; }

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド
    }
}
