using FluentAssertions;
using Moq;
using System.Diagnostics;
using Tutorial_UnitTest.Model;

namespace Tutorial_UnitTest
{
    /// <summary>
    /// 더미 객체를 만드는 Moq 사용방법 튜토리얼 
    /// Nuget에서 Moq 와 FluentAssertions을 설치해야됨
    /// FluentAssertions을 굳이 사용하지 않아도 되지만 Assert보다 가독성이 좋아 보여 사용하면 괜찮을 것 같음
    /// [참고자료]
    /// https://hamidmosalla.com/2017/08/03/moq-working-with-setupget-verifyget-setupset-verifyset-setupproperty/
    /// </summary>
    public class TutorialSample4
    {
        /// <summary>
        /// 지정한 속성의 Getter 호출시 더미 값을 부여하는 방법
        /// </summary>
        [Fact]
        public void StupPropertyWithSetupGet()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);
            mock.SetupGet(m => m.FirstName).Returns("Someone Nice");

            var name = nameUser.GetFirstName();

            name.Should().Be("Someone Nice");
        }

        /// <summary>
        /// 지정한 속성의 Getter를 몇번 호출했는지 확인하는 방법
        /// </summary>
        [Fact]
        public void VerifyPropertyWithVerifyGet()
        {
            var mock     = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);
            
            nameUser.GetFirstName();           
            mock.VerifyGet(m => m.FirstName, Times.Once);
        }

        /// <summary>
        /// 속성의 값에 설정되는 기대값과 실제 설정되는 속성값을 비교하는 방법
        /// </summary>
        [Fact]
        public void VerifyPropertyIsSet_WithSpecificValue_WithSetupSet()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            //기대값
            mock.SetupSet(m => m.FirstName = "Knights Of Ni!").Verifiable();
            
            //실제 설정되는 값
            nameUser.ChangeName("Knights Of Ni!");
            
            //검증
            mock.Verify();
        }

        /// <summary>
        /// 설정된 속성값을 검증하는 방법으로
        /// 위의 함수와는 미리 변경된 값을 예상한 후 마지막에 확인하는게 아니라 
        /// 변경되고 나서 마지막에 확인한다.        
        /// </summary>
        [Fact]
        public void VerifyPropertyIsSet_WithSpecificValue_WithVerifySet()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            nameUser.ChangeName("No Shrubbery!");

            mock.VerifySet(m => m.FirstName = "No Shrubbery!");
        }

        /// <summary>
        /// 함수가 몇번 호출되었고 함수의 전달된 파라메터가 예상한 값과 일치하는지 확인하는 방법
        /// </summary>
        [Fact]
        public void Verify()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            //함수 호출
            nameUser.ChangeRemoteName("My dear old wig");

            //전달된 파라메터가 예상한 값과 일치하는지 그리고 몇번 호출되었는지 확인
            //이부분에서 It.Is 와 It.Any의 차이를 대강 알 수 있다.
            //It.Any는 파라메터 값이 아무값이나 와도 상관없을때 사용하고
            //It.Is는 파라메터 값이 예측한 값인지 비교할때 사용한다.
            mock.Verify(m => m.MutateFirstName(It.Is<string>(a => a == "My dear old wig")), Times.Once);
        }

        /// <summary>
        /// 더미 데이터에 속성값을 지정하는 방법1
        /// </summary>
        [Fact]
        public void TrackPropertyWithSetUpProperty()
        {
            //방법 1
            var mock1 = new Mock<IPropertyManager>();

            mock1.SetupProperty(m => m.FirstName);
            mock1.Object.FirstName = "Ni!";

            mock1.Object.FirstName.Should().Be("Ni!");

            mock1.Object.FirstName = "der wechselnden";
            mock1.Object.FirstName.Should().Be("der wechselnden");

            //방법2
            var mock2    = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock2.Object);

            mock2.SetupProperty(m => m.FirstName, "ManBearPig");
            mock2.Object.FirstName.Should().Be("ManBearPig");
        }

        /// <summary>
        /// SetupGet 과 SetupProperty의 차이를 알려주는 샘플예제        
        /// </summary>
        [Fact]
        public void InitializeTrackPropertyWithSetUpProperty()
        {
            var mock     = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            mock.SetupProperty(m => m.FirstName, "Regina");

            //You can't change the property later with setupGet, but with setupProperty you can.
            //Comment the setup property code and uncomment this to see the difference.
            //mock.SetupGet(m => m.FirstName).Returns("Regina");

            mock.Object.FirstName.Should().Be("Regina");
            
            mock.Object.FirstName = "Floyd";
            mock.Object.FirstName.Should().Be("Floyd");
        }

        /// <summary>
        /// 더미 데이터에 모든 속성에 값을 할당 할 수 있게하는 방법
        /// </summary>
        [Fact]
        public void TrackAllPropertiesWithSetupAllProperties()
        {
            var mock = new Mock<IPropertyManager>();

            //mock.SetupProperty(m => m.FirstName);

            //Comment this and uncomment SetupProperty, the assertion fails
            mock.SetupAllProperties();

            mock.Object.FirstName = "Robert";
            mock.Object.LastName = "Paulson";

            mock.Object.FirstName.Should().Be("Robert");
            mock.Object.LastName.Should().Be("Paulson");
        }
    }
}