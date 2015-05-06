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

        //--- プロパティ

        public string Name { get; set; }

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static List<Item> All()
        {
            return new List<Item>()
            {
                new Item("hoge"),
                new Item("foo"),
                new Item("bar"),
                new Item("piyo"),
                new Item("hoge"),
                new Item("foo"),
                new Item("bar"),
                new Item("piyo"),
            };
        }
    }
}
