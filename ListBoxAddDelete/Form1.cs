using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ListBoxAddDelete
{
    public partial class Form1 : Form
    {
        private readonly HashSet<string> deletedItems = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();

            listBox1.SelectionMode = SelectionMode.One;
            this.Text = "ListBox: Добавление и удаление с запретом";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Введите текст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (deletedItems.Contains(text))
            {
                MessageBox.Show($"Элемент '{text}' был удалён ранее и не может быть добавлен снова.",
                               "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                return;
            }

            if (listBox1.Items.Contains(text))
            {
                MessageBox.Show("Такой элемент уже существует!", "Предупреждение",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                return;
            }

            listBox1.Items.Add(text);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите элемент для удаления!", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedItem = listBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedItem))
                return;

            deletedItems.Add(selectedItem);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);

            MessageBox.Show($"Элемент '{selectedItem}' удалён и больше не может быть добавлен.",
                           "Удалено", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}