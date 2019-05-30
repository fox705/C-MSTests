using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    public class PlayerDeflautAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[]
        {
            "PlayerDeflauts"
        };
    }

    public class PlayerHealthAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories => new[]
        {
            "PlayerHealth"
        };
    }
}