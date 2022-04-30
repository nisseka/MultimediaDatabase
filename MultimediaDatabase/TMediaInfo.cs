using MediaInfoLib;
using MultimediaDatabase.Properties;
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
    public class TMediaInfo
    {
	private MediaInfo mediaInfo;

	private string FRawDataString;
	private string VideoTrackXMLString0;
	private string AudioTrackXMLString0;
	private string GeneralTrackXMLString;
	private string MenuTrackXMLString;
	private string mediaInfoString;


	public Dictionary<string,string> GeneralTrackParameters;
	public Dictionary<string,string> MenuTrackParameters;
	public List<Dictionary<string, string>> VideoTrackParameters;
	public List<Dictionary<string, string>> AudioTrackParameters;
	public List<Dictionary<string, string>> SubtitleTrackParameters;

	private readonly TListOfStrings VideoTrackXMLStrings;
	private readonly TListOfStrings AudioTrackXMLStrings;
	private readonly TListOfStrings SubtitleTrackXMLStrings;

	private Dictionary<string, string> emptyTrackParameters;
	private Dictionary<string, string> parameterDictionary;


	public double Duration;
	public readonly TListOfStrings RawDataStrings;

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

	private string audioChannelLayout;
	private string audioChannelPositions;

	private bool readFromFile;
	private bool xmlMode;

	public string RawDataString
	{
	    get => FRawDataString;
	    set
	    {
		if (FRawDataString != value)
		{
		    FRawDataString = value;

		    RawDataStrings.Split(value, "\r\n");

		    if (value.IndexOf("<?xml") >= 0)
		    {
			xmlMode = true;
			ProcessXMLOutputRawdataString(value);
		    } else
		    {
			xmlMode = false;
			ProcessTextOutputRawdataString(value);
		    }
		}
	    }
	}

	public string MediaInfoString
	{
	    get => mediaInfoString;
	    set
	    {
		if (mediaInfoString != value)
		{
		    mediaInfoString = value;
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
	public TMediaInfo()
	{
	    mediaInfo = new MediaInfo();
	    RawDataStrings = new TListOfStrings();
	    VideoTrackParameters = new List<Dictionary<string, string>>();
	    AudioTrackParameters = new List<Dictionary<string, string>>();
	    SubtitleTrackParameters = new List<Dictionary<string, string>>();
	    emptyTrackParameters = new Dictionary<string, string>();
	    parameterDictionary = new Dictionary<string, string>();
	    VideoTrackXMLStrings = new TListOfStrings();
	    AudioTrackXMLStrings = new TListOfStrings();
	    SubtitleTrackXMLStrings = new TListOfStrings();

	    AudioCodec = string.Empty;
	    VideoCodec = string.Empty;
	    mediaInfoString = string.Empty;

	    // Add parameter translators:
	    // Read from resource file MediaInfoParameterDictionary.txt
	    TListOfStrings parDictStrings = new TListOfStrings(Resources.MediaInfoParameterDictionary, "\r\n");

	    int count = parDictStrings.Count;
	    TString strObj;

	    for (int i = 0; i < count; i++)
	    {
		strObj = parDictStrings.StringObject(i);
		parameterDictionary.Add(strObj.Name, strObj.Value);
	    }
/*
	    parameterDictionary.Add("FileSize", "File size");
	    parameterDictionary.Add("OverallBitRate", "Overall bit rate");
	    parameterDictionary.Add("OverallBitRateMode", "Overall bit rate mode");
	    parameterDictionary.Add("BitDepth", "Bit depth");
	    parameterDictionary.Add("BitRate", "Bit rate");
	    parameterDictionary.Add("DisplayAspectRatio", "Display aspect ratio");
	    parameterDictionary.Add("FrameRateMode", "Frame rate mode");
	    parameterDictionary.Add("FrameRate", "Frame rate");
	    parameterDictionary.Add("Encoded_Application", "Writing application");
*/
	}

//---------------------------------------------------------------------------
	~TMediaInfo()
	{
	}

//---------------------------------------------------------------------------
/// <summary>
///	Reads media info from the file pointed to by string aFile
/// </summary>
/// <param name="aFile">The file to read media info from</param>
/// <returns>
///	1 if successful, 0 if unsuccessful.
/// </returns>

	public int  ReadFromFile(string aFile)
	{
	    string str;
	    int r = 0;

	    r = mediaInfo.Open(aFile);

	    if (r > 0)
	    {
		readFromFile = true;

		mediaInfo.Option("Output", string.Empty);
		mediaInfoString = mediaInfo.Inform();

		FileSize = ParameterDWORDLONG(StreamKind.General, "FileSize");
		VideoTracksCount = ParameterDWORD(StreamKind.General, "VideoCount");
		AudioTracksCount = ParameterDWORD(StreamKind.General, "AudioCount");
		SubtitleTracksCount = ParameterDWORD(StreamKind.General, "TextCount");
		Duration = ParameterFloat(StreamKind.General, "Duration");
		OverallBitRate = ParameterDWORD(StreamKind.General, "OverallBitRate");
		FileFormat = mediaInfo.Get(StreamKind.General, 0, "Format");

		Duration /= 1000.0;

		mediaInfo.Option("Output", "XML");
		RawDataString = mediaInfo.Inform();

		if (VideoTracksCount > 0)
		{
/*
		    FVideoBitRate = Convert.ToUInt32(mediaInfo.Get(StreamKind.Video, 0, "BitRate"));
		    FVideoBitRateMode = Convert.ToUInt32(mediaInfo.Get(StreamKind.Video, 0, "BitRate_Mode"));
		    FVideoFrameRate = Convert.ToDouble(mediaInfo.Get(StreamKind.Video, 0, "FrameRate"));
*/
		    VideoCodec = System.String.Format("{0} ({1})", mediaInfo.Get(StreamKind.Video,0,"Format"), mediaInfo.Get(StreamKind.Video, 0, "CodecID"));
		    str = mediaInfo.Get(StreamKind.Video, 0, "Width");

		    if (str.Length > 0)
		    {
			VideoResolution = System.String.Format("{0} x {1}", str, mediaInfo.Get(StreamKind.Video, 0, "Height"));
		    }

		}

		if (AudioTracksCount > 0)
		{
/*
    		    FAudioBitRate = Convert.ToUInt32(mediaInfo.Get(StreamKind.Audio, 0, "BitRate"));
		    FAudioBitRateMode = mediaInfo.Get(StreamKind.Audio, 0, "BitRate_Mode"));
*/
		    AudioChannelCount = ParameterDWORD(StreamKind.Audio, "Channels");
		    AudioSampleRate = ParameterDWORD(StreamKind.Audio, "SamplingRate");
		    AudioBitDepth = ParameterDWORD(StreamKind.Audio, "BitDepth");

		    str = mediaInfo.Get(StreamKind.Audio, 0, "Format_Commercial_IfAny");
		    AudioCodec = str.Length > 0 ? str : mediaInfo.Get(StreamKind.Audio, 0, "Format");

		    str = mediaInfo.Get(StreamKind.Audio, 0, "Format_Profile");
		    if (str.Length > 0)
			AudioCodec += System.String.Format(" v {0} {1}", mediaInfo.Get(StreamKind.Audio, 0, "Format_Version"), str);

		    audioChannelLayout = mediaInfo.Get(StreamKind.Audio, 0, "ChannelLayout");
		    audioChannelPositions = mediaInfo.Get(StreamKind.Audio, 0, "ChannelPositions");
		}

		r = 1;
//		mediaInfo.Close();
	    }
	    else
	    {
		FRawDataString = string.Empty;
	    }

	    return r;
	}

	public void CloseFile()
	{
	    mediaInfo.Close();
	    readFromFile = false;
	}

	public bool ProcessXMLOutputRawdataString(string xmlRawDataString)
	{
	    int i;
	    string str;

	    MyString.RemoveStr(ref xmlRawDataString, "\r\n");

	    GeneralTrackXMLString = GetXMLElementContent(xmlRawDataString, "track", "type=\"General\"");
	    MenuTrackXMLString = GetXMLElementContent(xmlRawDataString, "track", "type=\"Menu\"");

	    if (readFromFile == false)
	    {
		FileSize = XMLElementContentDWORDLONG(GeneralTrackXMLString, "FileSize", "");
		VideoTracksCount = XMLElementContentDWORD(GeneralTrackXMLString, "VideoCount", "");
		AudioTracksCount = XMLElementContentDWORD(GeneralTrackXMLString, "AudioCount", "");
		SubtitleTracksCount = XMLElementContentDWORD(GeneralTrackXMLString, "TextCount", "");

		Duration = XMLElementContentFloat(GeneralTrackXMLString, "Duration", "");
		OverallBitRate = XMLElementContentDWORD(GeneralTrackXMLString, "OverallBitRate", "");
		FileFormat = XMLElementContentString(GeneralTrackXMLString, "Format", "");
	    }

	    for (i = 0; i < VideoTracksCount; i++)
	    {
		str = "type=\"Video\"";
		if (VideoTracksCount > 1)
		    str += System.String.Format(" typeorder=\"{0}\"", i + 1);

		str = GetXMLElementContent(xmlRawDataString, "track", str);
		VideoTrackXMLStrings.Add(str);
	    }
	    VideoTrackXMLString0 = VideoTrackXMLStrings[0];

	    for (i = 0; i < AudioTracksCount; i++)
	    {
		str = "type=\"Audio\"";
		if (AudioTracksCount > 1)
		    str += System.String.Format(" typeorder=\"{0}\"", i + 1);

		str = GetXMLElementContent(xmlRawDataString, "track", str);
		AudioTrackXMLStrings.Add(str);
	    }
	    AudioTrackXMLString0 = AudioTrackXMLStrings[0];

	    for (i = 0; i < SubtitleTracksCount; i++)
	    {
		str = "type=\"Text\"";
		if (SubtitleTracksCount > 1)
		    str += System.String.Format(" typeorder=\"{0}\"", i + 1);

		str = GetXMLElementContent(xmlRawDataString, "track", str);
		SubtitleTrackXMLStrings.Add(str);
	    }

	    if (readFromFile == false)
	    {
		if (VideoTracksCount > 0)
		{
		    //			FVideoBitRate=XMLElementContentDWORD[VideoTrackXMLString0, "BitRate", "");
		    //			FVideoBitRateMode=XMLElementContentString(VideoTrackXMLString0, "BitRate_Mode", "");
		    //			FVideoFrameRate=XMLElementContentFloat(VideoTrackXMLString0, "FrameRate", "");
		    VideoCodec = System.String.Format("{0} ({1})", XMLElementContentString(VideoTrackXMLString0, "Format", ""), XMLElementContentString(VideoTrackXMLString0, "CodecID", ""));
		    str = XMLElementContentString(VideoTrackXMLString0, "Width", "");
		    if (str.Length > 0)
		    {
			VideoResolution = System.String.Format("{0} x {1}", str, XMLElementContentString(VideoTrackXMLString0, "Height", ""));
		    }

		}

		if (AudioTracksCount > 0)
		{
		    //			FAudioBitRate=GetXMLElementContentDWORD(AudioTrackXMLString0, "BitRate", "");
		    //			FAudioBitRateMode=GetXMLElementContentString(AudioTrackXMLString0, "BitRate_Mode", "");
		    AudioChannelCount = XMLElementContentDWORD(AudioTrackXMLString0, "Channels", "");
		    AudioSampleRate = XMLElementContentDWORD(AudioTrackXMLString0, "SamplingRate", "");
		    AudioBitDepth = XMLElementContentDWORD(AudioTrackXMLString0, "BitDepth", "");

		    str = XMLElementContentString(AudioTrackXMLString0, "Format_Commercial_IfAny", "");
		    AudioCodec = str.Length > 0 ? str : XMLElementContentString(AudioTrackXMLString0, "Format", "");

		    str = XMLElementContentString(AudioTrackXMLString0, "Format_Profile", "");
		    if (str.Length > 0)
			AudioCodec += System.String.Format(" v {0} {1}", XMLElementContentDWORD(AudioTrackXMLString0, "Format_Version", ""), str);

		    //			FAudioChannelLayout=XMLElementContentString(AudioTrackXMLString0, "ChannelLayout", "");
		    //			FAudioChannelPositions=XMLElementContentString(AudioTrackXMLString0, "ChannelPositions", "");
		}
	    }
	    return true;
	}

	public bool ProcessTextOutputRawdataString(string aString)
	{
	    int i, i2, i3, lineCount;
	    string lineStr, str;
	    string key, keyvalue;
	    Dictionary<string, string> trackPars;

	    lineCount = RawDataStrings.Count;
	    for (i = 0; i < lineCount;)
	    {
		lineStr = RawDataStrings[i];
		if (lineStr.Length == 0)
		{
		    i++;
		    continue;
		}

		for (i2 = i; i2 < lineCount && RawDataStrings[i2].Length > 0; i2++) ;

		trackPars = new Dictionary<string, string>();

		for (i3 = i + 1; i3 < i2; i3++)
		{
		    str = RawDataStrings[i3];
		    key = str.Substring(0, 41).Trim();
		    keyvalue = str.Substring(43);

		    trackPars.Add(key, keyvalue);
		}

		if (lineStr == "General")
		{
		    GeneralTrackParameters = trackPars;
		}
		else
		if (lineStr == "Video")
		{
		    VideoTrackParameters.Add(trackPars);
		}
		else
		if (lineStr == "Audio")
		{
		    AudioTrackParameters.Add(trackPars);
		}
		else
		if (lineStr == "Text")
		{
		    SubtitleTrackParameters.Add(trackPars);
		}
		else
		if (lineStr == "Menu")
		{
		    MenuTrackParameters = trackPars;
		}

		i = i2 + 1;
	    }

	    if (GeneralTrackParameters == null)
	    {
		GeneralTrackParameters = new Dictionary<string, string>();
	    }
	    if (MenuTrackParameters == null)
	    {
		MenuTrackParameters = new Dictionary<string, string>();
	    }

	    if (readFromFile == false)
	    {
		VideoTracksCount = (uint)VideoTrackParameters.Count;
		AudioTracksCount = (uint)AudioTrackParameters.Count;
		SubtitleTracksCount = (uint)SubtitleTrackParameters.Count;
	    }
	    return true;
	}

	public string ParameterString(StreamKind StreamKind, string Parameter, int StreamNumber = 0)
	{
	    string str, key;
	    if (readFromFile == false)
	    {
		if (xmlMode)
		{
		    switch (StreamKind)
		    {
			case StreamKind.General:
			    key = GeneralTrackXMLString;
			    break;
			case StreamKind.Video:
			    key = VideoTrackXMLStrings[StreamNumber];
			    break;
			case StreamKind.Audio:
			    key = AudioTrackXMLStrings[StreamNumber];
			    break;
			case StreamKind.Text:
			    key = SubtitleTrackXMLStrings[StreamNumber];
			    break;
			case StreamKind.Menu:
			    key = MenuTrackXMLString;
			    break;
			default:
			    key = string.Empty;
			    break;
		    }
		    str = GetXMLElementContent(key, Parameter, string.Empty);
		} else
		{
		    Dictionary<string, string> trackPars;
		    switch (StreamKind)
		    {
			case StreamKind.General:
			    trackPars = GeneralTrackParameters;
			    break;
			case StreamKind.Video:
			    trackPars = VideoTrackParameters[StreamNumber];
			    break;
			case StreamKind.Audio:
			    trackPars = AudioTrackParameters[StreamNumber];
			    break;
			case StreamKind.Text:
			    trackPars = SubtitleTrackParameters[StreamNumber];
			    break;
			case StreamKind.Menu:
			    trackPars = MenuTrackParameters;
			    break;
			default:
			    trackPars = emptyTrackParameters;
			    break;
		    }

		    if (parameterDictionary.ContainsKey(Parameter))
		    {
			key = parameterDictionary[Parameter];
		    }
		    else
			key = Parameter;

		    str = trackPars.ContainsKey(key) ? trackPars[key] : string.Empty;
		}
	    } else
		str = mediaInfo.Get(StreamKind, StreamNumber, Parameter);

	    return str;
	}

	public uint ParameterDWORD(StreamKind StreamKind, string Parameter, int StreamNumber = 0)
	{
	    string str = ParameterString(StreamKind, Parameter, StreamNumber);

	    return str.Length > 0 ? Convert.ToUInt32(str) : 0;
	}

	//---------------------------------------------------------------------------
	public ulong ParameterDWORDLONG(StreamKind StreamKind, string Parameter, int StreamNumber = 0)
	{
	    string str = ParameterString(StreamKind, Parameter, StreamNumber);
	    return str.Length > 0 ? Convert.ToUInt64(str) : 0;
	}

	//---------------------------------------------------------------------------
	public int ParameterInteger(StreamKind StreamKind, string Parameter, int StreamNumber = 0)
	{
	    string str = ParameterString(StreamKind, Parameter, StreamNumber);
	    return str.Length > 0 ? Convert.ToInt32(str) : 0;
	}

	//---------------------------------------------------------------------------
	public double ParameterFloat(StreamKind StreamKind, string Parameter, int StreamNumber = 0)
	{
	    string str = ParameterString(StreamKind, Parameter, StreamNumber);
	    return str.Length > 0 ? Convert.ToDouble(str, CultureInfo.InvariantCulture) : 0;
	}

	//---------------------------------------------------------------------------
	public string OverallBitRateString
	{
	    get => FormatBitRateString(OverallBitRate);
	}

//---------------------------------------------------------------------------
	public  string VideoBitRateString(int TrackIndex)
	{
	    return  FormatBitRateString(VideoBitRate(TrackIndex));
	}

//---------------------------------------------------------------------------
	public string AudioBitRateString(int TrackIndex)
	{
	    return  FormatBitRateString(AudioBitRate(TrackIndex));
	}

//---------------------------------------------------------------------------
	public string WritingApplication
	{
	    get { return ParameterString(StreamKind.General, "Encoded_Application"); }
	}

//---------------------------------------------------------------------------
	public uint VideoBitRate(int TrackIndex)
	{
	    uint bitrate = ParameterDWORD(StreamKind.Video, "BitRate", TrackIndex);
	    if (bitrate == 0)
	    {
		bitrate = ParameterDWORD(StreamKind.Video, "BitRate_Maximum", TrackIndex);
	    }
	    return bitrate;
	}

//---------------------------------------------------------------------------
	public uint AudioBitRate(int TrackIndex)
	{
	    uint bitrate = ParameterDWORD(StreamKind.Audio, "BitRate", TrackIndex);
	    if (bitrate == 0)
	    {
		bitrate = ParameterDWORD(StreamKind.Audio, "BitRate_Maximum", TrackIndex);
	    }
	    return bitrate;
	}

	//---------------------------------------------------------------------------
	public string VideoBitRateMode(int TrackIndex)
	{
	    return ParameterString(StreamKind.Video, "BitRate_Mode", TrackIndex);
	}

	//---------------------------------------------------------------------------
	public string AudioBitRateMode(int TrackIndex)
	{
	    return ParameterString(StreamKind.Audio, "BitRate_Mode", TrackIndex);
	}

	//---------------------------------------------------------------------------
	public double VideoFrameRate(int TrackIndex)
	{
	    return ParameterFloat(StreamKind.Video,"FrameRate", TrackIndex);
	}
	//---------------------------------------------------------------------------
	public string VideoFrameRateString(int TrackIndex)
	{
	    return ParameterString(StreamKind.Video, "FrameRate", TrackIndex);
	}

	//---------------------------------------------------------------------------
	public double AspectRatio(int TrackIndex)
	{
	    return ParameterFloat(StreamKind.Video, "DisplayAspectRatio", TrackIndex);
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
		r = System.String.Format(CultureInfo.InvariantCulture,"{0,2:F3}", ar);

	    return r;
	}

	//---------------------------------------------------------------------------
	public string AudioChannelLayout(int TrackIndex)
	{
	    return ParameterString(StreamKind.Audio, "ChannelLayout", TrackIndex);
	}

	//---------------------------------------------------------------------------
	public string AudioChannelPositions(int TrackIndex)
	{
	    return ParameterString(StreamKind.Audio, "ChannelPositions", TrackIndex);
	}

	//---------------------------------------------------------------------------
	public string ID3Artist
	{
	    get { return ParameterString(StreamKind.General, "Performer"); }
	}

	//---------------------------------------------------------------------------
	public string ID3Title
	{
	    get { return ParameterString(StreamKind.General, "Title"); }
	}

	//---------------------------------------------------------------------------
	public string ID3Album
	{
	    get { return ParameterString(StreamKind.General, "Album"); }
	}

	//---------------------------------------------------------------------------
	public string ID3Genre
	{
	    get { return ParameterString(StreamKind.General, "Genre"); }
	}

	//---------------------------------------------------------------------------
	public int ID3TrackNumber
	{
	    get { return ParameterInteger(StreamKind.General, "Track_Position"); }
	}

	//---------------------------------------------------------------------------
	public uint ID3RecordedDate
	{
	    get
	    {
		return ParameterDWORD(StreamKind.General, "Recorded_Date");
	    }
	}

	//---------------------------------------------------------------------------
	public ulong StreamSize
	{
	    get
	    {
		return ParameterDWORDLONG(StreamKind.General, "StreamSize");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3Composer
	{
	    get
	    {
		return ParameterString(StreamKind.General, "Composer");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3Publisher
	{
	    get
	    {
		return ParameterString(StreamKind.General, "Publisher");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3EncodedBy
	{
	    get
	    {
		return ParameterString(StreamKind.General,"EncodedBy");
	    }
	}

	//---------------------------------------------------------------------------
	public string D3Comment
	{
	    get
	    {
		return ParameterString(StreamKind.General, "Copyright");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3Copyright
	{
	    get
	    {
		return ParameterString(StreamKind.General, "Copyright");
	    }
	}

	//---------------------------------------------------------------------------
	public int ID3DiscNumber
	{
	    get
	    {
		return ParameterInteger(StreamKind.General, "Part_Position");
	    }
	}

	//---------------------------------------------------------------------------
	public string ID3EncodedLibrary
	{
	    get
	    {
		return ParameterString(StreamKind.General, "Encoded_Library");
	    }
	}

	//---------------------------------------------------------------------------
	public int ID3NumTracks
	{
	    get
	    {
		return ParameterInteger(StreamKind.General, "Track_Position_Total");
	    }
	}

	//---------------------------------------------------------------------------
	public int ID3NumDiscs
	{
	    get { return ParameterInteger(StreamKind.General, "Part_Position_Total"); }
	}

	//---------------------------------------------------------------------------
	public uint FrameCount
	{
	    get { return ParameterDWORD(StreamKind.General, "FrameCount"); }
	}

	//---------------------------------------------------------------------------
	private string GetXMLElementContent(string aXMLString, string aXMLElement, string aXMLElementAttributes)
	{
	    int i, i2;
	    string r = string.Empty;

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
	private string RawDataXMLElementContentString(string XMLElement, string XMLElementAttributes)
	{
	    return GetXMLElementContent(RawDataString, XMLElement, XMLElementAttributes);
	}

	//---------------------------------------------------------------------------
	private string XMLElementContentString(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    return GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes);
	}

	//---------------------------------------------------------------------------
	private uint XMLElementContentDWORD(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    string s;
	    return (s = GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes)).Length > 0 ? Convert.ToUInt32(s) : 0;
	}

	//---------------------------------------------------------------------------
	private ulong XMLElementContentDWORDLONG(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    string s;
	    return (s = GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes)).Length > 0 ? Convert.ToUInt64(s) : 0;
	}

	//---------------------------------------------------------------------------
	private int XMLElementContentInteger(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    string s;
	    return (s = GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes)).Length > 0 ? Convert.ToInt32(s) : 0;
	}

	//---------------------------------------------------------------------------
	private double XMLElementContentFloat(string XMLString, string XMLElement, string XMLElementAttributes)
	{
	    string s;
	    return (s = GetXMLElementContent(XMLString, XMLElement, XMLElementAttributes)).Length > 0 ? Convert.ToDouble(s, CultureInfo.InvariantCulture) : 0;
	}
    }
}
