namespace Fortaggle.Models.Item
{
    using System.Collections.Generic;

    public static class ItemGroupService
    {
        //--- 定数

        private const string FileName = "ItemGroupData.xml";

        //--- フィールド

        private static List<ItemGroup> itemGroupList;

        //--- 静的コンストラクタ

        static ItemGroupService()
        {
            itemGroupList = XML.XMLFileManager.ReadXml<List<ItemGroup>>(FileName);
        }

        //--- static メソッド

        public static void Add(ItemGroup itemGroup)
        {
            itemGroupList.Add(itemGroup);
        }

        public static void Remove(ItemGroup itemGroup)
        {
            itemGroupList.Remove(itemGroup);
        }

        public static List<ItemGroup> All()
        {
            return itemGroupList;
        }

        public static void WriteXml()
        {
            XML.XMLFileManager.WriteXml<List<ItemGroup>>(FileName, itemGroupList);
        }
    }
}
