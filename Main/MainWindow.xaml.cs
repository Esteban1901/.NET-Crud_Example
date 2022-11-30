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
using BLL;

namespace Main
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CategoriaBLL catBll = new CategoriaBLL();
       
        public MainWindow()
        {
            InitializeComponent();
            ListarCategorias();
        }

        private void ListarCategorias()
        {
            LstTareas.ItemsSource = catBll.GetAll();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string nombre = TxtNombre.Text.Trim();
                catBll.Add(nombre);

                MessageBox.Show("Categoría agregada", "Nueva Categoría", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtNombre.Text = string.Empty;
                ListarCategorias();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Nueva Categoría", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = LstTareas.SelectedItem.ToString();

            catBll.Delete(nombre);

            ListarCategorias();
        }
    }
}
