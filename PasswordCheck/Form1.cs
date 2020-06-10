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

namespace Authorization
{
    public partial class Authorization : Form
    {
        string ErrorText;

        public Authorization()
        {
            InitializeComponent();
        }
        public void Check()
        {
           
            char[] password = txtBoxPassword.Text.ToCharArray();
            bool number = false;
            bool letter = false;
            bool symbol = false;

            if (password.Length < 6)
            {
                ErrorText = ("Пароль должен содержать минимум 6 cимволов");
                throw new Exception("min 6 symb");
            }
            else
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] >= '0' & password[i] <= '9')
                        number = true;
               
                    
                    if (password[i] >= 'A' & password[i] <= 'Z')
                        letter = true;
                    
                    if (password[i] == '!' | password[i] == '@' | password[i] == '#' | password[i] == '$' | password[i] == '%' | password[i] == '^')
                        symbol = true;
                    
                }


                if (number == false)
                {
                    ErrorText = ("Пароль должен содержать минимум одну цифру");
                    throw new Exception("min 1 numb");
                }
                if (letter == false)
                {
                    ErrorText = ("Пароль должен содержать минимум одну заглавную латинскую букву");
                    throw new Exception("min 1 lett");
                }
                if (symbol == false)
                {
                    ErrorText = ("Пароль должен содержать минимум один символ из набора ! @ # $ % ^ ");
                    throw new Exception("min 1 spec symb");
                }
                if (symbol == true && letter == true && number == true)
                {
                    StreamWriter writer = File.CreateText("users.txt");
                    writer.WriteLine(txtBoxPassword.Text);
                    writer.Close();
                    MessageBox.Show("Пароль сохранен Debug/users.txt", "Готово");

                }
            } 
       
        }
        public void CheckLogInPassword()
        {
            string Data = File.ReadAllText("users.txt");
            if (Data.Contains(txtBoxLog.Text) == true && Data.Contains(txtBoxPassword.Text) == true)
            { MessageBox.Show("Доступ разрешен");
                Close();
            }
            else 
            {
                ErrorText = "Вы ввели неверный логин или пароль";
                throw new Exception("wrong data");
              
            } 
        }
            

        private void Form1_Load(object sender, EventArgs e)
        {


     
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                CheckLogInPassword();
            }

            catch
            {
                MessageBox.Show(ErrorText,"Ошибка");
            }
        
        }
    }
}
