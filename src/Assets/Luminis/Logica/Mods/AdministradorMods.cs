#region Librerias
using UnityEngine;
using System.IO;
using System.Linq;
using System.Collections.Generic;
#endregion

namespace Luminis.Mods
{
    /// <summary>
    /// Clase que gestiona la carga y activación de mods.
    /// </summary>
    public class AdministradorMods : MonoBehaviour
    {
        #region Variables Privadas
        /// <summary>
        /// Lista de mods cargados en el juego.
        /// </summary>
        private List<Mod> mods;
        /// <summary>
        /// Ruta de la carpeta de mods.
        /// </summary>
        private string rutaMods;
        #endregion

        #region Inicializadores
        /// <summary>
        /// Inicializa el sistema de mods.
        /// </summary>
        private void Start()
        {
            // Crea una nueva lista de mods y los carga
            this.mods = new List<Mod>();
            
            // Define la ruta de la carpeta de mods, adaptándose al entorno
#if UNITY_EDITOR
            this.rutaMods = $"C://dev//nervelink//dungeon-lord//aplicacion//mods";
#else
            this.rutaMods = Path.Combine(Application.persistentDataPath, "mods");
#endif
            
            this.CargarMods();
        }
        #endregion

        #region API
        /// <summary>
        /// Activa un mod específico.
        /// </summary>
        /// <param name="indice">Índice del mod a activar.</param>
        public void ActivarMod(int indice)
        {
            // Verifica que el índice sea válido
            if (indice < 0 || indice >= this.mods.Count) return;

            this.mods[indice].Activo = true;
            Debug.Log($"Mod activado: {mods[indice].Nombre}");
            // Aquí puedes añadir la lógica para aplicar cambios del mod
        }

        /// <summary>
        /// Desactiva un mod específico.
        /// </summary>
        /// <param name="indice">Índice del mod a desactivar.</param>
        public void DesactivarMod(int indice)
        {
            // Verifica que el índice sea válido
            if (indice < 0 || indice >= mods.Count) return;

            this.mods[indice].Activo = false;
            Debug.Log($"Mod desactivado: {mods[indice].Nombre}");
            // Aquí puedes añadir la lógica para revertir cambios del mod
        }

        /// <summary>
        /// Devuelve la lista de mods.
        /// </summary>
        /// <returns>Lista de mods cargados.</returns>
        public List<Mod> ObtenerMods() => this.mods;
        
        /// <summary>
        /// Filtra los mods por su categoría.
        /// </summary>
        /// <param name="categoria">La categoría a filtrar.</param>
        /// <returns>Lista de mods que pertenecen a la categoría especificada.</returns>
        public List<Mod> FiltrarModsPorCategoria(CategoriaMod categoria)
        {
            return this.mods.Where(mod => mod.Categoria == categoria).ToList(); // Filtra y devuelve la lista
        }
        #endregion

        #region Metodos Privados
        /// <summary>
        /// Carga todos los mods disponibles en la carpeta de mods.
        /// </summary>
        private void CargarMods()
        {
            // Verifica que la carpeta de mods exista
            if (!Directory.Exists(this.rutaMods)) 
            {
                Debug.LogWarning("La carpeta de mods no existe: " + this.rutaMods);
                return;
            }

            // Obtiene todas las carpetas dentro de la carpeta de mods
            string[] directorios = Directory.GetDirectories(this.rutaMods);
            foreach (string m in directorios)
            {
                string rutaJson = Path.Combine(m, "data.json");

                // Verifica si el archivo JSON existe
                if (File.Exists(rutaJson)) 
                {
                    string dJson = File.ReadAllText(rutaJson); // Lee el contenido del archivo JSON
                    Mod dMod = JsonUtility.FromJson<ModJson>(dJson).ToMod(); // Deserializa y convierte a Mod
                    this.mods.Add(dMod); // Agrega el mod a la lista de mods cargados
                    Debug.Log("Mod cargado: " + dMod.Nombre); // Muestra en la consola el nombre del mod
                }
                else
                {
                    Debug.LogWarning("Archivo JSON no encontrado: " + rutaJson);
                }
            }
        }
        #endregion
    }
}
