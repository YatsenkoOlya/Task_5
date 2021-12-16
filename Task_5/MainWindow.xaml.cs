using System;
using System.Collections.Generic;
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

namespace Task5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void P1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        Type type = null;
        ILand obj = null;
        List<TextBlock> ltb = null;
        List<TextBox> ltbx = null;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            Type cs = typeof(AppleGarden);
            type = cs;
            ShowClass(cs);
            
        }
        private void ShowClass(Type cs)
        {
            System.Reflection.PropertyInfo[] pi = cs.GetProperties();
            List<TextBlock> textBlocks = new List<TextBlock>();

            //MessageBox.Show(es.Length.ToString());
            foreach (UIElement ui in main.Children)
            {
                if (ui is TextBlock)
                {
                    textBlocks.Add((TextBlock)ui);
                }

            }
            for (int i = 0; i < pi.Length; i++)
            {
                textBlocks[i].Text = pi[i].ToString();
            }
            // MessageBox.Show("size" +  textBlocks.Count);
            for (int i = 0; i < pi.Length; i++)
            {
                textBlocks.RemoveAt(0);
            }

            // MessageBox.Show("size" + textBlocks.Count);

            System.Reflection.MethodInfo[] mi = cs.GetMethods();
            List<System.Reflection.MethodInfo> mmi = new List<System.Reflection.MethodInfo>();
            foreach (System.Reflection.MethodInfo m in mi)
            {
                if (m.ToString().IndexOf("get", StringComparison.OrdinalIgnoreCase) < 0 && m.ToString().IndexOf("set", StringComparison.OrdinalIgnoreCase) < 0
                    && m.ToString().IndexOf("equals", StringComparison.OrdinalIgnoreCase) < 0 && m.ToString().IndexOf("hash", StringComparison.OrdinalIgnoreCase) < 0
                    && m.ToString().IndexOf("tostring", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    mmi.Add(m);
                    // MessageBox.Show(m.ToString());
                }
            }
            for (int i = 0; i < mmi.Count; i++)
            {
                textBlocks[i].Text = mmi[i].ToString();
            }
            for (int i = 0; i < mmi.Count; i++)
            {
                textBlocks.RemoveAt(0);
            }
            ltb = textBlocks;
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
            Type cs = typeof(MixedGarden);
            type = cs;
            ShowClass(cs);
        }

        private void CreateObject_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox>();

            //MessageBox.Show(es.Length.ToString());
            foreach (UIElement ui in main.Children)
            {
                if (ui is TextBox)
                {
                    textBoxes.Add((TextBox)ui);
                }
            }
            List<String> constr = new List<string>();
            if (type != null )
            {
                System.Reflection.PropertyInfo[] pi = type.GetProperties();
                for (int i=0;i<pi.Length;i++)
                {
                    constr.Add(textBoxes[i].Text);
                }
                for (int i = 0; i < pi.Length; i++)
                {
                    textBoxes.RemoveAt(0);
                }
                ltbx = textBoxes;
                obj =generatObject(constr,type);
                stateobj.Content = "Object created";
            }

        }
        private ILand generatObject(List<String> constr,Type type)
        {
            
            string address = constr[2];
            string gardenType = constr[3];
            Dictionary<String, int> quantity = parsedict(constr[4]);
            int number = Int32.Parse(constr[5]);
            if (type.Name.Equals("AppleGarden"))
            {
                int newTrees = Int32.Parse(constr[0]);
                string ownersName = constr[1];
                return new AppleGarden(address,number,gardenType,quantity, ownersName, newTrees);
            } else { if (type.Name.Equals("MixedGarden")) {
                    int berries = Int32.Parse(constr[0]);
                    int square = Int32.Parse(constr[1]);
                    return new MixedGarden(address, number, gardenType, quantity,berries, square);
                } }
            return null;
        }
        private Dictionary<String,int> parsedict(String str)
        {
            Dictionary<String, int> dictionary = new Dictionary<string, int>();
            String[] elements = str.Split(',');
            int size = elements.Length ;
            
            foreach (String s in elements) {
                dictionary.Add(s.Split(' ')[0], Int32.Parse( s.Split(' ')[1]));
            }
            return dictionary;
        }
        private Dictionary<int, int> parsedictii(String str)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            String[] elements = str.Split(',');
            int size = elements.Length;

            foreach (String s in elements)
            {
                dictionary.Add(Int32.Parse(s.Split(' ')[0]), Int32.Parse(s.Split(' ')[1]));
            }
            return dictionary;
        }

        private void Exm1_Click(object sender, RoutedEventArgs e)
        {
            //if (type.Name.Equals("CrspStudent"))
            // {

            Dictionary<String, int> tf = parsedict(ltbx[0].Text);
            ltb[0].Text = obj.LandValue(tf).ToString();
            //}

        }
        private void Exm2_Click(object sender, RoutedEventArgs e)
        {
            if (type.Name.Equals("AppleGarden"))
            {
                ltb[1].Text = ((AppleGarden)obj).EmpPercentage( Int32.Parse( ltbx[1].Text)).ToString();
            }
            else { if (type.Name.Equals("MixedGarden")) {
                    ltb[1].Text = ((MixedGarden)obj).LastT().ToString();

                }
            }
        }

        private void Exm3_Click(object sender, RoutedEventArgs e)
        {
            ltb[2].Text = ((Garden)obj).AvgQ().ToString();
        }

        private void Exm4_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int, int> st = parsedictii(ltbx[3].Text);
            Dictionary<int, int>.KeyCollection keyColl = st.Keys;
            MessageBox.Show(keyColl.ToString());
            ltb[3].Text = obj.LandWeave(st).ToString();
        }
    }
}
