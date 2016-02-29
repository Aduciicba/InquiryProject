using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    class InquireBehavior
    {
        int _id;
        int _fid_generating_answer;
        int _is_show_behavior;
        int _fid_question;
        int _fid_answer;

        public InquireBehavior()
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

        public int fid_generating_answer
        {
            get
            {
                return _fid_generating_answer;
            }
            set
            {
                _fid_generating_answer = value;
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
    }
}
