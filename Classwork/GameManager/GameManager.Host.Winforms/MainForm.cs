using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameManager.Host.Winforms
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
            Game game = new Game();



            game.Name = "Star Wars FU";
            game.Price = 59.99M;

            var name = game.Name;
            if (name.Length == 0)
                /* is empty */
                ;
            if (game.Name.Length == 0)
                /* is empty */
                ;


            var isCool = game.IsCoolGame;

            //Validate(game)
            game.Valiate();

            //x.ToString();
            //var str = game.Publisher;
            //Decimal.TryParse("45.99", out game.Price);

            _miGameAdd.Click += new EventHandler(OnGameAdd);

        }

        private void OnFileExit( object sender, EventArgs e )
        {
            //Local variable
            var x = 10;


            Close();
        }

        private void fileToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show("Help");
            var form = new AboutBox();
            form.ShowDialog();
        }

        private void OnGameAdd( object sender, EventArgs e )
        {
            
            //Display UI
            var form = new GameForm();

            //Modeless
            //form.Show();

            //Model
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            //If Ok then "add" to system
            _game = form.Game;
        }

        private Game _game;
        
       

        private void OnGameEdit( object sender, EventArgs e )
        {
         
            var form = new GameForm();

            //Game to edit
            form.Game = _game;
            
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            _game = form.Game;
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
            _game = null;
        }

        private Game GetSelectedGame ()
        {
            return _game;
        }
    }
}
