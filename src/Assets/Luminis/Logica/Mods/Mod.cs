namespace Luminis.Mods
{
    /// <summary>
    /// Clase que representa un mod en el juego.
    /// </summary>
    [System.Serializable]
    public class Mod
    {
        #region Propiedades
        /// <summary>
        /// Nombre del mod.
        /// </summary>
        public string Nombre { get; private set; }
        
        /// <summary>
        /// Descripcion del mod
        /// </summary>
        public string Descripcion { get; private set; }
        
        /// <summary>
        /// Categoria del mod
        /// </summary>
        public CategoriaMod Categoria { get; private set; }
        
        /// <summary>
        /// Indica si el mod está activo.
        /// </summary>
        public bool Activo { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase Mod.
        /// </summary>
        public Mod()
        {
        }
        
        /// <summary>
        /// Constructor que recibe nombre y descripción.
        /// </summary>
        public Mod(string nombre, string descripcion, CategoriaMod categoria)
        {
            Nombre = nombre; // Asigna el nombre
            Descripcion = descripcion; // Asigna la descripción
            Activo = false;
            Categoria = categoria;
        }
        #endregion
    }
}
