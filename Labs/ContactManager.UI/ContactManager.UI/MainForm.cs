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
                    

                    OnSafeAdd(form);
                    break;
                } catch (InvalidOperationException)
                {
                    MessageBox.Show(this, "invalid contact.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                
                _contacts.Add(form.Contact);
            } catch (NotImplementedException e)
            {
                
                throw new Exception("Not implemented yet", e);
            } catch (Exception e)
            {
               
                throw;
            };
        }


        private IContactDatabase _contacts = new MemoryContactDatabase();

        private Contact GetSelectedContact()
        {
            var value = _ListContacts.SelectedItem;

            
            var contact = value as Contact;

           
            var contact2 = (value is Contact) ? (Contact)value : null;

            return _ListContacts.SelectedItem as Contact;
        }

        


        private void OnContactsSend( object sender, EventArgs e )
        {
            _txtMessageBox.Text += Console.WriteLine($"? {completed}");
            _txtMessageBox.Text += Console.WriteLine($"? {completed}");
            _txtMessageBox.Text += Console.WriteLine($"? {completed}");
        }

        private void OnContactsEdit( object sender, EventArgs e )
        {
            var form = new CreateNewContacts();

            var contact = GetSelectedContacts();
            if (contact == null)
                return;

            //Contact to edit
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
            // Get selected Contact, if any
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

            var game = value as Contact;

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
