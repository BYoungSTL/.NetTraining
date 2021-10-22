using System;
using System.Diagnostics;
using NET01.Interfaces;

namespace NET01.Entities
{
    public class VideoMaterial : TrainingMaterials, IVersionable
    {
        private const int VersionSize = 8;
        private string _videoFormat;
        private byte[] _version = new byte[VersionSize];
        public string UriVideo { get; set; }
        public string UriPicture { get; set; }
        public string VideoFormat
        {
            get => _videoFormat;
            set
            {
                 bool isInitFormat = false;
                 foreach (var type in Enum.GetNames(typeof(VideoFormatTypes)))
                 {
                     if (String.Equals(value, type, StringComparison.CurrentCultureIgnoreCase))
                     {
                         _videoFormat = value;
                         isInitFormat = true;
                         break;
                     }
                 }

                 if (!isInitFormat)
                 {
                     throw new ArgumentException("Invalid Video Format");
                 }
            }
        }
   
        public byte[] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte[] version)
        {
            if (version.Length == _version.Length)
            {
                for (int i = 0; i < version.Length; i++)
                {
                    _version[i] = version[i];
                }
            }
            else
            {
                throw new ArgumentException("Invalid version(length mismatch)");
            }
        }
    }
}