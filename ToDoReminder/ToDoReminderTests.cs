using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ToDoReminder
{
    public class ToDoReminderTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\ToDoReminderWithAlarm-Apkpure.apk\";


        [SetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Android"};

            options.AddAdditionalCapability("app", appLocation);
            options.AddAdditionalCapability("appPackage", "com.ToDoReminder.gen");
            options.AddAdditionalCapability("appActivity", "com.ToDoReminder.ApplicationMain.NavigationMainActivity");
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), options);


        }

       

       

        [Test]
        public void Test_AddFirstTask()
        {
            Thread.Sleep(3000);

            var newActivity = driver.FindElementById("com.ToDoReminder.gen:id/uAddReminderMenuItem");
            newActivity.Click();

            Thread.Sleep(3000);

            var newNote = driver.FindElementById("com.ToDoReminder.gen:id/uTitleEditText");
            newNote.SendKeys("Pregled Viki");    

            var newDate = driver.FindElementById("com.ToDoReminder.gen:id/uSelectDateTextView");
            newDate.Click();

            var dateButton = driver.FindElementByXPath("//android.view.View[@content-desc=\"16 November 2023\"]");
            dateButton.Click();

            var okButton = driver.FindElementById("android:id/button1");
            okButton.Click();

            var saveButton = driver.FindElementById("com.ToDoReminder.gen:id/uSaveBtn");
            saveButton.Click();

            var result = driver.FindElementById("com.ToDoReminder.gen:id/uTitleTextView");
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Text, Is.EqualTo("Pregled Viki"));

     
            
        }
    }
}