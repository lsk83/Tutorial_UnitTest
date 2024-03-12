using FluentAssertions;
using Moq;
using System.Diagnostics;
using Tutorial_UnitTest.Model;

namespace Tutorial_UnitTest
{
    /// <summary>
    /// ���� ��ü�� ����� Moq ����� Ʃ�丮�� 
    /// Nuget���� Moq �� FluentAssertions�� ��ġ�ؾߵ�
    /// FluentAssertions�� ���� ������� �ʾƵ� ������ Assert���� �������� ���� ���� ����ϸ� ������ �� ����
    /// [�����ڷ�]
    /// https://hamidmosalla.com/2017/08/03/moq-working-with-setupget-verifyget-setupset-verifyset-setupproperty/
    /// </summary>
    public class TutorialSample4
    {
        /// <summary>
        /// ������ �Ӽ��� Getter ȣ��� ���� ���� �ο��ϴ� ���
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
        /// ������ �Ӽ��� Getter�� ��� ȣ���ߴ��� Ȯ���ϴ� ���
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
        /// �Ӽ��� ���� �����Ǵ� ��밪�� ���� �����Ǵ� �Ӽ����� ���ϴ� ���
        /// </summary>
        [Fact]
        public void VerifyPropertyIsSet_WithSpecificValue_WithSetupSet()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            //��밪
            mock.SetupSet(m => m.FirstName = "Knights Of Ni!").Verifiable();
            
            //���� �����Ǵ� ��
            nameUser.ChangeName("Knights Of Ni!");
            
            //����
            mock.Verify();
        }

        /// <summary>
        /// ������ �Ӽ����� �����ϴ� �������
        /// ���� �Լ��ʹ� �̸� ����� ���� ������ �� �������� Ȯ���ϴ°� �ƴ϶� 
        /// ����ǰ� ���� �������� Ȯ���Ѵ�.        
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
        /// �Լ��� ��� ȣ��Ǿ��� �Լ��� ���޵� �Ķ���Ͱ� ������ ���� ��ġ�ϴ��� Ȯ���ϴ� ���
        /// </summary>
        [Fact]
        public void Verify()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            //�Լ� ȣ��
            nameUser.ChangeRemoteName("My dear old wig");

            //���޵� �Ķ���Ͱ� ������ ���� ��ġ�ϴ��� �׸��� ��� ȣ��Ǿ����� Ȯ��
            //�̺κп��� It.Is �� It.Any�� ���̸� �밭 �� �� �ִ�.
            //It.Any�� �Ķ���� ���� �ƹ����̳� �͵� ��������� ����ϰ�
            //It.Is�� �Ķ���� ���� ������ ������ ���Ҷ� ����Ѵ�.
            mock.Verify(m => m.MutateFirstName(It.Is<string>(a => a == "My dear old wig")), Times.Once);
        }

        /// <summary>
        /// ���� �����Ϳ� �Ӽ����� �����ϴ� ���1
        /// </summary>
        [Fact]
        public void TrackPropertyWithSetUpProperty()
        {
            //��� 1
            var mock1 = new Mock<IPropertyManager>();

            mock1.SetupProperty(m => m.FirstName);
            mock1.Object.FirstName = "Ni!";

            mock1.Object.FirstName.Should().Be("Ni!");

            mock1.Object.FirstName = "der wechselnden";
            mock1.Object.FirstName.Should().Be("der wechselnden");

            //���2
            var mock2    = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock2.Object);

            mock2.SetupProperty(m => m.FirstName, "ManBearPig");
            mock2.Object.FirstName.Should().Be("ManBearPig");
        }

        /// <summary>
        /// SetupGet �� SetupProperty�� ���̸� �˷��ִ� ���ÿ���        
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
        /// ���� �����Ϳ� ��� �Ӽ��� ���� �Ҵ� �� �� �ְ��ϴ� ���
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