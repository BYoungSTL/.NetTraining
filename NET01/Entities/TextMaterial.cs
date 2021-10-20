using System;

namespace NET01.Entities
{
    public class TextMaterial : TrainingMaterials, IVersionable
    {
        public string Text
        {
            get => Text;
            set
            {
                if (value.Length > 10000)
                {
                    throw new ArgumentException("Text is too long!(Max length = 10000)");
                }

                Text = value;
            }
        }

    }
}