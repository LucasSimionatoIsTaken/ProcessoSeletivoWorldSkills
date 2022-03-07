using AlatechMachines.webAPI.Contexts;
using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AlatechMachines.webAPI.Repositories
{
    public class GraphicCardRepository : IGraphicCardRepository
    {
        private readonly AlatechDbContext _ctx = new AlatechDbContext();
        public GraphicCard GetById(int id)
        {
            return _ctx.GraphicCards.Find(id);
        }

        public List<GraphicCard> Read()
        {
            return _ctx.GraphicCards.ToList();
        }

        public List<GraphicCard> SearchByName(string name)
        {
            List<GraphicCard> GraphicCards = _ctx.GraphicCards.ToList();

            List<GraphicCard> GraphicCardsWithName = new List<GraphicCard>();

            foreach (GraphicCard graphicCard in GraphicCards)
            {
                if (graphicCard.Name.ToLower().Contains(name.ToLower()))
                {
                    GraphicCardsWithName.Add(graphicCard);
                }
            }

            return GraphicCardsWithName;
        }
    }
}
