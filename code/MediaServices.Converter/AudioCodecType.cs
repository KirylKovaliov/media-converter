using System.ComponentModel;

namespace MediaServices.Converter
{
    public enum AudioCodecType
    {
        [Description("libvorbis")]
        Ogg,
        [Description("libmp3lame")]
        Mp3,
        [Description("copy")]
        Copy,
    }
}
