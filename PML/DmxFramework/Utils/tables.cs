using System;
using System.Collections.Generic;
using System.Text;

namespace DmxFramework.Utils
{
    public class tables
    {
        public static object[] RemoveFromTab(object[] pTable, int pIndex)
        {
            if (pIndex >= pTable.Length)
                return null;

            int IndexInNewTable = 0;
            object[] NewTable = new object[pTable.Length - 1];

            for (int i = 0; i < pTable.Length; i++)
            {
                if (i == pIndex)
                    continue;

                NewTable[IndexInNewTable] = pTable[i];
                IndexInNewTable++;
            }

            return NewTable;
        }

        public static int[] RemoveFromTab(int[] pTable, int pIndex)
        {
            if (pIndex >= pTable.Length)
                return null;

            int IndexInNewTable = 0;
            int[] NewTable = new int[pTable.Length - 1];

            for (int i = 0; i < pTable.Length; i++)
            {
                if (i == pIndex)
                    continue;

                NewTable[IndexInNewTable] = pTable[i];
                IndexInNewTable++;
            }

            return NewTable;
        }
    }
}
