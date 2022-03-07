using AlatechMachines.webAPI.Domains;
using System.Collections.Generic;

namespace AlatechMachines.webAPI.Interfaces
{
    public interface IGraphicCardRepository
    {
        /// <summary>
        /// List all graphicCards
        /// </summary>
        /// <returns>GraphicCards list</returns>
        List<GraphicCard> Read();

        /// <summary>
        /// Get a graphicCard by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>GraphicCard or null</returns>
        GraphicCard GetById(int id);

        /// <summary>
        /// Search graphicCards by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>GraphicCards list</returns>
        List<GraphicCard> SearchByName(string name);
    }
}
