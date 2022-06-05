using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomator
{
    public class Page
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Func<Page, bool> CallBack { get; set; }
        public LogTime LogTime { get; set; }
        public Page(string nome, Func<Page, bool> callBack)
        {
            Id = Guid.NewGuid();
            LogTime = new LogTime();
            Nome = nome;
            CallBack = callBack;
        }

        public void Executar()
        {
            LogTime.Iniciar();
            CallBack(this);
            LogTime.Finalizar();
        }
    }
}
