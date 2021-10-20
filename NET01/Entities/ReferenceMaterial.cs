using System;

namespace NET01.Entities
{
    public class ReferenceMaterial : TrainingMaterials, IVersionable
    {
        private static readonly string[] RefTypes = {"unknown", "html", "image", "audio", "video"};
        public string URIContent { get; set; }
        public string ReferenceType
        {
            get => ReferenceType;
            set
            {
                bool isInitRefType = false;
                foreach (var type in RefTypes)
                {
                    if (value.ToLower() == type)
                    {
                        ReferenceType = value;
                        isInitRefType = true;
                        break;
                    }
                }

                if (!isInitRefType)
                {
                    throw new ArgumentException("Invalid Reference Type");
                }   
            }
            
        }
        
    }
}