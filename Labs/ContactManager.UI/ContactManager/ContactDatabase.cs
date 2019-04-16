﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public abstract class ContactDatabase : IContactDatabase
    {
        public Contact Add( Contact contact )
        {
            //Validate input
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            
            ObjectValidator.Validate(contact);

            //contact names must be unique
            var existing = FindByName(contact.Name);
            if (existing != null)
                throw new Exception("Contact must be unique.");

            return AddCore(contact);


        }

        public void Remove( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            DeleteCore(id);

        }

        public Contact Get( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);

        }

       
        public IEnumerable<Contact> GetAll()
        {
            return GetAllCore();
        }

        public Contact Update( int id, Contact contact )
        {
            //Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));


            ObjectValidator.Validate(contact);

            var sameName = FindByName(contact.Name);
            if (sameName != null && sameName.Id != id)
                throw new Exception("Contact info must be unique.");

            return UpdateCore(id, contact);
        }

        protected abstract Contact AddCore( Contact contact );

        protected abstract void DeleteCore( int id );

        protected virtual Contact FindByName( string name )
        {
            foreach (var contact in GetAllCore())
            {
                if (String.Compare(contact.Name, name, true) == 0)
                    return contact;
            };

            return null;
        }

        protected abstract Contact GetCore( int id );

        protected abstract IEnumerable<Contact> GetAllCore();

        protected abstract Contact UpdateCore( int id, Contact newContacts );

    }
}
