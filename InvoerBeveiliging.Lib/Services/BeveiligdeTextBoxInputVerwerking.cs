using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using InvoerBeveiliging.Lib.Entities;

namespace InvoerBeveiliging.Lib.Services
{
    class BeveiligdeTextBoxInputVerwerking
    {
        public List<BeveiligdeTextbox> BeveiligdeTextboxes { get; set; }
        public string Foutmeldingen { get; set; }
        public bool AlleInputIsCorrect { get; set; }
        public object Foutmelder { get; set; }
        public Button AfHankelijkeKnop { get; set; }
        int decimaalTeken;

        public BeveiligdeTextBoxInputVerwerking()
        {
            BeveiligdeTextboxes = new List<BeveiligdeTextbox>();
            BepaalDecimaalTeken();
        }

        public BeveiligdeTextBoxInputVerwerking(object foutmelder, Button afhankelijkeKnop): this()
        {
            Foutmelder = foutmelder;
            AfHankelijkeKnop = afhankelijkeKnop;
        }

        public void VoegBeveiligdeTextBoxToe(BeveiligdeTextbox beveiligdeTextbox)
        {
            beveiligdeTextbox.TeCheckenTextBox.TextChanged += TextBoxChanged;
            BeveiligdeTextboxes.Add(beveiligdeTextbox);

        }


        private void BepaalDecimaalTeken()
        {
            throw new NotImplementedException();
        }

        public void TextBoxTextChanged(object sender, RoutedEventArgs e)
        {
            BeveiligdeTextbox beveiligdeTextbox;
            TextBox textBox = new TextBox();
            textBox = (TextBox)sender;
            beveiligdeTextbox = ZoekBeveiligdeTextBox(textBox);

            beveiligdeTextbox.FoutMelding = IsGeldigGetal(beveiligdeTextbox.TeCheckenTextBox, beveiligdeTextbox.DataType);
            if (beveiligdeTextbox.FoutMelding == "")
            {
                beveiligdeTextbox.IsGeldig = true;
            }
            else
            {
                beveiligdeTextbox.IsGeldig = false;
            }
            BeveiligdeTextBoxInputVerwerking.MarkeerTextBox(beveiligdeTextbox.TeCheckenTextBox, beveiligdeTextbox.IsGeldig);
            EvalueerFouten();
            ToonFout();
            BeheerAfhankelijkeKnop();
        }

        private string IsGeldigGetal(TextBox teCheckenTextBox, Type dataType)
        {
            throw new NotImplementedException();
        }

        private BeveiligdeTextbox ZoekBeveiligdeTextBox(TextBox textBox)
        {
            throw new NotImplementedException();
        }

        private void BeheerAfhankelijkeKnop()
        {
            throw new NotImplementedException();
        }

        private void ToonFout()
        {
            throw new NotImplementedException();
        }

        private void EvalueerFouten()
        {
            throw new NotImplementedException();
        }

        private static void MarkeerTextBox(TextBox teCheckenTextBox, bool isGeldig)
        {
            throw new NotImplementedException();
        }
    }
}
