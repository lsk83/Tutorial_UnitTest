using System.Diagnostics;
using Tutorial_UnitTest.Model;

namespace Tutorial_UnitTest
{
    /// <summary>
    /// �����׽�Ʈ Ʃ�丮��  
    /// [�����ڷ�]
    /// https://hamidmosalla.com/2020/01/05/xunit-part-1-xunit-packages-and-writing-your-first-unit-test/
    /// https://teamsmiley.github.io/2020/03/11/xunit-unittest/
    /// https://xunit.net/
    /// (xUnit�� �� �Լ����� Ŭ���� ��ü�� �����Ͽ� ���� �� ��ü�� �ı��Ѵ�.)
    /// </summary>
    public class TutorialSample1 : IDisposable
    {
        /// <summary>
        /// �ʱ�ȭ �ڵ� �Է�
        /// </summary>
        public TutorialSample1()
        {            
            Debug.WriteLine("TutorialSample1:Constructor");
        }

        /// <summary>
        /// ����� �۾��ؾ��ϴ� �κ� �Է�
        /// </summary>
        public void Dispose()
        {
            Debug.WriteLine("TutorialSample1:CleanUp or Dispose Method");
        }

        /// <summary>
        /// �Լ����� ��ü�� ���� �����Ǵ��� Ȯ���ϱ� ���� �Լ�
        /// </summary>
        [Fact]        
        public void test1()
        {
            Debug.WriteLine("TutorialSample1:test1 - �Լ����� ��ü�� ���� �����Ǵ��� �׽�Ʈ");
        }

        /// <summary>
        /// �Լ����� ��ü�� ���� �����Ǵ��� Ȯ���ϱ� ���� �Լ�
        /// </summary>
        [Fact]
        public void test2()
        {
            Debug.WriteLine("TutorialSample1:test2 - �Լ����� ��ü�� ���� �����Ǵ��� �׽�Ʈ");
        }

        /// <summary>
        /// �׽�Ʈ ���ϰ� �ϴ� ���
        /// </summary>
        [Fact(Skip ="�׽�Ʈ �ǳʶٴ� ��� Ȯ��")]
        public void test2_skip()
        {
            Debug.WriteLine("TutorialSample1:test2 - �׽�Ʈ �ǳ� �ٴ��� Ȯ��");
        }

        /// <summary>
        /// �׽�Ʈ ���̽��� �Ķ���Ͱ� ���� ��� Fact �� �ƴ� Theory��
        /// Attribute�� �����ؾ� �ϸ� �� �׽�Ʈ ���̽��� �Ķ���ʹ�
        /// InlineData Attribute�� �����Ͽ� �׽�Ʈ �Ѵ�.
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
        /// �׽�Ʈ �����͸� �����ؼ� ����ؾ� �ɶ� MemberData �����
        /// (���Ͽ��� �׽�Ʈ ���̽��� �����;� �Ѵٸ� SharedTestData �� Users�� get �κ���
        /// ������ �о �����͸� �ε��ϵ��� �ڵ带 �����ϸ� ��)
        /// </summary>
        /// <param name="info"></param>
        [Theory]
        [MemberData(nameof(SharedTestData.Users), MemberType = typeof(SharedTestData))]
        public void test4(UserInfo info)
        {            
            Debug.WriteLine($"test4:{info.UserID} {info.UserName} {info.Age}");
        }

        /// <summary>
        /// �׽�Ʈ �����͸� �����ؼ� ����ؾ� �ɶ� MemberData ���� CustomDataAttribute�� 
        /// ���� ����ϴ� ���        
        /// </summary>
        /// <param name="info"></param>
        [Theory]
        [UserData]
        public void test5(UserInfo info)
        {
            Debug.WriteLine($"test4:{info.UserID} {info.UserName} {info.Age}");
        }

        /// <summary>
        /// ����Ǵ� ��� ���� �´��� Ȯ���ϴ� �Լ����� ����� ����
        /// </summary>
        [Fact]
        public void AssertTest()
        {
            var patientInfo = new PatientInfo()
            {
               PatientID="12345678",
               PatientName = "ȫ�浿",
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

            Assert.True(patientInfo.PatientName == "ȫ�浿");
            Assert.Equal(42, patientInfo.Age);            
            Assert.StartsWith("123",patientInfo.PatientID);
            Assert.EndsWith("678", patientInfo.PatientID);
            Assert.Contains("456", patientInfo.PatientID);
            Assert.DoesNotContain("kkk",patientInfo.PatientID);
            Assert.Matches(@"\d{3}-\d{4}-\d{4}",patientInfo.Phone);            
            Assert.NotEqual("�����", patientInfo.PatientName);            
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


            //�迭�� ũ�Ⱑ �ϳ����� üũ
            Assert.Single(patientInfo.GetCollection());            
        }

        /// <summary>
        /// �迭�� ������ �ϳ� �ϳ��� ���� �׽�Ʈ
        /// (�� �迭 �����ۿ� ������ ���� ��� ����)
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
        /// �迭�� ������ �ϳ� �ϳ��� ���� �׽�Ʈ
        /// (�� �迭 �����ۿ� �ٸ� ���� ��� ����)
        /// </summary>
        [Fact]
        public void AllNumberAreEvenAndNotZero()
        {
            var numbers = new List<int> { 2, 4, 6 };
            Assert.Collection(numbers, a => Assert.True(a == 2), a => Assert.True(a == 4), a => Assert.True(a == 6));            
        }

        /// <summary>
        /// WPF���� INotifyPropertyChanged �������̽��� ��ӹ��� 
        /// Ŭ�������� �Ӽ����� ����Ǿ����� �ȵǾ����� �׽�Ʈ�ϴ� ���
        /// Assert.PropertyChanged 3��° ���ڿ� �׽�Ʈ �ڵ带 �ְ�
        /// �ش� �׽�Ʈ �ڵ� ó�� �Ŀ� ������ �Ӽ����� ������ ������ ������ 
        /// ��´�.
        /// </summary>
        [Fact]
        public void ShouldClearWithEvents()
        {
            // arrange
            var car = new Car();
            car.Price = 40;
            
            // act            
            Assert.PropertyChanged(car, "Price", () => {
                //���� ������ �����Ͽ� �Ӽ��� ����Ǹ� ������ �߻����� ������
                //���� ���� ������� �� �̸��� �����ϸ� ������ �߻��Ѵ�.
                //car.Name="BMW";
                car.Price = 10;
            });            
        }


        /// <summary>
        /// �׽�Ʈ �ڵ���� ���� �� ������ �̺�Ʈ�� �߻��ϴ��� ���ϴ��� Ȯ���ϴ� ���� �׽�Ʈ
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
                                     
                                     //�׽�Ʈ ����
                                     //�̺�Ʈ�� �߻� �������Ƿ� ������ ���� �ʴ´�.
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