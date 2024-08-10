using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace tictactoe_ass
{
    public partial class Image_Sliding_Puzzle : Form
    {
        private readonly List<PictureBox> _pictureBoxes = new List<PictureBox>();
        private readonly List<string> _locations = new List<string>();
        private string _winPosition;
        private Bitmap _mainBitmap;
        private List<Bitmap> _images = new List<Bitmap>();

        public Image_Sliding_Puzzle()
        {
            InitializeComponent();

        }

        private void Open_File(object sender, EventArgs e)
        {
            ResetGame();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files Only | *.jpg; *.jpeg; *.gif; *.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _mainBitmap = new Bitmap(openFileDialog.FileName);
                CreatePictureBoxes();
                AddImages();
                SolvePuzzle();
            }
        }
        private void ResetGame()
        {
            foreach (PictureBox pictureBox in _pictureBoxes.ToList())
            {
                this.Controls.Remove(pictureBox);
            }
            _pictureBoxes.Clear();
            _locations.Clear();
            _winPosition = string.Empty;
            stat_lbl.Text = string.Empty;
        }


        private void CreatePictureBoxes()
        {
            for (int i = 0; i < 9; i++)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(PictureBoxSize, PictureBoxSize),
                    Tag = i.ToString()
                };
                pictureBox.Click += OnPicClick; // Corrected line
                _pictureBoxes.Add(pictureBox);
                _locations.Add(pictureBox.Tag.ToString());
            }
        }

        private const int PictureBoxSize = 130;


        private void AddImages()
        {
            Bitmap tempBitmap = new Bitmap(_mainBitmap, new Size(390, 390));
            CropImage(tempBitmap, PictureBoxSize, PictureBoxSize);
            for (int i = 1; i < _pictureBoxes.Count; i++)
            {
                _pictureBoxes[i].BackgroundImage = (Image)_images[i];
            }
            PlacePictureBoxesToForm();
        }

        private void PlacePictureBoxesToForm()
        {
            var shuffledPictureBoxes = _pictureBoxes.OrderBy(a => Guid.NewGuid()).ToList();
            // _pictureBoxes = shuffledPictureBoxes;
            _pictureBoxes.Clear();
            _pictureBoxes.AddRange(shuffledPictureBoxes);
            int x = InitialXPosition;
            int y = InitialYPosition;
            for (int i = 0; i < _pictureBoxes.Count; i++)
            {
                _pictureBoxes[i].BackColor = Color.MediumPurple;
                if (i == 3 || i == 6)
                {
                    y += PictureBoxSize;
                    x = InitialXPosition;
                }
                _pictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                _pictureBoxes[i].Location = new Point(x, y);
                this.Controls.Add(_pictureBoxes[i]);
                x += PictureBoxSize;
                _winPosition += _locations[i];
            }
        }
        private const int InitialXPosition = 200;
        private const int InitialYPosition = 25;

        private void OnPicClick(object? sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            PictureBox emptyBox = _pictureBoxes.Find(x => x.Tag.ToString() == "0");
            Point pic1 = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            Point pic2 = new Point(emptyBox.Location.X, emptyBox.Location.Y);
            var index1 = this.Controls.IndexOf(pictureBox);
            var index2 = this.Controls.IndexOf(emptyBox);
            if (pictureBox.Right == emptyBox.Left && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Left == emptyBox.Right && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Top == emptyBox.Bottom && pictureBox.Location.X == emptyBox.Location.X
                || pictureBox.Bottom == emptyBox.Top && pictureBox.Location.X == emptyBox.Location.X
                )
            {
                pictureBox.Location = pic2;
                emptyBox.Location = pic1;
                this.Controls.SetChildIndex(pictureBox, index2);
                this.Controls.SetChildIndex(emptyBox, index1);
            }
            stat_lbl.Text = "";
            CheckGame();
        }

        private void CropImage(Bitmap main_bitmap, int height, int width)
        {
            int x, y;
            x = 0;
            y = 0;
            for (int blocks = 0; blocks < 9; blocks++)
            {
                Bitmap cropped_image = new Bitmap(height, width);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        cropped_image.SetPixel(i, j, main_bitmap.GetPixel((i + x), (j + y)));
                    }
                }
                _images.Add(cropped_image); // Added cropped image to the images list
                x += 130;
                if (x == 390)
                {
                    x = 0;
                    y += 130;
                }
            }
        }

        private void CheckGame()
        {
            List<string> currentLocations = new List<string>();

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    currentLocations.Add(control.Tag.ToString());
                }
            }

            string currentPosition = string.Join("", currentLocations);
            list_lbl.Text = _winPosition;
            stat_lbl.Text = currentPosition;

            if (_winPosition == currentPosition)
            {
                stat_lbl.Text = "Matched!!!!";
            }
        }



        private Point GetLocationFromTag(string tag)
        {
            int index = int.Parse(tag);
            int row = index / 3;
            int col = index % 3;
            return new Point(200 + col * 130, 25 + row * 130);
        }

        private int CalculateMisplacedTiles()
        {
            int misplaced = 0;
            for (int i = 0; i < _pictureBoxes.Count; i++)
            {
                Point currentLocation = _pictureBoxes[i].Location;
                Point correctLocation = GetLocationFromTag(i.ToString());

                if (currentLocation != correctLocation)
                    misplaced++;
            }
            return misplaced;
        }

        private void SolvePuzzle()
        {
            HillClimbing();
        }

        private void HillClimbing()
        {
            int currentMisplaced = CalculateMisplacedTiles(); // Evaluate the current arrangement

            while (currentMisplaced > 0)
            {
                bool foundBetterMove = false;

                for (int i = 0; i < _pictureBoxes.Count; i++)
                {
                    Point currentLocation = _pictureBoxes[i].Location;
                    Point correctLocation = GetLocationFromTag(i.ToString());

                    if (currentLocation != correctLocation)
                    {
                        // Try moving the current tile in all four directions
                        List<Point> possibleMoves = new List<Point>
                        {
                            new Point(currentLocation.X + 130, currentLocation.Y), // Move right
                            new Point(currentLocation.X - 130, currentLocation.Y), // Move left
                            new Point(currentLocation.X, currentLocation.Y + 130), // Move down
                            new Point(currentLocation.X, currentLocation.Y - 130) // Move up
                        };

                        foreach (Point move in possibleMoves)
                        {
                            // Check if the move is valid (within bounds)
                            if (IsMoveValid(move))
                            {
                                // Temporarily move the tile
                                _pictureBoxes[i].Location = move;
                                int newMisplaced = CalculateMisplacedTiles();

                                // If the new arrangement is better, keep the move
                                if (newMisplaced < currentMisplaced)
                                {
                                    currentMisplaced = newMisplaced;
                                    foundBetterMove = true;
                                    break; // Move only one tile per iteration
                                }
                                else
                                {
                                    // Revert the move if it doesn't improve the arrangement
                                    _pictureBoxes[i].Location = currentLocation;
                                }
                            }
                        }

                        if (foundBetterMove)
                            break; // Move only one tile per iteration
                    }
                }

                if (!foundBetterMove)
                    break; // Exit loop if no better move is found
            }
        }

        private bool IsMoveValid(Point move)
        {
            return move.X >= 200 && move.X <= 470 && move.Y >= 25 && move.Y <= 355; // Check if within puzzle bounds
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void list_lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
