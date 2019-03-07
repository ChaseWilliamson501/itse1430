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

        public Character Character { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var character = SaveData();


            // Validate at business level
            if (!character.Validate())
            {
                MessageBox.Show("Game not valid.", "Error", MessageBoxButtons.OK);
                return;
            };

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private int ReadInt( TextBox control )
        {
            if (control.Text.Length == 0)
                return 0;

            if (int.TryParse(control.Text, out var value))
                return value;

            return -1;
        }

        private void LoadData( Character character )
        {
            _txtName.Text = character.Name;
            _txtProfession.Text = character.Profession;
            _txtRace.Text = character.Race;
            _txtStrength.Text = character.Strength.ToString();
            _txtIntelligence.Text = character.Intelligence.ToString();
            _txtAgility.Text = character.Agility.ToString();
            _txtConstitution.Text = character.Constitution.ToString();
            _txtCharisma.Text = character.Chrisma.ToString();

        }
        //Saves UI into new game

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
            character.Chrisma = ReadInt(_txtCharisma);



            //Demoing ctor
            var character2 = new Character(_txtName.Text, ReadInt(_txtStrength), ReadInt(_txtIntelligence), ReadInt(_txtAgility), ReadInt(_txtConstitution), ReadInt(_txtCharisma));
            return character;
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
            if (Character != null)
            {
                LoadData(Character);
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
                _errors.SetError(tb, " ");
        }

        private void OnValidateProfession( object sender, CancelEventArgs e )
        {
            
        }

        private void OnValidateRace( object sender, CancelEventArgs e )
        {

        }

        private void OnValidateAttributes( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            var price = ReadInt(tb);
            if (price < 0)
            {
                _errors.SetError(tb, "Price must be >= 0.");
                e.Cancel = true;
            } else
                _errors.SetError(tb, " ");
        }
    }

}
}
