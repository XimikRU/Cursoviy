using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Rifma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Функция поиска.
        private void find(string[] s, string findThisWord, string types)
        {
            // массив найденных и подходящих под условие рифмы слов
            string[] found = new string[s.Length];

            // кол-во символов в конце
            int letters = (int)numericLetters.Value;

            // если кол-во символов в конце больше чем длина введенного слова тогда ошибка
            if(findThisWord.Length < letters)
            {
                MessageBox.Show("Строка не может должна иметь минимум " + letters + " буквы!");
                return;
            }

            // подстрока для поиска(конец основной строки)
            string subStrFind = findThisWord.Substring(findThisWord.Length - letters);
            int foundAmount = 0;
            
            // Перебор словаря
            for(int i = 0; i < s.Length; i++)
            {
                string checkWord = s[i];

                // если слово из словоря короче чем подстрока для поиска(тогда пропускаем слово)
                if (subStrFind.Length > checkWord.Length)
                    continue;

                // подстрока для конца слова из словаря
                string subStrWord = checkWord.Substring(checkWord.Length - letters);

                // если -> подстрока для конца слова из словаря и подстрока для поиска введенного слова идентичны тогда есть рифма.
                if (subStrWord.Equals(subStrFind))
                {
                    found[foundAmount] = checkWord;
                    foundAmount++;
                }
            }

            // Вывод
            richTextBoxOutput.Text += ("\nНайдено всего: " + foundAmount + " " + types + "\n\n");

            for (int i = 0; i < foundAmount; i++)
                richTextBoxOutput.Text += (found[i] + "\n");
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Clear();
            string input = textBoxInput.Text;
            if(checkBoxSyw.Checked == true)
            {
                string[] syw = File.ReadAllLines("syw.txt");
                find(syw, input, "сущ.");
            }

            if (checkBoxGl.Checked == true)
            {
                string[] glag = File.ReadAllLines("glag.txt");
                find(glag, input, "глаг.");
            }

            if (checkBoxPril.Checked == true)
            {
                string[] pril = File.ReadAllLines("pril.txt");
                find(pril, input, "прил.");
            }

            if (checkBoxNa.Checked == true)
            {
                string[] nar = File.ReadAllLines("nar.txt");
                find(nar, input, "нар.");
            }
        }
    }
}
