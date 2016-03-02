using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    //Ответ
    public partial class Answer
    {
        int _id;            //ИД
        string _var_text;   //текст ответа 
        int _fid_question;  //Ссылка на вопрос

        public Answer()
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

        public string var_text
        {
            get
            {
                return _var_text;
            }
            set
            {
                _var_text = value;
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
    }
}
