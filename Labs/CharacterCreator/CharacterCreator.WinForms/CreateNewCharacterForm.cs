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
    public partial class CreateNewCharacterForm : Form
    {
        public CreateNewCharacterForm()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        /// <summary>
        /// Click the save button to process character data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var character = SaveData();


            // Validate at business level
            if (!character.Validate())
            {
                MessageBox.Show("Character not valid.", "Error", MessageBoxButtons.OK);
                return;
            };

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// // Gotta have a name, any name will do. Will take silly name like uhm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// // Gotta have a name, any name will do. Will take silly name like uhm.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private int ReadInt( TextBox control )
        {
            if (control.Text.Length == 0)
                return 0;

            if (int.TryParse(control.Text, out var value))
                return value;

            return -1;
        }

        /// <summary>
        /// Load the character's data 
        /// </summary>
        /// <param name="character"></param>
        private void LoadData( Character character )
        {
            _txtName.Text = character.Name;
            _txtProfession.Text = character.Profession;
            _txtRace.Text = character.Race;
            _txtStrength.Text = character.Strength.ToString();
            _txtIntelligence.Text = character.Intelligence.ToString();
            _txtAgility.Text = character.Agility.ToString();
            _txtConstitution.Text = character.Constitution.ToString();
            _txtCharisma.Text = character.Charisma.ToString();

        }

        /// <summary>
        /// //Saves user input into new character
        /// </summary>
        /// <returns></returns>
        private Character SaveData()
        {
            var character = new Character();
            character.Name = _txtName.Text;
            character.Profession = _txtProfession.Text;
            character.Race = _txtRace.Text;
            character.Strength = ReadInt(_txtStrength);
            character.Intelligence = ReadInt(_txtIntelligence);
            character.Agility = ReadInt(_txtAgility);
            character.Constitution = ReadInt(_txtConstitution);
            character.Charisma = ReadInt(_txtCharisma);



            
            var character2 = new Character(_txtName.Text, ReadInt(_txtStrength), ReadInt(_txtIntelligence), ReadInt(_txtAgility), ReadInt(_txtConstitution), ReadInt(_txtCharisma));
            return character;
        }

        
        
        protected override void OnLoad( EventArgs e )
        {
            
            // Centers the UI when initialized
            base.OnLoad(e);

            //Init UI if editing a game
            if (Character != null)
            {
                LoadData(Character);
            }

            ValidateChildren();
        }

        /// <summary>
        /// // Gotta have a name, any name will do. Will take silly name like uhm.
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
        ///  // Making sure the attributes are between 1 or 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnValidateAttributes( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            var attributes = ReadInt(tb);
            if (attributes < 1 || attributes > 100)
            {
                _errors.SetError(tb, "The attribute must be between 1 or 100.");
                e.Cancel = true;
            } else
                _errors.SetError(tb, "");
        }


    }

}

