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

        void LoadUI ()
        {
            Game game = new Game();


            
            game.Name = "Star Wars FU";
            game.Price = 59.99M;

            //Validate(game)
            game.Valiate();

            //x.ToString();
            //var str = game.Publisher;
            //Decimal.TryParse("45.99", out game.Price);




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
        }

        private void addToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }
    }
}
