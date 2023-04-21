using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
namespace AppImg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string con = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=imageDB;Integrated Security=True";

        private void btnSet_Click(object sender, EventArgs e)
        {
            var uploader = new ImageUploader(con);
            uploader.Upload(pictureSet);
        }
        class ImageUploader
        {
            private readonly string _connectionString;

            public ImageUploader(string connectionString)
            {
                _connectionString = connectionString;
            }

            public void Upload(PictureBox pictureBox)
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO myTable (image) VALUES (@image)";

                    var image = new Bitmap(pictureBox.Image);
                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, ImageFormat.Jpeg);
                        memoryStream.Position = 0;

                        var sqlParameter = new SqlParameter("@image", SqlDbType.VarBinary, (int)memoryStream.Length)
                        {
                            Value = memoryStream.ToArray()
                        };
                        command.Parameters.Add(sqlParameter);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        class ImageRetriever
        {
            private readonly string _connectionString;

            public ImageRetriever(string connectionString)
            {
                _connectionString = connectionString;
            }

            public void Retrieve(PictureBox pictureBox, int id)
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT image FROM myTable WHERE id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var imageData = (byte[])reader["image"];
                            using (var memoryStream = new MemoryStream(imageData))
                            {
                                pictureBox.Image = Image.FromStream(memoryStream);
                            }
                        }
                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureSet.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var retriever = new ImageRetriever(con);
            retriever.Retrieve(pictureView, id);
        }
    }
}
