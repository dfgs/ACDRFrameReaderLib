using BigEndianReaderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDRFrameReaderLib
{
	public class ACDRReader : IACDRReader
	{
		public ACDR Read(byte[] Data)
		{
			if (Data == null) throw new ArgumentNullException(nameof(Data));
			if (Data.Length < 28) throw new ArgumentOutOfRangeException(nameof(Data));
			return Read(new BigEndianReader(Data));

		}

		public ACDR Read(IBigEndianReader Reader)
		{
			ACDRHeader header;

			byte version;
			uint timeStamp;
			ushort sequenceNumber;
			int sourceID,destID;
			byte extraData; 
			TracePoints tracePoint;
			MediaTypes mediaType;
			byte headerExtensionLength;
			SessionID sessionID;
			BoardID boardID;
			byte resetCounter;
			FullSessionID fullSessionID;

			byte[] headerExtensions;
			byte[] payload;

			if (Reader == null) throw new ArgumentNullException(nameof(Reader));

			version = Reader.ReadByte();
			timeStamp = Reader.ReadUInt32();
			sequenceNumber = Reader.ReadUInt16();
			sourceID = Reader.ReadInt32();
			destID = Reader.ReadInt32(); 
			extraData = Reader.ReadByte();

			try
			{
				tracePoint = (TracePoints)Reader.ReadByte(); 
			}
			catch (Exception)
			{
				throw new ArgumentOutOfRangeException("Invalid trace point");
			}
			try
			{
				mediaType = (MediaTypes)Reader.ReadByte(); 
			}
			catch (Exception)
			{
				throw new ArgumentOutOfRangeException("Invalid media type");
			}

			headerExtensionLength = Reader.ReadByte(); ;

			boardID = new BoardID(Reader.ReadByte(), Reader.ReadByte(), Reader.ReadByte());
			resetCounter = Reader.ReadByte();
			sessionID = new SessionID(Reader.ReadByte(), Reader.ReadByte(), Reader.ReadByte(), Reader.ReadByte(), Reader.ReadByte());
			fullSessionID = new FullSessionID(boardID, resetCounter, sessionID);

			header= new ACDRHeader(version,timeStamp,sequenceNumber,sourceID,destID,extraData,tracePoint,mediaType,headerExtensionLength);
			
			headerExtensions = Reader.ReadBytes(headerExtensionLength);
			payload = Reader.ReadBytes(Reader.Length - Reader.Position);
				//Data.Skip(28+headerExtensionLength).Take(Data.Length - 28-headerExtensionLength).ToArray();

			return new ACDR(header,fullSessionID,headerExtensions, payload);


		}




	}
}
