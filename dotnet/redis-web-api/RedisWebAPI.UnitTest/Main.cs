using System;
using Xunit;

namespace RedisWebAPI.UnitTest
{
    public class Main
    {
        [Fact]
        public void CheerUp()
        {
            Assert.Equal("😸", "😸");
        }
    }
}
