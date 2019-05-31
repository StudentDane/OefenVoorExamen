using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace InvoerBeveiliging.Lib.Entities
{
    public class BeveiligdeTextbox
    {
        public TextBox TeCheckenTextBox { get; set; }
        public Type DataType { get; set; }
        public int BreedteRandBijFout { get; set; }
        public bool IsGeldig { get; set; }
        public string FoutMelding { get; set; }

        public BeveiligdeTextbox(TextBox gekozenTextBox, Type gewensteDataType, int randBreedteBijFout = 3)
        {
            TeCheckenTextBox = gekozenTextBox;
            TeCheckenTextBox.BorderBrush = Brushes.Red;
            DataType = gewensteDataType;
        }

        public override string ToString()
        {
            string info;
            info = $"{TeCheckenTextBox} - {DataType}";
            return info;
        }
    }
}
