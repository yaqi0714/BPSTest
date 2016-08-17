using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Close_Reopen_Workspaces
{
    class BaseException : ApplicationException
    {
        protected int errorId;

        protected string message;

        public BaseException(int _errorId, string _message)
            : base(_message)
        {
            this.errorId = _errorId;
            this.message = _message;
        }

        public int ErrorId
        {
            get { return this.errorId; }
        }

        public string ErrorMessage
        {
            get { return this.message; }
        }
    }
}
