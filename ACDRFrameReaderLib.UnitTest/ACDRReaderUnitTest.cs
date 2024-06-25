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


			/*

			// SenderInfo
			Assert.AreEqual(3901249035u, acdr.SenderInfo.NTPTimeStampIntegerPart);
			Assert.AreEqual(3012348327u, acdr.SenderInfo.NTPTimeStampFractionalPart);
			Assert.AreEqual(44812u, acdr.SenderInfo.RTPTimeStamp);
			Assert.AreEqual(247u, acdr.SenderInfo.SenderPacketCount);
			Assert.AreEqual(39520u, acdr.SenderInfo.SenderOctetCount);

			// ReceptionReport
			Assert.AreEqual(1, acdr.ReceptionReports.Length);
			Assert.AreEqual(2571709637u, acdr.ReceptionReports[0].SSRC);
			Assert.AreEqual(0, acdr.ReceptionReports[0].FractionLost);
			Assert.AreEqual(0u, acdr.ReceptionReports[0].CumulatedPacketLost);
			Assert.AreEqual(0u, acdr.ReceptionReports[0].SequenceNumberCycles);
			Assert.AreEqual(2173u, acdr.ReceptionReports[0].HighestSequenceNumberReceived);
			Assert.AreEqual(4u, acdr.ReceptionReports[0].InterarrivalJitter);
			Assert.AreEqual(0u, acdr.ReceptionReports[0].LastSRTimeStamp);
			Assert.AreEqual(0u, acdr.ReceptionReports[0].DelaySinceLastSRTimeStamp);
			//*/
		}


	}

}