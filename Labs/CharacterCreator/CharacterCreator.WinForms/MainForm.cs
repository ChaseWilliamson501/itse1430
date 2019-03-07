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
            if (name.Length == 0)
                /* is empty */

                //Checking for null - long way
                if (character.Name != null && character.Name.Length == 0)
                    ;

            //Short way
            if ((character.Name?.Length ?? 0) == 0)
                ;

            if (character.Name.Length == 0)
                /* is empty */
                ;


            var isCool = character.IsCoolCharacter;

            //Validate(game)
            character.Validate();


        }

        private void BindList()
        {
            //Bind games to listbox
            _ListOfCharacters.Items.Clear();

            //nameof(Game.Name) == "Name"
            _ListOfCharacters.DisplayMember = nameof(Character.Name);

            //_ListGames.Items.AddRange(_game)
            foreach (var character in _characters)
            {
                if (character != null)
                    _ListOfCharacters.Items.Add(character);
            }
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

        private int GetNextEmptyGame()
        {
            for (var index = 0; index < _characters.Length; ++index)
                if (_characters[index] == null)
                    return index;

            return -1;
        }

        private Character[] _characters = new Character[100];

        private void OnGameEdit( object sender, EventArgs e )
        {
            var form = new Create_New_Character();

            var game = GetSelectedGame();
            if (game == null)
                return;

            //Game to edit
            form.Character = character;

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            //TODO: Fix to edit, not add
            UpdateGame(game, form.Character);

            BindList();
        }
        private void UpdateGame( Character oldCharacter, Character newCharacter )
        {
            for (var index = 0; index < _characters.Length; ++index)
            {
                if (_characters[index] == _character)
                {
                    _characters[index] = newCharacter;
                    break;
                };
            };
        }

        private void OnGameDelete( object sender, EventArgs e )
        {
            //Get selected game, if any
            var selected = GetSelectedGame();
            if (selected == null)
                return;

            //Display confirmation
            if (MessageBox.Show(this, $"Are you sure want to delete {selected.Name}?", "Confirm Delete",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //TODO: DELETE
            DeleteGame(selected);
            BindList();
        }

        private void DeleteGame( Character character )
        {
            for (var index = 0; index < _characters.Length; ++index)
            {


                if (_characters[index] == character)
                {
                    _characters[index] = null;
                }

            }
        }

        private Character GetSelectedGame()
        {
            // How to typecast in C#

            var value = _ListOfCharacters.SelectedItem;

            //C-style cast - don't do this
            //var game = (Game)value; // Game = DataType, value = Expression

            //Preferred - null if not valid
            var game = value as Character;  // Expression as DataType

            //Type check 
            var game2 = (value is Character) ? (Character)value : null; // Expression is DataType --> bool

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
