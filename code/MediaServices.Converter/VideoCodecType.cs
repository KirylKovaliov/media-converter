using System.ComponentModel;

namespace MediaServices.Converter
{
    public enum VideoCodecType
    {
        [Description("libtheora")]
        Theora,

        [Description("libx264")]
        H254,

        [Description("flv")]
        Flash,

        [Description("libvpx")]
        VP8,
    }
}
