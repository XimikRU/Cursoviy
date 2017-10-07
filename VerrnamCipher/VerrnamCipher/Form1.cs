using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerrnamCipher
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // Кнопка шифрование
        public void buttonEncrypt_Click(object sender, EventArgs e)
        {
            // Если поле ввода не пустое
            if (richTextBoxEncryptText.Text.ToString() != "")
            {
                // Очищаем поля вывода и ключа
                richTextBoxEncryptOut.Clear();
                richTextBoxEncryptKey.Clear();

                // Иницаилизируем необходимые переменные
                char[] openedStr = richTextBoxEncryptText.Text.ToCharArray();
                int len = openedStr.Length;
                char[] cryptedStr = new char[len];
                char[] key = new char[len];
                Random r = new Random();

                // Заполянем массив ключа случайными английскими буквами
                for (int i = 0; i < len; i++)
                    key[i] = (char)r.Next(65,90);

                // Шифр с помощью исключающего ИЛИ
                for (int i = 0; i < len; i++)
                    cryptedStr[i] = (char)(openedStr[i] ^ key[i]);

                // Выводим ключ и 
                foreach (char c in key)
                    richTextBoxEncryptKey.Text += c;

                // Зашифрованный текст
                foreach (char c in cryptedStr)
                    richTextBoxEncryptOut.Text += c;
            }
            else
            {
                MessageBox.Show("Текст не введен");
            }
        }

        // Кнопка дешифрование
        public void buttonDecrypt_Click(object sender, EventArgs e)
        {
            // Иницаилизируем необходимые переменные
            char[] cryptedStr = richTextBoxDecryptText.Text.TrimEnd().ToCharArray();
            char[] key = richTextBoxDecryptKey.Text.TrimEnd().ToCharArray();
            int len = cryptedStr.Length;
            int lenk = key.Length;

            // Если поле ввода не пустое и размер ключа равен размеру текста
            if (cryptedStr.ToString() != "" && key.ToString() != "" && len == lenk)
            {
                richTextBoxDecryptOut.Clear();

                char[] openedStr = new char[len];

                // Дешифруем с помощью ИЛИ
                for (int i = 0; i < len; i++)
                    openedStr[i] = (char)(cryptedStr[i] ^ key[i]);

                // Выводим
                foreach (char c in openedStr)
                    richTextBoxDecryptOut.Text += c;
            }
            else
            {
                MessageBox.Show("Ключ и текст не одинаковой длины / либо пусты");
            }
        }
    }
}
