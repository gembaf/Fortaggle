using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortaggle.Model.ItemGroup
{
    public class ItemGroup
    {
        #region プロパティ

        public string Name { get; private set; }

        #endregion

        #region コンストラクタ

        public ItemGroup(string name)
        {
            Name = name;
        }

        #endregion
    }
}
