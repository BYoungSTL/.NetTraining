using System;

namespace NET01.Entities
{
    public class TextMaterial : TrainingMaterials
    {
        private const int TextLength = 10000;
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (value.Length > TextLength)
                {
                    throw new ArgumentException($"Text is too long!(Max length = {TextLength})");
                }

                _text = value;
            }
        }
    }
}