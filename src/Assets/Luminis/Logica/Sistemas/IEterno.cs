namespace Luminis
{
    /// <summary>
    /// Clase abstracta base que representa a una entidad eterna, como un Señor Demoníaco o un Dios.
    /// </summary>
    public abstract class IEterno
    {
        #region Variables Privadas
        /// <summary>
        /// Datos del modo de juego, gestionados mediante un ScriptableObject.
        /// </summary>
        protected ModoAsset datos;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que inicializa la entidad modo con los datos del ScriptableObject.
        /// </summary>
        /// <param name="datos">ScriptableObject que contiene los datos del modo de juego.</param>
        public IEterno(ModoAsset datos)
        {
            this.datos = datos;
        }
        #endregion

        #region API
        /// <summary>
        /// Método abstracto que activa el modo de juego específico.
        /// </summary>
        public abstract void ActivarModoJuego();
        #endregion
    }
}