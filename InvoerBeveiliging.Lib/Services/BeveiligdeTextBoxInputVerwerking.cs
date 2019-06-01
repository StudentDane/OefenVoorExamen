using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using InvoerBeveiliging.Lib.Entities;

namespace InvoerBeveiliging.Lib.Services
{
    class BeveiligdeTextBoxInputVerwerking
    {
        public List<BeveiligdeTextbox> BeveiligdeTextboxes { get; set; }
        public string Foutmeldingen { get; set; }
        public bool AlleInputCorrect { get; set; }
        public object Foutmelder { get; set; }
        public Button AfhankelijkeKnop { get; set; }
        string decimaalTeken;

        public BeveiligdeTextBoxInputVerwerking()
        {
            BeveiligdeTextboxes = new List<BeveiligdeTextbox>();
            BepaalDecimaalTeken();
        }

        public BeveiligdeTextBoxInputVerwerking(object foutmelder, Button afhankelijkeKnop): this()
        {
            Foutmelder = foutmelder;
            AfhankelijkeKnop = afhankelijkeKnop;
        }

        public void VoegBeveiligdeTextBoxToe(BeveiligdeTextbox beveiligdeTextbox)
        {
            beveiligdeTextbox.TeCheckenTextBox.TextChanged += TextBoxTextChanged;
            BeveiligdeTextboxes.Add(beveiligdeTextbox);
        }

        BeveiligdeTextbox ZoekBeveiligdeTextBox(TextBox textBox)
        {
            BeveiligdeTextbox gezocht = null;
            foreach (BeveiligdeTextbox beveiligdeTextbox in BeveiligdeTextboxes)
            {
                if (beveiligdeTextbox.TeCheckenTextBox == textBox)
                {
                    gezocht = beveiligdeTextbox;
                }
            }
            return gezocht;
        }


        private void BepaalDecimaalTeken()
        {
            float testGetal = 0F;
            string testGetalString = testGetal.ToString("0.0");
            decimaalTeken = testGetalString.Substring(1, 1);
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

        public static string IsGeldigGetal(TextBox teCheckenTextBox, Type dataType)
        {
            string gepasteFoutmelding = "";
            string getal;
            string typeNaam = "";
            getal = teCheckenTextBox.Text;
            try
            {
                switch (dataType.Name)
                {
                    case nameof(Int32):
                        typeNaam = "geheel getal";
                        int.Parse(getal);
                        break;
                    case nameof(Int64):
                        typeNaam = "geheel getal";
                        int.Parse(getal);
                        break;
                    case nameof(Single):
                        typeNaam = "kommagetal";
                        float.Parse(getal);
                        break;
                    case nameof(Double):
                        typeNaam = "kommagetal";
                        float.Parse(getal);
                        break;
                    case nameof(Decimal):
                        typeNaam = "decimaal getal";
                        decimal.Parse(getal);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

                gepasteFoutmelding = $"{getal} is geen geldig {typeNaam}";
            }
            return gepasteFoutmelding;
        }

        public void BeheerAfhankelijkeKnop()
        {
            if (AlleInputCorrect) AfhankelijkeKnop.IsEnabled = true;
            else AfhankelijkeKnop.IsEnabled = false;
        }

        public void ToonFout()
        {
            if (Foutmelder is TextBlock)
            {
                TextBlock textBlock = (TextBlock)Foutmelder;
                textBlock.Text = Foutmeldingen;
            }
            else if (Foutmelder is Label)
            {
                Label label = (Label)Foutmelder;
                label.Content = Foutmeldingen;
            }
            else if (Foutmelder is null
                        && !string.IsNullOrEmpty(Foutmeldingen)
                        && !string.IsNullOrWhiteSpace(Foutmeldingen))
            {
                MessageBox.Show(Foutmeldingen);
            }
        }

        private void EvalueerFouten()
        {
            StelFoutmeldingenSamen();
        }

        public static void MarkeerTextBox(TextBox beveiligdeTextBox, bool isGeldig)
        {
            if (isGeldig)
            {
                beveiligdeTextBox.BorderThickness = new Thickness(1);
                beveiligdeTextBox.BorderBrush = Brushes.Gray;
                beveiligdeTextBox.Background = Brushes.White;
            }
            else
            {
                beveiligdeTextBox.BorderThickness = new Thickness(3);
                beveiligdeTextBox.BorderBrush = Brushes.Red;
                beveiligdeTextBox.Background = Brushes.LightPink;
            }
        }
        public void StelFoutmeldingenSamen()
        {
            Foutmeldingen = "";
            AlleInputCorrect = true;
            foreach (BeveiligdeTextbox beveiligdeTextBox in BeveiligdeTextboxes)
            {
                if (!string.IsNullOrEmpty(beveiligdeTextBox.FoutMelding))
                {
                    Foutmeldingen += beveiligdeTextBox.FoutMelding + "\n";
                }

                if (!beveiligdeTextBox.IsGeldig)
                {
                    AlleInputCorrect = false;
                    break;
                }
            }
        }
    }
}
