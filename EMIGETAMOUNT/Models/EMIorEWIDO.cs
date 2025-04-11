using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMIGETAMOUNT.Models
{
    public class EMIorEWIDO
    {       
        public double interestDO
        {
            get;
            set;
        }
        public double principalDD
        {
            get;
            set;
        }
        public double emiDO
        {
            get;
            set;
        }
        public double balanceDO
        {
            get;
            set;
        }
        public int snoDO
        {
            get;
            set;
        }
        public string RepaymentMode
        {
            get;
            set;
        }
        public double LoanAmount
        {
            get;
            set;
        }
        public double AnnualInterest
        {
            get;
            set;        
        }
        public int NoofPayment
        {
            get;
            set;
        }
    }
}