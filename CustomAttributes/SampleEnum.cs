using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    public enum SampleEnum
    {
        [LocalizedDisplay(DisplayName ="Orange")]
        Oragne,
        [LocalizedDisplay(DisplayName = "Exotic Mango")]
        Mango,
        [LocalizedDisplay(DisplayName = "Tasty Banana")]
        Banana,
        [LocalizedDisplay(DisplayName = "Sweet Kiwis")]
        Kiwi
    }
}
