using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountInfo
{
   public class MyBankDetails 
    {
       private long caId;

       public long CARD_NUMBER
        {
            get { return caId; }
            set { caId = value; }
        }

        private string CaType;

        public string CARD_TYPE
        {
            get { return CaType; }
            set { CaType = value; }
        }

        private long cvv;

        public long CVV_NUMBER
        {
            get { return cvv; }
            set { cvv = value; }
        }
        

        private string _CARDNAME;

        public string CARDNAME
        {
            get { return _CARDNAME; }
            set { _CARDNAME = value; }
        }

        private int _EXPIRYM;

        public int EXPIRYM
        {
            get { return _EXPIRYM; }
            set { _EXPIRYM = value; }
        }

        private int _EXPIRYY;

        public int EXPIRYY
        {
            get { return _EXPIRYY; }
            set { _EXPIRYY = value; }
        }



       

    }
}
