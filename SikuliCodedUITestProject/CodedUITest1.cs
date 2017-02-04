using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System.IO;
using System.Threading;

namespace SikuliCodedUITestProject
{
    [CodedUITest]
    public class CodedUITest1
    {
        static IWebDriver _driver;

        APILauncher _launcher = new APILauncher( true );

        public CodedUITest1()
        {
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _launcher.Start();
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl( "http://www.xingzuo360.cn/uploads/media/121030/1-1210300F426.swf" );
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            _driver.Quit();
            _launcher.Stop();
        }

        #endregion


        [TestMethod]
        [DeploymentItem( "Images\\" ,"Images\\" )]
        public void CodedUITestMethod1()
        {
            Thread.Sleep(5000);
            
            //定義目前的畫面為偵測區
            Screen mainPage = new Screen();

            //透過 Pattern 類別宣告並定義要比對的控制項擷圖
            Pattern goButton = new Pattern( Path.Combine( AppDomain.CurrentDomain.BaseDirectory + @"\Images\Go.png" ) );
            Pattern nameField = new Pattern( Path.Combine( AppDomain.CurrentDomain.BaseDirectory + @"\Images\Name.png" ) );
            Pattern birthdayField = new Pattern( Path.Combine( AppDomain.CurrentDomain.BaseDirectory + @"\Images\Birthday.png" ) );
            Pattern gender = new Pattern( Path.Combine( AppDomain.CurrentDomain.BaseDirectory + @"\Images\Gender.png" ) );
            Pattern bloodType = new Pattern( Path.Combine( AppDomain.CurrentDomain.BaseDirectory + @"\Images\BloodType.png" ) );
            Pattern placeField = new Pattern( Path.Combine( AppDomain.CurrentDomain.BaseDirectory + @"\Images\PlaceGrownUp.png" ) );
            Pattern okButton = new Pattern( Path.Combine( AppDomain.CurrentDomain.BaseDirectory + @"\Images\OkButton.png" ) );
            Pattern result = new Pattern( Path.Combine( AppDomain.CurrentDomain.BaseDirectory + @"\Images\Result.png" ) );

            //等待 go 按鈕出現
            mainPage.Wait( goButton );

            //對 go 按鈕按下滑鼠左鍵
            mainPage.Click(goButton);

            Thread.Sleep( 3000 );

            //在姓名欄位輸入文字
            mainPage.Type( nameField , "Ouch" );

            //在生日欄位輸入文字
            mainPage.Type( birthdayField, "19781128" );

            //點選男性
            mainPage.Click( gender );

            //點選 B 型
            mainPage.Click( bloodType );

            //在成長地點欄位輸入文字
            mainPage.Type( placeField , "Taipei" );

            //按下 Ok 按鈕
            mainPage.Click( okButton );

            Thread.Sleep( 8000 );

            //以結果是否出現作為判斷測試成功的條件
            Assert.IsTrue(mainPage.Exists(result));
       }
    }
}
