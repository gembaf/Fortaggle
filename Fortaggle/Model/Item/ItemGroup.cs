using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortaggle.Model.Item
{
    public class ItemGroup
    {
        //--- 定数

        private const string FileName = "ItemGroupData.xml";

        //--- private static 変数

        private static List<ItemGroup> itemGroupList;

        //--- プロパティ

        public string Name { get; set; }

        //--- コンストラクタ

        public ItemGroup(string name)
        {
            Name = name;
        }

        public ItemGroup() : this(null)
        {
        }

        //--- static コンストラクタ

        static ItemGroup()
        {
            itemGroupList = XML.XMLFileManager.ReadXml<List<ItemGroup>>(FileName);
        }

        //--- public static メソッド

        public static List<ItemGroup> All()
        {
            return itemGroupList;
        }

        public static void Add(ItemGroup itemGroup)
        {
            itemGroupList.Add(itemGroup);
        }

        public static void Save()
        {
            XML.XMLFileManager.WriteXml<List<ItemGroup>>(FileName, itemGroupList);
        }
    }
}
