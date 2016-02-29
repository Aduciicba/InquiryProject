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
    public partial class Inquire:INotifyPropertyChanged
    {
        public static Inquire LoadById(int id)
        {
            Inquire inq = new Inquire();
            var db = App.db;
            inq = db.Inquires.Get(id).Cast<Inquire>();
            List<Question> qu_list = db.Questions.FindAllByFid_Inquiry(id).ToList<Question>();
            return inq;
        }

        List<Question> _questions;
        Question _current_question;

        public Question current_question
        {
            get
            {
                if (_current_question == null)
                    _current_question = _questions.First(q => q.previous_question == null);
                return _current_question;
            }
        }

        public void next()
        {
            _current_question = _current_question.next_question;
            OnPropertyChanged("current_question");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
