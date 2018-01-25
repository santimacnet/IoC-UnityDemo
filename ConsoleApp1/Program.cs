using System;
using Unity;
using Unity.Resolution;

namespace ConsoleApp1
{
    /// <summary>
    /// INYECCION DEPENDENCIAS CON UNITY - EJEMPLO PARA FORMACION
    /// Ejemplo basico para entender de forma simple en que consiste el concepto de IoC
    /// El objetivo de este codigo es meramente informativo y con fines de formacion
    /// Mostramos como utilizamos Unity para inyectar dependencias sin resolver un "grafo de depencias"
    /// 
    /// Cualquier IoC está desaconsejado en diseños sencillos en los que la inyección de dependencias 
    /// pueda realizarse de forma “manual”, asi: IGame game = new TrivialPursuit(); 
    /// 
    /// Unity o cualquier otro IoC se recomienda cuando resuelve todas las dependencias “encadenadas” de una clase de forma automática.
    /// en escenarios más simples o con poca complejidad no se recomienda a no ser que a futuro sea necesario utilizarlo.
    /// </summary>
    public class Program
    {
        // Declaramos un contenedor Unity para pruebas
        static UnityContainer unityContainer;

        static void Main(string[] args)
        {
            // Inicializar y Registrar el contenedor para que proporcione una instancia de TrivialPursuit
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IGame, TrivialPursuit>();

            // Ejemplos de uso de inyeccion dependencias con Unity
            EjemploResolucionDirecta();
            EjemploResolucionInDirecta();
            EjemploResolucionSobrecarga();
        }

        /// <summary>
        /// Hacemos que Unity resuelva la interfaz de forma directa desde IGame
        /// </summary>
        private static void EjemploResolucionDirecta()
        {
            // Comprobamos que el funcionamiento es correcto
            // Resolvemos directamente la interfaz IGame
            var game = unityContainer.Resolve<IGame>();
            game.addPlayer();
            game.addPlayer();

            // Mostramos el resultado 
            Console.WriteLine(string.Format("Game: {0} personas están jugando a {1}", game.CurrentPlayers, game.Name));
            Console.WriteLine("Pulsa INTRO para continuar...");
            Console.ReadLine();
        }

        /// <summary>
        /// Hacemos que Unity resuelva la interfaz de forma "indirecta" desde Tablero
        /// </summary>
        private static void EjemploResolucionInDirecta()
        {
            // Comprobamos que el funcionamiento es correcto
            // Indicamos a Unity que resuelva una instancia de la clase Tablero en lugar de IGame
            var tablero = unityContainer.Resolve<Tablero>();
            tablero.AddPlayer();
            tablero.AddPlayer();
            tablero.RemovePlayer();
            tablero.AddPlayer();
            tablero.AddPlayer();
            tablero.RemovePlayer();
            tablero.AddPlayer();
            tablero.Play();

            // Mostramos el resultado 
            Console.WriteLine("Tablero: " + tablero.GameStatus());
            Console.WriteLine("Pulsa INTRO para continuar...");
            Console.ReadLine();
        }

        /// <summary>
        /// Hacemos que Unity resuelva de forma "concreta" con sobrecarga "ParameterOverride"
        /// </summary>
        private static void EjemploResolucionSobrecarga()
        {
            // Comprobamos que el funcionamiento es correcto
            // Mediante la sobrecarga del parámetro del constructor de Tablero le indicamos "TicTacToe"
            var tablero = unityContainer.Resolve<Tablero>(new ParameterOverride("game", new TicTacToe()));
            tablero.AddPlayer();
            tablero.AddPlayer();
            tablero.AddPlayer();
            tablero.AddPlayer();
            tablero.Play();

            // Mostramos el resultado 
            Console.WriteLine("TicTacToe: " + tablero.GameStatus());
            Console.WriteLine("Pulsa INTRO para continuar...");
            Console.ReadLine();
        }
    }
}
