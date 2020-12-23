using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace ALPLen
{
    /// <summary>
    /// Interaction logic for AddGroundLayer.xaml
    /// </summary>
    public partial class AddGroundLayer : Window
    {
        public AddGroundLayer()
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
                float par1 = float.Parse(Add_par1.Text);
                float par2 = float.Parse(Add_par2.Text);
                float par3 = float.Parse(Add_par3.Text);

                // Creating new ground layer
                Ground_layer n_GL = new Ground_layer(par1, par2, par3, Add_par4.Text, true);
                n_GL.Name = Add_name.Text;
                n_GL.Comment = Add_comment.Text;

                // Creating ground layers' list
                userInputs.GL_List.Add(n_GL);

                this.Close();
            }
            catch (FormatException)
            {
                Add_par1.Text = "";
                Add_par2.Text = "";
                Add_par3.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }            
        }
    }
}
