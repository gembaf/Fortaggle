namespace Fortaggle.Models.Item
{
    using System.Collections.Generic;

    public class ItemGroup
    {
        //--- 定数

        private const string FileName = "ItemGroupData.xml";

        //--- フィールド

        private static List<ItemGroup> itemGroupList;

        //--- 静的コンストラクタ

        static ItemGroup()
        {
            itemGroupList = XML.XMLFileManager.ReadXml<List<ItemGroup>>(FileName);
        }

        //--- コンストラクタ (+2)

        public ItemGroup(string name)
        {
            Name = name;
        }

        public ItemGroup()
            : this(null)
        {
        }

        //--- プロパティ

        #region string Name プロパティ

        public string Name { get; set; }

        #endregion

        //--- public メソッド

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

        public static List<ItemGroup> All()
        {
            return itemGroupList;
        }

        public static void Add(ItemGroup itemGroup)
        {
            itemGroupList.Add(itemGroup);
        }

        public static void Remove(ItemGroup itemGroup)
        {
            itemGroupList.Remove(itemGroup);
        }

        public static void Save()
        {
            XML.XMLFileManager.WriteXml<List<ItemGroup>>(FileName, itemGroupList);
        }
    }
}
