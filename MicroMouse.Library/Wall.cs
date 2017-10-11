using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroMouse.Library
{
    public class Wall
    {
        bool _hasOpening;

        public Wall(bool hasOpening)
        {
            _hasOpening = hasOpening;
        }

        public bool HasOpening()
        {
            return _hasOpening;
        }
    }

}
