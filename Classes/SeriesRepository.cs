using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    public class SeriesRepository : IRepository<TvSeries>
    {
        private List<TvSeries> _seriesList = new List<TvSeries>();
            
        public List<TvSeries> List()
        {
            return _seriesList;
        }

        public TvSeries GetById(int id)
        {
            return _seriesList[id];
        }

        public void Insert(TvSeries entity)
        {
            _seriesList.Add(entity);
        }

        public void Remove(int id)
        {
            _seriesList[id].Delete();
        }

        public void Update(int id, TvSeries entity)
        {
            _seriesList[id] = entity;
        }

        public int NextId()
        {
            return _seriesList.Count;
        }
    }
}