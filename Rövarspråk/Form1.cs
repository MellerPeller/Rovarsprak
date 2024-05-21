using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rövarspråk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        

        private void textBox1_changed(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            string translatedText = TranslateToRovarsprak(inputText);
            textBox2.Text = translatedText;
        }

        //Metod som gör översättningen från svenska till rövarspråk
        private string TranslateToRovarsprak(string input)
        {
            // Fixar så att x/X behandlas som ks/KS (Istället för xox blir det koksos)
            input = input.Replace("x", "ks").Replace("X", "KS");

            // Matchar alla konsonanter både i små och stora bokstäver
            string pattern = @"[bcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ]";
            // Tar varje matchad konsonant och lägger till o sedan konsonanten igen
            string replacementEvaluator(Match m)
            {
                string consonant = m.Value;
                return consonant + "o" + consonant.ToLower();
            }

            /* Använder texten från textbox1 och mönstret (pattern variabeln) för att sedan
               byta ut texten med den översatta texten från replacementEvaluator fuctionen 
               replacementEvaluator använder bara konsonanter.                             */
            string result = Regex.Replace(input, pattern, new MatchEvaluator(replacementEvaluator));
            return result;
        }
    }
}

