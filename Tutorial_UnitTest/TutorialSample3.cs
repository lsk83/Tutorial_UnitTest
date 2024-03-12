using System.Diagnostics;

namespace Tutorial_UnitTest
{
    /// <summary>
    /// �����׽�Ʈ Ʃ�丮��    
    /// ���� �׽�Ʈ Ŭ�������� ������ ��ü�� �����ؾ� �Ҷ� ICollectionFixture �������̽��� ����Ѵ�.
    /// </summary>
    [Collection("Context collection")]
    public class TutorialSample3_1 : IDisposable
    {
        InMemoryDbContextFixture _fixture;

        public TutorialSample3_1(InMemoryDbContextFixture fixture)
        {
            _fixture = fixture;            
            //TODO:�ʱ�ȭ �Է�
            Debug.WriteLine("TutorialSample3:Constructor");
        }

        public void Dispose()
        {
            //TODO:����� �۾��ؾ��ϴ� �κ� �Է�
            Debug.WriteLine("TutorialSample3:CleanUp or Dispose Method");
        }

        [Fact]
        public void test1()
        {            
            Debug.WriteLine("TutorialSample3:test1 - �Լ����� ��ü�� ���� �����Ǵ��� �׽�Ʈ");
        }

        [Fact]
        public void test2()
        {
            Debug.WriteLine("TutorialSample3:test2 - �Լ����� ��ü�� ���� �����Ǵ��� �׽�Ʈ");
        }
    }

    [Collection("Context collection")]
    public class TutorialSample3_2 : IDisposable
    {
        InMemoryDbContextFixture _fixture;

        public TutorialSample3_2(InMemoryDbContextFixture fixture)
        {
            _fixture = fixture;
            //TODO:�ʱ�ȭ �Է�
            Debug.WriteLine("TutorialSample4:Constructor");
        }

        public void Dispose()
        {
            //TODO:����� �۾��ؾ��ϴ� �κ� �Է�
            Debug.WriteLine("TutorialSample4:CleanUp or Dispose Method");
        }

        [Fact]
        public void test1()
        {
            Debug.WriteLine("TutorialSample4:test1 - �Լ����� ��ü�� ���� �����Ǵ��� �׽�Ʈ");
        }

        [Fact]
        public void test2()
        {
            Debug.WriteLine("TutorialSample4:test2 - �Լ����� ��ü�� ���� �����Ǵ��� �׽�Ʈ");
        }
    }
}