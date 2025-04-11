using EMIGETAMOUNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMIGETAMOUNT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult HomeView()
        {
            return View();
        }          
        [HttpPost]
        public JsonResult GetData(string RepaymentMode, double LoanAmount, double AnnualInterest, int NoofPayment)
        {            
            string repaymentmode = RepaymentMode;
            double loanamount = LoanAmount;
            double interest = AnnualInterest;
            int noofpayment = NoofPayment;
            List<EMIorEWIDO> listdata = new List<EMIorEWIDO>();
            if (repaymentmode.Equals("Monthly")&&repaymentmode=="Monthly")
            {
                double loanamounttemp = loanamount;
                double monthlyinterest = interest / 12;
                double monthlyinterestrate = monthlyinterest / 100;
                int tempnofpayment = noofpayment;
                double interestamount = 0;
                double upval = 0;
                double downval = 0;
                double emi = 0;
                listdata.Clear();
                int sno = 1;
                for (int i = 0; i < noofpayment; i++)
                {
                    EMIorEWIDO objj = new EMIorEWIDO();
                    interestamount = loanamounttemp * monthlyinterestrate;
                    upval = Math.Pow(1 + monthlyinterestrate, tempnofpayment);
                    downval = (Math.Pow(1 + monthlyinterestrate, tempnofpayment)) - 1;
                    emi = interestamount * (upval / downval);
                    double principal = emi - interestamount;
                    double bal = loanamounttemp - principal;
                    objj.interestDO = Math.Round(interestamount,2);
                    objj.principalDD = Math.Round(principal,2);
                    objj.emiDO = Math.Round(emi,2);
                    objj.balanceDO = Math.Round(bal,2);
                    objj.snoDO = sno;
                    listdata.Add(objj);
                    loanamounttemp = loanamounttemp - principal;
                    tempnofpayment = tempnofpayment - 1;
                    sno++;
                }

            }
            else if (repaymentmode.Equals("Weekly"))
            {
                double loanamounttemp = loanamount;
                double monthlyinterest = interest / 12;
                double monthlyinterestrate = monthlyinterest / 100;
                double weeklyinterestrate = monthlyinterestrate / 4.345;
                int tempnofpayment = noofpayment;
                double interestamount = 0;
                double upval = 0;
                double downval = 0;
                double emi = 0;
                listdata.Clear();
                int sno = 1;
                for (int i = 0; i < noofpayment; i++)
                {
                    EMIorEWIDO objj = new EMIorEWIDO();
                    interestamount = loanamounttemp * weeklyinterestrate;
                    upval = Math.Pow(1 + weeklyinterestrate, tempnofpayment);
                    downval = (Math.Pow(1 + weeklyinterestrate, tempnofpayment)) - 1;
                    emi = interestamount * (upval / downval);
                    double principal = emi - interestamount;
                    double bal = loanamounttemp - principal;
                    objj.interestDO = Math.Round(interestamount,2);
                    objj.principalDD = Math.Round(principal,2);
                    objj.emiDO = Math.Round(emi,2);
                    objj.balanceDO = Math.Round(bal,2);
                    objj.snoDO = sno;
                    listdata.Add(objj);
                    loanamounttemp = loanamounttemp - principal;
                    tempnofpayment = tempnofpayment - 1;
                    sno++;
                }
            }
                return Json(listdata, JsonRequestBehavior.AllowGet);
        }
    }
}