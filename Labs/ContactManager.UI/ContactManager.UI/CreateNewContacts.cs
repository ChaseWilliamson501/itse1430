using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class CreateNewContacts : Form
    {
        public CreateNewContacts()
        {
            InitializeComponent();
        }

        public Contact Contact { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var contact = SaveData();


            // Validate at business level
            try
            {
               
                ObjectValidator.Validate(contact);
            } catch (ValidationException)
            {
                MessageBox.Show(this, "Contact information not valid.", "Error", MessageBoxButtons.OK);
                return;
            };
            

            Contact = contact;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadData( Contact Contact )
        {
            _txtName.Text = contact.Name;
            _txtEmail.Text = contact.Email;
            
        }
        //Saves UI into new game

        private Contact SaveData()
        {
            var contact = new Contact();
            contact.Name = _txtName.Text;
            contact.Email = _txtEmail.Text;
            
            //Demoing ctor
            var contact2 = new Contact(_txtName.Text, (_txtEmail));
            return contact;
        }

        //Defined in types
        //Derived types may override and change it
        protected virtual void CanbeChanged() { }

        //Override a virtual member in Form
        protected override void OnLoad( EventArgs e )
        {
            //this.OnLoad(e);
            base.OnLoad(e);

            //Init UI if editing a game
            if (Contact != null)
            {
                LoadData(Contact);
            }

            ValidateChildren();
        }


        private void OnValidateName( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            if (tb.Text.Length == 0)
            {
                _errors.SetError(tb, "Name is required.");
                e.Cancel = true;
            } else
                _errors.SetError(tb, "");
        }

        private void OnValidateEmail( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            if (tb.Text.Length == 0)
            {
                _errors.SetError(tb, "Email is required.");
                e.Cancel = true;
            } else
                _errors.SetError(tb, "");
        }



        bool IsValidEmail( string source )
        {
            try
            {
                new System.Net.Mail.MailAddress(source);
                return true;
            } catch
            { };

            return false;
        }
    }

}

    

