using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
namespace ClipperApp5 
{
    
    public enum EstadoPedido
    {
        Pendiente,
        EnProceso,
        Entregado
    }

    
    public enum TipoUsuario
    {
        Cliente,
        Repartidor
    }

    // Clase Producto
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }

        public Producto(string id, string nombre, decimal precio, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }
    }

    // Clase Usuario
    public class Usuario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public TipoUsuario Tipo { get; set; }

        public Usuario(string id, string nombre, string correo, string telefono, TipoUsuario tipo)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Tipo = tipo;
        }
    }




    // Clase Pedido
    public class Pedido
    {
        public string Id { get; set; }
        public Usuario Cliente { get; set; }
        public List<Producto> Productos { get; set; }
        public decimal PrecioTotal { get; set; }
        public EstadoPedido Estado { get; set; }
        public Usuario Repartidor { get; set; }
        public string DireccionEntrega { get; set; }
        public DateTime? FechaEntrega { get; set; }

        public Pedido(string id, Usuario cliente, List<Producto> productos, decimal precioTotal, EstadoPedido estado, Usuario repartidor, string direccionEntrega, DateTime? fechaEntrega)
        {
            Id = id;
            Cliente = cliente;
            Productos = productos;
            PrecioTotal = precioTotal;
            Estado = estado;
            Repartidor = repartidor;
            DireccionEntrega = direccionEntrega;
            FechaEntrega = fechaEntrega;
        }
    }

    // Clase MainWindow
    public sealed partial class MainWindow : Window
    {
        // Lista de productos
        public List<Producto> productos = new List<Producto>
        {
            new Producto("1", "Pizza", 8.99m, "Comida"),
            new Producto("2", "Pepsi", 1.99m, "Bebidas"),
            new Producto("3", "Malteada", 5.99m, "Bebida")
        };

        // Usuarios de ejemplo
        public Usuario cliente = new Usuario("c1", "Juan Pérez", "juan@example.com", "123456789", TipoUsuario.Cliente);
        public Usuario repartidor = new Usuario("r1", "Carlos Gómez", "carlos@example.com", "987654321", TipoUsuario.Repartidor);

        // Lista de pedidos
        public List<Pedido> pedidos = new List<Pedido>();

        public MainWindow()
        {
            this.InitializeComponent();

            // Crear algunos pedidos de ejemplo
            pedidos = new List<Pedido>
            {
                new Pedido("p1", cliente, new List<Producto> { productos[0], productos[1] }, 10.98m, EstadoPedido.Pendiente, null, "Calle falsa 123", null),
                new Pedido("p2", cliente, new List<Producto> { productos[2] }, 5.99m, EstadoPedido.EnProceso, repartidor, "Calle falsa 123", DateTime.Now)
            };
        }

        // Cambio del texto del botón al hacer clic
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "¡Pedido Realizado!";
        }
    }
}



