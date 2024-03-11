using System.Diagnostics;

namespace Tutorial_UnitTest
{
    /// <summary>
    /// �����׽�Ʈ Ʃ�丮��
    /// �׽�Ʈ �ó������� �ۼ��Ҷ� ��ü�� �����ϰ� �����ϴµ� ���� �ð��� �ɷ��� �׽�Ʈ�� ��������
    /// �̶� IClassFixture�� ����Ѵ�.
    /// IClassFixture �������̽��� ��� ������ �����ڿ��� Dependency Injection���� ��ü�� ���ԹްԵǰ� 
    /// ���Թ��� class�� �׽�Ʈ�� ����ɶ� ���� ������ ��ü�� �����ϰ� �ȴ�.
    /// ���� DB �۾��� �ϴ� ��ü�� ����Ҷ� �̿��Ѵ�.
    /// </summary>
    public class TutorialSample2 : IClassFixture<InMemoryDbContextFixture> ,IDisposable
    {
        InMemoryDbContextFixture _fixture;

        public TutorialSample2(InMemoryDbContextFixture test)
        {
            _fixture = test;      
            //TODO:�ʱ�ȭ �Է�
            Debug.WriteLine("TutorialSample2:Constructor");
        }

        public void Dispose()
        {
            //TODO:����� �۾��ؾ��ϴ� �κ� �Է�
            Debug.WriteLine("TutorialSample2:CleanUp or Dispose Method");
        }

        [Fact]
        public void test1()
        {            
            Debug.WriteLine("TutorialSample2:test1 - �Լ����� ��ü�� ���� �����Ǵ��� �׽�Ʈ");
        }

        [Fact]
        public void test2()
        {
            Debug.WriteLine("TutorialSample2:test2 - �Լ����� ��ü�� ���� �����Ǵ��� �׽�Ʈ");
        }
    }   
}