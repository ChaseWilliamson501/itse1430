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
    public partial class CreateNewContacts : Form
    {
        public CreateNewContacts()
        {
            InitializeComponent();
        }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var game = SaveData();


            // Validate at business level
            try
            {
                //new ObjectValidator().Validate(game);
                ObjectValidator.Validate(game);
            } catch (ValidationException)
            {
                MessageBox.Show(this, "Game not valid.", "Error", MessageBoxButtons.OK);
                return;
            };
            //if (!game.Validate())
            //{
            //    MessageBox.Show("Game not valid.", "Error", MessageBoxButtons.OK);
            //    return;
            //};

            Game = game;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
