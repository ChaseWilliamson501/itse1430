using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class SubjectAndMessage : Form
    {
        public SubjectAndMessage()
        {
            InitializeComponent();
        }

        public Message Message { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var message = SaveData();


            
            try
            {

                ObjectValidator.Validate(message);
            } catch (ValidationException)
            {
                MessageBox.Show(this, "Contact information not valid.", "Error", MessageBoxButtons.OK);
                return;
            };


            Message = message;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadData( Message message )
        {
            message.Subject = _txtSubject.Text;
            message.Body = _txtMessage.Text;

        }
      

        private Message SaveData()
        {
            var message = new Message();
            message.Subject = _txtSubject.Text;
            message.Body = _txtMessage.Text;

            
            var message2 = new Message(_txtSubject.Text, _txtMessage.Text);
            return message;
        }

        
        protected virtual void CanbeChanged() { }

        
        protected override void OnLoad( EventArgs e )
        {
            
            base.OnLoad(e);

            //Init UI if editing a game
            if (Message != null)
            {
                LoadData(Message);
            }

            ValidateChildren();
        }


        private void OnValidateSubject( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            if (tb.Text.Length == 0)
            {
                _errors.SetError(tb, "Subject is required.");
                e.Cancel = true;
            } else
                _errors.SetError(tb, "");
        }
    }
}
