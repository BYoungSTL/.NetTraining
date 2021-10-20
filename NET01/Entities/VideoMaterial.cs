using System;
using System.Diagnostics;

namespace NET01.Entities
{
    public class VideoMaterial : TrainingMaterials, IVersionable
    {
        private string _videoFormat;
        private byte[] _version = new byte[8];
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
                this._version = version;
            }
            else
            {
                throw new ArgumentException("Invalid version(length mismatch)");
            }
        }
    }
}