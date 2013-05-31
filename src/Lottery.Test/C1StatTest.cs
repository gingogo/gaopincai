using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Lottery.Test
{
    using Statistics.D11X5;

    public class C1StatTest
    {
        [Test]
        public void SpanTest()
        {
            C1Stat stat = new C1Stat();
            stat.C1StatMain("shand11x5");
        }
    }
}
