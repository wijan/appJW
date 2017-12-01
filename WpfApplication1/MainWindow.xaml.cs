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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Wololo(object sender, RoutedEventArgs e)
        {
            ListaHermanos.Items.Clear();
            List<string> Hermanos = Directory.GetDirectories(path + "\\DB\\Congregaciones\\Roses\\Grupo1\\Hermanos").Select(s => s.Split('\\').Last()).ToList();
            foreach(string Hermano in Hermanos)
            {
                ComboBoxItem itm = new ComboBoxItem();
                itm.Content = Hermano;

                ListaHermanos.Items.Add(itm);
            }
            ListaHermanos.Visibility = System.Windows.Visibility.Visible;

            
            /*string juanjostr = File.ReadAllText(path + "\\DB\\Congregaciones\\Roses\\Grupo1\\Hermanos\\Juanjo.json");
            JObject juanjoObj = JObject.Parse(juanjostr);
            string nombre = juanjoObj["Nombre"].ToString();
            MessageBox.Show(nombre);*/
        }

        private void CargarInfoHermano(object sender, SelectionChangedEventArgs e)
        {
            resetInfo();
            ComboBoxItem lbi = ((sender as ComboBox).SelectedItem as ComboBoxItem);
            string hermanoSeleccionado = lbi.Content.ToString();
            string HermanoStr = File.ReadAllText(path + "\\DB\\Congregaciones\\Roses\\Grupo1\\Hermanos\\" + hermanoSeleccionado + "\\Info.json");
            JObject HermanoObj = JObject.Parse(HermanoStr);
            NombreHermano.Text = NombreHermano.Text + " " + HermanoObj["Nombre"].ToString();
            ApellidoHermano.Text = ApellidoHermano.Text + " " + HermanoObj["Apellido"].ToString();
            EdadHermano.Text = EdadHermano.Text + " " + HermanoObj["Edad"].ToString();
            LocalidadHermano.Text = LocalidadHermano.Text + " " + HermanoObj["Localidad"].ToString();
            DireccionHermano.Text = DireccionHermano.Text + " " + HermanoObj["Direccion"].ToString();
            TelefonoHermano.Text = TelefonoHermano.Text + " " + HermanoObj["Telefono"].ToString();
            EmailHermano.Text = EmailHermano.Text + " " + HermanoObj["Email"].ToString();
        }
        private void resetInfo()
        {
            NombreHermano.Text = "Nombre:";
            ApellidoHermano.Text = "Apellido:";
            EdadHermano.Text = "Edad:";
            LocalidadHermano.Text = "Localidad:";
            DireccionHermano.Text = "Direccion:";
            TelefonoHermano.Text = "Teléfono:";
            EmailHermano.Text = "Email:";
        }
        

    }
}
