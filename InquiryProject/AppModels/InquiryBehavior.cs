using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    //Поведение внутри анкеты
    class InquiryBehavior
    {
        int _id;                     //ИД 
        int _is_show_behavior;       //= 1, если в результате вопрос/ответ нужно показать, 0, если скрыть
        int _fid_question;           //Ссылка на вопрос, поведение которого регулируется
        int _fid_answer;             //Ссылка на ответ, поведение которого регулируется. Если в БД null, то = 0   
        int _fid_rule;               //Ссылка на правило, регулирующее поведение
        int _fid_previous_question;  //Ссылка на предыдущий вопрос, устанавливается для описания поведения вопроса
        int _fid_inquiry;            //Ссылка на анкетц, поведение которой описывается

        public InquiryBehavior()
        {

        }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public bool is_show_behavior
        {
            get
            {
                return _is_show_behavior == 1;
            }
            set
            {
                _is_show_behavior = (value ? 1 : 0);
            }
        }

        public int fid_question
        {
            get
            {
                return _fid_question;
            }
            set
            {
                _fid_question = value;
            }
        }

        public int fid_answer
        {
            get
            {
                return _fid_answer;
            }
            set
            {
                _fid_answer = value;
            }
        }

        public int fid_rule
        {
            get
            {
                return _fid_rule;
            }
            set
            {
                _fid_rule = value;
            }
        }

        public int fid_previous_question
        {
            get
            {
                return _fid_previous_question;
            }
            set
            {
                _fid_previous_question = value;
            }
        }

        public int fid_inquiry
        {
            get
            {
                return _fid_inquiry;
            }
            set
            {
                _fid_inquiry = value;
            }
        }
    }
}
