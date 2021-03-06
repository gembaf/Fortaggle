﻿namespace Fortaggle.Models.Item
{
    using System.Collections.Generic;

    public class ItemGroup
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ (+1)

        public ItemGroup(string name)
        {
            Name = name;
            ItemList = new List<Item>();
        }

        public ItemGroup()
            : this(null)
        {
        }

        //--- プロパティ

        public string Name { get; set; }

        public string Ruby { get; set; }

        public List<Item> ItemList { get; set; }

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

    }
}
