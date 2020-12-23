using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ALPLen
{
    // Observable properties
    public class ObservableObj : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class ObservUserInputs : ObservableObj
    {
        // Resistance exploitation factor
        private string _Ref;
        public string Ref
        {
            get
            {
                if (string.IsNullOrEmpty(_Ref))
                    return "";

                return _Ref;
            }
            set
            {
                _Ref = value;
                OnPropertyChanged("Ref");
            }
        }

        // Characteristic loads in kN
        // Permanent
        private string _N_k;
        public string N_k
        {
            get
            {
                if (string.IsNullOrEmpty(_N_k))
                    return "";

                return _N_k;
            }
            set
            {                
                _N_k = value;
                OnPropertyChanged("N_k");
            }
        }
        // Variable
        private string _Q_k;
        public string Q_k
        {
            get
            {
                if (string.IsNullOrEmpty(_Q_k))
                    return "";

                return _Q_k;
            }
            set
            {
                _Q_k = value;
                OnPropertyChanged("Q_k");
            }
        }

        // Pile properties
        // Diameter
        private string _P_diameter;
        public string P_diameter
        {
            get
            {
                if (string.IsNullOrEmpty(_P_diameter))
                    return "";

                return _P_diameter;
            }
            set
            {
                _P_diameter = value;
                OnPropertyChanged("P_diameter");
            }
        }
        // Alpha p coefficient
        private string _AlphaP;
        public string AlphaP
        {
            get
            {
                if (string.IsNullOrEmpty(_AlphaP))
                    return "";

                return _AlphaP;
            }
            set
            {
                _AlphaP = value;
                OnPropertyChanged("AlphaP");
            }
        }
        // S coefficient
        private string _S;
        public string S
        {
            get
            {
                if (string.IsNullOrEmpty(_S))
                    return "";

                return _S;
            }
            set
            {
                _S = value;
                OnPropertyChanged("S");
            }
        }
        // Beta coefficient
        private string _Beta;
        public string Beta
        {
            get
            {
                if (string.IsNullOrEmpty(_Beta))
                    return "";

                return _Beta;
            }
            set
            {
                _Beta = value;
                OnPropertyChanged("Beta");
            }
        }
        // Xi coefficient
        private string _Xi;
        public string Xi
        {
            get
            {
                if (string.IsNullOrEmpty(_Xi))
                    return "";

                return _Xi;
            }
            set
            {
                _Xi = value;
                OnPropertyChanged("Xi");
            }
        }

        //Embedment properties
        // Min soil layer depth under pile base (l4)
        private string _MinDepthUnder;
        public string MinDepthUnder
        {
            get
            {
                if (string.IsNullOrEmpty(_MinDepthUnder))
                    return "";

                return _MinDepthUnder;
            }
            set
            {
                _MinDepthUnder = value;
                OnPropertyChanged("MinDepthUnder");
            }
        }
        // Min pile embedment into base layer (l3)
        private string _MinEmbed;
        public string MinEmbed
        {
            get
            {
                if (string.IsNullOrEmpty(_MinEmbed))
                    return "";

                return _MinEmbed;
            }
            set
            {
                _MinEmbed = value;
                OnPropertyChanged("MinEmbed");
            }
        }
        // Unevaluated depth of soil from ground surface (l2)
        private string _UnevalDepth;
        public string UnevalDepth
        {
            get
            {
                if (string.IsNullOrEmpty(_UnevalDepth))
                    return "";

                return _UnevalDepth;
            }
            set
            {
                _UnevalDepth = value;
                OnPropertyChanged("UnevalDepth");
            }
        }
        // Min embedment height into foundation (l1)
        private string _MinEmbedF;
        public string MinEmbedF
        {
            get
            {
                if (string.IsNullOrEmpty(_MinEmbedF))
                    return "";

                return _MinEmbedF;
            }
            set
            {
                _MinEmbedF = value;
                OnPropertyChanged("MinEmbedF");
            }
        }

    }

    // Global project properties
    public class PrInfoData : ObservableObj
    {
        // Project name
        private string _PrName;
        public string PrName
        {
            get
            {
                if (string.IsNullOrEmpty(_PrName))
                    return "";

                return _PrName;
            }
            set
            {
                _PrName = value;
                OnPropertyChanged("PrName");
            }
        }
        // Project date
        private string _PrDate;
        public string PrDate
        {
            get
            {
                if (string.IsNullOrEmpty(_PrDate))
                    return "";

                return _PrDate;
            }
            set
            {
                _PrDate = value;
                OnPropertyChanged("PrDate");
            }
        }
        // Project author
        private string _PrAuthor;
        public string PrAuthor
        {
            get
            {
                if (string.IsNullOrEmpty(_PrAuthor))
                    return "";

                return _PrAuthor;
            }
            set
            {
                _PrAuthor = value;
                OnPropertyChanged("PrAuthor");
            }
        }
    }

    // Result
    public class Results: ObservableObj
    {
        // Minimum pile length
        private string _MinPLength;
        public string MinPLength
        {
            get
            {
                if (string.IsNullOrEmpty(_MinPLength))
                    return "";

                return _MinPLength;
            }
            set
            {
                _MinPLength = value;
                OnPropertyChanged("MinPLength");
            }
        }
    }

    // User input variables (global variable class)    
    static class userInputs
    {
        // Design approache combinations' list
        public static ObservableCollection<DACombination> DAC_List
        { get; set; }

        // Ground layers' list
        public static ObservableCollection<Ground_layer> GL_List 
        { get; set; }
    }

    // Design approach (superclass)
    public class Design_approach
    {
        // Constructor
        public Design_approach(string name)
        {
            approach_name = name;
        }

        // Public properties getter methods
        public string approach_name { get; }
    }

    // Design approach (subclass)
    public class DACombination : Design_approach
    {
        // Constructor
        public DACombination(string approach, string name, float g_b, float g_s, float g_t, float g_G, float g_Q) : base(approach)
        {
            comb_name = name;
            gamma_b = g_b;
            gamma_s = g_s;
            gamma_t = g_t;
            gamma_G = g_G;
            gamma_Q = g_Q;
        }

        // Public properties getter methods
        public string comb_name { get; }
        public float gamma_b { get; }
        public float gamma_s { get; }
        public float gamma_t { get; }
        public float gamma_G { get; }
        public float gamma_Q { get; }
        public string Comment { get; set; }
    }

    // Ground layer (superclass)
    public class Ground_layer
    {
        // Constructor
        public Ground_layer(float qc_k, float a_s, float z, string id = "", bool isBase = false)
        {
            CPT_id = id;
            qc = qc_k;
            alfa_s = a_s;
            layer_height = z;
            Base = isBase;
        }

        // Public properties getter methods
        public string CPT_id { get; set; }
        public string Name { get; set; }
        public float qc { get; set; }
        public float alfa_s { get; set; }
        public float layer_height { get; set; }
        public string Comment { get; set; }
        public bool Base { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static (string, float, float) CalcRsd(DACombination DAcomb, float R_b_k, float N_k, float Q_k, float REF)
        {
            // Pile base design resistance in MN
            float R_b_d = R_b_k / DAcomb.gamma_b;

            // Design loads in kN
            // Permanent
            float N_d = N_k * DAcomb.gamma_G;
            // Variable
            float Q_d = Q_k * DAcomb.gamma_Q;

            // Total design axial load in kN
            float ALoad_total = N_d + Q_d;

            // Pile design compressive resistance in MN
            float R_c_d = ALoad_total / REF / 1000;

            // Pile lateral design resistance
            float R_s_d = R_c_d - R_b_d;
            // Pile lateral characteristic resistance
            float R_s_k = R_s_d * DAcomb.gamma_s;

            return (DAcomb.comb_name, R_s_d, R_s_k);
        }

        static float? CalcMinLength(float Max_R_s_k, float Xi, float P_diameter, ObservableCollection<Ground_layer> List_gl, float MinEmbedF, float UnevalDepth, float MinEmbed, float MinDepthUnder)
        {
            // Mimimal required lateral resistance for pile minimum length calculations
            float R_s_cal = Max_R_s_k * Xi;
            float P_length = 0;
            float check_resist = 0;
            
            foreach (Ground_layer gl in List_gl)
            {
                float qs_calc = gl.alfa_s * gl.qc; // Lateral surface friction strength for resistance calculation
                float Perimeter = (float)(Math.Round(Math.PI * P_diameter, 3));
                float z = gl.layer_height;
                
                float l2 = UnevalDepth;
                // Considering unevaluated depth of ground from surface (l2)
                if (l2 >= z)
                {
                    l2 -= z;
                    z = 0;
                }
                else
                {
                    z -= l2;
                }
                
                float A_s = Perimeter * z;
                // Ground characterictic lateral resistance calculation
                float Ground_lat_resist = qs_calc * A_s;

                check_resist += Ground_lat_resist;
                if (check_resist >= R_s_cal)
                {
                    float baseEmbedLen = R_s_cal / (qs_calc * Perimeter);                    
                    // Evaluating min pile embedment into base layer (l3)
                    if (baseEmbedLen < MinEmbed)
                    {
                        float delta = MinEmbed - baseEmbedLen;
                        baseEmbedLen += delta;
                        if (baseEmbedLen > z)
                        {
                            MessageBox.Show("CalculationError. Insufficient base layer height. l3 condition is not satisfied", "Calc error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return null;
                        }
                    }
                    
                    float depthUnder = z - baseEmbedLen;
                    // Evaluating min ground layer depth under pile base (l4)
                    if (depthUnder < MinDepthUnder)
                    {
                        MessageBox.Show("CalculationError. Insufficient base layer height. l4 condition is not satisfied", "Calc error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return null;
                    }
                    
                    P_length += baseEmbedLen;
                    
                    // Adding min pile embedment into foundation (l1)
                    P_length += MinEmbedF;
                    return P_length;
                }
                else if (check_resist < R_s_cal)
                {
                    R_s_cal -= Ground_lat_resist;
                    P_length += gl.layer_height;
                }
            }

            // Minimal pile length was not found
            MessageBox.Show("CalculationError. Can't determine minimal pile length. Please check and/or adjust design parameters, conditions and try again", "Calc error", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }

        // Public property of class ObservUserInputs for binding
        public ObservUserInputs observUserInputs { get; private set; }
        
        // Public property of class PrInfoData for binding
        public PrInfoData prInfo { get; private set; }

        // Public property of class Results for binding
        public Results results { get; private set; }

        // Placeholder list for results of CalcMinRsd
        List<(string, float, float)> results_CalcRsd = new List<(string, float, float)>();

        // Placeholder variable for index of base ground layer
        Nullable<int> base_layer_index = null;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Creating default DA_List members
            // Design approach combinations
            // DA1 (Design approach 1)
            DACombination DA1_A1_M1_R1 = new DACombination("DA1", "A1+M1+R1", 1.25f, 1f, 1.15f, 1.35f, 1.3f);
            DACombination DA1_A2_M1_R4 = new DACombination("DA1", "A2+M1+R4", 1.6f, 1.3f, 1.5f, 1f, 1.3f);
            // DA2 (Design approach 2)
            DACombination DA2_A1_M1_R2 = new DACombination("DA2", "A1+M1+R2", 1.1f, 1.1f, 1.1f, 1.35f, 1.3f);

            // Assigning new empty list to 'global' variable DA_List with default members
            userInputs.DAC_List = new ObservableCollection<DACombination>() { DA1_A1_M1_R1, DA1_A2_M1_R4, DA2_A1_M1_R2 };

            // Assigning new empty list to 'global' variable GL_List
            userInputs.GL_List = new ObservableCollection<Ground_layer>();

            // Initializing observable objects to store properties which will be updated in model view if changed
            observUserInputs = new ObservUserInputs();
            //observUserInputs.Ref = "0.5";
            prInfo = new PrInfoData();
            results = new Results();
        }

        private void Tab1NextButton_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void Tab2BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
        }

        private void Tab2CalcButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Declaring required variables
                List<float> R_s_k_list = new List<float>();

                // Resetting results and clearing lists used in calculations
                results.MinPLength = null;
                results_CalcRsd.Clear();
                R_s_k_list.Clear();

                // Pile geometric properties in meters
                double P_perimeter = Math.Round(Math.PI * float.Parse(observUserInputs.P_diameter), 3);
                double P_base_area = Math.Round(Math.PI * Math.Pow(float.Parse(observUserInputs.P_diameter), 2) / 4, 3);

                // Base layer
                Ground_layer baseLayer = userInputs.GL_List.Last();

                // Pile base strength for resistance calculation
                float qb_k = 0;
                qb_k = baseLayer.qc;
                float qb_cal = 0.5f * float.Parse(observUserInputs.AlphaP) * float.Parse(observUserInputs.S) * float.Parse(observUserInputs.Beta) * qb_k;

                // Pile base characteristic resistance
                float R_b_k = (qb_cal * (float)P_base_area) / float.Parse(observUserInputs.Xi);

                // Calculating pile lateral design resistance
                foreach (var item in userInputs.DAC_List)
                {
                    results_CalcRsd.Add(CalcRsd(item, R_b_k, float.Parse(observUserInputs.N_k), float.Parse(observUserInputs.Q_k), float.Parse(observUserInputs.Ref)));
                }

                // Maximum pile lateral characteristic resistance            
                foreach (var item in results_CalcRsd)
                {
                    R_s_k_list.Add(item.Item3);
                }
                float Max_R_s_k = R_s_k_list.Max();

                // Calculating minimum pile length
                results.MinPLength = CalcMinLength(Max_R_s_k, float.Parse(observUserInputs.Xi), float.Parse(observUserInputs.P_diameter), userInputs.GL_List, float.Parse(observUserInputs.MinEmbedF), float.Parse(observUserInputs.UnevalDepth),
                                     float.Parse(observUserInputs.MinEmbed), float.Parse(observUserInputs.MinDepthUnder)).ToString();

                // Variable report MessageBox for debugging 
                /*
                MessageBox.Show(
                $"Perimeter: {P_perimeter}\n" +
                $"Base area: {P_base_area}\n" +
                $"Base layer index: {base_layer_index}\n" +
                $"Base strength char: {qb_k}\n" +
                $"Base strength calc: {qb_cal}\n" +
                $"Base resistance char: {R_b_k}\n" +
                $"Result of CalcMinRsd 1: {results_CalcRsd[0]}\n" +
                $"Result of CalcMinRsd 2: {results_CalcRsd[1]}\n" +
                $"Result of CalcMinRsd 3: {results_CalcRsd[2]}\n" +
                $"R_s_k_list[0]: {R_s_k_list[0]}\n" +
                $"R_s_k_list[1]: {R_s_k_list[1]}\n" +
                $"R_s_k_list[2]: {R_s_k_list[2]}\n" +
                $"Max Rsk: {Max_R_s_k}\n" +
                $"Ground layer height: {userInputs.GL_List[0].layer_height}\n" +
                $"Min pile length: {results.MinPLength}\n");
                */

            }
            catch (FormatException)
            {
                MessageBox.Show("UserInputError. Check your inputs and try to calculate again", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
            //Refreshing DataGrid copies on Results tab.
            DACDataGridCopy.Items.Refresh();
            GroundDataGridCopy.Items.Refresh();
            
            MainTabControl.SelectedIndex = 2;                        
        }

        private void Tab3BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;            
        }

        private void REF_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (REF_inputBox.Text != "")
                {
                    float.Parse(REF_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                REF_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }        

        private void PD_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (PD_inputBox.Text != "")
                {
                    float.Parse(PD_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                PD_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void AlphaP_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (AlphaP_inputBox.Text != "")
                {
                    float.Parse(AlphaP_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                AlphaP_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void S_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (S_inputBox.Text != "")
                {
                    float.Parse(S_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                S_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Beta_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Beta_inputBox.Text != "")
                {
                    float.Parse(Beta_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                Beta_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Nk_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Nk_inputBox.Text != "")
                {
                    float.Parse(Nk_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                Nk_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Qk_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Qk_inputBox.Text != "")
                {
                    float.Parse(Qk_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                Qk_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Xi3_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Xi4_inputBox.Text = "";
            Xi4_CheckBox.IsChecked = false;
            Xi3_inputBox.Visibility = Visibility.Visible;
            Xi4_inputBox.Visibility = Visibility.Hidden;
        }

        private void Xi3_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Xi3_inputBox.Visibility = Visibility.Hidden;
        }

        private void Xi3_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Xi3_inputBox.Text != "")
                {
                    float.Parse(Xi3_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                Xi3_inputBox.Text = "";
                Xi4_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Xi4_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Xi3_inputBox.Text = "";
            Xi3_CheckBox.IsChecked = false;
            Xi4_inputBox.Visibility = Visibility.Visible;
            Xi3_inputBox.Visibility = Visibility.Hidden;
        }

        private void Xi4_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Xi4_inputBox.Visibility = Visibility.Hidden;
        }

        private void Xi4_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Xi4_inputBox.Text != "")
                {
                    float.Parse(Xi4_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                Xi3_inputBox.Text = "";
                Xi4_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        
        private void MinEmbedF_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (MinEmbedF_inputBox.Text != "")
                {
                    float.Parse(MinEmbedF_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                MinEmbedF_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void MinDepthUnder_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (MinDepthUnder_inputBox.Text != "")
                {
                    float.Parse(MinDepthUnder_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                MinDepthUnder_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void MinEmbed_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (MinEmbed_inputBox.Text != "")
                {
                    float.Parse(MinEmbed_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                MinEmbed_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void UnevalDepth_inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (UnevalDepth_inputBox.Text != "")
                {
                    float.Parse(UnevalDepth_inputBox.Text);
                }
            }
            catch (FormatException)
            {
                UnevalDepth_inputBox.Text = "";
                MessageBox.Show("Wrong input format. Please enter a number", "Input error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }               
        
        private void GroundDataTab_Selected(object sender, RoutedEventArgs e)
        {
            // Binding DataGrid control with the list of ground layers
            GroundDataGrid.ItemsSource = userInputs.GL_List;
        }

        private void Tab2AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Set all current elements in GL_list to be not the base layer, before adding new one which becomes the base
            foreach (Ground_layer gl in userInputs.GL_List)
            {
                gl.Base = false;
            }

            AddGroundLayer AddGroundLayer = new AddGroundLayer();
            AddGroundLayer.AddGL_cancel.Click += AddGroundLayer_Canceled;
            AddGroundLayer.DataContext = this;
            AddGroundLayer.Owner = this;
            AddGroundLayer.Show();
            GroundDataGrid.Items.Refresh();
        }

        private void AddGroundLayer_Canceled(object sender, EventArgs e)
        {
            if (userInputs.GL_List.Count != 0)
            {
                userInputs.GL_List.Last().Base = true;
            }            
            GroundDataGrid.Items.Refresh();
        }

        private void Tab2DelButton_Click(object sender, RoutedEventArgs e)
        {
            Ground_layer selected_layer = (Ground_layer)GroundDataGrid.SelectedItem;
            if (selected_layer != null)
            {
                userInputs.GL_List.RemoveAt(userInputs.GL_List.IndexOf(selected_layer));
                
                if (userInputs.GL_List.Count != 0)
                {
                    userInputs.GL_List.Last().Base = true;
                }
            }
            GroundDataGrid.Items.Refresh();
        }

        private void Tab2ClearAll_Click(object sender, RoutedEventArgs e)
        {
            userInputs.GL_List.Clear();
            GroundDataGrid.Items.Refresh();
        }

        private void ResultsTab_Selected(object sender, RoutedEventArgs e)
        {            
            DACDataGridCopy.ItemsSource = userInputs.DAC_List;
            GroundDataGridCopy.ItemsSource = userInputs.GL_List;
        }
        
        private void RowUp_Click(object sender, RoutedEventArgs e)
        {
            Ground_layer current_layer = (Ground_layer)GroundDataGrid.SelectedItem;
            int cLayer_index = userInputs.GL_List.IndexOf(current_layer);
            MessageBox.Show(cLayer_index.ToString());
            if (cLayer_index != 0)
            {
                if (cLayer_index == (userInputs.GL_List.Count - 1))
                {
                    Ground_layer temp = userInputs.GL_List[cLayer_index - 1];
                    userInputs.GL_List[cLayer_index - 1] = current_layer;
                    userInputs.GL_List[cLayer_index] = temp;
                    current_layer.Base = false;
                    temp.Base = true;                    
                }
                else
                {
                    Ground_layer temp = userInputs.GL_List[cLayer_index - 1];
                    userInputs.GL_List[cLayer_index - 1] = current_layer;
                    userInputs.GL_List[cLayer_index] = temp;
                }                
            }
            GroundDataGrid.SelectedIndex = cLayer_index - 1;
            GroundDataGrid.Items.Refresh();
        }

        private void RowDown_Click(object sender, RoutedEventArgs e)
        {
            Ground_layer current_layer = (Ground_layer)GroundDataGrid.SelectedItem;
            int cLayer_index = userInputs.GL_List.IndexOf(current_layer);
            MessageBox.Show(cLayer_index.ToString());
            if (cLayer_index != (userInputs.GL_List.Count - 1))
            {
                if (cLayer_index == (userInputs.GL_List.Count - 2))
                {
                    Ground_layer temp = userInputs.GL_List[cLayer_index + 1];
                    userInputs.GL_List[cLayer_index + 1] = current_layer;
                    userInputs.GL_List[cLayer_index] = temp;
                    current_layer.Base = true;
                    temp.Base = false;
                }
                else
                {
                    Ground_layer temp = userInputs.GL_List[cLayer_index + 1];
                    userInputs.GL_List[cLayer_index + 1] = current_layer;
                    userInputs.GL_List[cLayer_index] = temp;
                }                
            }
            GroundDataGrid.SelectedIndex = cLayer_index + 1;
            GroundDataGrid.Items.Refresh();
        }

        private void InputsTab_Selected(object sender, RoutedEventArgs e)
        {
            // Binding DataGrid control with the list of design approaches and combinations
            DACDataGrid.ItemsSource = userInputs.DAC_List;
        }        

        private void Tab1AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddDAC AddDAC = new AddDAC();
            AddDAC.Owner = this;
            AddDAC.Show();
        }

        private void Tab1DelButton_Click(object sender, RoutedEventArgs e)
        {
            DACombination selected_DAC = (DACombination)DACDataGrid.SelectedItem;
            if (selected_DAC != null)
            {
                userInputs.DAC_List.RemoveAt(userInputs.DAC_List.IndexOf(selected_DAC));
            }
        }

        private void PrInfo_Click(object sender, RoutedEventArgs e)
        {
            PrInfo PrInfo = new PrInfo();
            PrInfo.DataContext = this;
            PrInfo.Owner = this;
            PrInfo.Show();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void MenuItem_VDoc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/tdulskas/ALPLen/blob/master/README.md");
        }
    }
}
