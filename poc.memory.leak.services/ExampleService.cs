using poc.memory.leak.interfaces;
using poc.memory.leak.interfaces.Services;

namespace poc.memory.leak.services
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository _exampleRepository;

        public ExampleService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public object GetItem(string item)
        {
            return _exampleRepository.GetItem(item);
        }
    }
}