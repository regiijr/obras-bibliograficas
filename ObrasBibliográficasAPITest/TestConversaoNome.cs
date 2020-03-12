using System;
using Xunit;

namespace ObrasBibliográficasAPITest
{
    public class TestConversaoNome
    {
        [Fact]
        public void ConversaoDeNomes()
        {
          
            var name = new ObrasBibliográficasAPI.Names.names();
            string result = name.nameProcessPrint("Regivaldo Dos Santos Junior");
            Assert.Equal("SANTOS JUNIOR, Regivaldo dos", result);
        }

    }
}
