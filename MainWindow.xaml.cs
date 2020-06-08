using Registro_de_Usuario.BLL;
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

namespace Registro_de_Usuario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Entidades.Usuarios usuarios = new Entidades.Usuarios();
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = usuarios;
        }

        private void Limpiar()
        {
            this.usuarios = new Entidades.Usuarios();
            this.DataContext = usuarios;
        }

        private bool Validacion()
        {
            bool valido = true;

            if (UsuarioIdTextBox.Text.Length == 0 || nombreTextBox.Text.Length == 0 ||
                ClaveTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Verifique que no alla campos vacios.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (UsuarioIdTextBox.Text.Length == 0 || nombreTextBox.Text.Length < 2)
            {
                valido = false;
                MessageBox.Show("Ingrese un Nombre valido.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return valido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

            var usuarios = UsuariosBLL.Buscar(int.Parse(UsuarioIdTextBox.Text));

            if (usuarios != null)
            {
                this.usuarios = usuarios;
            }
            else
            {
                this.usuarios = new Entidades.Usuarios();
            }

            this.DataContext = this.usuarios;
        }

        /*Cambio key por paso*/
        private void guardarbotton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacion())
            {
                return;
            }

            var key = UsuariosBLL.Guardar(usuarios);

            if (key)
            {
                Limpiar();
                MessageBox.Show("Se Guardo Exitosamente ", "Excelente!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ERROR.", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void Nuevobotton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            if (UsuariosBLL.Eliminar(int.Parse(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se a Eliminado." + UsuarioIdTextBox, "Exitosamente!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el registro" + UsuarioIdTextBox, "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
