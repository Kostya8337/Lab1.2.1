using System;
using System.Windows.Forms;

namespace StudentSurvey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Установлюємо заголовок форми
            this.Text = "Лаб. 1";
        }

        private TextBox GetTxtGroup()
        {
            return txtGroup;
        }

        // Обробник натискання кнопки OK
        private void btnOK_Click(object sender, EventArgs e, TextBox txtGroup)
        {
            // Читання даних з текстових полів
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string birthYear = txtBirthYear.Text;
            string group = txtGroup.Text;
            string course = txtCourse.Text;

            // Перевірка на коректність даних
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(birthYear) || string.IsNullOrWhiteSpace(group) ||
                string.IsNullOrWhiteSpace(course))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка на коректність року народження
            if (!int.TryParse(birthYear, out int year))
            {
                MessageBox.Show("Невірний формат року народження!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Виведення результатів в багаторядкове поле
            rtbResults.Text = $"Ім’я: {firstName}\nПрізвище: {lastName}\nРік народження: {birthYear}\nГрупа: {group}\nКурс: {course}";
        }

        // Обробник натискання кнопки Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Закриття форми
            this.Close();
        }

        // Обробники подій для реагування на клавіатуру
        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClose.PerformClick();
            }
        }
    }
}
