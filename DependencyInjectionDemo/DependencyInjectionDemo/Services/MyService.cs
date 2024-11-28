namespace DependencyInjectionDemo.Services
{

    public class MyService : IMyService
    {
        public string GetMessage()
        {

            {
                return "Hi I am from Myservice";
            }
        }
    }

}
