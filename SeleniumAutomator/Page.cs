using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomator
{
    public class Page
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        private Func<Page, bool> CallBack { get; set; }

        public Page(string nome, Func<Page, bool> callBack)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CallBack = callBack;
        }

        public void Executar()
        {
            CallBack(this);
        }
    }
}
