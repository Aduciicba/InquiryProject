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

        public abstract bool Evaluate();


    }
}
