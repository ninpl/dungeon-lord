#region Librerias
using UnityEngine;
#endregion

namespace Luminis
{
    /// <summary>
    /// ScriptableObject que contiene la información de los modos de juego.
    /// </summary>
    [CreateAssetMenu(fileName = "NuevoModoAsset", menuName = "Luminis/Modos/Nuevo Modo")]
    public class ModoAsset : ScriptableObject
    {
        #region Variables Publicas
        /// <summary>
        /// Nombre del modo de juego (Señor Demoníaco o Dios).
        /// </summary>
        public string nombre;
        /// <summary>
        /// Descripcion del modo de juego.
        /// </summary>
        public string descripcion;
        #endregion
    }
}


