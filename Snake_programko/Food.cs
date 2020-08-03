using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Snake_programko {
    class Food {        
        int cooX;
        int cooY, val;
        bool eaten;

        public int CooY {
            get { return cooY; }  // Getter
            set { cooY = value; } // Setter
        }
        public int CooX {
            get { return cooX; }  // Getter
            set { cooX = value; } // Setter
        }
        public int Val {
            get { return val; }
            
        }
        public bool Eaten {
            get { return eaten; }  // Getter
            set { eaten = value; } // Setter
        }
        /*public Food() {
            this.cooX = cooX;
            this.cooY = cooY;
            this.val = val;
        }*/
    }
}