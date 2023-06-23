using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    // Clase base abstracta para representar un producto
    public abstract class Producto
    {
        // Propiedades comunes a todos los productos
        public string Modelo { get; set; }
        public int Año { get; set; }
        public int UnidadDeUso { get; set; }
        public string? Color { get; set; }
        public string? Dueño { get; set; }
        public int Autonomia { get; set; }
        public int Service { get; set; }

        // Propiedad calculada para obtener el porcentaje de carga restante
        public double CargaRestante
        {
            get
            {
                // Calcula el módulo de la autonomía en función de la unidad de uso
                int modulo = Autonomia - (UnidadDeUso % Autonomia);

                if (modulo == Autonomia)
                    return 100;

                // Calcula el porcentaje de carga restante redondeado a 2 decimales
                return Math.Round((double)modulo / Autonomia * 100, 2);
            }
        }

        // Método abstracto para obtener información específica del producto
        public abstract string ObtenerInformacion();

        // Método virtual para realizar el escaneo del producto
        public virtual void RealizarEscaneo()
        {
            // Lógica de escaneo común a todos los productos

            // Obtener el resultado del escaneo
            string resultado = ObtenerResultadoEscaneo();

            resultado = ObtenerInformacion() + "\n\n" + resultado;

            // Mostrar el resultado en un popup
            MessageBox.Show(resultado, "Resultado del escaneo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Método abstracto para obtener el resultado del escaneo específico del producto
        protected abstract string ObtenerResultadoEscaneo();
    }

    // Clase base abstracta para los productos Tesla
    public abstract class TeslaBase : Producto
    {
        // Implementación del método abstracto para obtener el resultado del escaneo de un producto Tesla
        protected override string ObtenerResultadoEscaneo()
        {
            int cantidadServices = this.UnidadDeUso / this.Service;
            List<string> serviciosRealizados = new List<string>();


            int cinturones = 1000;
            int baterias = 2000;
            int nav = 2500;
            int traccion = 3000;
            int motor = 3000;
            int servi = this.Service;


            for (int i = 1; i < cantidadServices + 1; i++)
            {
                // Agregar los servicios realizados a la lista
                string servicio = $"Service {i}: \n";
                

                // Se contempla el eventual caso en que el service no coincida con ningun chequeo (como si ocurre el el falcon 9) 
                if ((servi < cinturones) && (servi < baterias) && (servi < nav) && (servi < traccion) && (servi < motor))
                {
                    servicio += "   Sin necesidad de Chequeos extras \n";
                }
                // Verificar si se debe realizar el control de cinturones de seguridad
                if (servi >= cinturones)
                {
                    cinturones = cinturones + 1000;
                    servicio += "   Control Cinturones de Seguridad: OK \n";
                }
                // Verificar si se debe realizar el control de baterías
                if (servi >= baterias)
                {
                    baterias = baterias + 2000;
                    servicio += "   Control de Baterias: OK \n";
                }
                // Verificar si se debe realizar el control de sistema de navegación
                if (servi >= nav)
                {
                    nav = nav + 2500;
                    servicio += "   Control del Sistema de Navegacion: OK \n";
                }
                // Verificar si se debe realizar el control de sistema de tracción
                if (servi >= traccion)
                {
                    traccion = traccion + 3000;
                    servicio += "   Control del Sistema de Traccion: OK \n";
                }
                // Verificar si se debe realizar el control de motor
                if (servi >= motor)
                {
                    motor = motor + 3000;
                    servicio += "   Control del motor: OK \n";
                }
                servi += this.Service;
                serviciosRealizados.Add(servicio);
            }

            // Construir el mensaje de resultado
            string mensaje = $"Cantidad de services realizados para {Modelo}: {cantidadServices}\r\n";

            if (cantidadServices < 1)
            {
                mensaje = "Aun no es necesario realizar ningun service \n";
            }
            else
            {
                mensaje += "Servicios Realizados:\n";

                for (int i = 0; i < serviciosRealizados.Count; i++)
                {
                    mensaje += serviciosRealizados[i] + "\r\n";
                }
            }

            return mensaje;
        }
    }

    // Clase concreta que representa el modelo Tesla Model X
    public class TeslaModelX : TeslaBase
    {
        public TeslaModelX()
        {
            UnidadDeUso = 0;
            Autonomia = 560;
            Service = 1000;
        }

        public int Asientos { get; set; } = 7;

        // Implementación del método para obtener información específica del Tesla Model X
        public override string ObtenerInformacion()
        {
            return $" Producto: Tesla Model X\n\n Año: {Año}\n Kilometraje: {UnidadDeUso} km\n Color: {Color}\n Dueño: {Dueño}\n Asientos: {Asientos}\n Autonomia: {Autonomia} km\n Service: cada {Service} km\n Combustible restante: {CargaRestante} %";
        }
    }

    // Clase concreta que representa el modelo Tesla Model S
    public class TeslaModelS : TeslaBase
    {
        public TeslaModelS()
        {
            UnidadDeUso = 0;
            Autonomia = 650;
            Service = 2000;
        }

        public int Asientos { get; set; } = 5;

        // Implementación del método para obtener información específica del Tesla Model S
        public override string ObtenerInformacion()
        {
            return $" Producto: Tesla Model S\n\n Año: {Año}\n Kilometraje: {UnidadDeUso} km\n Color: {Color}\n Dueño: {Dueño}\n Asientos: {Asientos}\n Autonomia: {Autonomia} km\n Service: cada {Service} km\n Combustible restante: {CargaRestante} %";
        }
    }

    // Clase concreta que representa el modelo Tesla Cybertruck
    public class TeslaCybertruck : TeslaBase
    {
        public TeslaCybertruck()
        {
            UnidadDeUso = 0;
            Autonomia = 800;
            Service = 3000;
        }

        public int Asientos { get; set; } = 6;

        // Implementación del método para obtener información específica del Tesla Cybertruck
        public override string ObtenerInformacion()
        {
            return $" Producto: Tesla Cybertruck\n\n Año: {Año}\n Kilometraje: {UnidadDeUso} km\n Color: {Color}\n Dueño: {Dueño}\n Asientos: {Asientos}\n Autonomia: {Autonomia} km\n Service: cada {Service} km\n Combustible restante: {CargaRestante} %";
        }
    }

    // Clase base abstracta para los productos SpaceX
    public abstract class SpaceXBase : Producto
    {
        // Implementación del método abstracto para obtener el resultado del escaneo de un producto SpaceX
        protected override string ObtenerResultadoEscaneo()
        {
            int cantidadServices = this.UnidadDeUso / this.Service;
            List<string> serviciosRealizados = new List<string>();

            int prop = 1000;
            int nav = 500;
            int servi = this.Service;
            for (int i = 1; i < cantidadServices + 1; i++)
            {
                // Agregar los servicios realizados a la lista
                string servicio = $"Service {i}: \n";

                // En el falcon 9 el primer service es a los 400, pero no se checkea ni propulsion ni navegacion
                if ((servi < nav) && (servi < prop))
                {
                    servicio += "   Sin necesidad de Chequeos extras \n";
                }

                // Verificar si se debe realizar el control del sistema de propulsión
                if ((servi) >= prop)
                {
                    prop = prop + 1000;
                    servicio += "   Control del Sistema de Propulsion: OK  \n";
                }
                // Verificar si se debe realizar el control del sistema de navegación
                if ((servi) >=  nav )
                {
                    nav = nav + 500; 
                    servicio += "   Control del Sistema de Navegacion: OK  \n";
                }

                servi += this.Service;

                serviciosRealizados.Add(servicio);
            }

            //// Construir el mensaje de resultado
            //string mensaje = $"Cantidad de services realizados para {this.GetType().Name}: {cantidadServices}\n";
            //mensaje += "Servicios Realizados:\n";

            //for (int i = 0; i < serviciosRealizados.Count; i++)
            //{
            //    mensaje += serviciosRealizados[i] + "\n";
            //}

            //return mensaje;
            // Construir el mensaje de resultado
            string mensaje = $"Cantidad de services realizados para {Modelo}: {cantidadServices}\r\n";

            if (cantidadServices < 1)
            {
                mensaje = "Aun no es necesario realizar ningun service \n";
            }
            else
            {
                mensaje += "Servicios Realizados:\n";

                for (int i = 0; i < serviciosRealizados.Count; i++)
                {
                    mensaje += serviciosRealizados[i] + "\r\n";
                }
            }

            return mensaje;
        }
    }

    // Clase concreta que representa la SpaceX Starship
    public class SpaceXStarship : SpaceXBase
    {
        public SpaceXStarship()
        {
            UnidadDeUso = 0;
            Autonomia = 500;
            Service = 1000;
        }

        // Implementación del método para obtener información específica de la SpaceX Starship
        public override string ObtenerInformacion()
        {
            return $" Producto: SpaceX Starship\n\n Año: {Año}\n Horas de vuelo: {UnidadDeUso} hs\n Color: {Color}\n Dueño: {Dueño}\n Autonomia: {Autonomia} hs\n Service: cada {Service} hs\n Carga restante: {CargaRestante} %";
        }
    }

    // Clase concreta que representa la SpaceX Falcon 9
    public class SpaceXFalcon9 : SpaceXBase
    {
        public SpaceXFalcon9()
        {
            UnidadDeUso = 0;
            Autonomia = 200;
            Service = 400;
        }

        // Implementación del método para obtener información específica de la SpaceX Falcon 9
        public override string ObtenerInformacion()
        {
            return $" Producto: SpaceX Falcon 9\n\n Año: {Año}\n Horas de vuelo: {UnidadDeUso} hs\n Color: {Color}\n Dueño: {Dueño}\n Autonomia: {Autonomia} hs\n Service: cada {Service} hs\n Carga restante: {CargaRestante} %";
        }
    }
}
