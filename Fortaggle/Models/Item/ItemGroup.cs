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

        public void Save()
        {
            itemGroupList.Add(this);
        }

        public void Remove()
        {
            itemGroupList.Remove(this);
        }

        //--- protected メソッド

        //--- private メソッド

        //--- static メソッド

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
