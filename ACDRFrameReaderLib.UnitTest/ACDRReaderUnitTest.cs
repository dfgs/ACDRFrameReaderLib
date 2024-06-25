using BigEndianReaderLib;

namespace ACDRFrameReaderLib.UnitTest
{
	[TestClass]
	public class ACDRReaderUnitTest
	{
		[TestMethod]
		public void ShouldCheckIfDataIsNull()
		{
			ACDRReader reader;

			reader = new ACDRReader();
			Assert.ThrowsException<ArgumentNullException>(() => reader.Read((byte[])null));
			Assert.ThrowsException<ArgumentNullException>(() => reader.Read((BigEndianReader)null));
		}

		[TestMethod]
		public void ShouldCheckIfDataIsTooSmall()
		{
			ACDRReader reader;

			reader = new ACDRReader();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => reader.Read(Consts.ACDRTooSmall));
		}//*/

		[TestMethod]
		public void ShouldReadACDR1()
		{
			ACDRReader reader;
			ACDR acdr;

			reader = new ACDRReader();

			acdr = reader.Read(Consts.ACDR1);
			Assert.AreEqual(9, acdr.Header.Version);
			Assert.AreEqual(2397586379, acdr.Header.TimeStamp);
			Assert.AreEqual(36323, acdr.Header.SequenceNumber);
			Assert.AreEqual(8269, acdr.Header.SourceID);
			Assert.AreEqual(8269, acdr.Header.DestID);
			Assert.AreEqual(00, acdr.Header.ExtraData);
			Assert.AreEqual(TracePoints.DspDecoder, acdr.Header.TracePoint);
			Assert.AreEqual(MediaTypes.ACDR_RTP, acdr.Header.MediaType);
			Assert.AreEqual(9, acdr.Header.HeaderExtensionLength);
			Assert.AreEqual("CD91EB:43:32054343", acdr.FullSessionID.ToString());


		}

		[TestMethod]
		public void ShouldReadACDR2()
		{
			ACDRReader reader;
			ACDR acdr;

			reader = new ACDRReader();

			acdr = reader.Read(Consts.Invite);

			// header
			Assert.AreEqual(9, acdr.Header.Version);
			Assert.AreEqual(228248349u, acdr.Header.TimeStamp);
			Assert.AreEqual(814, acdr.Header.SequenceNumber);
			Assert.AreEqual(-1, acdr.Header.SourceID);
			Assert.AreEqual(-1, acdr.Header.DestID);
			Assert.AreEqual(8, acdr.Header.ExtraData);
			Assert.AreEqual(TracePoints.System, acdr.Header.TracePoint);
			Assert.AreEqual(MediaTypes.ACDR_SIP, acdr.Header.MediaType);
			Assert.AreEqual(14, acdr.Header.HeaderExtensionLength);
			
			Assert.AreEqual("C62550:87:32", acdr.FullSessionID.ToString());


		}


		[TestMethod]
		public void ShouldReadACDR3()
		{
			ACDRReader reader;
			ACDR acdr;

			reader = new ACDRReader();

			acdr = reader.Read(Consts.RTP);

			// header
			Assert.AreEqual(9, acdr.Header.Version);
			Assert.AreEqual(231324277u, acdr.Header.TimeStamp);
			Assert.AreEqual(1049, acdr.Header.SequenceNumber);
			Assert.AreEqual(11, acdr.Header.SourceID);
			Assert.AreEqual(11, acdr.Header.DestID);
			Assert.AreEqual(0, acdr.Header.ExtraData);
			Assert.AreEqual(TracePoints.VoipDecoder, acdr.Header.TracePoint);
			Assert.AreEqual(MediaTypes.ACDR_RTP, acdr.Header.MediaType);
			Assert.AreEqual(9, acdr.Header.HeaderExtensionLength);

			Assert.AreEqual("C62550:87:32", acdr.FullSessionID.ToString());


		}










	}

}