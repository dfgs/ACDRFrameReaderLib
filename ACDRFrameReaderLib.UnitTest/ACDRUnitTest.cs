using ACDRFrameReaderLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACDRFrameReaderLib.UnitTest
{
	[TestClass]
	public class ACDRUnitTest
	{
		[TestMethod]
		public void ShouldCheckIfPayloadIsNull()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new ACDR(new ACDRHeader(),new FullSessionID(new BoardID(),0,new SessionID()), Array.Empty<byte>(), null));
		}
        [TestMethod]
        public void ShouldCheckIExtensionIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ACDR(new ACDRHeader(), new FullSessionID(new BoardID(), 0, new SessionID()), null, Array.Empty<byte>()));
        }

    }
}
