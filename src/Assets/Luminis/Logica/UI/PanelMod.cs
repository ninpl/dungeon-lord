#region Librerias
using UnityEngine.UI;
using Luminis.Mods;
#endregion

namespace Luminis.UI
{
    /// <summary>
    /// Panel de la interfaz de usuario para gestionar mods.
    /// </summary>
    public class PanelMod : IPanel
    {
        #region Librerias
        /// <summary>
        /// Referencia al <see cref="AdministradorMods"/> para interactuar con los mods.
        /// </summary>
        public AdministradorMods modManager;
        /// <summary>
        /// Botones en la UI para cada mod disponible.
        /// </summary>
        public Button[] modButtons;
        #endregion

        #region Inicializadores
        /// <summary>
        /// Inicializa los botones al inicio del juego.
        /// </summary>
        private void Start()
        {
            // Asigna las funciones a los botones
            for (int i = 0; i < modButtons.Length; i++)
            {
                int index = i; // Captura el índice para el listener
                modButtons[i].onClick.AddListener(() => ToggleMod(index)); // Añade el listener al botón
            }
        }
        #endregion

        #region Metodos Privados
        /// <summary>
        /// Activa o desactiva un mod al presionar el botón correspondiente.
        /// </summary>
        /// <param name="modIndex">Índice del mod a gestionar.</param>
        private void ToggleMod(int modIndex)
        {
            // Comprueba si el mod está activo y llama al método correspondiente
            if (modManager.ObtenerMods()[modIndex].Activo)
                modManager.DesactivarMod(modIndex); // Desactiva el mod si está activo
            else
                modManager.ActivarMod(modIndex); // Activa el mod si no está activo
        }
        #endregion
    }
}
