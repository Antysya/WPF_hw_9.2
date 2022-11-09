using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WPF_hw_9._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        

        public MainWindow()
        {
            InitializeComponent();
            lb_change_count.Content = Convert.ToString(count);
        }

        private void bt_paste_Click(object sender, RoutedEventArgs e)
        {
            if (cb_max_inp.Text != "Unlimited")
            {
                password_b.MaxLength = Convert.ToInt32(tb_password.Text.Length);
                if (password_b.MaxLength <= Convert.ToInt32(cb_max_inp.Text))
                {
                    password_b.PasswordChar = Convert.ToChar(mask_cb.Text);

                    password_b.Paste();
                    count++;
                    lb_change_count.Content = Convert.ToString(count);
                }

                else
                {
                    MessageBox.Show("Превышено количество символов в пароле.", "Внимание", MessageBoxButtons.OK);
                    tb_password.Clear();
                }
            }
            else
            {
                password_b.MaxLength = 0;
                password_b.Paste();
            }

        }

        private void copy_cont_Click(object sender, RoutedEventArgs e)
        {
            if (cb_max_inp.Text != "Unlimited")
            {
                if (tb_password.GetLineLength(0) <= Convert.ToInt32(cb_max_inp.Text))
                {
                    tb_password.Copy();
                }
                else
                {
                    MessageBox.Show("Превышено количество символов в пароле.\n Скорректируйте введенный пароль.", "Внимание", MessageBoxButtons.OK);
                }
            }
            else
                tb_password.Copy();
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            password_b.Clear();
            tb_password.Clear();
        }

    }
}
