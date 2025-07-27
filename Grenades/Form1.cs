using System.Media;

namespace Grenades
{
    public partial class Form1 : Form
    {
        /* Explosion Sound*/
        SoundPlayer sPlayer = new SoundPlayer(Resource.explosion);

        /*Grenade Location*/
        Random xRandom = new Random();/*0-750*/

        /*Grenade PictureBox*/
        PictureBox grenade = null;
        PictureBox grenade2 = null;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                character.Location = new Point(character.Location.X-7,character.Location.Y);
                character.Image = Resource.runner_left;
            }

            if (e.KeyCode == Keys.Right)
            {
                character.Location = new Point(character.Location.X+7,character.Location.Y);
                character.Image = Resource.runner_right;

            }
        }


        private void generationTimer_Tick(object sender, EventArgs e)
        {
            /*Grenade 1*/
            grenade = new PictureBox();
            grenade.Image = Resource.grenade;
            grenade.SizeMode = PictureBoxSizeMode.CenterImage;
            grenade.Size = new Size(50, 50);
            grenade.Location = new Point(xRandom.Next(0, 750), 20);

            /*Grenade 2*/
            grenade2 = new PictureBox();
            grenade2.Image = Resource.grenade;
            grenade2.SizeMode = PictureBoxSizeMode.CenterImage;
            grenade2.Size = new Size(50, 50);
            grenade2.Location = new Point(xRandom.Next(0, 750), 20);

            /*Add the Form*/
            this.Controls.Add(grenade);
            this.Controls.Add(grenade2);
        }

        private void movementTimer_Tick(object sender, EventArgs e)
        {
            if (grenade != null && grenade2 != null)
            {
                grenade.Location = new Point(grenade.Location.X, grenade.Location.Y + 7);
                grenade2.Location = new Point(grenade2.Location.X, grenade2.Location.Y + 7);
            }

            
            if (grenade is null || grenade2 is null) { return; };
            // Eðer grenade nesneleri henüz oluþturulmadýysa (null ise),
            // aþaðýdaki hareket ve çarpýþma iþlemlerini yapma.

            if (character.Bounds.IntersectsWith(grenade.Bounds) || character.Bounds.IntersectsWith(grenade2.Bounds))
            {
                /* Delete Grenade Object */
                grenade.Dispose();
                grenade2.Dispose();

                /* Timer Stop */
                generationTimer.Stop();
                movementTimer.Stop();

                /* Exposion Sound */
                sPlayer.Play();

                /* Message */
                MessageBox.Show("Oyun Bitti !","Kaybettiniz",MessageBoxButtons.OK,MessageBoxIcon.Error);

                /*Close the App*/
                this.Dispose();

            }
        }

        
    }
}
