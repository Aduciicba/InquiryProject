using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Simple.Data;
using Simple.OData;
using Simple.OData.Client;

namespace InquiryProject
{
    public partial class Inquiry
    {
        List<Question> _questions;   //список вопросов анкеты
        Question _current_question;  //текущий вопрос

        public static Inquiry LoadById(int id)
        {
            var db = App.db;
            //загружаем анкету по переданному ид
            Inquiry inq = db.Inquiry.Get(id);
            //загружаем список вопросов анкеты
            inq.questions = db.Question.FindAllByFid_Inquiry(id).ToList<Question>();
            //загружаем список правил и поведений для анкеты
            List<InquiryBehavior> behaviours = db.Inquiry_Behavior.FindAllByFid_Inquiry(id).ToList<InquiryBehavior>();
            List<Rule> rules = db.Rule.FindAllByFid_Inquiry(id).ToList<Rule>();
            //создаем пустой список для всех ответов анкеты
            List<Answer> all_answ = new List<Answer>();
            //заполняем информацию по каждому вопросу
            foreach(var qu in inq.questions)
            {
                //загружаем список ответов
                qu.answers = db.Answer.FindAllByFid_question(qu.id).ToList<Answer>();
                //добавляем в список всех ответов
                all_answ.AddRange(qu.answers);
                foreach(var a in qu.answers)
                {
                    //выбираем поведение для соответствующего ответа
                    InquiryBehavior bha = behaviours.FirstOrDefault(b => b.fid_question == qu.id && b.fid_answer == a.id);
                    //выбираем правило, определяющее поведение ответа
                    if (bha != null)
                        a.active_rule = rules.FirstOrDefault(r => r.id == bha.fid_rule);
                    a.parent_question = qu;
                }
                //выбираем поведение для соответствующего вопроса
                InquiryBehavior bhq = behaviours.FirstOrDefault(b => b.fid_question == qu.id && b.fid_answer == 0);
                if (bhq != null)
                {
                    //устанавливаем предыдущий вопрос
                    qu.previous_question = inq.questions.FirstOrDefault(q => q.id == bhq.fid_previous_question);
                    //выбираем правило, определяющее поведение вопроса
                    qu.active_rule = rules.FirstOrDefault(r => r.id == bhq.fid_rule);
                }
                var potent_questions = from pqu in inq.questions
                                       join bh in behaviours on pqu.id equals bh.fid_question
                                       where (bh.fid_previous_question == qu.id)
                                       select pqu;  
                foreach(Question pqu in potent_questions)
                {
                    qu.addPotentialNextQuestion(pqu);
                }
            }
            foreach (var qu in inq.questions)
            {
                //заполняем данные правила для вопроса
                FillRule(qu.active_rule, rules, all_answ);
                foreach (var a in qu.answers)
                {
                    //заполняем данные правила для ответа
                    FillRule(a.active_rule, rules, all_answ);
                }
            }
            return inq;
        }

        static void FillRule(
                              Rule rule
                            , List<Rule> rules
                            , List<Answer> answers
                            )
        {
            if (rule == null)
                return;
            //получаем список операндов правила
            List<RuleOperand> op_list = App.db.Rule_operand.FindAllByFid_rule(rule.id).ToList<RuleOperand>();
            foreach (var o in op_list)
            {
                //если операнд - ответ, то добавляем его в список
                if (o.operand_type == "answer")
                    rule.addOperand(answers.First(a => a.id == o.fid_operand));
                else
                {
                    //если операнд - правило, то добавляем его в список и вызываем его заполнение
                    Rule rule_operand = rules.First(r => r.id == o.fid_operand);
                    rule.addOperand(rule_operand);
                    FillRule(rule_operand, rules, answers);
                }
            }
        }
        
        public Question current_question
        {
            get
            {
                
                return _current_question;
            }
        }

        public List<Question> questions
        {
            get
            {
                return _questions;
            }

            set
            {
                _questions = value;
            }
        }

        public Question next()
        {
            if (_current_question == null)
                _current_question = _questions.First(q => q.previous_question == null);
            else
                _current_question = _current_question.next_question;
            return _current_question;
        }

    }
}
