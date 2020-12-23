using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ALPLen
{
    /// <summary>
    /// Interaction logic for AddDAC.xaml
    /// </summary>
    public partial class AddDAC : Window
    {
        public AddDAC()
        {
            InitializeComponent();
        }

        private void AddGL_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddGL_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float gammab = float.Parse(Add_gammab.Text);
                float gammas = float.Parse(Add_gammas.Text);
                float gammat = float.Parse(Add_gammat.Text);
                float gammaG = float.Parse(Add_gammaG.Text);
                float gammaQ = float.Parse(Add_gammaQ.Text);

                // Creating new design approach combination
                DACombination n_DAC = new DACombination(Add_DAName.Text, Add_CName.Text, gammab, gammas, gammat, gammaG, gammaQ);
                n_DAC.Comment = Add_comment.Text;

                // Creating ground layers' list
                userInputs.DAC_List.Add(n_DAC);

                this.Close();                
            }
            catch (FormatException)
            {
                Add_gammab.Text = "";
                Add_gammas.Text = "";
                Add_gammat.Text = "";
                Add_gammaG.Text = "";
                Add_gammaQ.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);                
            }            
        }        
    }
}
