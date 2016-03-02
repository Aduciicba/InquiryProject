using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Question
    {
        bool _is_active;                           //показывать/не показывать 
        Question _previous_question;               //предыдущий вопрос 
        List<Question> _potential_next_questions;  //список возможных следующих вопросов
        List<Answer> _answers;                     //список ответов на вопрос
        Rule _active_rule = null;                  //правило, определяющее показывать/не показывать 

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

        public Rule active_rule
        {
            get
            {
                return _active_rule;
            }
            set
            {
                _active_rule = value;
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
            potential_next_questions.Insert(0, qu);
        }

        List<Question> potential_next_questions
        {
            get
            {
                if (_potential_next_questions == null)
                    _potential_next_questions = new List<Question>();
                return _potential_next_questions;
            }
        }

        public Question next_question
        {
            get
            {
                //получаем список возможных следующих вопросов, т.е. тех, у которых выполнились правила
                List<Question> que_list = potential_next_questions.Where(q => q.Active).ToList();
                //если в списке нет или 1 запись, то возвращаем нул или единственную запись
                if (que_list.Count < 2)
                    return que_list.FirstOrDefault();
                //если в списке более 1 кандидата, то берем первого и запоминаем
                Question next = que_list.First();
                //удалаяем его из списка потенциальных кандидатов
                que_list.Remove(next);
                //всех оставшихся потенциальных кандидатов добавляем в список потенциальных следующих вопросов для того вопроса, 
                // который сейчас вернем как следующий
                foreach (var qu in que_list)
                {
                    if (next.potential_next_questions.Count(q => q.id == qu.id) == 0)
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

    }
}
