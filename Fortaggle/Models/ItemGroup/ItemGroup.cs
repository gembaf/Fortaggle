namespace Fortaggle.Models.ItemGroup
{
    using System.Collections.Generic;

    [System.Xml.Serialization.XmlRoot("ItemGroup")]
    public class ItemGroup
    {
        //--- 定数

        //--- フィールド

        //--- 静的コンストラクタ

        //--- コンストラクタ (+2)

        public ItemGroup(string name)
        {
            Name = name;
            ItemList = new List<Item>()
            {
                new Item("hoge"),
                new Item("foo"),
            };
        }

        public ItemGroup()
            : this(null)
        {
        }

        //--- プロパティ

        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("Item")]
        public List<Item> ItemList { get; set; }

        //--- public メソッド

        //public void AddItem(Item item)
        //{
        //    ItemList.Add(item);
        //}

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

    }
}
