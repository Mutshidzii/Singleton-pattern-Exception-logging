using System;
using System.IO;
using System.Text;

namespace Logger
{
    //sealed restrict the inheritance
    public sealed class Log : ILog
    {
       

        //private constructor ensures that object is not instantiated other than within the class itself
        private Log()
        {
          
        }

        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());

        //public  property is used to return only one instance of the class leveraging on the private property
        public static Log GetInstance
        {
            get
            {
                return instance.Value;
            }
        }

        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory,fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using(StreamWriter writer  = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
