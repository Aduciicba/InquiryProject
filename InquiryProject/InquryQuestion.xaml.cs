using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InquiryProject
{
    /// <summary>
    /// Interaction logic for InquryQuestion.xaml
    /// </summary>
    public partial class InquryQuestion : Window
    {
        Inquiry _inq;
        public InquryQuestion(Inquiry i)
        {
            InitializeComponent();
            _inq = i;
            Load();
        }

        private void Load()
        {
            setNextQuestion();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            setNextQuestion();
            if (_inq.current_question == null)
            {
                MessageBox.Show("Спасибо за прохождение анкеты");
                DialogResult = true;
                return;
            }
            
        }

        void setNextQuestion()
        {
            mainGrid.DataContext = null;
            _inq.next();
            mainGrid.DataContext = _inq.current_question;
        }
    }
}
