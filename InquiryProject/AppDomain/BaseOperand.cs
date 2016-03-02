using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    //Базовый класс операнда
    public abstract class BaseOperand
    {
        bool _result;
        string _type;

        public string ClassType
        {
            get
            {
                return this.GetType().ToString().Replace("InquiryProject.", ""); // GetClass();
            }
        }

        public abstract bool Evaluate();
        //protected abstract string GetClass();

    }
}
