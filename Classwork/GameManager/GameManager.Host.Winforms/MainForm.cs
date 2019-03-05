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

             //Checking for null - long way
            if (game.Name != null && game.Name.Length == 0)
                ;

            //Short way
            if ((game.Name?.Length ?? 0) == 0)
                ;

            if (game.Name.Length == 0)
                /* is empty */
                ;


            var isCool = game.IsCoolGame;

            //Validate(game)
            game.Validate();

            //x.ToString();
            //var str = game.Publisher;
            //Decimal.TryParse("45.99", out game.Price);

            //_miGameAdd.Click += new EventHandler(OnGameAdd);

        }

        private void OnFileExit( object sender, EventArgs e )
        {
            //Local variable
            var x = 10;


            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show("Help");
            var form = new AboutBox();
            form.ShowDialog();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            BindList();
        }

        private void BindList ()
        {
            //Bind games to listbox
            _ListGames.Items.Clear();

            //nameof(Game.Name) == "Name"
            _ListGames.DisplayMember = nameof(Game.Name);

            _ListGames.Items.AddRange(_games.GetAll());
            //foreach (var game in _games)
            //{
            //    if(game != null)
            //    _ListGames.Items.Add(game);
            //}
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

            //Add
            //_games[GetNextEmptyGame()] = form.Game;
            _games.Add(form.Game);

            BindList();
        }

        //HACK: Find first spot with no game
        //private int GetNextEmptyGame ()
        //{
        //    for (var index = 0; index < _games.Length; ++index)
        //        if (_games[index] == null)
        //            return index;

        //    return -1;
        //}

        private GameDatabase _games = new GameDatabase();
        
       

        private void OnGameEdit( object sender, EventArgs e )
        {
         
            var form = new GameForm();

            var game = GetSelectedGame();
            if (game == null)
                return;

            //Game to edit
            form.Game = game;
            
            if (form.ShowDialog(this) != DialogResult.OK)
                return;


            //UpdateGame(game, form.Game);
            _games.Update(game.Id ,form.Game);
           
            BindList();
        }
        //private void UpdateGame (Game oldGame, Game newGame)
        //{
        //    for (var index = 0; index < _games.Length; ++index)
        //    {
        //        if (_games[index] == oldGame)
        //        {
        //            _games[index] = newGame;
        //            break;
        //        };
        //    };
        //}

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
            //DeleteGame(selected);
            _games.Delete(selected.Id);
            BindList();
        }

        //private void DeleteGame (Game game)
        //{
        //    for (var index = 0; index < _games.Length; ++index)
        //    {
                
                
        //            if(_games[index]==game)
        //            {
        //                _games[index] = null;
        //            }
                
        //    }
        //}

        private Game GetSelectedGame ()
        {
            // How to typecast in C#

            var value = _ListGames.SelectedItem;

            //C-style cast - don't do this
            //var game = (Game)value; // Game = DataType, value = Expression

            //Preferred - null if not valid
            var game = value as Game;  // Expression as DataType

            //Type check 
            var game2 = (value is Game) ? (Game)value : null; // Expression is DataType --> bool

            return _ListGames.SelectedItem as Game;
            
        }

        private void OnGameSelected( object sender, EventArgs e )
        {

        }

        protected override void OnFormClosing( FormClosingEventArgs e )
        {
            
            if(MessageBox.Show(this, "Are you sure?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            };
            base.OnFormClosing(e);
        }
    }
}
