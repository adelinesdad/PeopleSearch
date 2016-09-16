using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PeopleSearch.Logic
{
    public interface ISearch<TEntity>
    {
        IList<TEntity> GetResults(string searchString);
    }

    public abstract class Search<TEntity> : ISearch<TEntity>
    {
        private IQueryable<TEntity> _queryable;

        private int _start = 0;
        private int _numResults = 0; // 0 = unlimited (default)
       
        public Search(IQueryable<TEntity> queryable)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException("queryable");
            }
            _queryable = queryable;
        }

        public int Start
        {
            get { return _start; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "Start cannot be negative.");
                }
                _start = value;
            }
        }

        public int NumResults
        {
            get { return _numResults; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "NumResults cannot be negative.");
                }
                _numResults = value;
            }
        }

        public IList<TEntity> GetResults(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                throw new ArgumentNullException("searchString", "searchString must not be empty.");
            }

            searchString = searchString.Trim();

            var query = this.GetQuery(_queryable, searchString);
            query = this.GetRange(query);
            
            return query.ToList();
        }

        protected abstract IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, string searchString);

        private IQueryable<TEntity> GetRange(IQueryable<TEntity> query)
        {
            if (this.Start > 0)
            {
                query = query.Skip(this.Start);
            }

            if (this.NumResults > 0)
            {
                query = query.Take(this.NumResults);
            }
            // else 0 means take all results

            return query;
        }
    }

    public sealed class PeopleSearcher : Search<Person>
    {
        public PeopleSearcher(IQueryable<Person> people) : base(people)
        {
        }

        protected override IQueryable<Person> GetQuery(IQueryable<Person> query, string searchString)
        {
            searchString = searchString.ToLower();
            return query.Where(p => p.Name.ToLower().Contains(searchString))
                .OrderBy(p => p.Name);   // todo: support other search orders and directions
        }
    }
}