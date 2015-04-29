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
            Collections = new List<ItemGroup>()
            {
                new ItemGroup("hoge"),
                new ItemGroup("foo"),
                new ItemGroup("bar"),
                new ItemGroup("piyo"),
                new ItemGroup("fuga")
            };
        }

        //--- public メソッド

        public void Add(ItemGroup itemGroup)
        {
            Collections.Add(itemGroup);
        }
    }
}
