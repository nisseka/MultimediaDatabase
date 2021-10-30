using Stndrd;
using Strings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Strings.MyString;

namespace MultimediaDatabase
{
    public class MediaInfo
    {
	string FRawDataString;
	public string VideoTrackXMLString0;
	public string AudioTrackXMLString0;
	public string GeneralTrackXMLString;
	public string MenuTrackXMLString;

	public double Duration;
	public readonly TListOfStrings RawDataStrings;
	public readonly TListOfStrings VideoTrackXMLStrings;
	public readonly TListOfStrings AudioTrackXMLStrings;
	public readonly TListOfStrings SubtitleTrackXMLStrings;

	public uint OverallBitRate;
	public uint VideoTracksCount;
	public uint AudioTracksCount;
	public uint SubtitleTracksCount;
	//	uint 		FVideoBitRate;
	//	double		FVideoFrameRate;
	public string VideoCodec;
	public string VideoResolution;
	//	uint 		FAudioBitRate;
	public uint AudioChannelCount;
	//	string 	FVideoBitRateMode;
	//	string 	FAudioBitRateMode;
	public uint AudioSampleRate;
	public uint AudioBitDepth;
	public string AudioCodec;
	//	string 	FAudioChannelLayout;
	//	string 	FAudioChannelPositions;
	public string FileFormat;
	public ulong FileSize;

	string mediainfoPrg = @"D:\Programmering\Projects\CPlusPlus\MySQL\MultimediaDatabase\MediaInfo\MediaInfo.exe";

	public string RawDataString
	{
	    get => FRawDataString;
	    set
	    {
		if (FRawDataString != value)
		{
		    FRawDataString = value;

		    string s;
		    int i, c = RawDataStrings.Split(value,"\r\n");

		    MyString.RemoveStr(ref value, "\r\n");

		    GeneralTrackXMLString = GetXMLElementContent(value, "track", "type=\"General\"");
		    MenuTrackXMLString = GetXMLElementContent(value, "track", "type=\"Menu\"");

		    FileSize = XMLElementContentDWORDLONG(GeneralTrackXMLString, "FileSize", "");
		    VideoTracksCount = XMLElementContentDWORD(GeneralTrackXMLString, "VideoCount","");
		    AudioTracksCount = XMLElementContentDWORD(GeneralTrackXMLString, "AudioCount", "");
		    SubtitleTracksCount = XMLElementContentDWORD(GeneralTrackXMLString, "TextCount", "");

		    Duration = XMLElementContentFloat(GeneralTrackXMLString, "Duration", "");
		    OverallBitRate = XMLElementContentDWORD(GeneralTrackXMLString, "OverallBitRate", "");
		    FileFormat = XMLElementContentString(GeneralTrackXMLString, "Format", "");

		    for (i = 0; i < VideoTracksCount; i++)
		    {
			s = "type=\"Video\"";
			if (VideoTracksCount > 1)
			    s += System.String.Format(" typeorder=\"{0}\"", i + 1);

			s = GetXMLElementContent(value, "track", s);
			VideoTrackXMLStrings.Add(s);
		    }
		    VideoTrackXMLString0 = VideoTrackXMLStrings[0];

		    for (i = 0; i < AudioTracksCount; i++)
		    {
			s = "type=\"Audio\"";
			if (AudioTracksCount > 1)
			    s += System.String.Format(" typeorder=\"{0}\"", i + 1);

			s = GetXMLElementContent(value, "track", s);
			AudioTrackXMLStrings.Add(s);
		    }
		    AudioTrackXMLString0 = AudioTrackXMLStrings[0];

		    for (i = 0; i < SubtitleTracksCount; i++)
		    {
			s = "type=\"Text\"";
			if (SubtitleTracksCount > 1)
			    s += System.String.Format(" typeorder=\"{0}\"", i + 1);

			s = GetXMLElementContent(value, "track", s);
			SubtitleTrackXMLStrings.Add(s);
		    }

		    if (VideoTracksCount > 0)
		    {
			//			FVideoBitRate=XMLElementContentDWORD[VideoTrackXMLString0, "BitRate", "");
			//			FVideoBitRateMode=XMLElementContentString(VideoTrackXMLString0, "BitRate_Mode", "");
			//			FVideoFrameRate=XMLElementContentFloat(VideoTrackXMLString0, "FrameRate", "");
			VideoCodec = System.String.Format("{0} ({1})", XMLElementContentString(VideoTrackXMLString0, "Format", ""), XMLElementContentString(VideoTrackXMLString0, "CodecID", ""));
			s = XMLElementContentString(VideoTrackXMLString0, "Width", "");
			if (s.Length > 0)
			{
			    VideoResolution = System.String.Format("{0} x {1}", s, XMLElementContentString(VideoTrackXMLString0, "Height", ""));
			}

		    }

		    if (AudioTracksCount > 0)
		    {
			//			FAudioBitRate=GetXMLElementContentDWORD(AudioTrackXMLString0, "BitRate", "");
			//			FAudioBitRateMode=GetXMLElementContentString(AudioTrackXMLString0, "BitRate_Mode", "");
			AudioChannelCount = XMLElementContentDWORD(AudioTrackXMLString0, "Channels", "");
			AudioSampleRate = XMLElementContentDWORD(AudioTrackXMLString0, "SamplingRate", "");
			AudioBitDepth = XMLElementContentDWORD(AudioTrackXMLString0, "BitDepth", "");

			s = XMLElementContentString(AudioTrackXMLString0, "Format_Commercial_IfAny", "");
			AudioCodec = s.Length > 0 ? s : XMLElementContentString(AudioTrackXMLString0, "Format", "");

			s = XMLElementContentString(AudioTrackXMLString0, "Format_Profile", "");
			if (s.Length > 0)
			    AudioCodec += System.String.Format(" v {0} {1}", XMLElementContentDWORD(AudioTrackXMLString0, "Format_Version", ""), s);

			//			FAudioChannelLayout=XMLElementContentString(AudioTrackXMLString0, "ChannelLayout", "");
			//			FAudioChannelPositions=XMLElementContentString(AudioTrackXMLString0, "ChannelPositions", "");
		    }
		}

	    }
	}

	public string DurationString
	{
	    get
	    {
		string r;
		TTimePrintModes tpm;

		tpm = TTimePrintModes.Hours | TTimePrintModes.Minutes | TTimePrintModes.Seconds | TTimePrintModes.Milliseconds;

		r = printf_time(Duration, tpm);

		return r;

	    }
	}
	//	Constructor..
	public MediaInfo()
	{
	    RawDataStrings = new TListOfStrings();
	    VideoTrackXMLStrings = new TListOfStrings();
	    AudioTrackXMLStrings = new TListOfStrings();
	    SubtitleTrackXMLStrings = new TListOfStrings();

	    AudioCodec = MyString.EmptyStr;
	    VideoCodec = MyString.EmptyStr;
	}

	//---------------------------------------------------------------------------
	~MediaInfo()
	{
	}

//---------------------------------------------------------------------------
	public int  ReadFromFile(string aFile)
	{
	    int r = 0;
	    TProcessParameters processParameters;

	    string programOutput;

	    r = Exec.RunProgramCatchOutput(mediainfoPrg, out programOutput, out processParameters, "--output=XML \"{0}\"", aFile);
//	    Process process = Exec.RunProgramCatchOutput(mediainfoPrg, out programOutput, "--output=XML \"{0}\"", aFile);

	    if (r > 0)
//	    if ( process is not null )
	    {
		RawDataString=programOutput;
		r = 1;
	    } else
	    {
		FRawDataString = MyString.EmptyStr;
	    }
	    return r;
	} 

//---------------------------------------------------------------------------
	public string GetXMLElementContent(string aXMLString, string aXMLElement, string aXMLElementAttributes)
	{
	    int i,i2;
	    string r = MyString.EmptyStr;

	    if (aXMLString.Length > 0)
	    {
		if (aXMLElementAttributes.Length > 0)
		{
		    aXMLElementAttributes = MyString.space + aXMLElementAttributes;
		}

		string xmlelement_starttag_str = System.String.Format("<{0}{1}>", aXMLElement, aXMLElementAttributes);
		string xmlelement_endtag_str = System.String.Format("</{0}>", aXMLElement);

		int l;
		int estsl = xmlelement_starttag_str.Length;
		int ectsl = xmlelement_endtag_str.Length;


		if ((i = aXMLString.IndexOf(xmlelement_starttag_str)) >= 0)
		{
		    i += estsl;
		    if ((i2 = aXMLString.IndexOf(xmlelement_endtag_str, i)) > 0)
		    {
			l = i2 - i;
			r = aXMLString.Substring(i, l);
			//		    str = &str3[ectsl];
		    }
		}
	    }
	    return r;
	}

//---------------------------------------------------------------------------
	public string RawDataXMLElementContentString(string XMLElement, string XMLElementAttributes)
	{
	    return  GetXMLElementContent(RawDataString, XMLElement, XMLElementAttributes);
	}

	//---------------------------------------------------------------------------
	public string XMLElementContentString(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    return  GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes);
	}

	//---------------------------------------------------------------------------
	public uint XMLElementContentDWORD(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    string s;
	    return (s = GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes)).Length > 0 ? Convert.ToUInt32(s) : 0;
	}

//---------------------------------------------------------------------------
	public ulong XMLElementContentDWORDLONG(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    string s;
	    return (s = GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes)).Length > 0 ? Convert.ToUInt64(s) : 0;
	}

	//---------------------------------------------------------------------------
	public int XMLElementContentInteger(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    string s;
	    return (s = GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes)).Length > 0 ? Convert.ToInt32(s) : 0;
	}

//---------------------------------------------------------------------------
	public	double XMLElementContentFloat(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    string s;
	    return (s = GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes)).Length > 0 ? Convert.ToDouble(s, CultureInfo.InvariantCulture) : 0;
	}

//---------------------------------------------------------------------------
	public string OverallBitRateString
	{
	    get => MyString.FormatSizeString(OverallBitRate) + "/s";
	}

	//---------------------------------------------------------------------------
	public  string VideoBitRateString(int TrackIndex)
	{
	    return  MyString.FormatSizeString(VideoBitRate(TrackIndex)) + "/s";
	}

	//---------------------------------------------------------------------------
	public string AudioBitRateString(int TrackIndex)
	{
	    return MyString.FormatSizeString(AudioBitRate(TrackIndex)) + "/s";
	}

	//---------------------------------------------------------------------------
	public string WritingApplication
	{
	    get { return XMLElementContentString(GeneralTrackXMLString, "Encoded_Application", ""); }
	}

	//---------------------------------------------------------------------------
	public uint VideoBitRate(int TrackIndex)
	{
	    string s = VideoTrackXMLStrings[TrackIndex];
	    uint r = XMLElementContentDWORD(s,"BitRate","");

	    if ( r == 0)
	    {
		r = XMLElementContentDWORD(s, "BitRate_Maximum","");
	    }

	    return r;
	}

//---------------------------------------------------------------------------
	public uint AudioBitRate(int TrackIndex)
	{
	    string s = AudioTrackXMLStrings[TrackIndex];
	    return XMLElementContentDWORD(s,"BitRate","");
	}

	//---------------------------------------------------------------------------
	public string VideoBitRateMode(int TrackIndex)
	{
	    string s = VideoTrackXMLStrings[TrackIndex];
	    return XMLElementContentString(s,"BitRate_Mode", "");
	}

	//---------------------------------------------------------------------------
	public string AudioBitRateMode(int TrackIndex)
	{
	    string s = AudioTrackXMLStrings[TrackIndex];
	    return XMLElementContentString(s,"BitRate_Mode", "");
	}

	//---------------------------------------------------------------------------
	public double VideoFrameRate(int TrackIndex)
	{
	    string s = VideoTrackXMLStrings[TrackIndex];
	    return XMLElementContentFloat(s, "FrameRate", "");
	}
	//---------------------------------------------------------------------------
	public string VideoFrameRateString(int TrackIndex)
	{
	    return VideoFrameRate(TrackIndex).ToString();
	}

	//---------------------------------------------------------------------------
	public double AspectRatio(int TrackIndex)
	{
	    string s = VideoTrackXMLStrings[TrackIndex];
	    return XMLElementContentFloat(s, "DisplayAspectRatio", "");
	}

	//---------------------------------------------------------------------------
	public string AspectRatioString(int TrackIndex)
	{
	    string r;
	    double ar = AspectRatio(TrackIndex);

	    if (ar == 1.778 || ar == 16 / 9.0)
	    {
		r = "16:9";
	    }
	    else if (ar == 1.6)
	    {
		r = "16:10";
	    }
	    else if (ar == 1.333)
	    {
		r = "4:3";
	    }
	    else if (ar == 1.666 || ar == 1.658)
	    {
		r = "5:3";
	    }
	    else if (ar == 9 / 16.0 || ar == 0.563)
	    {
		r = "9:16";
	    }
	    else
		r = System.String.Format("{0,2:F3}", ar);

	    return r;
	}

	//---------------------------------------------------------------------------
	public string AudioChannelLayout(int TrackIndex)
	{
	    string s = AudioTrackXMLStrings[TrackIndex];
	    return XMLElementContentString(s,"ChannelLayout", "");
	}

	//---------------------------------------------------------------------------
	public string AudioChannelPositions(int TrackIndex)
	{
	    string s = AudioTrackXMLStrings[TrackIndex];
	    return XMLElementContentString(s,"ChannelPositions", "");
	}

	//---------------------------------------------------------------------------
	public string ID3Artist
	{
	    get { return XMLElementContentString(GeneralTrackXMLString, "Performer", ""); }
	}

	//---------------------------------------------------------------------------
	public string ID3Title
	{
	    get { return XMLElementContentString(GeneralTrackXMLString, "Title", ""); }
	}

	//---------------------------------------------------------------------------
	public string ID3Album
	{
	    get { return XMLElementContentString(GeneralTrackXMLString, "Album", ""); }
	}

	//---------------------------------------------------------------------------
	public string ID3Genre
	{
	    get { return XMLElementContentString(GeneralTrackXMLString, "Genre", ""); }
	}

	//---------------------------------------------------------------------------
	public int ID3TrackNumber
	{
	    get { return XMLElementContentInteger(GeneralTrackXMLString, "Track_Position", ""); }
	}

	//---------------------------------------------------------------------------
	public uint ID3RecordedDate
	{
	    get
	    {
		return XMLElementContentDWORD(GeneralTrackXMLString, "Recorded_Date", "");
	    }
	}

	//---------------------------------------------------------------------------
	public ulong StreamSize
	{
	    get
	    {
		return XMLElementContentDWORDLONG(GeneralTrackXMLString, "StreamSize", "");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3Composer
	{
	    get
	    {
		return XMLElementContentString(GeneralTrackXMLString, "Composer", "");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3Publisher
	{
	    get
	    {
		return XMLElementContentString(GeneralTrackXMLString, "Publisher", "");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3EncodedBy
	{
	    get
	    {
		return XMLElementContentString(GeneralTrackXMLString, "EncodedBy", "");
	    }
	}

	//---------------------------------------------------------------------------
	public string D3Comment
	{
	    get
	    {
		return XMLElementContentString(GeneralTrackXMLString, "Copyright", "");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3Copyright
	{
	    get
	    {
		return XMLElementContentString(GeneralTrackXMLString, "Copyright", "");
	    }
	}

	//---------------------------------------------------------------------------
	public int ID3DiscNumber
	{
	    get
	    {
		return XMLElementContentInteger(GeneralTrackXMLString, "Part_Position", "");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3EncodedLibrary
	{
	    get
	    {
		return XMLElementContentString(GeneralTrackXMLString, "Encoded_Library", "");
	    }
	}

	//---------------------------------------------------------------------------
	public int ID3NumTracks
	{
	    get
	    {
		return XMLElementContentInteger(GeneralTrackXMLString, "Track_Position_Total", "");
	    }
	}

	//---------------------------------------------------------------------------
	public int ID3NumDiscs
	{
	    get { return XMLElementContentInteger(GeneralTrackXMLString, "Part_Position_Total", ""); }
	}

	//---------------------------------------------------------------------------
	public uint FrameCount
	{
	    get { return XMLElementContentDWORD(GeneralTrackXMLString, "FrameCount", ""); }
	}
    }
}
