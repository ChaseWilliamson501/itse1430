﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager
{
    
    public class MemoryGameDatabase : GameDatabase
    {
       

        protected override Game AddCore( Game game )
        {
            
            game.Id = ++_nextId;
            _items.Add(Clone(game));

            return game;
        }

        protected override void DeleteCore( int id )
        { 

            var index = GetIndex(id);
            if (index >= 0)
                _items.RemoveAt(index);
          
        }

        protected override Game GetCore( int id )
        {

            var index = GetIndex(id);
            if (index >= 0)
                return Clone(_items[index]);

            return null;
        }

        //public Game[] GetAll()
        protected override IEnumerable<Game> GetAllCore()
        {
            //Use iterator
            //foreach (var item in _items)
            //    yield return Clone(item);
            //return _items;

            return _items.Select(Clone);
        }

        protected override Game UpdateCore( int id, Game game )
        {
            var index = GetIndex(id);

            game.Id = id;
            var existing = _items[index];
            Clone(existing, game);

            return game;
        }

        private Game Clone( Game game )
        {
            var newGame = new Game();
            Clone(newGame, game);

            return newGame;
        }

        private void Clone( Game target, Game source )
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.Owned = source.Owned;
            target.Completed = source.Completed;
        }

        private int GetIndex( int id )
        {
            //var tempType = new IsIdType() { Id = id };
            //Can use lambda anywhere you need a function object, must be explicit on type
            //Func<Game, bool> isId = (g) => g.Id == id;

            //_items = all games
            // .Where = filters down to only those matching IsId
            // .FirstOrDefault = returns first of filtered items, if any
            var game = _items.Where((g) => g.Id == id).FirstOrDefault();

            //Demoing anonymous type
            //var games = from g in _items
            //            where g.Id == id
            //            select new { Id = g.Id, Name = g.Name };
            //var game = games.FirstOrDefault();
            if (game != null)
                return _items.IndexOf(game);

            //Forget this
            //for (var index = 0; index < _items.Count; ++index)
            //    if (_items[index]?.Id == id)
            //        return index;

            return -1;
        }

        //Helper type to capture data needed by function
        //private sealed class IsIdType

        //{
        //    public int Id { get; set; }

        //    public bool IsId( Game game )
        //    {
        //        return game.Id == Id;
        //    }
        //}
        //Arrays are so 90s
        //private readonly Game[] _items = new Game[100];

        //ArrayLists are so 00s
        //private readonly ArrayList _items = new ArrayList();

        private readonly List<Game> _items = new List<Game>();
        //private readonly Collection<Game> _items = new Collection<Game>();

        private int _nextId = 0;
    }
}

