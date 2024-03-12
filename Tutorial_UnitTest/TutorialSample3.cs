using System.Diagnostics;

namespace Tutorial_UnitTest
{
    /// <summary>
    /// 유닛테스트 튜토리얼    
    /// 여러 테스트 클레스에서 동일한 객체를 유지해야 할때 ICollectionFixture 인터페이스를 사용한다.
    /// </summary>
    [Collection("Context collection")]
    public class TutorialSample3_1 : IDisposable
    {
        InMemoryDbContextFixture _fixture;

        public TutorialSample3_1(InMemoryDbContextFixture fixture)
        {
            _fixture = fixture;            
            //TODO:초기화 입력
            Debug.WriteLine("TutorialSample3:Constructor");
        }

        public void Dispose()
        {
            //TODO:종료시 작업해야하는 부분 입력
            Debug.WriteLine("TutorialSample3:CleanUp or Dispose Method");
        }

        [Fact]
        public void test1()
        {            
            Debug.WriteLine("TutorialSample3:test1 - 함수마다 객체가 새로 생성되는지 테스트");
        }

        [Fact]
        public void test2()
        {
            Debug.WriteLine("TutorialSample3:test2 - 함수마다 객체가 새로 생성되는지 테스트");
        }
    }

    [Collection("Context collection")]
    public class TutorialSample3_2 : IDisposable
    {
        InMemoryDbContextFixture _fixture;

        public TutorialSample3_2(InMemoryDbContextFixture fixture)
        {
            _fixture = fixture;
            //TODO:초기화 입력
            Debug.WriteLine("TutorialSample4:Constructor");
        }

        public void Dispose()
        {
            //TODO:종료시 작업해야하는 부분 입력
            Debug.WriteLine("TutorialSample4:CleanUp or Dispose Method");
        }

        [Fact]
        public void test1()
        {
            Debug.WriteLine("TutorialSample4:test1 - 함수마다 객체가 새로 생성되는지 테스트");
        }

        [Fact]
        public void test2()
        {
            Debug.WriteLine("TutorialSample4:test2 - 함수마다 객체가 새로 생성되는지 테스트");
        }
    }
}