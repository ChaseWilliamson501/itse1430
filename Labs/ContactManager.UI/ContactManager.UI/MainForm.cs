using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            this.Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show("Help");
            var form = new AboutBox();
            form.ShowDialog();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //Seed if database is empty
            var games = _contacts.GetAll();
            if (games.Count() == 0)
                //SeedDatabase.Seed(_games);
                _contacts.Seed();

            BindList();
        }

        private void BindList()
        {
            //Bind games to listbox
            _ListContacts.Items.Clear();
            _ListContacts.DisplayMember = nameof(Contact.Name);

            var items = _contacts.GetAll();
            items = items.OrderBy(GetName);

            _ListContacts.Items.AddRange(items.ToArray());

        }

        private string GetName( Contact contact )
        {
            return contact.Name;
        }

        private void OnContactAdd( object sender, EventArgs e )
        {
            // Display UI
            var form = new CreateNewContacts();

            while (true)
            {
                //Modal
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                //Add
                try
                {
                    //Anything in here that raises an exception will
                    //be sent to the catch block

                    OnSafeAdd(form);
                    break;
                } catch (InvalidOperationException)
                {
                    MessageBox.Show(this, "Choose a better game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex)
                {
                    //Recover from errors
                    DisplayError(ex);
                };
            };

            BindList();
        }


        private void DisplayError( Exception ex )
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnSafeAdd( CreateNewContacts form )
        {
            try
            {
                //_games[GetNextEmptyGame()] = form.Game;
                _contacts.Add(form.Contact);
            } catch (NotImplementedException e)
            {
                //Rewriting an exception
                throw new Exception("Not implemented yet", e);
            } catch (Exception e)
            {
                //Log a message 

                //Rethrow exception - wrong way
                //throw e;
                throw;
            };
        }


        private IContactDatabase _contacts = new MemoryContactDatabase();

        private Contact GetSelectedContact()
        {
            var value = _ListContacts.SelectedItem;

            //C-style cast - don't do this
            //var game = (Game)value;

            //Preferred - null if not valid
            var game = value as Contact;

            //Type check
            var game2 = (value is Contact) ? (Contact)value : null;

            return _ListContacts.SelectedItem as Contact;
        }


        /// <summary>
        /// OnContactEdit and OnContactDelete
        /// </summary>
        /// <returns></returns>

        private void OnContactsSend( object sender, EventArgs e )
        {

        }

        private void OnContactsEdit( object sender, EventArgs e )
        {
            var form = new CreateNewContacts();

            var contact = GetSelectedContacts();
            if (contact == null)
                return;

            //Game to edit
            form.Contact = contact;

            while (true)
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    //UpdateGame(game, form.Game);            
                    _contacts.Update(contact.Id, form.Contact);
                    break;
                } catch (Exception ex)
                {
                    DisplayError(ex);
                };
            };

            BindList();
        }

        private void OnContactsDelete( object sender, EventArgs e )
        {
            // Get selected game, if any
            var selected = GetSelectedContacts();
            if (selected == null)
                return;

            //Display confirmation
            if (MessageBox.Show(this, $"Are you sure you want to delete {selected.Name}?",
                               "Confirm Delete", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                //DeleteGame(selected);
                _contacts.Remove(selected.Id);
            } catch (Exception ex)
            {
                DisplayError(ex);
            };
            BindList();
        }
    

        private Contact GetSelectedContacts()
        {
            var value = _ListContacts.SelectedItem;

            //C-style cast - don't do this
            //var game = (Game)value;

            //Preferred - null if not valid
            var game = value as Contact;

            //Type check
            var game2 = (value is Contact) ? (Contact)value : null;

            return _ListContacts.SelectedItem as Contact;
        }


        protected override void OnFormClosing( FormClosingEventArgs e )
        {
            if (MessageBox.Show(this, "Are you sure?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            };
            base.OnFormClosing(e);
        }

        
    }
}
