﻿using System;
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


        /// <summary>
        /// Save your contact info (click save)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// In case you change your mind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadData( Contact contact )
        {
           
            _txtName.Text = contact.Name;
            _txtEmail.Text = contact.Email;
            
        }
        

        private Contact SaveData()
        {
            var contact = new Contact();
            contact.Name = _txtName.Text;
            contact.Email = _txtEmail.Text;
            
            
            var contact2 = new Contact(_txtName.Text, _txtEmail.Text);
            return contact;
        }

        
        protected virtual void CanbeChanged() { }

        
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //Init UI if editing a game
            if (Contact != null)
            {
                LoadData(Contact);
            }

            ValidateChildren();
        }

        /// <summary>
        /// Need to know your name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Need a valid address to send the message to
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        bool IsValidEmail( string Email)
        {
            try
            {
                new System.Net.Mail.MailAddress(Email);
                return true;
            } catch
            { };

            return false;
        }
    }

}

    

