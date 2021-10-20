using System;

namespace NET01.Entities
{
    public class ReferenceMaterial : TrainingMaterials
    {
        private string _referenceType;
        public string UriContent { get; set; }
        public string ReferenceType
        {
            get => _referenceType;
            set
            {
                bool isInitRefType = false;
                foreach (var type in Enum.GetNames(typeof(RefTypes)))
                {
                    if (String.Equals(value, type, StringComparison.CurrentCultureIgnoreCase))
                    {
                        _referenceType = value;
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