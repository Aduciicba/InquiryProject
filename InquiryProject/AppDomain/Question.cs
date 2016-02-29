using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Question
    {
        bool _is_active;
		
        Question _previous_question;
        List<Question> _potential_next_questions;
		
	Inquire _parent_inquiry;

        List<Answer> _answers;
        Answer _selected_answer;

        Rule _active_rule;

        public bool Active
        {
            get
            { 
                if (_active_rule == null)
                {
                    _is_active = true;
                }
                else
                {
                    _is_active = _active_rule.Evaluate();
                }
                return _is_active;
            }
        }
		
		public Inquire inquiry
		{
			get
			{
				return _parent_inquiry
			}
		}

        public Question previous_question
        {
            get
            {
                return _previous_question;
            }
            set
            {
                _previous_question = value;
            }
        }

        public void addPotentialNextQuestion(Question qu)
        {
            if (_potential_next_questions == null)
                _potential_next_questions = new List<Question>();

            _potential_next_questions.Insert(0, qu);
        }

        public Question next_question
        {
            get
            {
                List<Question> que_list = _potential_next_questions.Where(q => q.Active).ToList();
                if (que_list.Count < 2)
                    return que_list.FirstOrDefault();
                Question next = que_list.First();
                que_list.Remove(next);

                foreach (var qu in que_list)
                {
                    next.addPotentialNextQuestion(qu);
                }
                return next;
            }
        }

        public List<Answer> answers
        {
            get
            {
                return _answers;
            }
            set
            {
                _answers = value;
            }
        }

        public Answer selected_answer
        {
            get
            {
                return _selected_answer;
            }
            set
            {
                _selected_answer = value;
            }
        }

/*        public void setInactive()
        {
            _is_active = false;
            if (previous_question.next_question == this)
            {
                previous_question.next_question = next_question;
                next_question = null;
            }
        }

        public void setActive()
        {
            _is_active = true;
            if (previous_question.next_question != this)
            {
                next_question = previous_question.next_question;
                previous_question.next_question = this;
            }
        }
        */

    }
}
