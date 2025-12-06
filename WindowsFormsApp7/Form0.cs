using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form0 : Form
    {
        private string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Database.mdb;";
        private Random random = new Random(); 
        private bool discountApplied;
        private object discountPercentage;

        public Form0()
        {
            InitializeComponent();
        }

        private void btnSubmitComment_Click(object sender, EventArgs e)
        {
            string comment = txtComment.Text.Trim();

            if (string.IsNullOrEmpty(comment))
            {
                MessageBox.Show("Пожалуйста, введите комментарий.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO CommentsTable (Comment) VALUES (@Comment)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Comment", comment);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Комментарий успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtComment.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении комментария: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Исправлено: Убрано лишнее событие Click, убрана дублирующая логика
        private void label5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))  // Проверяем, что textBox1 не пуст
            {
                MessageBox.Show("Уважаемый гость, Вы уже получили скидку");
            }
            else
            {
                // Проверяем, что скидка еще не была применена
                if (!discountApplied)
                {
                    UpdatePercentage();
                }
                else
                {
                    MessageBox.Show($"Уважаемый гость, Вы уже получили скидку: {discountPercentage}%", "Скидка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        
        }

        private void Form0_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            UpdatePercentage();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            //TODO: Добавить реализацию для этого обработчика событий 
        }

        //Вынесено в отдельный метод для удобства переиспользования
        private void UpdatePercentage()
        {
            int percentage = random.Next(0, 8); 
            textBox1.Text = percentage.ToString() + "%";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
