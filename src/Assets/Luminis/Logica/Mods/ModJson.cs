#region Librerias
using System;
#endregion

namespace Luminis.Mods
{
    /// <summary>
    /// Clase que representa los datos de un mod deserializados desde JSON.
    /// </summary>
    [System.Serializable]
    public class ModJson
    {
        #region Variables Publicas
        public string Name;
        public string Description;
        public string Category;
        #endregion

        /// <summary>
        /// Convierte este objeto ModJson a un objeto Mod.
        /// </summary>
        public Mod ToMod()
        {
            // Verifica que la categoría no sea nula ni vacía
            if (string.IsNullOrEmpty(Category))
            {
                throw new ArgumentException("La categoría no puede ser nula o vacía.");
            }

            // Convierte el nombre de la categoría en el JSON a su correspondiente en el enum
            CategoriaMod categoriaMod = ConvertirCategoria(Category);
            return new Mod(Name, Description, categoriaMod);
        }

        #region Metodos Privados
        /// <summary>
        /// Convierte el nombre de la categoría en el JSON al valor correspondiente en el enum CategoriaMod.
        /// </summary>
        /// <param name="categoria">El nombre de la categoría en el JSON.</param>
        /// <returns>El valor correspondiente en el enum CategoriaMod.</returns>
        private CategoriaMod ConvertirCategoria(string categoria)
        {
            switch (categoria)
            {
                case "Lord":
                    return CategoriaMod.Lord; // Mapea "Lord" a Lord
                case "Goddesses":
                    return CategoriaMod.Diosa; // Mapea "Goddesses" a Diosa
                case "Mode":
                    return CategoriaMod.Modo; // Mapea "Mode" a Modo
                case "Unit":
                    return CategoriaMod.Unidad; // Mapea "Unit" a Unidad
                case "Event":
                    return CategoriaMod.Evento; // Mapea "Event" a Evento
                case "Translation":
                    return CategoriaMod.Traduccion; // Mapea "Translation" a Traduccion
                default:
                    throw new ArgumentException($"La categoría '{categoria}' no es válida.");
            }
        }
        #endregion
    }
}
