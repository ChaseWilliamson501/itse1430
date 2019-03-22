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

        /// <summary>
        /// Bind the new Character to the _ListOfCharacters
        /// </summary>
        private void BindList()
        {
            //Bind games to listbox
            _ListOfCharacters.Items.Clear();
            _ListOfCharacters.DisplayMember = nameof(Character.Name);

            foreach (var character in _characters)
            {
                if (character != null)
                    _ListOfCharacters.Items.Add(character);
            }
        }

        /// <summary>
        /// Opens up the UI to create your fantasy character (Character->New)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCharacterNew( object sender, EventArgs e )
        {
            //Display UI
            var form = new CreateNewCharacterForm();

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            for (var index = 0; index < _characters.Length; ++index)
            {
               if (_characters[index] == null)
                {
                    _characters[index] = form.Character;
                    break;
                }
                        
            }
            BindList();
        }

        /// <summary>
        /// When somethings wasn't suppose to happen
        /// </summary>
        /// <param name="ex"></param>
        private void DisplayError( Exception ex )
        {
            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Exit the Program (File -> exit)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileExit( object sender, EventArgs e )
        {
            this.Close();
        }

        /// <summary>
        /// Info about the program and it's creator (yours truly)
        /// (Help -> About)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// To make changes a character(s) (Character->Edit)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Delete a Character (Character->Delete)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
          
            var value = _ListOfCharacters.SelectedItem;

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
