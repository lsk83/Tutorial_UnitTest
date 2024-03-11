using System.Diagnostics;

namespace Tutorial_UnitTest
{
    /// <summary>
    /// 유닛테스트 튜토리얼
    /// 테스트 시나리오를 작성할때 객체를 생성하고 종료하는데 많은 시간이 걸려서 테스트가 느려질때
    /// 이때 IClassFixture를 사용한다.
    /// IClassFixture 인터페이스를 상속 받으면 생성자에서 Dependency Injection으로 객체를 주입받게되고 
    /// 주입받은 class의 테스트가 종료될때 까지 동일한 객체를 유지하게 된다.
    /// 보통 DB 작업을 하는 객체를 사용할때 이용한다.
    /// </summary>
    public class TutorialSample2 : IClassFixture<InMemoryDbContextFixture> ,IDisposable
    {
        InMemoryDbContextFixture _fixture;

        public TutorialSample2(InMemoryDbContextFixture test)
        {
            _fixture = test;      
            //TODO:초기화 입력
            Debug.WriteLine("TutorialSample2:Constructor");
        }

        public void Dispose()
        {
            //TODO:종료시 작업해야하는 부분 입력
            Debug.WriteLine("TutorialSample2:CleanUp or Dispose Method");
        }

        [Fact]
        public void test1()
        {            
            Debug.WriteLine("TutorialSample2:test1 - 함수마다 객체가 새로 생성되는지 테스트");
        }

        [Fact]
        public void test2()
        {
            Debug.WriteLine("TutorialSample2:test2 - 함수마다 객체가 새로 생성되는지 테스트");
        }
    }   
}