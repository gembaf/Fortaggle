namespace Fortaggle.Models.Item
{
    using System.Collections.Generic;

    public class ItemGroupService
    {
        //--- 定数

        private const string FileName = "ItemGroupData.xml";

        //--- フィールド

        private List<ItemGroup> itemGroupList;

        //--- コンストラクタ

        public ItemGroupService()
        {
            itemGroupList = new List<ItemGroup>();
        }

        //--- public メソッド

        public void Add(ItemGroup itemGroup)
        {
            itemGroupList.Add(itemGroup);
        }

        public void Remove(ItemGroup itemGroup)
        {
            itemGroupList.Remove(itemGroup);
        }

        public void Save()
        {
            Common.XMLFileManager.WriteXml<List<ItemGroup>>(FileName, itemGroupList);
        }

        //--- static メソッド

        public static List<ItemGroup> All()
        {
            return Common.XMLFileManager.ReadXml<List<ItemGroup>>(FileName);
        }
    }
}
