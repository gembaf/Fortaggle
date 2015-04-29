using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortaggle.Model.ItemGroup
{
    public class ItemGroup
    {
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
    }
}
