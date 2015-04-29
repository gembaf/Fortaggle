using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortaggle.Model.ItemGroup
{
    public class ItemGroupList
    {
        //--- プロパティ

        public List<ItemGroup> Collections { get; private set; }

        //--- コンストラクタ

        public ItemGroupList()
        {
            Collections = XML.XMLFileManager.ReadXml<List<ItemGroup>>("ItemGroupData.xml");
        }

        ~ItemGroupList()
        {
            XML.XMLFileManager.WriteXml<List<ItemGroup>>("ItemGroupData.xml", Collections);
        }

        //--- public メソッド

        public void Add(ItemGroup itemGroup)
        {
            Collections.Add(itemGroup);
        }
    }
}
