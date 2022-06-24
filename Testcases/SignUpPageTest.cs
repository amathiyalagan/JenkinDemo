using AventStack.ExtentReports;
using ELIT_Selenium_TR.Config;
using ELIT_Selenium_TR.PageMethods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELIT_Selenium_TR.TestCases
{

   [TestFixture]
   public class SignUpPageTest:ReportsGenerationClass
   {
        SignUpPage signuppage;

        [Test,Order(1)]
        [Category("User Aggreement")]
        public void accepting_user_agreement()
        {
            signuppage = new SignUpPage(GetDriver());
            try
            {
                signuppage.GoToPage("https://dev.elit.ai/");
                signuppage.Clickon_Signup();
                _test.Log(Status.Pass, "Clicked on SignUp");

                signuppage.Mouseaction();
                signuppage.Accept();
                _test.Log(Status.Pass, "Accepted Terms and Conditions");

                _test.Log(Status.Pass, "Returned back to LOGIN Page : " + signuppage.VerifyAccept().ToString());
                Assert.IsTrue(signuppage.VerifyAccept());
                signuppage.LoginPage();
            }
            catch (Exception ex)
            {
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("dd_MM_yyyy_hh_mm_ss") + ".png";
                String screenShotPath = Capture(_driver, fileName);
                _test.Log(Status.Fail, ex.ToString());
                _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
            }
            finally
            {
                signuppage.closeBrowser();
            }
        }

        [Test,Order(2)]
        [Category("User Aggreement")]
        public void declining_user_agreement()
        {
            signuppage = new SignUpPage(GetDriver());
            try
            {
                signuppage.GoToPage("https://dev.elit.ai/");
                signuppage.Clickon_Signup();
                _test.Log(Status.Pass, "Clicked on SignUp");

                signuppage.Mouseaction();
                signuppage.Decline();
                _test.Log(Status.Pass, "Declined Terms and Conditions");

                _test.Log(Status.Pass,"Returned back to LOGIN Page : " + signuppage.VerifyDecline().ToString());
                Assert.IsTrue(signuppage.VerifyDecline());
            }
            catch (Exception ex)
            {
                DateTime time = DateTime.Now;
                String fileName = "Screenshot_" + time.ToString("dd_MM_yyyy_hh_mm_ss") + ".png";
                String screenShotPath = Capture(_driver, fileName);
                _test.Log(Status.Fail, ex.ToString());
                _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
            }
            finally
            {
                signuppage.closeBrowser();
            }
       }
    }
}
