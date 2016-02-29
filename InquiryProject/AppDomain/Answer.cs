using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Answer: BaseOperand
    {
        bool _is_active;
        bool _is_selected;
        Question _parent_question;

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

        public bool Selected
        {
            get
            {
                return _is_selected;
            }
        }

        List<InquireBehavior> _behaviors;

        /*public void setInactive()
        {
            _is_active = false;
        }

        public void setActive()
        {
            _is_active = true;
        }*/

        public void Unselect()
        {
            _is_selected = false;
        }

        public void Select()
        {
            _is_selected = true;
            _parent_question.selected_answer = this;

            /*foreach (var q in _dependency_questions)
            {
                InquireBehavior bh = _behaviors.FirstOrDefault(b => b.fid_question == q.id);
                if (bh.is_show_behavior)
                    q.setActive();
                else
                    q.setInactive();                 
            }

            foreach (var a in _dependency_answers)
            {
                InquireBehavior bh = _behaviors.FirstOrDefault(b => b.fid_answer == a.id);
                if (bh.is_show_behavior)
                    a.setActive();
                else
                    a.setInactive();
            }*/
        }

        public override bool Evaluate()
        {
            return Active;
        }
    }
}
