using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDRFrameReaderLib
{
	public enum TracePoints { Net2Dsp = 0, Dsp2Net = 1, Dsp2Host = 2, Host2Dsp = 3, Net2Host = 4, Host2Net = 5, System = 6, Dsp2Dsp = 7, Net2Net = 8, Dsp2Tdm = 9, Tdm2Dsp = 10, Np2Dsp = 11, Dsp2Np = 12, Host2Np = 13, Np2Host = 14, acUnknown = 15, Net = 16, P2P = 17, DspDecoder = 18, DspEncoder = 19, VoipDecoder = 20, VoipEncoder = 21, NetEncoder = 22, P2PDecoder = 23, P2PEncoder = 24, Host2Pstn = 25, Pstn2Host = 26, Net2DspPing = 27, Dsp2NetPing = 28, Src2Dest = 29, Addr2Addr = 30, GeneralSystem = 31, AllMedia = 32, DspIncoming = 33, DspOutgoing = 34, AfterSrtpDecoder = 35 }
	public enum MediaTypes { ACDR_DSP_AC49X = 0, ACDR_RTP = 1, ACDR_RTCP = 2, ACDR_T38 = 3, ACDR_Event = 4, ACDR_Info = 5, ACDR_VoiceAI = 6, ACDR_NotUse1 = 7, ACDR_NotUse2 = 8, ACDR_NotUse3 = 9, ACDR_SIP = 10, ACDR_MEGACO = 11, ACDR_MGCP = 12, ACDR_TPNCP = 13, ACDR_Control = 14, ACDR_PCM = 15, ACDR_NP_CONTROL = 16, ACDR_NP_DATA = 17, ACDR_DSP_AC45X = 18, ACDR_DSP_AC48X = 19, ACDR_HA = 20, ACDR_CAS = 21, ACDR_NET_BRICKS = 22, ACDR_COMMAND = 23, ACDR_VIDEORTP = 24, ACDR_VIDEORTCP = 25, ACDR_PCIIF_COMMAND = 26, ACDR_GWAPPSYSLOG = 27, ACDR_V1501 = 28, ACDR_DSP_AC5X = 29, ACDR_TLS = 30, ACDR_TLSPeek = 31, ACDR_DSP_AC5X_MII = 32, ACDR_NATIVE = 33, ACDR_SIGNALING = 34, ACDR_FRAGMENTED = 35, ACDR_QOE_CDR = 36, ACDR_QOE_MDR = 37, ACDR_QOE_EVENT = 38, ACDR_DSP_TDM_PLAYBACK = 39, ACDR_DSP_NET_PLAYBACK = 40, ACDR_DSP_DATA_RELAY = 41, ACDR_DSP_SNIFFER = 42, ACDR_RTP_AMR = 43, ACDR_RTP_EVRC = 44, ACDR_RTP_RFC2198 = 45, ACDR_RTP_RFC2833 = 46, ACDR_T38_OVER_RTP = 47, ACDR_RTP_FEC = 48, ACDR_RTP_FAX_BYPASS = 49, ACDR_RTP_MODEM_BYPASS = 50, ACDR_RTP_NSE = 51, ACDR_RTP_NO_OP = 52, ACDR_DTLS = 53 }

}
