using System;
using System.Collections.Generic;
using System.Text;

namespace Pedagio.Cadastro.Application.Utils
{
    /// <summary>
    /// Exceções de negócio
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string msg)
        {
            var i = msg.IndexOf('|');
            if ( i >= 1 )
            {
                Code = int.Parse(msg.Substring(0, i));
                Message = msg.Substring(i+1);
            }
            else
            {
                Message = msg;
            }
        }
        /// <summary>
        /// Código do erro
        /// </summary>
        public int Code { get; protected set; }

        /// <summary>
        /// Descrição do erro
        /// </summary>
        public string Message { get; protected set; }
    }
}
