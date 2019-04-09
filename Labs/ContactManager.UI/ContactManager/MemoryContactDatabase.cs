using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class MemoryContactDatabase : ContactDatabase
    {
        protected override Contact AddCore( Contact contact )
        {

            contact.Id = ++_nextId;
            _items.Add(Clone(contact));

            return contact;
        }

        protected override void DeleteCore( int id )
        {

            var index = GetIndex(id);
            if (index >= 0)
                _items.RemoveAt(index);

        }

        protected override Contact GetCore( int id )
        {

            var index = GetIndex(id);
            if (index >= 0)
                return Clone(_items[index]);

            return null;
        }

       
        protected override IEnumerable<Contact> GetAllCore()
        {
            //Use iterator
            foreach (var item in _items)
                yield return Clone(item);
        }

        protected override Contact UpdateCore( int id, Contact game )
        {
            var index = GetIndex(id);

            game.Id = id;
            var existing = _items[index];
            Clone(existing, game);

            return game;
        }

        private Contact Clone( Contact game )
        {
            var newContact = new Contact();
            Clone(newContact, contact);

            return newContact;
        }

        private void Clone( Contact target, Contact source )
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Email = source.Email;
            
        }

        private int GetIndex( int id )
        {
            for (var index = 0; index < _items.Count; ++index)
                if (_items[index]?.Id == id)
                    return index;

            return -1;
        }



        //Arrays are so 90s
        //private readonly Game[] _items = new Game[100];

        //ArrayLists are so 00s
        //private readonly ArrayList _items = new ArrayList();

        private readonly List<Contact> _items = new List<Contact>();
        //private readonly Collection<Game> _items = new Collection<Game>();

        private int _nextId = 0;
    }
}

    

