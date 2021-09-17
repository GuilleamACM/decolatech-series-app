using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> m_seriesList = new List<Series>();
            
        public List<Series> List()
        {
            return m_seriesList;
        }

        public Series GetById(int id)
        {
            return m_seriesList[id];
        }

        public void Insert(Series entity)
        {
            m_seriesList.Add(entity);
        }

        public void Remove(int id)
        {
            m_seriesList[id].Delete();
        }

        public void Update(int id, Series entity)
        {
            m_seriesList[id] = entity;
        }

        public int NextId()
        {
            return m_seriesList.Count;
        }
    }
}