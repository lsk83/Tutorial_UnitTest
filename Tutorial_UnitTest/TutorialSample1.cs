using System.Diagnostics;
using Tutorial_UnitTest.Model;

namespace Tutorial_UnitTest
{
    /// <summary>
    /// 유닛테스트 튜토리얼  
    /// [참고자료]
    /// https://hamidmosalla.com/2020/01/05/xunit-part-1-xunit-packages-and-writing-your-first-unit-test/
    /// https://teamsmiley.github.io/2020/03/11/xunit-unittest/
    /// https://xunit.net/
    /// (xUnit은 각 함수마다 클레스 객체를 생성하여 실행 후 객체를 파괴한다.)
    /// </summary>
    public class TutorialSample1 : IDisposable
    {
        /// <summary>
        /// 초기화 코드 입력
        /// </summary>
        public TutorialSample1()
        {            
            Debug.WriteLine("TutorialSample1:Constructor");
        }

        /// <summary>
        /// 종료시 작업해야하는 부분 입력
        /// </summary>
        public void Dispose()
        {
            Debug.WriteLine("TutorialSample1:CleanUp or Dispose Method");
        }

        /// <summary>
        /// 함수마다 객체가 새로 성성되는지 확인하기 위한 함수
        /// </summary>
        [Fact]        
        public void test1()
        {
            Debug.WriteLine("TutorialSample1:test1 - 함수마다 객체가 새로 생성되는지 테스트");
        }

        /// <summary>
        /// 함수마다 객체가 새로 성성되는지 확인하기 위한 함수
        /// </summary>
        [Fact]
        public void test2()
        {
            Debug.WriteLine("TutorialSample1:test2 - 함수마다 객체가 새로 생성되는지 테스트");
        }

        /// <summary>
        /// 테스트 안하게 하는 방법
        /// </summary>
        [Fact(Skip ="테스트 건너뛰는 기능 확인")]
        public void test2_skip()
        {
            Debug.WriteLine("TutorialSample1:test2 - 테스트 건너 뛰는지 확인");
        }

        /// <summary>
        /// 테스트 케이스에 파라메터가 있을 경우 Fact 가 아닌 Theory로
        /// Attribute를 선언해야 하며 각 테스트 케이스의 파라메터는
        /// InlineData Attribute로 선언하여 테스트 한다.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Theory]
        [InlineData(0,1)]
        [InlineData(2,3)]
        [InlineData(4,6)]
        public void test3(int a,int b)
        {
            var result = a + b;
            Assert.Equal(a + b, result);
            Debug.WriteLine($"{a} + {b} = {result}");
        }

        /// <summary>
        /// 테스트 데이터를 공유해서 사용해야 될때 MemberData 사용함
        /// (파일에서 테스트 케이스를 가져와야 한다면 SharedTestData 의 Users의 get 부분을
        /// 파일을 읽어서 데이터를 로드하도록 코드를 수정하면 됨)
        /// </summary>
        /// <param name="info"></param>
        [Theory]
        [MemberData(nameof(SharedTestData.Users), MemberType = typeof(SharedTestData))]
        public void test4(UserInfo info)
        {            
            Debug.WriteLine($"test4:{info.UserID} {info.UserName} {info.Age}");
        }

        /// <summary>
        /// 테스트 데이터를 공유해서 사용해야 될때 MemberData 말고 CustomDataAttribute를 
        /// 만들어서 사용하는 방법        
        /// </summary>
        /// <param name="info"></param>
        [Theory]
        [UserData]
        public void test5(UserInfo info)
        {
            Debug.WriteLine($"test4:{info.UserID} {info.UserName} {info.Age}");
        }

        /// <summary>
        /// 예상되는 결과 값과 맞는지 확인하는 함수들의 사용방법 샘플
        /// </summary>
        [Fact]
        public void AssertTest()
        {
            var patientInfo = new PatientInfo()
            {
               PatientID="12345678",
               PatientName = "홍길동",
               Age = 42,
               Phone = "010-1234-5678"
            };

            var userInfo = new UserInfo()
            {
                UserID="10041004",
                UserName = "test",
                Age = 20,
                Phone = "010-1004-1004"
            };

            Assert.True(patientInfo.PatientName == "홍길동");
            Assert.Equal(42, patientInfo.Age);            
            Assert.StartsWith("123",patientInfo.PatientID);
            Assert.EndsWith("678", patientInfo.PatientID);
            Assert.Contains("456", patientInfo.PatientID);
            Assert.DoesNotContain("kkk",patientInfo.PatientID);
            Assert.Matches(@"\d{3}-\d{4}-\d{4}",patientInfo.Phone);            
            Assert.NotEqual("김상중", patientInfo.PatientName);            
            Assert.InRange<int>(patientInfo.Age, 30, 45);

            PatientInfo? info2 = null;

            Assert.Null(info2);
            Assert.NotNull(patientInfo);

            Assert.IsType<PatientInfo>(patientInfo);
            Assert.IsNotType<UserInfo>(patientInfo);
            Assert.IsAssignableFrom<Person>(patientInfo);
            Assert.IsNotAssignableFrom<Person>(userInfo);

            Assert.Same("12345678", patientInfo.PatientID);
            Assert.NotSame("kkk", patientInfo.PatientID);


            //배열이 크기가 하나인지 체크
            Assert.Single(patientInfo.GetCollection());            
        }

        /// <summary>
        /// 배열의 데이터 하나 하나씩 단위 테스트
        /// (각 배열 아이템에 동일한 검증 방법 적용)
        /// </summary>
        [Fact]
        public void AllNumberIsEven()
        {
            var numbers = new List<int> { 2, 4, 6 };

            Action<int> allAreEven = (a) =>
            {
                Assert.True(a % 2 == 0);
            };

            Assert.All(numbers, allAreEven);
        }

        /// <summary>
        /// 배열의 데이터 하나 하나씩 단위 테스트
        /// (각 배열 아이템에 다른 검증 방법 적용)
        /// </summary>
        [Fact]
        public void AllNumberAreEvenAndNotZero()
        {
            var numbers = new List<int> { 2, 4, 6 };
            Assert.Collection(numbers, a => Assert.True(a == 2), a => Assert.True(a == 4), a => Assert.True(a == 6));            
        }

        /// <summary>
        /// WPF에서 INotifyPropertyChanged 인터페이스를 상속받은 
        /// 클레스에서 속성값이 변경되었는지 안되었는지 테스트하는 방법
        /// Assert.PropertyChanged 3번째 인자에 테스트 코드를 넣고
        /// 해당 테스트 코드 처리 후에 지정한 속성값이 변하지 않으면 에러를 
        /// 뱉는다.
        /// </summary>
        [Fact]
        public void ShouldClearWithEvents()
        {
            // arrange
            var car = new Car();
            car.Price = 40;
            
            // act            
            Assert.PropertyChanged(car, "Price", () => {
                //가격 정보를 변경하여 속성이 변경되면 에러가 발생하지 않지만
                //가격 정보 변경없이 차 이름만 변경하면 에러가 발생한다.
                //car.Name="BMW";
                car.Price = 10;
            });            
        }


        /// <summary>
        /// 테스트 코드로직 실행 후 설정한 이벤트가 발생하는지 않하는지 확인하는 단위 테스트
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void RaiseEventAssertions()
        {
            var messageSender = new Message();

            var receivedEvent = Assert.Raises<MessageEventArgs>(
                                 a => messageSender.SendMessageEvent += a,
                                 a => messageSender.SendMessageEvent -= a,
                                 () => {
                                     
                                     //테스트 로직
                                     //이벤트를 발생 시켰으므로 에러가 나지 않는다.
                                     messageSender.SendMessageToUser("This is an event message");
                                 });

            Assert.NotNull(receivedEvent);
            Assert.Equal("This is an event message", receivedEvent.Arguments.Message);


            var receivedEventTask = Assert.RaisesAsync<MessageEventArgs>(
                                    a => messageSender.SendMessageEvent += a,
                                    a => messageSender.SendMessageEvent -= a,
                                    async () => await messageSender.SendMessageToUserAsync("This is an event message"));
            var receivedEventAsync = await receivedEventTask;

            Assert.NotNull(receivedEventAsync);
            Assert.Equal("This is an event message", receivedEventAsync.Arguments.Message);
        }
    }
}