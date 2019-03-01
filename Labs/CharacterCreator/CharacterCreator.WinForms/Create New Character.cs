using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.WinForms
{
    public partial class Create_New_Character : Form
    {
        public Create_New_Character()
        {
            InitializeComponent();
        }


        public Character Character { get; set }

        private void OnSave( object sender, EventArgs e )
        {
            if (ValidateChildren())
                return;

            var character = SaveData();

            //Validate at business level
            if(!character.Valiate())
            {
                MessageBox.Show("Character not valid.", "Error", MessageBoxButtons.OK);
                return;
            };

            character = character;
            DialogResult = DialogResult.Cancel;
            Close();
                  
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadData( Character character )
        {
            _textName.Text = character.Name;
            _textProfession.Text = character.Professional;
            _textName.Text = character.Name;
            _textName.Text = character.Name;
            _textName.Text = character.Name;
            _textName.Text = character.Name;
            _textName.Text = character.Name;
            _textName.Text = character.Name;

        }
    }
}
