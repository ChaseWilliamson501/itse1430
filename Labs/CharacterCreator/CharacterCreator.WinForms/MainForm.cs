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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            LoadUI();
        }

        void LoadUI()
        {
            Character character = new Character();

            var name = character.Name;

            //Validate(character)
            character.Validate();

   
        }

        private void BindList()
        {
            //Bind games to listbox
            _ListOfCharacters.Items.Clear();

            //nameof(Game.Name) == "Name"
            _ListOfCharacters.DisplayMember = nameof(Character.Name);

            foreach (var character in _characters)
            {
                if (character != null)
                    _ListOfCharacters.Items.Add(character);
            }
        }

        private void OnCharacterNew( object sender, EventArgs e )
        {
            //Display UI
            var form = new CreateNewCharacterForm();

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            BindList();
        }

        private void DisplayError( Exception ex )
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private int GetNextEmptyCharacter()
        {
            for (var index = 0; index < _characters.Length; ++index)
                if (_characters[index] == null)
                    return index;

            return -1;
        }

        private Character[] _characters = new Character[100];

        private void OnCharacterEdit( object sender, EventArgs e )
        {
            var form = new CreateNewCharacterForm();

            var character = GetSelectedCharacter();
            if (character == null)
                return;

            //Game to edit
            form.Character = character;

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: Fix to edit, not add
            UpdateCharacter(character, form.Character);

            BindList();
        }
        private void UpdateCharacter( Character oldCharacter, Character newCharacter )
        {
            for (var index = 0; index < _characters.Length; ++index)
            {
                if (_characters[index] == oldCharacter)
                {
                    _characters[index] = newCharacter;
                    break;
                };
            };
        }

        private void OnCharacterDelete( object sender, EventArgs e )
        {
            //Get selected game, if any
            var selected = GetSelectedCharacter();
            if (selected == null)
                return;

            //Display confirmation
            if (MessageBox.Show(this, $"Are you sure want to delete {selected.Name}?", "Confirm Delete",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //TODO: DELETE
            DeleteCharacter(selected);
            BindList();
        }

        private void DeleteCharacter( Character character )
        {
            for (var index = 0; index < _characters.Length; ++index)
            {


                if (_characters[index] == character)
                {
                    _characters[index] = null;
                }

            }
        }

        private Character GetSelectedCharacter()
        {
            // How to typecast in C#

            var value = _ListOfCharacters.SelectedItem;

            //C-style cast - don't do this
            //var game = (Game)value; // Game = DataType, value = Expression

            //Preferred - null if not valid
            var character = value as Character;  // Expression as DataType

            //Type check 
            var character2 = (value is Character) ? (Character)value : null; // Expression is DataType --> bool

            return _ListOfCharacters.SelectedItem as Character;

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
