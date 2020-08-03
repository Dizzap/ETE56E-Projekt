using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Snake_programko
{
    class SnakeNode {

        int cooX, cooY, nodeDir, nodeNum, val;
        public SnakeNode next;

        public int CooY {
            get { return cooY; }
            set { cooY = value; }
        }
        public int CooX {
            get { return cooX; }
            set { cooX = value; }
        }
        public int Val {
            get { return val; }
            set { val = value; }
        }
        public int NodeDir {
            get { return nodeDir; }
            set { nodeDir = value; }
        }
        public int NodeNum {
            get { return nodeNum; }
            set { nodeNum = value; }
        }

        public SnakeNode(int val, int cooX, int cooY, int nodeDir, int nodeNum) {
            this.cooX = cooX;
            this.cooY = cooY;
            this.val = val;
        }

    }
    
}
