using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
  [TestClass()]
  public class SortedFloatListTests {
    [TestMethod()]
    public void AddTest() {
      bool[] tf = new bool[] { true, false };
      SortedFloatList.SortMethod[] sortMethods = new SortedFloatList.SortMethod[] {
        SortedFloatList.SortMethod.binary,
        SortedFloatList.SortMethod.selection
      };

      foreach (SortedFloatList.SortMethod sortMethod in sortMethods) {
        foreach (bool sortAscending in tf) {
          SortedFloatList list = new SortedFloatList(sortAscending, sortMethod);

          int i, j, k;

          float[] VALS = new float[] {
            810.554347922967f,17964.4851646972f,43393.3517837235f,47369.5357345684f,50678.6954220669f,21010.5229913603f,60810.8205978239f,47257.3221453367f,
            1904.6083844867f,40464.7881222446f,25285.7469479091f,51294.7841317519f,28193.3261031102f,60334.1988803367f,64982.4274233095f,30129.9071091908f,
            34518.2292817877f,37973.2249101872f,18761.096031676f,15327.2628889317f,45785.2652377094f,29324.883820461f,899.655202552909f,23718.7267607944f,
            62720.8285936138f,10404.4087696534f,54548.7838133249f,45936.6899711855f,8161.40622464976f,11385.9452642572f,31141.6000329854f,5894.9854236208f,
            3062.33011280332f,12938.0328940447f,36096.7510651371f,27091.8455358706f,55732.7750127724f,20921.5950303427f,45399.8426998454f,15840.0389490756f,
            30339.3222292005f,2373.36824378866f,58198.1815140475f,27334.5259487989f
          };

          float[] SORTED_VALS = null;

          for (i = 0; i < VALS.Length; ++i) {
            Assert.AreEqual(list.Count, i);

            list.Add(VALS[i]);

            SORTED_VALS = new float[list.Count];

            Array.Copy(VALS, SORTED_VALS, list.Count);
            if (sortAscending) {
              Array.Sort(SORTED_VALS);
            } else {
              Array.Sort(SORTED_VALS, (a, b) => b.CompareTo(a));
            }

            for (k = 0; k < list.Count; ++k) {
              Assert.AreEqual(list.Get(k), SORTED_VALS[k]);
            }
          }

          Assert.AreEqual(list.Count, SORTED_VALS.Length);
          Assert.AreEqual(list.Count, VALS.Length);
        }
      }
    }
  }
}
